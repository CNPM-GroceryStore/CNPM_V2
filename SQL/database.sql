use master
drop database CuaHangTienLoi
-- Tạo database mới
CREATE DATABASE CuaHangTienLoi;
GO

-- Sử dụng database mới tạo
USE CuaHangTienLoi;
GO


-- tạo procedure thêm dữ liệu vào MyVoucher
CREATE PROCEDURE InsertToMyVoucher
    @soDienThoai VARCHAR(15),
    @maVoucher INT
AS
BEGIN
    IF EXISTS(SELECT * FROM MyVoucher WHERE SoDienThoai = @soDienThoai AND MaVoucher = @maVoucher)
    BEGIN
        UPDATE MyVoucher SET SoLuong = SoLuong + 1 WHERE SoDienThoai = @soDienThoai AND MaVoucher = @maVoucher;
    END
    ELSE
    BEGIN
        INSERT INTO MyVoucher(SoDienThoai, MaVoucher) VALUES(@soDienThoai, @maVoucher);
    END
END
go

-- procedure liet ke voucher theo ma user
CREATE PROCEDURE listMyVoucher 
    @SoDienThoai VARCHAR(15)
AS
BEGIN
    SELECT 
        V.MaVoucher,
        V.TenVoucher,
        V.GiaVoucher,
        V.HinhAnh,
		MV.SoLuong
    FROM 
        MyVoucher MV
        JOIN Voucher V ON MV.MaVoucher = V.MaVoucher
    WHERE 
        MV.SoDienThoai = @SoDienThoai
END
go

-- Tạo bảng nhân viên
CREATE TABLE NhanVien (
    SoDienThoai VARCHAR(15) PRIMARY KEY,
    Email VARCHAR(50) NOT NULL,
    HoTen NVARCHAR(50) NOT NULL,
    DiaChi NVARCHAR(200) NOT NULL,
    MatKhau NVARCHAR(20) NOT NULL,
	DiemTichLuy Int Default 0
);
GO


--Tạo bảng sản phẩm
CREATE TABLE SanPham (
	MaSp INT IDENTITY(1,1) PRIMARY KEY,
	TenSp NVARCHAR(100) NOT NULL,
	GiaSP INT NOT NULL,
	HinhAnh VARCHAR(300) NOT NULL,
	LoaiSp VARCHAR(10) NOT NULL

);
GO

--Tạo bản GIỏ hàng và Sản phẩm giỏ hàng
CREATE TABLE Cart (
  idUser VARCHAR(15) PRIMARY KEY,
  FOREIGN KEY (idUser) REFERENCES NhanVien(SoDienThoai)
);

--drop table cart_item

CREATE TABLE cart_item (
  item_id VARCHAR(50) PRIMARY KEY,
  cart_id VARCHAR(15),
  item_name NVARCHAR(255),
  item_price INt,
  quantity INT,
  FOREIGN KEY (cart_id) REFERENCES Cart(idUser)
);
GO

--Tạo bảng voucher
CREATE TABLE Voucher (
	MaVoucher INT IDENTITY(1,1) PRIMARY KEY,
	TenVoucher NVARCHAR(100) NOT NULL,
	GiaVoucher INT NOT NULL,
	HinhAnh VARCHAR(300) NOT NULL,
);
GO

--Tạo bảng MyVoucher
CREATE TABLE MyVoucher (
    SoDienThoai VARCHAR(15) NOT NULL,
    MaVoucher INT NOT NULL,
	SoLuong int default 1,
    CONSTRAINT PK_MyVoucher PRIMARY KEY (SoDienThoai, MaVoucher),
    CONSTRAINT FK_MyVoucher_NhanVien FOREIGN KEY (SoDienThoai) REFERENCES NhanVien(SoDienThoai),
    CONSTRAINT FK_MyVoucher_Voucher FOREIGN KEY (MaVoucher) REFERENCES Voucher(MaVoucher)
);


CREATE TABLE OrderHistory(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idUser VARCHAR(15),
	price INT,
	amount INT,
	paymethod VARCHAR(20),
	paydate VARCHAR(20),
	status VARCHAR(20),
	FOREIGN KEY (idUser) REFERENCES NhanVien(SoDienThoai)
)

GO


-- Tạo stored procedure để kiểm tra tài khoản đăng nhập
CREATE PROCEDURE checkLogin
    @SoDienThoai VARCHAR(50)
AS
BEGIN 
    SELECT SoDienThoai, MatKhau FROM NhanVien WHERE SoDienThoai = @SoDienThoai
END
GO

-- Tạo stored procedure để kiểm tra sự tồn tại của tài khoản
CREATE PROCEDURE checkExistAccount
    @sdt VARCHAR(20),
    @password VARCHAR(20)
AS
BEGIN
    SELECT COUNT(*) AS 'Tontai' FROM NhanVien WHERE SoDienThoai LIKE @sdt AND MatKhau LIKE @password
END
GO


CREATE PROCEDURE loadCart
	@idUser VARCHAR(20)
