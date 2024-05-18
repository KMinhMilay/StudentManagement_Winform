use QLHS
go
-- NGUYEN HOANG TRUNG
-- Login
create proc SP_RecordTransaction
@transaction_detail nvarchar(max)
as
begin
	declare @record nvarchar(max)
	set @record = '[' + Cast(GETDATE() as nvarchar(max)) + ']: ' + @transaction_detail
	insert into TransactionHistory(transactionText)
	values (@record)
end
go

create  proc SP_Login
@username varchar(32), @password varchar(max), @role varchar(1)
as
begin
	declare @hashedPassword varbinary(max);
    SET @hashedPassword =	CONVERT(VARBINARY(MAX), HASHBYTES('SHA1', @password), 1);
	if @role = '0'
		begin
			select top 1 IDHS as 'ID', TENDN, IDLOP as 'LOP', 'hocsinh' as 'LOAITAIKHOAN', 'hocsinhthuong' as 'CHUCVU'
			from HOCSINH
			where TENDN = @username and MATKHAU = @hashedPassword and (IDTRANGTHAI = 'BL' or IDTRANGTHAI = 'DH') and isEnable = 'Yes'
			order by IDLOP desc
		end
	if @role = '1'
		begin
			select top 1 IDHS as 'ID', TENDN, IDLOP as 'LOP', 'hocsinh' as 'LOAITAIKHOAN', 'loptruong' as 'CHUCVU'
			from HOCSINH
			where IDCV = 'LT' and TENDN = @username and MATKHAU = @hashedPassword and (IDTRANGTHAI = 'BL' or IDTRANGTHAI = 'DH') and isEnable = 'Yes'
			order by IDLOP desc
		end
	if @role = '2'
		begin
			select top 1 IDGV as 'ID', TENDN, IDLOPCN as 'LOP', 'giaovien' as 'LOAITAIKHOAN', 'giaovienthuong' as 'CHUCVU'
			from GIAOVIEN
			where TENDN = @username and MATKHAU = @hashedPassword and isEnable = 'Yes'
			order by IDLOPCN desc
		end
	if @role = '3'
		begin
			select top 1 IDGV as 'ID', TENDN, IDLOPCN as 'LOP', 'giaovien' as 'LOAITAIKHOAN', 'admin' as 'CHUCVU'
			from GIAOVIEN
			where VAITRO = 3 and TENDN = @username and MATKHAU = @hashedPassword and isEnable = 'Yes'
			order by IDLOPCN desc
		end
end
go

--Lấy thông tin cá nhân giáo viên
create  proc SP_GetTeacherPersonalInfo
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


	select top 1 IDGV, HO, TEN, NAMSINH, GIOITINH, QUEQUAN, DIACHI, EMAIL, SDT, IDLOPCN, @decryptedSalary as 'LUONG', TENMH
	from GIAOVIEN
		inner join MONHOC on GIAOVIEN.IDMH = MONHOC.IDMH
	where IDGV = @id
	order by IDLOPCN
end
go


--Lấy thông tin cá nhân học sinh
create  proc SP_GetStudentPersonalInfo
@id varchar(64)
as
begin
	select top 1 IDHS, hs.HO, hs.TEN, hs.NAMSINH, hs.GIOITINH, hs.QUEQUAN, hs.DIACHI, hs.EMAIL, hs.SDT, IDLOP, SDTPH, TENPH, gv.HO + ' ' + gv.TEN as 'TENGV', TENCV, TENTRANGTHAI as 'TRANGTHAI'
	from HOCSINH hs
		inner join GIAOVIEN gv on hs.IDGV = gv.IDGV
		inner join CHUCVU cv on hs.IDCV = cv.IDCV
		inner join TRANGTHAI tt on hs.IDTRANGTHAI = tt.IDTRANGTHAI
	where IDHS = @id
	order by IDLOP
end
go

-- Đổi mật khẩu
create  proc SP_ChangePassword
@id varchar(64), @password varchar(max), @accountType varchar(20)
as
begin
	declare @transaction_detail nvarchar(max)

	declare @hashedPassword varbinary(max);
    SET @hashedPassword =	CONVERT(VARBINARY(MAX), HASHBYTES('SHA1', @password), 1);

	if @accountType = 'hocsinh'
		begin
			update HOCSINH set MATKHAU = @hashedPassword
			where IDHS = @id

			--record
			set @transaction_detail =  N'Học sinh có mã ' + @id + N' đã thay đổi mật khẩu mới'
			exec SP_RecordTransaction @transaction_detail
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

			--record
			if exists (select IDGV from GIAOVIEN where IDGV = @id and VAITRO = 3)
				begin
					set @transaction_detail =  N'Đã thay đổi mật khẩu mới'
				end
			else
				begin
					set @transaction_detail =  N'Giáo viên có mã ' + @id + N' đã thay đổi mật khẩu mới'
				end
			exec SP_RecordTransaction @transaction_detail
		end
