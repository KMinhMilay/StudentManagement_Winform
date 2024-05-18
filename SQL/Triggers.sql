

--LE PHU NHAN
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

-- NGUYEN HOANG THUONG
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

        IF @hanhkiem IS NULL OR @hanhkiem = 'Chua dánh giá'
        BEGIN
            UPDATE XEPLOAI SET DIEMTONGKET = @diemtongket WHERE IDHS = @idhs and IDHK = @idhk
        END
        ELSE
        BEGIN
            if(@diemtongket < 3.5)
                set @hocluc = N'Kém'
            else if(@diemtongket < 5)
                set @hocluc = N'Y?u'
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
                if(@hanhkiem = N'Gi?i')
                    set @hocluc = N'Gi?i'
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