AS
BEGIN 
	SELECT item_id, item_name, item_price, quantity FROM cart_item WHERE cart_id = @idUser
END
GO


--tạo prodcedure select toàn bộ sản phẩm
CREATE PROCEDURE GetAllProducts
AS
BEGIN
    SELECT * FROM SanPham;
END
GO

--procude insert Nhanvien
CREATE PROCEDURE InsertNhanVien
    @SoDienThoai nvarchar(50),
    @Email nvarchar(50),
    @HoTen nvarchar(50),
    @DiaChi nvarchar(50),
    @MatKhau nvarchar(50)
AS
BEGIN
    INSERT INTO NhanVien (SoDienThoai, Email, HoTen, DiaChi, MatKhau)
    VALUES (@SoDienThoai, @Email, @HoTen, @DiaChi, @MatKhau)
END
GO




-- Thêm dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (SoDienThoai, Email, HoTen, DiaChi, MatKhau)
VALUES
('0977756777', 'LeVanC@gmail.com', N'Lê Văn X',  N'Hồ Chí Minh', '11122222'),
('0987654321', 'NguyenVanA@gmail.com', N'Nguyễn Văn A', N'Hà Nội', '123456'),
('0912345678', 'TranThiB@gmail.com', N'Trần Thị B', N'Hải Phòng', 'abcdef'),
('0977777777', 'LeVanC@gmail.com', N'Lê Văn C', N'Hồ Chí Minh', '111222');

--Thêm dữ liệu vào bảng SanPham

INSERT INTO SanPham(TenSp, GiaSP, HinhAnh, LoaiSp)
VALUES
(N'Bánh Bắp Ngọt Oishi', 14000, 'bno.jpeg', 'DAV'),
(N'Khoai Tây Chiên Vị Kim Chi OStar ', 17000, 'kco.jpeg', 'DAV'),
(N'Khoai Tây Chiên Vị Bò Bít Tết Swing', 28000, 'bts.jpeg', 'DAV'),
(N'Khoai Tây Chiên Vị Rong Biển OStar', 17000, 'rbo.jpeg', 'DAV'),
(N'Mì Trộn Xúc Xích Trứng Chiên', 34000, 'ccdc.jpeg', 'DA'),
(N'Mì Hảo Hảo', 5000, 'mhh.jpg', 'DA'),
(N'Bánh Mì Ốp La 2 Trứng', 19000, 'mtxxt.png', 'DA'),
(N'Xúc Xích', 20000, 'xx.png', 'DA'),
(N'Bông Tẩy Trang Jomi', 37000, 'jomi.jpeg', 'DGD'),
(N'Bật Lửa J3 Bic', 16000, 'j3.jpeg', 'DGD'),
(N'Sữa tắm nước hoa Romano Classic sạch sảng khoái 650g', 175000, 'romano.jpeg', 'DGD'),
(N'Nước Súc Miệng Listerine Bạc Hà 250ml', 90000, 'bh.jpeg', 'DGD'),
(N'Khăn Giấy Ướt Yuniku Lài 90 Miếng', 37000, 'yuni.jpeg', 'DGD'),
(N'Sữa tươi cà phê', 25000, 'cps.png', 'DU'),
(N'Trà đào', 30000, 'td.png', 'DU'),
(N'Cà phê đen đá', 15000, 'cpd.png', 'DU'),
(N'Trà sữa thái', 18000, 'ol.jpeg', 'DU'),
(N'Cà phê phin sữa đá', 18000, 'psd.png', 'DU');


--Thêm dữ liệu vào bảng Voucher
INSERT INTO Voucher(TenVoucher, GiaVoucher, HinhAnh)
VALUES
(N'Giảm 10k cho đơn 0đ', 10000, ''),
(N'Giảm 20k cho đơn 0đ', 20000, ''),
(N'Giảm 30k cho đơn 0đ', 30000, ''),
(N'Giảm 40k cho đơn 0đ', 40000, ''),
(N'Giảm 50k cho đơn 0đ', 50000, '');

INSERT INTO NhanVien (SoDienThoai, Email, HoTen, DiaChi, MatKhau, DiemTichLuy)
VALUES
('0387790894', 'lehuynhphat@gmail.com', N'Lê Huỳnh Phát',  N'Bến Tre', '12345678', 1000000);

insert into MyVoucher (SoDienThoai, MaVoucher) values ('0387790894', 1);

delete from MyVoucher where SoDienThoai = '0387790894' and MaVoucher = '1';

-- Thực thi stored procedure để kiểm tra đăng nhập
EXECUTE checkLogin '0977756777';

-- Thực thi stored procedure để kiểm tra sự tồn tại của tài khoản
EXECUTE checkExistAccount '0977756777', '11122222';

Execute InsertToMyVoucher '0387790894', '1';

select * from NhanVien
select * from Voucher
select * from MyVoucher
select * from Voucher

select * from Cart
select * from cart_item
delete from OrderHistory
select * from OrderHistory
	
exec listMyVoucher '0387790894'