end
go


--Thay đổi thông tin học sinh
create  proc SP_UpdateStudentPersonalInfo

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
	declare @transaction_detail nvarchar(max)

	update HOCSINH
	set HO = @HO, TEN = @TEN, NAMSINH = @NAMSINH, GIOITINH = @GIOITINH, QUEQUAN = @QUEQUAN, DIACHI = @DIACHI, EMAIL = @EMAIL, SDT = @SDT, TENPH = @TENPH, SDTPH = @SDTPH
	where IDHS = @IDHS

	set @transaction_detail =  N'Học sinh có mã ' + @IDHS + N' đã thay đổi thông tin cá nhân'
	exec SP_RecordTransaction @transaction_detail
end
go

--Thay đổi thông tin giáo viên
create  proc SP_UpdateTeacherPersonalInfo
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
	declare @transaction_detail nvarchar(max)

	update GIAOVIEN
	set HO = @HO, TEN = @TEN, NAMSINH = @NAMSINH, GIOITINH = @GIOITINH, QUEQUAN = @QUEQUAN, DIACHI = @DIACHI, EMAIL = @EMAIL, SDT = @SDT
	where IDGV = @IDGV

	set @transaction_detail =  N'Giáo viên có mã ' + @IDGV + N' đã thay đổi thông tin cá nhân'
	exec SP_RecordTransaction @transaction_detail
end
go

--Function giải mã lương
create function DecryptSalary (@id varchar(64))
returns int
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
	return @decryptedSalary
end
go

--Function mã hóa lương
create function EncryptSalary (@id varchar(64), @luong int)
returns varbinary(max)
as
begin
	declare @Salary varchar(100);
	SET @Salary = CONVERT(varchar(100), @luong, 1);
	DECLARE @encryptedLUONG VARBINARY(MAX);
	SET @encryptedLUONG = CONVERT(VARBINARY(MAX),ENCRYPTBYASYMKEY(ASYMKEY_ID(@id),@Salary),1);
	return @encryptedLUONG
end
go

--Lấy danh sách giáo viên
create proc SP_GetTeacherList
as
begin
	select IDGV, HO, TEN, NAMSINH, GIOITINH, QUEQUAN, DIACHI, EMAIL, SDT, IDLOPCN, dbo.DecryptSalary(IDGV) as 'LUONG', TENMH
	from GIAOVIEN inner join MONHOC on GIAOVIEN.IDMH = MONHOC.IDMH
	where isEnable = 'Yes'
end
go

--Lấy danh sách lớp
create proc SP_GetClassList
as
begin
	select IDLOP
	from LOP
end
go

--Lấy danh sách môn học
create proc SP_GetSubjectList
as
begin
	select TENMH
	from MONHOC
end
go

--Xóa thông tin giáo viên
create proc SP_DeleteTeacher
@id varchar(64)
as
begin
	declare @transaction_detail nvarchar(max)

	update GIAOVIEN
	set isEnable = 'No'
	where IDGV = @id

	set @transaction_detail =  N'Đã xóa giáo viên có mã ' + @id
	exec SP_RecordTransaction @transaction_detail
end
go

--Thay đổi thông tin giáo viên bởi admin
create proc SP_UpdateTeacherInfo_ByAdmin
@IDGV varchar(64),
@HO nvarchar(64),
@TEN nvarchar(32),
@NAMSINH datetime,
@GIOITINH nvarchar(10),
@QUEQUAN nvarchar(64),
@DIACHI nvarchar(64),
@EMAIL nvarchar(64),
@SDT varchar(12),
@IDLOPCN varchar(32),
@LUONG int,
@TENMH nvarchar(64)
as
begin
	declare @transaction_detail nvarchar(max)

	declare @encryptedSalary varbinary(max)
	set @encryptedSalary = dbo.EncryptSalary(@IDGV, @LUONG)

	declare @idmh varchar(32)
	select @idmh = IDMH from MONHOC where TENMH = @TENMH
	
	update GIAOVIEN
	set	HO = @HO, TEN = @TEN, NAMSINH = @NAMSINH, GIOITINH = @GIOITINH, QUEQUAN = @QUEQUAN, DIACHI = @DIACHI, EMAIL = @EMAIL, SDT = @SDT, IDLOPCN = @IDLOPCN, LUONG = @encryptedSalary, IDMH = @idmh
	where IDGV = @IDGV

	set @transaction_detail =  N'Giáo viên có mã ' + @IDGV + N' đã được thay đổi thông tin'
	exec SP_RecordTransaction @transaction_detail
