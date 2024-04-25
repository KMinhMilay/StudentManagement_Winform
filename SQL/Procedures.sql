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
			where TENDN = @username and MATKHAU = @hashedPassword
		end
	if @role = '1'
		begin
			select IDHS as 'ID', TENDN, IDLOP as 'LOP', 'hocsinh' as 'LOAITAIKHOAN', 'loptruong' as 'CHUCVU'
			from HOCSINH
			where IDCV = 'LT' and TENDN = @username and MATKHAU = @hashedPassword
		end
	if @role = '2'
		begin
			select IDGV as 'ID', TENDN, IDLOPCN as 'LOP', 'giaovien' as 'LOAITAIKHOAN', 'giaovienthuong' as 'CHUCVU'
			from GIAOVIEN
			where TENDN = @username and MATKHAU = @hashedPassword
		end
	if @role = '3'
		begin
			select IDGV as 'ID', TENDN, IDLOPCN as 'LOP', 'giaovien' as 'LOAITAIKHOAN', 'admin' as 'CHUCVU'
			from GIAOVIEN
			where VAITRO = 0 and TENDN = @username and MATKHAU = @hashedPassword
		end
end
go