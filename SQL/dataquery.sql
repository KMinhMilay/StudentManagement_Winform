
create database QLHS
go
use QLHS 
go
create table NAMHOC (
	IDNAM int,
	NAMBATDAU nvarchar(20),
	NAMKETTHUC nvarchar(20),
	primary key (IDNAM)
)
go
create table HOCKY (
	IDHK int primary key,
	IDNAM int,
	HOCKY int,

	FOREIGN KEY (IDNAM) REFERENCES NAMHOC(IDNAM)
)
create table MONHOC (
	IDMH varchar(32),
	TENMH nvarchar(64),
	SOTIET int,
	primary key (IDMH)
)
go
create table LOP (
	IDLOP varchar(32),
	TENLOP nvarchar(64),
	SOLUONG int,
	primary key (IDLOP)
)
go
create table CHUCVU (
	IDCV varchar(32),
	TENCV nvarchar(64),
	primary key (IDCV)

)
go
create table TRANGTHAI(
	IDTRANGTHAI varchar(64),
	TENTRANGTHAI nvarchar(64),

	primary key (IDTRANGTHAI)
)
go
create table GIAOVIEN(
	IDGV varchar(64) primary key,
	HO nvarchar(64),
	TEN nvarchar(32),
	NAMSINH datetime,
	GIOITINH nvarchar(10),
	QUEQUAN nvarchar(64),
	DIACHI nvarchar(64),
	EMAIL nvarchar(64),
	SDT varchar(12),
	IDLOPCN varchar(32),
	IDMH varchar(32),
	LUONG varbinary(max),
	TENDN varchar(32),
	MATKHAU varbinary(max),
	VAITRO int,
	isEnable varchar(10) default('Yes')
	--primary key (IDGV,IDLOPCN,IDMH),

	FOREIGN KEY (IDLOPCN) REFERENCES LOP(IDLOP),
	FOREIGN KEY (IDMH) REFERENCES MONHOC(IDMH)

)
go
create table HOCSINH(
	IDHS varchar(64) primary key,
	HO nvarchar(64),
	TEN nvarchar(32),
	NAMSINH datetime,
	GIOITINH nvarchar(10),
	QUEQUAN nvarchar(64),
	DIACHI nvarchar(64),
	EMAIL nvarchar(64),
	SDT varchar(12),
	IDLOP varchar(32),
	IDCV varchar(32),
	IDGV varchar(64),
	IDTRANGTHAI varchar(64),
	SDTPH varchar(12),
	TENPH nvarchar(64),
	TENDN varchar(32),
	MATKHAU varbinary(max),
	isEnable varchar(10) default('Yes')

	FOREIGN KEY (IDLOP) REFERENCES LOP(IDLOP),
	FOREIGN KEY (IDCV) REFERENCES CHUCVU(IDCV),
	FOREIGN KEY (IDGV) REFERENCES GIAOVIEN(IDGV),
	FOREIGN KEY (IDTRANGTHAI) REFERENCES TRANGTHAI(IDTRANGTHAI)

)
go
create table DIEM (
	IDDIEM varchar(64) primary key ,
	IDHK int,
	IDMH varchar(32),
	IDHS varchar(64),
	DIEMQT float,
	DIEMGK float,
	DIEMCK float,
	DTB float,
	FOREIGN KEY (IDHK) REFERENCES HOCKY(IDHK),
	FOREIGN KEY (IDMH) REFERENCES MONHOC(IDMH),
	FOREIGN KEY (IDHS) REFERENCES HOCSINH(IDHS)
)
go
create table XEPLOAI (
	IDXEPLOAI int primary key identity(1,1),
	IDHK int,
	IDHS varchar(64) not null,	
	DIEMTONGKET float,
	HOCLUC nvarchar(16) default(N'Chưa đánh giá'),
	HANHKIEM nvarchar(16) default(N'Chưa đánh giá'),
	FOREIGN KEY (IDHS) REFERENCES HOCSINH(IDHS),
	FOREIGN KEY (IDHK) REFERENCES HOCKY(IDHK)

)
go
create table TransactionHistory(
	id int identity(1,1) primary key,
	transactionText nvarchar(max)
)
go
---------------------------------------------
--------------STORE PROCEDURE----------------
---------------------------------------------
CREATE PROCEDURE SP_INS_GIAOVIEN
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
	@IDMH varchar(32),
	@LUONG int,
	@TENDN varchar(32),
	@MATKHAU varchar(max),
	@ROLE int