end
go

--Thêm thông tin giáo viên bởi admin
create proc SP_AddTeacherInfo_ByAdmin
@IDGV varchar(64),
@HO nvarchar(64),
@TEN nvarchar(32),
@NAMSINH datetime,
@GIOITINH nvarchar(10),
@QUEQUAN nvarchar(64),
@DIACHI nvarchar(64),
@EMAIL nvarchar(64),
@SDT varchar(12),
@IDLOPCN varchar(32),
@LUONG int,
@TENMH nvarchar(64)
as
	declare @transaction_detail nvarchar(max)

	begin TRY
		--hash password
		declare @hashedPW varbinary(max);
		SET @hashedPW = CONVERT(VARBINARY(MAX), HASHBYTES('SHA1', @IDGV), 1);

		--create asymmetric key
		DECLARE @Sql NVARCHAR(MAX)
		DECLARE @pwd NVARCHAR(max)
		SET @pwd = CONVERT(nvarchar(max),@hashedPW,1)

		SET @Sql = N'CREATE ASYMMETRIC KEY ' + QUOTENAME(@IDGV) + 
				   N' WITH ALGORITHM = RSA_2048
				   ENCRYPTION BY PASSWORD = ''' + @pwd + ''';';
		EXEC sp_executesql @Sql;

		--encrypt salary
		declare @encryptedSalary varbinary(max)
		set @encryptedSalary = dbo.EncryptSalary(@IDGV, @LUONG)

		--find subject id
		declare @idmh varchar(32)
		select @idmh = IDMH from MONHOC where TENMH = @TENMH
		insert into GIAOVIEN(IDGV,HO,TEN,NAMSINH,GIOITINH,QUEQUAN,DIACHI,EMAIL,SDT,IDLOPCN,LUONG,IDMH,TENDN,MATKHAU,VAITRO,isEnable)
		values(@IDGV,@HO,@TEN,@NAMSINH,@GIOITINH,@QUEQUAN,@DIACHI,@EMAIL,@SDT,@IDLOPCN,@encryptedSalary,@idmh,@IDGV,@hashedPW,2,'Yes')

		set @transaction_detail =  N'Đã thêm giáo viên với mã ' + @IDGV
		exec SP_RecordTransaction @transaction_detail
	end TRY

	begin CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = N'Đã có giáo viên với ID này',
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        -- Gửi thông báo lỗi tùy chỉnh
        RAISERROR ('Lỗi khi thêm giáo viên: %s', @ErrorSeverity, @ErrorState, @ErrorMessage);
	end CATCH
go

--Lưu Transaction


---------------------------------------------------------------------------------
-- LE PHU NHAN
-- exec SP_GET_DANHSACHHOCSINH '1', 'tendn1'
create PROCEDURE SP_GET_DANHSACHHOCSINH
    @UserRole NVARCHAR(64),
    @UserName NVARCHAR(64)
