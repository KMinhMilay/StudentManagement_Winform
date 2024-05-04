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

EXEC SP_GET_DANHSACHHOCSINH '2', 'tendn1'
go

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
Exec SearchStudents 'hs1','A','10'
go
create PROCEDURE SP_INS_HOCSINH_AUTO
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
END
go
EXEC SP_INS_HOCSINH_AUTO N'Lê Phú', N'Nhân', '2003-01-24', N'Nam', N'Bến Tre', N'27 Ngô Quyền', 'lpn@email.com', '0123456789', '12C3', 'LP', 'GV003', 'DH', '0987654321', N'Kim Uyên'


create TRIGGER trg_InsertDiem
ON HOCSINH
AFTER INSERT
AS
BEGIN
    DECLARE @IDDIEM VARCHAR(100);
    DECLARE @IDHK INT;
    DECLARE @IDHS VARCHAR(64);
    DECLARE @MONHOC NVARCHAR(50);
    DECLARE @Sql NVARCHAR(MAX);

    -- Lấy IDHK cao nhất từ bảng HOCKY
    SELECT @IDHK = MAX(IDHK) FROM HOCKY;

    -- Lấy IDHS từ dữ liệu mới được thêm vào
    SELECT @IDHS = IDHS FROM inserted;

    -- Duyệt qua danh sách môn học và thêm dữ liệu vào bảng DIEM
    DECLARE @i INT = 1;
    DECLARE @TotalMonHoc INT = (SELECT COUNT(*) FROM MONHOC);
    DECLARE @OriginalIDHS VARCHAR(100) = @IDHS;

    WHILE @i <= @TotalMonHoc
    BEGIN
        SELECT @MONHOC = IDMH FROM (SELECT ROW_NUMBER() OVER (ORDER BY IDMH) AS RowNum, * FROM MONHOC) AS MonHocRow WHERE RowNum = @i;

        -- Kiểm tra xem IDDIEM đã tồn tại chưa, nếu tồn tại thì tăng số thứ tự cho IDDIEM
        DECLARE @Count INT = (SELECT COUNT(*) FROM DIEM WHERE IDDIEM LIKE CONCAT(@IDDIEM, '%')) + 1;
		SET @IDDIEM = CONCAT(LOWER(LEFT(@IDHS, CHARINDEX('-', @IDHS) - 1)), LOWER(@MONHOC), @IDHK);
        WHILE EXISTS (SELECT 1 FROM DIEM WHERE IDDIEM = @IDDIEM)
        BEGIN
            SET @IDDIEM = CONCAT(LOWER(LEFT(@IDHS, CHARINDEX('-', @IDHS) - 1)), LOWER(@MONHOC), @IDHK);
            SET @Count = @Count + 1;
        END;

        -- Lấy giá trị gốc của @IDHS và @MONHOC
        DECLARE @OriginalMONHOC NVARCHAR(100) = @MONHOC;

        -- Tạo câu lệnh SQL để thêm dữ liệu vào bảng DIEM với giá trị gốc của @IDHS và @MONHOC
        SET @Sql = 'INSERT INTO DIEM (IDDIEM, IDHK, IDMH, IDHS) VALUES (''' + @IDDIEM + ''', ' + CAST(@IDHK AS VARCHAR) + ', ''' + @OriginalMONHOC + ''', ''' + @OriginalIDHS + ''')';

        -- Thực thi câu lệnh SQL
        EXEC sp_executesql @Sql;
        SET @i = @i + 1;
    END;
END;
go

CREATE TRIGGER trg_InsertXepLoai
ON HOCSINH
AFTER INSERT
AS
BEGIN
    DECLARE @IDHK INT;
    DECLARE @IDHS varchar(64);

    -- Lấy IDHK cao nhất từ bảng HOCKY
    SELECT @IDHK = MAX(IDHK) FROM HOCKY;

    -- Lấy IDHS từ dữ liệu mới được thêm vào
    SELECT @IDHS = IDHS FROM inserted;

    -- Thêm dữ liệu vào bảng XEPLOAI
    INSERT INTO XEPLOAI (IDHK, IDHS, DIEMTONGKET) VALUES (@IDHK, @IDHS, NULL);
END;
go

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
SP_GET_GIAOVIEN_BY_LOP '10A2'

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

EXEC FindTeacherIDByFullName N'Nguyễn Văn G';

CREATE PROCEDURE DisableStudentByID
    @IDHS VARCHAR(10)
AS
BEGIN
    UPDATE HOCSINH
    SET isEnable = 'No'
    WHERE IDHS = @IDHS;
END
go

CREATE PROCEDURE UpdateStudentInfo
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
    @TENPH NVARCHAR(50)
AS
BEGIN
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

alter PROCEDURE SP_DoiLopHocSinh
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
    @IDGV NVARCHAR(64),
    @SDTPH NVARCHAR(20),
    @TenPH NVARCHAR(50)
AS
BEGIN
    IF @IDHS IS NULL
        RETURN; -- Thoát stored procedure nếu @IDHS là NULL
		DECLARE @IDHSnew NVARCHAR(64);
    SET @IDHSnew = LEFT(@IDHS, CHARINDEX('-', @IDHS) - 1) + '-' + @IDLop; -- Nối IDHS với IDLop để tạo IDHS mới
	DECLARE @IDHSNumber NVARCHAR(64);

	-- Tìm vị trí của ký tự '-' trong chuỗi
	DECLARE @Index INT = CHARINDEX('-', @IDHS);

	-- Lấy phần số từ chuỗi bắt đầu từ vị trí đầu tiên đến vị trí trước ký tự '-'
	Set @IDHSNumber = SUBSTRING(@IDHS, 3, @Index - 3);
	-- Tạo TENDN tự động
	DECLARE @TENDN varchar(32);
    DECLARE @MATKHAU varchar(32);
    SET @TENDN = 'hocsinh' + CAST(@IDHSNumber AS varchar(10));

    -- Tạo mật khẩu tự động
    SET @MATKHAU = 'matkhau' + CAST(@IDHSNumber AS varchar(10));
    -- Gọi stored procedure SP_INS_HOCSINH để chèn dữ liệu mới
    EXEC SP_INS_HOCSINH @IDHSnew, @Ho, @Ten, @NamSinh, @GioiTinh, @QueQuan, @DiaChi, @Email, @SDT, @IDLop, 'X', @IDGV, 'DH', @SDTPH, @TenPH, @TENDN, @MATKHAU;
END

go


EXECUTE SP_DoiLopHocSinh N'HS11-12C3', N'Lê Phú', N'Nhân', '2003-01-24', N'Nam', N'Bến Tre', N'27 Ngô Quyền', 'lpn@email.com', '0123456789', '10A2', 'GV006', '0987654321', N'Kim Uyên';