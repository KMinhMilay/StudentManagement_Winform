alter proc SP_Login
@username varchar(32), @password varchar(max), @role varchar(1)
as
begin
	declare @hashedPassword varbinary(max);
    SET @hashedPassword =	CONVERT(VARBINARY(MAX), HASHBYTES('SHA1', @password), 1);
	if @role = '0'
		begin
			select IDHS as 'ID', TENDN, IDLOP as 'LOP', 'hocsinh' as 'LOAITAIKHOAN', 'hocsinhthuong' as 'CHUCVU'
			from HOCSINH
			where TENDN = @username and MATKHAU = @hashedPassword and (IDTRANGTHAI = 'BL' or IDTRANGTHAI = 'DH') and isEnable = 'Yes'
		end
	if @role = '1'
		begin
			select IDHS as 'ID', TENDN, IDLOP as 'LOP', 'hocsinh' as 'LOAITAIKHOAN', 'loptruong' as 'CHUCVU'
			from HOCSINH
			where IDCV = 'LT' and TENDN = @username and MATKHAU = @hashedPassword and (IDTRANGTHAI = 'BL' or IDTRANGTHAI = 'DH') and isEnable = 'Yes'
		end
	if @role = '2'
		begin
			select IDGV as 'ID', TENDN, IDLOPCN as 'LOP', 'giaovien' as 'LOAITAIKHOAN', 'giaovienthuong' as 'CHUCVU'
			from GIAOVIEN
			where TENDN = @username and MATKHAU = @hashedPassword and isEnable = 'Yes' 
		end
	if @role = '3'
		begin
			select IDGV as 'ID', TENDN, IDLOPCN as 'LOP', 'giaovien' as 'LOAITAIKHOAN', 'admin' as 'CHUCVU'
			from GIAOVIEN
			where VAITRO = 0 and TENDN = @username and MATKHAU = @hashedPassword and isEnable = 'Yes'
		end
end
go

-- Thong tin ca nhan giao vien
create proc SP_GetTeacherPersonalInfo
@id varchar(64)
as
begin
	declare @encryptedSalary varbinary(max)
	declare @decryptedSalary int
	declare @pwd NVARCHAR(max)

	select @encryptedSalary = LUONG, @pwd = convert(nvarchar(max), MATKHAU,1)
	from GIAOVIEN
	where IDGV = @id

	declare @tmp varchar(max)
	set @tmp = CONVERT(varchar(max), DECRYPTBYASYMKEY(ASYMKEY_ID(@id), @encryptedSalary, @pwd))
	set @decryptedSalary = CONVERT(int,@tmp,1)


	select IDGV, HO, TEN, NAMSINH, GIOITINH, QUEQUAN, DIACHI, EMAIL, SDT, @decryptedSalary as 'LUONG', TENMH
	from GIAOVIEN
		inner join MONHOC on GIAOVIEN.IDMH = MONHOC.IDMH
	where IDGV = @id
end
go

-- Thong tin ca nhan hoc sinh
alter proc SP_GetStudentPersonalInfo
@id varchar(64)
as
begin
	select IDHS, hs.HO, hs.TEN, hs.NAMSINH, hs.GIOITINH, hs.QUEQUAN, hs.DIACHI, hs.EMAIL, hs.SDT, SDTPH, TENPH, gv.HO + ' ' + gv.TEN as 'TENGV', TENCV, TENTRANGTHAI as 'TRANGTHAI'
	from HOCSINH hs
		inner join GIAOVIEN gv on hs.IDGV = gv.IDGV
		inner join CHUCVU cv on hs.IDCV = cv.IDCV
		inner join TRANGTHAI tt on hs.IDTRANGTHAI = tt.IDTRANGTHAI
	where IDHS = @id
end
go

-- Thay doi mat khau
create proc SP_ChangePassword
@id varchar(64), @password varchar(max), @accountType varchar(20)
as
begin
	declare @hashedPassword varbinary(max);
    SET @hashedPassword =	CONVERT(VARBINARY(MAX), HASHBYTES('SHA1', @password), 1);

	if @accountType = 'hocsinh'
		begin
			update HOCSINH set MATKHAU = @hashedPassword
			where IDHS = @id
		end
	if @accountType = 'giaovien'
		begin
			--decrypt luong--
			declare @encryptedSalary varbinary(max)
			DECLARE @decryptedSalary int
			declare @oldpwd NVARCHAR(max)

			select @encryptedSalary = LUONG, @oldpwd = convert(nvarchar(max), MATKHAU,1)
			from GIAOVIEN
			where IDGV = @id

			declare @tmp varchar(max)
			SET @tmp = CONVERT(varchar(max), DECRYPTBYASYMKEY(ASYMKEY_ID(@id), @encryptedSalary, @oldpwd))
			set @decryptedSalary = CONVERT(int,@tmp,1)

			--drop old asymmetric key--
			declare @Sql nvarchar(MAX);
			SET @Sql = N'DROP ASYMMETRIC KEY ' + QUOTENAME(@id) + ';';
			EXEC sp_executesql @Sql;

			--generate new asymmetric key--
			declare @newpass nvarchar(max)
			set @newpass = CONVERT(nvarchar(max),@hashedPassword,1)
			set @Sql = N'CREATE ASYMMETRIC KEY ' + QUOTENAME(@id) + 
			   N' WITH ALGORITHM = RSA_2048
               ENCRYPTION BY PASSWORD = ''' + @newpass + ''';';
			exec sp_executesql @Sql;

			--encrypt luong--
			declare @tmpSalary varchar(100);
			set @tmpSalary = CONVERT(varchar(100), @decryptedSalary, 1);
			set @encryptedSalary = CONVERT(VARBINARY(MAX),ENCRYPTBYASYMKEY(ASYMKEY_ID(@id),@tmpSalary),1);
			update GIAOVIEN set MATKHAU = @hashedPassword, LUONG = @encryptedSalary
			where IDGV = @id 
		end
end
go

--Thay doi thong tin hoc sinh
alter proc SP_UpdateStudentPersonalInfo
@IDHS varchar(64),
@HO nvarchar(64),
@TEN nvarchar(32),
@NAMSINH datetime,
@GIOITINH nvarchar(10),
@QUEQUAN nvarchar(64),
@DIACHI nvarchar(64),
@EMAIL nvarchar(64),
@SDT varchar(12),
@TENPH nvarchar(64),
@SDTPH varchar(12)
as
begin
	update HOCSINH
	set HO = @HO, TEN = @TEN, NAMSINH = @NAMSINH, GIOITINH = @GIOITINH, QUEQUAN = @QUEQUAN, DIACHI = @DIACHI, EMAIL = @EMAIL, SDT = @SDT, TENPH = @TENPH, SDTPH = @SDTPH
	where IDHS = @IDHS
end
go

--Thay doi thong tin giao vien
create proc SP_UpdateTeacherPersonalInfo
@IDGV varchar(64),
@HO nvarchar(64),
@TEN nvarchar(32),
@NAMSINH datetime,
@GIOITINH nvarchar(10),
@QUEQUAN nvarchar(64),
@DIACHI nvarchar(64),
@EMAIL nvarchar(64),
@SDT varchar(12)
as
begin
	update GIAOVIEN
	set HO = @HO, TEN = @TEN, NAMSINH = @NAMSINH, GIOITINH = @GIOITINH, QUEQUAN = @QUEQUAN, DIACHI = @DIACHI, EMAIL = @EMAIL, SDT = @SDT
	where IDGV = @IDGV
end
go