AS
BEGIN
    DECLARE @UserID VARCHAR(64)

    -- Lấy UserID từ username
    SELECT @UserID = IDGV FROM GIAOVIEN WHERE TENDN = @UserName and VAITRO = @UserRole
    IF @UserID IS NULL
    BEGIN
		IF @UserRole=1
		BEGIN
			SELECT @UserID = IDHS FROM HOCSINH WHERE TENDN = @UserName and (IDCV='LT' or IDCV='LP')
		END
    END

    IF @UserID IS NULL -- Nếu không tìm thấy UserID từ username
    BEGIN
        Print N'Không tìm thấy thông tin người dùng đúng với vai trò'
    END
    ELSE
    BEGIN
        IF @UserRole = '3' -- Nếu là admin
        BEGIN
            SELECT 
                IDHS,
                HO,
				TEN,
                NAMSINH,
                GIOITINH,
                QUEQUAN,
                DIACHI,
                EMAIL,
                SDT,
                IDLOP,
                CASE 
					WHEN IDCV = 'LT' THEN N'Lớp trưởng'
					WHEN IDCV = 'LP' THEN N'Lớp phó'
					ELSE N'Học sinh'
				END AS CHUCVU,
                IDGV,
                SDTPH,
                TENPH,
				CASE 
					WHEN IDTRANGTHAI = 'DH' THEN N'Đang học'
					WHEN IDTRANGTHAI = 'BL' THEN N'Bảo lưu'
					WHEN IDTRANGTHAI = 'CT' THEN N'Chuyển trường'
					ELSE N'Nghỉ học'
				END AS IDTRANGTHAI,
                TENDN,
                isEnable
            FROM 
                HOCSINH
        END
        ELSE IF @UserRole = '2'-- Nếu là giáo viên
        BEGIN
            -- Kiểm tra xem giáo viên có phải là chủ nhiệm lớp nào không
            DECLARE @ChuNhiemLop VARCHAR(32)
            SELECT @ChuNhiemLop = IDLOPCN FROM GIAOVIEN WHERE IDGV = @UserID

            IF @ChuNhiemLop IS NOT NULL -- Nếu là chủ nhiệm lớp
            BEGIN
                SELECT 
                    HS.IDHS,
                    HS.HO,
					HS.TEN,
                    HS.NAMSINH,
                    HS.GIOITINH,
                    HS.QUEQUAN,
                    HS.DIACHI,
                    HS.EMAIL,
                    HS.SDT,
                    HS.IDLOP,
                    CASE 
						WHEN HS.IDCV = 'LT' THEN N'Lớp trưởng'
						WHEN HS.IDCV = 'LP' THEN N'Lớp phó'
						ELSE N'Học sinh'
					END AS CHUCVU,
                    HS.IDGV,
                    HS.SDTPH,
                    HS.TENPH,
                    HS.TENDN,
					CASE 
					WHEN IDTRANGTHAI = 'DH' THEN N'Đang học'
					WHEN IDTRANGTHAI = 'BL' THEN N'Bảo lưu'
					WHEN IDTRANGTHAI = 'CT' THEN N'Chuyển trường'
					ELSE N'Nghỉ học'
				END AS IDTRANGTHAI,
                    HS.isEnable
                FROM 
                    HOCSINH HS
                INNER JOIN GIAOVIEN GV ON HS.IDLOP = GV.IDLOPCN
                WHERE 
                    GV.TENDN = @UserName AND HS.isEnable = 'Yes'
            END
        END
        ELSE IF @UserRole = '1'-- Nếu là lớp phó hoặc lớp trưởng
		BEGIN
			DECLARE @UserLopID NVARCHAR(64)
			SELECT @UserLopID = (
				SELECT MAX(IDLOP) AS LopCaoNhat
				FROM HOCSINH
				WHERE TENDN = @UserName AND (IDCV = 'LT' OR IDCV = 'LP'))
			SELECT 
				IDHS,
				HO,
				TEN,
				NAMSINH,
				GIOITINH,
				QUEQUAN,
				DIACHI,
				EMAIL,
				SDT,
				IDLOP,
				CASE 
					WHEN IDCV = 'LT' THEN N'Lớp trưởng'
					WHEN IDCV = 'LP' THEN N'Lớp phó'
					ELSE N'Học sinh'
				END AS CHUCVU,
				IDGV,
				SDTPH,
				TENPH,
				TENDN,
				CASE 
					WHEN IDTRANGTHAI = 'DH' THEN N'Đang học'
					WHEN IDTRANGTHAI = 'BL' THEN N'Bảo lưu'
					WHEN IDTRANGTHAI = 'CT' THEN N'Chuyển trường'
					ELSE N'Nghỉ học'
				END AS IDTRANGTHAI,
				isEnable
			FROM 
				HOCSINH
			WHERE 
				IDLOP = @UserLopID AND isEnable = 'Yes'
		END
        ELSE
        BEGIN
            -- Trả về thông báo lỗi hoặc không có dữ liệu tùy thuộc vào yêu cầu
            Print N'Bạn không có quyền truy cập'
        END
    END
END
go

--EXEC SP_GET_DANHSACHHOCSINH '2', 'tendn1'
--go