AS
BEGIN
	--hash password
	declare @hashedPW varbinary(max);
    SET @hashedPW = CONVERT(VARBINARY(MAX), HASHBYTES('SHA1', @MATKHAU), 1);

	--create asymmetric key
	DECLARE @Sql NVARCHAR(MAX)
	DECLARE @ParmDefinition NVARCHAR(500);
	DECLARE @pwd NVARCHAR(max)
	SET @pwd = CONVERT(nvarchar(max),@hashedPW,1)

	SET @Sql = N'CREATE ASYMMETRIC KEY ' + QUOTENAME(@IDGV) + 
			   N' WITH ALGORITHM = RSA_2048
               ENCRYPTION BY PASSWORD = ''' + @pwd + ''';';
	EXEC sp_executesql @Sql;

	--encrypt luong
	DECLARE @Sql_encrypted NVARCHAR(MAX);
	declare @Salary varchar(100);
	SET @Salary = CONVERT(varchar(100), @LUONG, 1);
	DECLARE @encryptedLUONG VARBINARY(MAX);
	SET @encryptedLUONG = CONVERT(VARBINARY(MAX),ENCRYPTBYASYMKEY(ASYMKEY_ID(@IDGV),@Salary),1);

	--insert
	INSERT INTO GIAOVIEN VALUES ( @IDGV,@HO,@TEN,@NAMSINH,@GIOITINH,@QUEQUAN,@DIACHI,@EMAIL,@SDT,@IDLOPCN,@IDMH,@encryptedLUONG,@TENDN,@hashedPW,@ROLE, 'Yes')
END
go

CREATE PROCEDURE SP_INS_HOCSINH
	@IDHS varchar(64),
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
	@TENPH nvarchar(64),
	@TENDN varchar(32),
	@MATKHAU varchar(max)
AS
BEGIN
	declare @MKHASH varbinary(max);
    SET @MKHASH =	CONVERT(VARBINARY(MAX), HASHBYTES('SHA1', @MATKHAU), 1);

	INSERT INTO HOCSINH VALUES ( @IDHS,@HO,@TEN,@NAMSINH,@GIOITINH,@QUEQUAN,@DIACHI,@EMAIL,@SDT,@IDLOP,@IDCV,@IDGV,@IDTRANGTHAI,@SDTPH,@TENPH,@TENDN,@MKHASH,'Yes')
END
go









---------------------------------------------
-----------------THEM DU LIEU----------------
---------------------------------------------
insert into NAMHOC values (20202021,'2020','2021'), (20212022,'2021','2022'), (20222023,'2022','2023')
go
--insert into NAMHOC values (20232024,'2023','2024')
insert into HOCKY values (20201,20202021, 1), (20202, 20202021, 2 ), (20211, 20212022, 1 ), (20212, 20212022, 2 ), (20221, 20222023, 1 ), (20222, 20222023, 2 )
go
--insert into HOCKY values (20231,20232024, 1),insert into HOCKY values(20232,20232024, 2)
insert into MONHOC values ('TOAN',N'Toán',60),
('VAN',N'Văn',60),('NN',N'Ngoại Ngữ',60),
('SINH',N'Sinh học',45),('LY',N'Vật lý',45),
('HOA',N'Hóa học',45),('SU',N'Lịch sử',45),
('DIA',N'Địa lý',45),('GDCD',N'Giáo dục công dân',45),
('GDTC',N'Giáo dục thể chất',30),('GDQP',N'Giáo dục quốc phòng',30)
go


