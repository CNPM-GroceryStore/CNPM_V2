use master
drop database CuaHangTienLoi
-- Tạo database mới
CREATE DATABASE CuaHangTienLoi;
GO

-- Sử dụng database mới tạo
USE CuaHangTienLoi;
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
    CONSTRAINT PK_MyVoucher PRIMARY KEY (SoDienThoai, MaVoucher),
    CONSTRAINT FK_MyVoucher_NhanVien FOREIGN KEY (SoDienThoai) REFERENCES NhanVien(SoDienThoai),
    CONSTRAINT FK_MyVoucher_Voucher FOREIGN KEY (MaVoucher) REFERENCES Voucher(MaVoucher)
);



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
(N'Bánh Bắp Ngọt Oishi', 14000, 'http://surl.li/focdh', 'DAV'),
(N'Khoai Tây Chiên Vị Kim Chi OStar ', 17000, 'http://surl.li/focde', 'DAV'),
(N'Khoai Tây Chiên Vị Bò Bít Tết Swing', 28000, 'http://surl.li/focdz', 'DAV'),
(N'Khoai Tây Chiên Vị Rong Biển OStar', 17000, 'http://surl.li/focep', 'DAV'),
(N'Mì Trộn Xúc Xích Trứng Chiên', 34000, 'https://bom.so/4eOF7v', 'DA'),
(N'Mì Hảo Hảo', 5000, 'https://bom.so/CaWeAF', 'DA'),
(N'Bánh Mì Ốp La 2 Trứng', 19000, 'https://bom.so/pRlOJa', 'DA'),
(N'Xúc Xích', 20000, 'https://bom.so/oVW2M1', 'DA'),
(N'Bông Tẩy Trang Jomi', 37000, 'https://bom.so/283p6f', 'DGD'),
(N'Bật Lửa J3 Bic', 16000, 'https://bom.so/05bq3j', 'DGD'),
(N'Sữa tắm nước hoa Romano Classic sạch sảng khoái 650g', 175000, 'https://bom.so/eUX84C', 'DGD'),
(N'Nước Súc Miệng Listerine Bạc Hà 250ml', 90000, 'https://bom.so/fXSOXl', 'DGD'),
(N'Khăn Giấy Ướt Yuniku Lài 90 Miếng', 37000, 'https://bom.so/7k2Qyl', 'DGD'),
(N'Sữa tươi cà phê', 25000, 'https://bom.so/4XB3xx', 'DU'),
(N'Trà đào', 30000, 'http://surl.li/fookl', 'DU'),
(N'Cà phê đen đá', 15000, 'https://bom.so/B0Bt08', 'DU'),
(N'Trà sữa thái', 18000, 'https://bom.so/okWtaS', 'DU'),
(N'Cà phê phin sữa đá', 18000, 'https://bom.so/NsYnDp', 'DU');


--Thêm dữ liệu vào bảng Voucher
INSERT INTO Voucher(TenVoucher, GiaVoucher, HinhAnh)
VALUES
(N'Giảm 10k cho đơn 0đ', 10000, ''),
(N'Giảm 20k cho đơn 0đ', 20000, ''),
(N'Giảm 30k cho đơn 0đ', 30000, ''),
(N'Giảm 40k cho đơn 0đ', 40000, ''),
(N'Giảm 50k cho đơn 0đ', 50000, '');


select * from NhanVien
-- Thực thi stored procedure để kiểm tra đăng nhập
EXECUTE checkLogin '0977756777';

-- Thực thi stored procedure để kiểm tra sự tồn tại của tài khoản
EXECUTE checkExistAccount '0977756777', '11122222';

select * from MyVoucher