create PROCEDURE SearchStudents
    @StudentID varchar(32) = NULL,
    @FullName nvarchar(100) = NULL,
    @ClassName nvarchar(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;

    -- Tìm kiếm học sinh
    SELECT 
        HS.IDHS,
        HO,
		TEN,
        NAMSINH,
        GIOITINH,
        QUEQUAN,
        DIACHI,
        EMAIL,
        SDT,
        HS.IDLOP,
        CASE 
            WHEN IDCV = 'LT' THEN N'Lớp trưởng'
            WHEN IDCV = 'LP' THEN N'Lớp phó'
            ELSE N'Học sinh'
        END AS CHUCVU,
        IDGV,
        CASE 
            WHEN IDTRANGTHAI = 'DH' THEN N'Đang học'
            WHEN IDTRANGTHAI = 'BL' THEN N'Bảo lưu'
            WHEN IDTRANGTHAI = 'CT' THEN N'Chuyển trường'
            ELSE N'Nghỉ học'
        END AS IDTRANGTHAI,
        SDTPH,
        TENPH,
        TENDN,
        HS.isEnable
    FROM 
        HOCSINH HS
    INNER JOIN
        LOP ON HS.IDLOP = LOP.IDLOP
    WHERE 
        (@StudentID IS NULL OR HS.IDHS LIKE '%' + @StudentID + '%')
        AND (@FullName IS NULL OR HS.HO + ' ' + HS.TEN LIKE N'%' + @FullName + N'%')
        AND (@ClassName IS NULL OR LOP.TENLOP LIKE '%' + @ClassName + '%');

END
go


--Exec SearchStudents 'hs1','A','10'
--go
create  PROCEDURE SP_INS_HOCSINH_AUTO
    @HO nvarchar(64),
    @TEN nvarchar(32),
    @NAMSINH datetime,
    @GIOITINH nvarchar(10),
    @QUEQUAN nvarchar(64),
    @DIACHI nvarchar(64),
    @EMAIL nvarchar(64),
    @SDT varchar(12),
    @IDLOP varchar(32),
    @IDCV varchar(32),
    @IDGV varchar(64),
    @IDTRANGTHAI varchar(64),
    @SDTPH varchar(12),
    @TENPH nvarchar(64)
AS
BEGIN
    DECLARE @IDHS varchar(64);
    DECLARE @TENDN varchar(32);
    DECLARE @MATKHAU varchar(32);

    -- Tạo IDHS tự động
    DECLARE @MAX_IDHS INT;
	SELECT @MAX_IDHS = ISNULL(MAX(CAST(SUBSTRING(IDHS, 3, CHARINDEX('-', IDHS) - 3) AS INT)), 0) FROM HOCSINH;
	SET @MAX_IDHS = @MAX_IDHS + 1;

	-- Tạo IDHS mới
	SET @IDHS = 'HS' + CAST(@MAX_IDHS AS varchar(10)) + '-' + @IDLOP;


    -- Tạo TENDN tự động
    SET @TENDN = 'hocsinh' + CAST(@MAX_IDHS AS varchar(10));

    -- Tạo mật khẩu tự động
    SET @MATKHAU = 'matkhau' + CAST(@MAX_IDHS AS varchar(10));

    -- Thêm học sinh vào bảng bằng cách gọi stored procedure SP_INS_HOCSINH
    EXEC SP_INS_HOCSINH @IDHS, @HO, @TEN, @NAMSINH, @GIOITINH, @QUEQUAN, @DIACHI, @EMAIL, @SDT, @IDLOP, @IDCV, @IDGV, @IDTRANGTHAI, @SDTPH, @TENPH, @TENDN, @MATKHAU;
	INSERT INTO TransactionHistory (transactionText)
    VALUES (
        N'[' + Cast(GETDATE() as nvarchar(max)) + N']: Giáo viên có mã ' + @IDGV + 
        N' đã thêm học sinh có mã là ' + @IDHS + N' có lớp là ' +@IDLOP
    );END
go
--EXEC SP_INS_HOCSINH_AUTO N'Lê Phú', N'Nhân', '2003-01-24', N'Nam', N'Bến Tre', N'27 Ngô Quyền', 'lpn@email.com', '0123456789', '12C3', 'LP', 'GV003', 'DH', '0987654321', N'Kim Uyên'



CREATE PROCEDURE SP_GET_GIAOVIEN_BY_LOP
    @IDLop NVARCHAR(64)
AS
BEGIN
    SELECT
        GV.HO + ' ' + GV.TEN AS HoTen
    FROM
        GIAOVIEN GV
    INNER JOIN
        HOCSINH HS ON GV.IDLOPCN = HS.IDLOP
    WHERE
        HS.IDLOP = @IDLop
END
go
--SP_GET_GIAOVIEN_BY_LOP '10A2'


CREATE PROCEDURE FindTeacherIDByFullName
    @HoTen NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Ho NVARCHAR(50);
    DECLARE @Ten NVARCHAR(50);

    DECLARE @IndexOfLastSpace INT;

    -- Tìm vị trí của dấu cách cuối cùng trong chuỗi HoTen
    SET @IndexOfLastSpace = LEN(@HoTen) - CHARINDEX(' ', REVERSE(@HoTen)) + 1;

    -- Tách Ho và Ten từ chuỗi HoTen
    SET @Ho = LEFT(@HoTen, @IndexOfLastSpace - 1);
    SET @Ten = RIGHT(@HoTen, LEN(@HoTen) - @IndexOfLastSpace);

    -- Tìm IDGV dựa trên Ho và Ten
    SELECT IDGV
    FROM GIAOVIEN
    WHERE Ho = @Ho AND Ten = @Ten;
END;
go




create  PROCEDURE DisableStudentByID
@IDHS VARCHAR(10),
@IDGV VARCHAR(20)
AS
BEGIN
    UPDATE HOCSINH
    SET isEnable = 'No'
    WHERE IDHS = @IDHS;
	INSERT INTO TransactionHistory (transactionText)
    VALUES (
        N'[' + Cast(GETDATE() as nvarchar(max)) + N']: Giáo viên có mã ' + @IDGV +
        N' đã xóa học sinh có mã ' + @IDHS
    );END
go

create  PROCEDURE UpdateStudentInfo
    @IDHS NVARCHAR(64),
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(50),
    @NamSinh DATETIME,
    @GioiTinh NVARCHAR(10),
    @QueQuan NVARCHAR(100),
    @DiaChi NVARCHAR(100),
    @Email NVARCHAR(50),
    @SDT NVARCHAR(20),
    @IDCV NVARCHAR(10),
    @IDTRANGTHAI NVARCHAR(10),
    @SDTPH NVARCHAR(20),
    @TENPH NVARCHAR(50),
	@IDGV NVARCHAR(20)
AS
BEGIN
	INSERT INTO TransactionHistory (transactionText)
    VALUES (
        N'[' + Cast(GETDATE() as nvarchar(max)) + N']: Học sinh có mã ' + @IDHS + 
        N' được thay đổi thông tin bởi giáo viên có mã ' + @IDGV
    );
    UPDATE HOCSINH
    SET 
        HO = @Ho,
        TEN = @Ten,
        NAMSINH = @NamSinh,
        GIOITINH = @GioiTinh,
        QUEQUAN = @QueQuan,
        DIACHI = @DiaChi,
        EMAIL = @Email,
        SDT = @SDT,
        IDCV = @IDCV,
        IDTRANGTHAI = @IDTRANGTHAI,
        SDTPH = @SDTPH,
        TENPH = @TENPH
    WHERE
        IDHS = @IDHS;
END
go

create  PROCEDURE SP_DoiLopHocSinh
    @IDHS NVARCHAR(64),
    @Ho NVARCHAR(50),
    @Ten NVARCHAR(50),
    @NamSinh DATETIME,
    @GioiTinh NVARCHAR(10),
    @QueQuan NVARCHAR(100),
    @DiaChi NVARCHAR(100),
    @Email NVARCHAR(50),
    @SDT NVARCHAR(20),
    @IDLop NVARCHAR(64),
    @IDCV NVARCHAR(32),
    @IDGV NVARCHAR(64),
    @SDTPH NVARCHAR(20),
    @TenPH NVARCHAR(50)
AS
BEGIN
    IF @IDHS IS NULL
        RETURN; -- Thoát stored procedure nếu @IDHS là NULL
    
    -- Kiểm tra xem có sẵn IDHSnew trong DIEM hoặc XEPLOAI hay không
    IF EXISTS (
        SELECT 1 
        FROM DIEM 
        WHERE LEFT(IDHS, 4) = LEFT(@IDHS, 4) 
            AND IDHK = (SELECT MAX(IDHK) FROM HOCKY)
    ) OR EXISTS (
        SELECT 1 
        FROM XEPLOAI 
        WHERE LEFT(IDHS, 4) = LEFT(@IDHS, 4) 
            AND IDHK = (SELECT MAX(IDHK) FROM HOCKY)
    )
    BEGIN
        -- Nếu có, không thực hiện thêm mới
        PRINT N'Đang là học kỳ mới nhất, không thể đổi lớp học sinh.'
    END
    ELSE
    BEGIN
        DECLARE @IDHSnew NVARCHAR(64);
        SET @IDHSnew = LEFT(@IDHS, CHARINDEX('-', @IDHS) - 1) + '-' + @IDLop; -- Nối IDHS với IDLop để tạo IDHS mới
        
        DECLARE @IDHSNumber NVARCHAR(64);
        -- Tìm vị trí của ký tự '-' trong chuỗi
        DECLARE @Index INT = CHARINDEX('-', @IDHS);
        -- Lấy phần số từ chuỗi bắt đầu từ vị trí đầu tiên đến vị trí trước ký tự '-'
        SET @IDHSNumber = SUBSTRING(@IDHS, 3, @Index - 3);

        -- Tạo TENDN tự động
        DECLARE @TENDN varchar(32);
        DECLARE @MATKHAU varchar(32);
        SET @TENDN = 'hocsinh' + CAST(@IDHSNumber AS varchar(10));

        -- Tạo mật khẩu tự động
        SET @MATKHAU = 'matkhau' + CAST(@IDHSNumber AS varchar(10));
        
        -- Gọi stored procedure SP_INS_HOCSINH để chèn dữ liệu mới
        EXEC SP_INS_HOCSINH @IDHSnew, @Ho, @Ten, @NamSinh, @GioiTinh, @QueQuan, @DiaChi, @Email, @SDT, @IDLop, @IDCV, @IDGV, 'DH', @SDTPH, @TenPH, @TENDN, @MATKHAU;
		INSERT INTO TransactionHistory (transactionText)
		VALUES (
			N'[' + Cast(GETDATE() as nvarchar(max)) + N']: Học sinh có mã ' + @IDHS + 
			N' được cập nhật mã học sinh mới là '+ @IDHSnew+ N' và lớp mới là' + @IDLOP + N' bởi giáo viên có mã ' + @IDGV
		);
    END
END
go

--KHÁNH MINH
create procedure SP_GetTranList 
as
begin
	select transactionText from TransactionHistory;
end
go

Create procedure SP_GetTranListByText
@textValue nvarchar(max)
as
begin 
	select transactionText from TransactionHistory where transactionText LIKE N'%' + @textValue +  N'%'
end
go
exec SP_GetTranListByText 'o'
go

-- NGUYEN HOANG THUONG
create proc Proc_GetDiem
as
select d.IDDIEM, d.IDHK, hk.HOCKY, hk.IDNAM, CONCAT(n.NAMBATDAU, ' - ', N.NAMKETTHUC) as NAM,
d.IDMH, m.TENMH, d.IDHS, CONCAT(hs.HO, ' ', hs.TEN) as HoTenHocSinh, hs.TEN, DIEMQT, DIEMGK, DIEMCK, DTB 
from Diem d
inner join HOCKY hk on d.IDHK = hk.IDHK
inner join NAMHOC n on hk.IDNAM = n.IDNAM
inner join MONHOC m on d.IDMH = m.IDMH
inner join HOCSINH hs on d.IDHS = hs.IDHS
go

--exec Proc_GetDiem

create proc Proc_GetDiem_Filter
@tenhs nvarchar(255), @malop varchar(32), @mamon varchar(32)
as
select d.IDDIEM, d.IDHK, hk.HOCKY, hk.IDNAM, CONCAT(n.NAMBATDAU, ' - ', N.NAMKETTHUC) as NAM,
d.IDMH, m.TENMH, d.IDHS, CONCAT(hs.HO, ' ', hs.TEN) as HoTenHocSinh, hs.TEN, DIEMQT, DIEMGK, DIEMCK, DTB 
from Diem d
inner join HOCKY hk on d.IDHK = hk.IDHK
inner join NAMHOC n on hk.IDNAM = n.IDNAM
inner join MONHOC m on d.IDMH = m.IDMH
inner join HOCSINH hs on d.IDHS = hs.IDHS
where CONCAT(hs.HO, ' ', hs.TEN) like '%' + @tenhs + '%'
AND hs.IDLOP = @malop
AND d.IDMH = @mamon
go

--exec Proc_GetDiem_Filter @tenhs = '', @mamon = 'HOA', @malop = '10A1'

create proc Proc_Diem_Update
@iddiem varchar(64), @diemqt float, @diemgk float, @diemck float
as
update DIEM
SET DIEMQT = @diemqt,
DIEMGK = @diemgk,
DIEMCK = @diemck
WHERE IDDIEM = @iddiem
go


create proc Proc_GetXepLoai
as
select x.IDXEPLOAI, CONCAT(n.NAMBATDAU, ' - ', N.NAMKETTHUC) as NAM, x.IDHS,
CONCAT(hs.HO, ' ', hs.TEN) as HoTenHocSinh, hs.TEN, l.IDLOP,
l.TENLOP, x.DIEMTONGKET, x.HOCLUC, x.HANHKIEM, x.IDHK, hk.HOCKY 
from XEPLOAI x
inner join HOCKY hk on x.IDHK = hk.IDHK
inner join NAMHOC n on hk.IDNAM = n.IDNAM
inner join HOCSINH hs on x.IDHS = hs.IDHS
inner join LOP l on hs.IDLOP = l.IDLOP
go

create proc Proc_FilterXepLoai
@tenhs nvarchar(64), @malop varchar(32), @hocluc nvarchar(16), @hanhkiem nvarchar(16)
as
select x.IDXEPLOAI, CONCAT(n.NAMBATDAU, ' - ', N.NAMKETTHUC) as NAM, x.IDHS, CONCAT(hs.HO, ' ', hs.TEN) as HoTenHocSinh, hs.TEN, l.IDLOP, l.TENLOP, x.DIEMTONGKET, x.HOCLUC, x.HANHKIEM, x.IDHK, hk.HOCKY 
from XEPLOAI x
inner join HOCKY hk on x.IDHK = hk.IDHK
inner join NAMHOC n on hk.IDNAM = n.IDNAM
inner join HOCSINH hs on x.IDHS = hs.IDHS
inner join LOP l on hs.IDLOP = l.IDLOP
where CONCAT(hs.HO, ' ', hs.TEN) like '%' + @tenhs + '%'
AND x.HOCLUC like '%' + @hocluc + '%'
AND x.HANHKIEM like '%' + @hanhkiem + '%'
AND l.IDLOP = @malop
go

create trigger TRIGGER_XepLoai_UpdateDiemTBTongKet
on DIEM
after INSERT, Update
as
begin
    declare @idhs varchar(32), @idhk int, @diemtongket float
    select @idhs = IDHS, @idhk = IDHK from inserted

    select @diemtongket = ROUND(AVG(DTB), 2) from DIEM
    where IDHS = @idhs
    and IDHK = @idhk

    IF EXISTS(select IDXEPLOAI from XEPLOAI WHERE IDHS = @idhs and IDHK = @idhk)
    begin
        declare @hanhkiem nvarchar(32), @hocluc nvarchar(32)
        select @hanhkiem = HANHKIEM from XEPLOAI WHERE IDHS = @idhs and IDHK = @idhk

        IF @hanhkiem IS NULL OR @hanhkiem = N'Chưa dánh giá'
        BEGIN
            UPDATE XEPLOAI SET DIEMTONGKET = @diemtongket WHERE IDHS = @idhs and IDHK = @idhk
        END
        ELSE
        BEGIN
            if(@diemtongket < 3.5)
                set @hocluc = N'Kém'
            else if(@diemtongket < 5)
                set @hocluc = N'Yếu'
            else if(@diemtongket < 6.5)
                set @hocluc = N'Trung b?nh'
            else if(@diemtongket < 8)
            begin
                if(@hanhkiem = N'Khá' OR @hanhkiem = N'Gi?i')
                    set @hocluc = N'Khá'
                else
                    set @hocluc = N'Trung b?nh'
            end
            else
            begin
                if(@hanhkiem = N'Giỏi')
                    set @hocluc = N'Giỏi'
                else
                    set @hocluc = N'Khá'
            end
            UPDATE XEPLOAI SET DIEMTONGKET = @diemtongket, HOCLUC = @hocluc WHERE IDHS = @idhs and IDHK = @idhk
        END
    end
    ELSE
    begin
        insert into XEPLOAI(IDHK, IDHS, DIEMTONGKET)
        values (@idhk, @idhs, @diemtongket)
    end
end
go

create proc Proc_XepLoai_Update
@idxeploai int, @hanhkiem nvarchar(20), @hocluc nvarchar(20)
as
update XEPLOAI
set HANHKIEM = @hanhkiem,
HOCLUC = @hocluc
where IDXEPLOAI = @idxeploai
go
create trigger TRIGGER_Diem_UpdateDiemTB
on DIEM
after INSERT, UPDATE
as
begin
    declare @iddiem varchar(64), @diemqt float, @diemgk float, @diemck float
    select @iddiem = IDDIEM, @diemqt = DIEMQT, @diemgk = DIEMGK, @diemck = DIEMCK from inserted

    if(@diemqt IS NOT NULL AND @diemgk IS NOT NULL AND @diemck IS NOT NULL)
    begin
        UPDATE DIEM
        SET DTB = ROUND((@diemqt + @diemgk * 2 + @diemck * 3) / 6, 2)
        WHERE IDDIEM = @iddiem
    end
end
go