insert into LOP values 
('10A1',N'Lớp 10A1',42),('10A2',N'Lớp 10A2',40),('10A3',N'Lớp 10A3',44),
('11B1',N'Lớp 11B1',42),('11B2',N'Lớp 11B2',40),('11B3',N'Lớp 11B3',41),
('12C1',N'Lớp 12C1',41),('12C2',N'Lớp 12C1',40),('12C3',N'Lớp 12C3',40)
go
insert into LOP values 
('NO',N'Không có',0)
go
insert into CHUCVU values
('X',N'Học sinh'),
('LT',N'Lớp Trưởng'),
('LP',N'Lớp Phó')
go

insert into TRANGTHAI values
('DH',N'Đang học'),
('CT',N'Chuyển trường'),
('BL',N'Bảo lưu'),
('NH',N'Nghỉ học')
go

EXEC SP_INS_GIAOVIEN 'ADMIN', N'Phạm Lê Khánh ', N'Minh', '1992-01-01', N'Nam', N'Khánh Hòa', N'223 Đường C, Quận 1', 'plkminh@email.com', '0123456789', 'NO', 'VAN', 0, 'admin', 'nhomchialadu',3
EXEC SP_INS_GIAOVIEN 'GV001', N'Nguyễn Văn ', N'A', '1980-01-01', N'Nam', N'Hà Nội', N'123 Đường A, Quận 1', 'nguyenvana@email.com', '0123456789', '10A1', 'VAN', 7000000, 'tendn1', '19800101',2
EXEC SP_INS_GIAOVIEN 'GV002', N'Phạm Thị ', N'B', '1985-02-15', N'Nữ', N'Hồ Chí Minh', N'456 Đường B, Quận 2', 'phamthib@email.com', '0987654321', '11B2', 'TOAN', 8000000, 'tendn2', '19850215',2
EXEC SP_INS_GIAOVIEN 'GV003', N'Lê Đình ', N'C', '1990-03-20', N'Nam', N'Đà Nẵng', N'789 Đường C, Quận 3', 'ledinhc@email.com', '0123456789', '11B3', 'NN', 8860000, 'tendn3', '19900320',2
EXEC SP_INS_GIAOVIEN 'GV004', N'Trần Thị ', N'D', '1995-04-25', N'Nữ', N'Cần Thơ', N'101 Đường D, Quận 4', 'trand@email.com', '0987654321', '12C1', 'HOA', 7400000, 'tendn4', '19950425',2
EXEC SP_INS_GIAOVIEN 'GV005', N'Hoàng Văn ', N'E', '1999-05-30', N'Nam', N'Vũng Tàu', N'112 Đường E, Quận 5', 'hoangvane@email.com', '0123456789', '12C2', 'SU', 7000000, 'tendn5', '19990530',2
EXEC SP_INS_GIAOVIEN 'GV006', N'Nguyễn Văn ', N'F', '1999-06-30', N'Nam', N'Bến Tre', N'223 Đường F, Quận 9', 'nguyenvanf@email.com', '0123456789', '10A2', 'NN', 8000000, 'tendn6', '19990630',2
EXEC SP_INS_GIAOVIEN 'GV007', N'Nguyễn Văn ', N'H', '1999-07-30', N'Nam', N'Bến Tre', N'253 Đường F, Quận 9', 'nguyenvanh@email.com', '0123456789', '10A3', 'LY', 8000000, 'tendn7', '19990730',2
EXEC SP_INS_GIAOVIEN 'GV008', N'Nguyễn Văn ', N'G', '1999-08-30', N'Nam', N'Bến Tre', N'23 Đường G, Quận 9', 'nguyenvang@email.com', '0123456789', '12C3', 'TOAN', 8000000, 'tendn8', '19990830',2
EXEC SP_INS_GIAOVIEN 'GV009', N'Lê Văn ', N'K', '1997-10-20', N'Nam', N'Hà Nội', N'68 Đường K, Quận 3', 'levank@email.com', '0123456789', '11B1', 'HOA', 8000000, 'tendn9', '19971020',2

EXEC SP_INS_HOCSINH 'HS1-10A1', N'Vũ Thị', N'A', '2010-06-10', N'Nữ', N'Hải Phòng', N'113 Đường A, Quận 1', 'vuthia@email.com', '0123456789', '10A1', 'X', 'GV001', 'DH', '0987654321', N'Phụ huynh A', 'hocsinh1', 'password1'
EXEC SP_INS_HOCSINH 'HS2-11B1', N'Vũ Thị', N'B', '2010-07-11', N'Nữ', N'Hải Phòng', N'113 Đường B, Quận 2', 'vuthib@email.com', '0123456789', '11B1', 'X', 'GV009', 'DH', '0987654321', N'Phụ huynh B', 'hocsinh2', 'password2'
EXEC SP_INS_HOCSINH 'HS3-10A2', N'Đặng Văn', N'C', '2011-07-15', N'Nam', N'Bình Phước', N'114 Đường C, Quận 3', 'dangvanc@email.com', '0123456789', '10A2', 'LT', 'GV006', 'DH', '0987654321', N'Phụ huynh C', 'hocsinh3', 'password3'
EXEC SP_INS_HOCSINH 'HS4-11B2', N'Đặng Văn', N'D', '2011-04-15', N'Nam', N'Bình Dương', N'14 Đường D, Quận 4', 'dangvand@email.com', '0123456789', '11B2', 'X', 'GV002', 'DH', '0987654321', N'Phụ huynh D', 'hocsinh4', 'password4'
EXEC SP_INS_HOCSINH 'HS5-12C2', N'Đặng Văn', N'E', '2011-07-24', N'Nam', N'Bến Tre', N'24 Đường E, Quận 5', 'dangvane@email.com', '0123456789', '12C2', 'X', 'GV005', 'DH', '0987654321', N'Phụ huynh E', 'hocsinh5', 'password5'
EXEC SP_INS_HOCSINH 'HS6-10A1', N'Ngô Thị', N'F', '2012-08-20', N'Nữ', N'Đắk Lắk', N'115 Đường F, Quận 6', 'ngothif@email.com', '0123456789', '10A1', 'LT', 'GV001', 'DH', '0987654321', N'Phụ huynh F', 'hocsinh6', 'password6'
EXEC SP_INS_HOCSINH 'HS7-12C3', N'Bùi Văn', N'G', '2013-09-25', N'Nam', N'Đồng Nai', N'116 Đường G, Quận 7', 'buivang@email.com', '0123456789', '12C3', 'LP','GV008', 'DH', '0987654321', N'Phụ huynh G', 'hocsinh7', 'password7'
EXEC SP_INS_HOCSINH 'HS8-10A2', N'Lý Thị', N'H', '2014-10-30', N'Nữ', N'Bà Rịa - Vũng Tàu', N'117 Đường H, Quận 8', 'lythih@email.com', '0123456789', '10A2','LP','GV006', 'DH', '0987654321', N'Phụ huynh H', 'hocsinh8', 'password8'
EXEC SP_INS_HOCSINH 'HS9-10A2', N'Trịnh Văn ', N'K', '2015-11-10', N'Nam', N'Long An', N'118 Đường K, Quận 9', 'trinhvank@email.com', '0123456789', '10A2', 'X', 'GV006', 'BL', '0987654321', N'Phụ huynh K', 'hocsinh9', 'password9'
EXEC SP_INS_HOCSINH 'HS10-11B3', N'Mai Thị ', N'L', '2016-12-15', N'Nữ', N'Tây Ninh', N'119 Đường L, Quận 10', 'maithil@email.com', '0123456789', '11B3', 'X', 'GV003', 'DH', '0987654321', N'Phụ huynh L', 'hocsinh10', 'password10'
EXEC SP_INS_HOCSINH 'HS11-10A3', N'Đinh Văn ', N'M', '2017-01-20', N'Nam', N'An Giang', N'120 Đường M, Quận 11', 'dinhvanm@email.com', '0123456789', '10A3', 'LP', 'GV007', 'NH', '0987654321', N'Phụ huynh M', 'hocsinh11', 'password11'
EXEC SP_INS_HOCSINH 'HS12-12C1', N'Vương Thị ', N'N', '2018-02-25', N'Nữ', N'Kiên Giang', N'121 Đường N, Quận 12', 'vuongthin@email.com', '0123456789', '12C1', 'LT', 'GV004', 'DH', '0987654321', N'Phụ huynh N', 'hocsinh12', 'password12'
EXEC SP_INS_HOCSINH 'HS13-10A3', N'Chu Văn ', N'I', '2019-03-30', N'Nam', N'Vĩnh Long', N'122 Đường I, Quận 13', 'chuvani@email.com', '0123456789', '10A3', 'X','GV007', 'DH', '0987654321', N'Phụ huynh I', 'hocsinh13', 'password13'


insert into DIEM values ('hs1toan20221',20221,'TOAN','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs1van20221',20221,'VAN','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs1nn20221',20221,'NN','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs1sinh20221',20221,'SINH','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs1hoa20221',20221,'HOA','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs1ly20221',20221,'LY','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs1su20221',20221,'SU','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs1dia20221',20221,'DIA','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs1gdcd20221',20221,'GDCD','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs1gdtc20221',20221,'GDTC','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs1gdqp20221',20221,'GDQP','HS1-10A1',null,null,null,null)
insert into DIEM values ('hs3toan20221',20221,'TOAN','HS3-10A2',null,null,null,null)
insert into DIEM values ('hs3van20221',20221,'VAN','HS3-10A2',null,null,null,null)
insert into DIEM values ('hs3nn20221',20221,'NN','HS3-10A2',null,null,null,null)
insert into DIEM values ('hs3sinh20221',20221,'SINH','HS3-10A2',null,null,null,null)
insert into DIEM values ('hs3hoa20221',20221,'HOA','HS3-10A2',null,null,null,null)
insert into DIEM values ('hs3ly20221',20221,'LY','HS3-10A2',null,null,null,null)
insert into DIEM values ('hs3su20221',20221,'SU','HS3-10A2',null,null,null,null)
insert into DIEM values ('hs3dia20221',20221,'DIA','HS3-10A2',null,null,null,null)
insert into DIEM values ('hs3gdcd20221',20221,'GDCD','HS3-10A2',null,null,null,null)
insert into DIEM values ('hs3gdtc20221',20221,'GDTC','HS3-10A2',null,null,null,null)
insert into DIEM values ('hs3gdqp20221',20221,'GDQP','HS3-10A2',null,null,null,null)
/*
nhớ chỉnh lại thành
HOCLUC nvarchar(16) default(N'Chưa đánh giá'),
HANHKIEM nvarchar(16) default(N'Chưa đánh giá')
thiếu chữ N nó ko hiểu TViet
*/
/*
IDXEPLOAI int primary key identity(1,1),
	IDHK int,
	IDHS varchar(64) not null,	
	DIEMTONGKET float,
	HOCLUC nvarchar(16) default('Chưa đánh giá'),
	HANHKIEM nvarchar(16) default('Chưa đánh giá'),
*/
insert into XEPLOAI(IDHK,IDHS,DIEMTONGKET) values (20221,'HS1-10A1',null)
insert into XEPLOAI(IDHK,IDHS,DIEMTONGKET)  values (20221,'HS2-11B1',null)
insert into XEPLOAI(IDHK,IDHS,DIEMTONGKET)  values (20221,'HS3-10A2',null)
insert into XEPLOAI(IDHK,IDHS,DIEMTONGKET)  values (20221,'HS4-11B2',null)
insert into XEPLOAI(IDHK,IDHS,DIEMTONGKET)  values (20221,'HS5-12C2',null)
insert into XEPLOAI(IDHK,IDHS,DIEMTONGKET)  values (20221,'HS6-10A1',null)
insert into XEPLOAI(IDHK,IDHS,DIEMTONGKET)  values (20221,'HS7-10A2',null)
insert into XEPLOAI(IDHK,IDHS,DIEMTONGKET)  values (20221,'HS8-10A3',null)
insert into XEPLOAI(IDHK,IDHS,DIEMTONGKET)  values (20221,'HS9-10A3',null)
insert into XEPLOAI(IDHK,IDHS,DIEMTONGKET)  values (20221,'HS10-10A3',null)
--select n.NAMBATDAU,n.NAMKETTHUC,h.HOCKY from NAMHOC n inner join HOCKY h 
--ON n.IDNAM = h.IDNAM 










------

------TRIGGER tinh diem trung binh ---
