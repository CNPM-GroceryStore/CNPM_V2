﻿use master 
drop database CuaHangTienLoi
go
-- Tạo database mới
CREATE DATABASE CuaHangTienLoi;
GO

-- Sử dụng database mới tạo
USE CuaHangTienLoi;
GO


-- Tạo bảng nhân viên
CREATE TABLE NhanVien (
    numberPhone VARCHAR(15) PRIMARY KEY,
    Email VARCHAR(50) NOT NULL,
    name NVARCHAR(50) NOT NULL,
    address NVARCHAR(200) NOT NULL,
    password NVARCHAR(20) NOT NULL,
	DiemTichLuy Int Default 0
);
GO


--Tạo bảng sản phẩm
CREATE TABLE Product (
	idProduct INT IDENTITY(1,1) PRIMARY KEY,
	nameProduct NVARCHAR(100) NOT NULL,
	amountProduct INT NOT NULL, 
	priceProduct INT NOT NULL,
	imageProduct NVARCHAR(300) NOT NULL,
	typeProduct VARCHAR(10) NOT NULL,
	shipment VARCHAR(20) NOT NULL,
	shelflife date NOT NULL
);
GO

--Tạo bản GIỏ hàng và Sản phẩm giỏ hàng
CREATE TABLE Cart (
  idUser VARCHAR(15) PRIMARY KEY,
  FOREIGN KEY (idUser) REFERENCES NhanVien(numberPhone)
);

--drop table cart_item

CREATE TABLE cart_item (
  item_id NVARCHAR(255) PRIMARY KEY,
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
    numberPhone VARCHAR(15) NOT NULL,
    MaVoucher INT NOT NULL,
	SoLuong int default 1,
    CONSTRAINT PK_MyVoucher PRIMARY KEY (numberPhone, MaVoucher),
    CONSTRAINT FK_MyVoucher_NhanVien FOREIGN KEY (numberPhone) REFERENCES NhanVien(numberPhone),
    CONSTRAINT FK_MyVoucher_Voucher FOREIGN KEY (MaVoucher) REFERENCES Voucher(MaVoucher)
);


CREATE TABLE OrderHistory(
	id INT IDENTITY(1,1) PRIMARY KEY,
	idUser VARCHAR(15),
	price INT,
	amount INT,
	paymethod NVARCHAR(20),
	paydate date,
	status VARCHAR(20),
	FOREIGN KEY (idUser) REFERENCES NhanVien(numberPhone)
)

GO


-- Tạo stored procedure để kiểm tra tài khoản đăng nhập
CREATE PROCEDURE checkLogin
    @numberPhone VARCHAR(50)
AS
BEGIN 
    SELECT numberPhone, password FROM NhanVien WHERE numberPhone = @numberPhone
END
GO

-- Tạo stored procedure để kiểm tra sự tồn tại của tài khoản
CREATE PROCEDURE checkExistAccount
    @sdt VARCHAR(20),
    @password VARCHAR(20)
AS
BEGIN
    SELECT COUNT(*) AS 'Tontai' FROM NhanVien WHERE numberPhone LIKE @sdt AND password LIKE @password
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
    SELECT * FROM Product;
END
GO

--procude insert Nhanvien
CREATE PROCEDURE InsertNhanVien
    @numberPhone nvarchar(50),
    @Email nvarchar(50),
    @HoTen nvarchar(50),
    @DiaChi nvarchar(50),
    @password nvarchar(50)
AS
BEGIN
    INSERT INTO NhanVien (numberPhone, Email, name, address, password)
    VALUES (@numberPhone, @Email, @HoTen, @DiaChi, @password)
END
GO


go
-- tạo procedure thêm dữ liệu vào MyVoucher
CREATE PROCEDURE InsertToMyVoucher
    @numberPhone VARCHAR(15),
    @maVoucher INT
AS
BEGIN
    IF EXISTS(SELECT * FROM MyVoucher WHERE numberPhone = @numberPhone AND MaVoucher = @maVoucher)
    BEGIN
        UPDATE MyVoucher SET SoLuong = SoLuong + 1 WHERE numberPhone = @numberPhone AND MaVoucher = @maVoucher;
    END
    ELSE
    BEGIN
        INSERT INTO MyVoucher(numberPhone, MaVoucher) VALUES(@numberPhone, @maVoucher);
    END
END
go



-- procedure liet ke voucher theo ma user
CREATE PROCEDURE listMyVoucher 
    @numberPhone VARCHAR(15)
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
        MV.numberPhone = @numberPhone
END
go

-- procedure insert cart
create PROCEDURE usp_InsertProductIntoCart
    @item_id varchar(255),
    @idUser varchar(255),
    @nameProduct NVARCHAR(100),
    @priceProduct Int,
    @quantity INT
AS
BEGIN
    INSERT INTO cart_item (item_id, cart_id, item_name, item_price, quantity)
    VALUES (@item_id, @idUser, @nameProduct, @priceProduct, @quantity)
END
Go

-- procedure delete cart item
create PROCEDURE usp_DeleteProductIntoCart
    @item_id varchar(255),
	@cart_id varchar(255)
AS
BEGIN
    DELETE FROM cart_item WHERE item_id = @item_id AND cart_id = @cart_id
END
Go

-- procedure update cart item
create PROCEDURE usp_UpdateProductIntoCart
	@quantity varchar(255),
	@cart_id varchar(255),
    @item_id varchar(255)
AS
BEGIN
    UPDATE cart_item SET quantity = @quantity WHERE cart_id = @cart_id and item_id = @item_id
END
Go

-- procedure create cart
create PROCEDURE usp_CreateCart
	@cart_id varchar(255)
AS
BEGIN
    INSERT INTO Cart VALUES (@cart_id);
END
Go

-- procedure check Exitst Cart
create PROCEDURE usp_CheckExistCart
	@cart_id varchar(255)
AS
BEGIN
    SELECT COUNT(idUser) FROM Cart WHERE idUser = @cart_id
END
Go

-- procedure delete Cart
create PROCEDURE usp_DeleteCart
	@cart_id varchar(255)
AS
BEGIN
    DELETE FROM cart_item WHERE cart_id = @cart_id
END
Go

-- procedure Show all products 
create PROCEDURE usp_ShowAllProducts
AS
BEGIN
    SELECT idProduct, nameProduct, amountProduct, priceProduct, imageProduct, typeProduct, shipment, shelflife FROM Product
END
go

-- procedure show products by type 
create PROCEDURE getProductsByType
	@typeProduct varchar(255)
AS
BEGIN
    SELECT nameProduct, priceProduct, imageProduct, typeProduct FROM Product WHERE typeProduct = @typeProduct
END
go

-- procedure show products by name 
create PROCEDURE getProductsByName
	@nameProduct nvarchar(255)
AS
BEGIN
    SELECT * FROM Product WHERE nameProduct = @nameProduct
END
go

-- procedure Show all voucher 
create PROCEDURE showAllVouchers
AS
BEGIN
    SELECT MaVoucher, TenVoucher, GiaVoucher, HinhAnh FROM Voucher
END
go

-- procedure show vouchers by name 
create PROCEDURE getVouchersByName
	@TenVoucher varchar(255)
AS
BEGIN
    SELECT * FROM Voucher WHERE TenVoucher = @TenVoucher
END
go

-- procedure Delete MyVoucher 
create PROCEDURE deleteMyVoucher
	@numberPhone varchar(255),
	@MaVoucher varchar(255)
AS
BEGIN
	delete from MyVoucher where numberPhone = @numberPhone and MaVoucher = @MaVoucher
END
go

-- procedure add history order 
create PROCEDURE insertOrderHistory
	@idUser varchar(255), 
	@price int, 
	@amount int, 
	@paymethod nvarchar(255), 
	@status nvarchar(255), 
	@paydate date
AS
BEGIN
	INSERT INTO OrderHistory (idUser, price, amount, paymethod, status, paydate) VALUES ( @idUser , @price , @amount , @paymethod , @status , @paydate )
END
go

-- procedure show all history order 
create PROCEDURE showAllHistoryOrder
	@idUser varchar(255)
AS
BEGIN
	SELECT id as 'ID', price as 'Giá', amount as 'Số lượng', paymethod as 'Phương thức thanh toán', status as 'Trạng thái', paydate as 'Ngày thanh toán' FROM OrderHistory WHERE idUser = @idUser
END
go

-- procedure show all history order 
create PROCEDURE showAllHistoryOrderNoUser
AS
BEGIN
	SELECT id as 'ID', price as 'Giá', amount as 'Số lượng', paymethod as 'Phương thức thanh toán', status as 'Trạng thái', paydate as 'Ngày thanh toán' FROM OrderHistory 
END
go

-- procedure get most recent 
create PROCEDURE getRecentOrder
AS
BEGIN
	SELECT TOP 5 id as 'ID', price as 'Giá', amount as 'Số lượng', paymethod as 'Phương thức thanh toán', status as 'Trạng thái', paydate as 'Ngày thanh toán' FROM OrderHistory ORDER BY paydate
END
go

-- procedure Insert product 
create PROCEDURE insertProduct
@nameProduct nvarchar(255), 
@amountProduct int, 
@priceProduct int, 
@imageProduct nvarchar(255), 
@typeProduct varchar(255), 
@shipment varchar(255), 
@shelflife date
AS
BEGIN
	INSERT INTO Product (nameProduct, amountProduct, priceProduct, imageProduct, typeProduct, shipment, shelflife) VALUES ( @nameProduct , @amountProduct , @priceProduct , @imageProduct , @typeProduct , @shipment , @shelflife)
END
go

-- procedure Delete product 
create PROCEDURE deleteProduct
@idProduct varchar(255)
AS
BEGIN
	DELETE FROM Product WHERE idProduct = @idProduct
END
go

-- procedure Update product 
create PROCEDURE updateProduct
@nameProduct varchar(255), 
@priceProduct int, 
@imageProduct varchar(255), 
@typeProduct varchar(255),
@idProduct varchar(255)
AS
BEGIN
	UPDATE Product SET nameProduct = @nameProduct , priceProduct = @priceProduct , imageProduct = @imageProduct , typeProduct = @typeProduct WHERE idProduct = @idProduct
END
go

-- procedure Check exists Product 
create PROCEDURE checkExistsProduct
@nameProduct varchar(255), 
@priceProduct int, 
@imageProduct varchar(255), 
@typeProduct varchar(255)
AS
BEGIN
	SELECT count(idProduct) FROM Product WHERE nameProduct = @nameProduct and priceProduct = @priceProduct and imageProduct = @imageProduct and typeProduct = @typeProduct
END
go

-- procedure show all info of user 
create PROCEDURE showAllUser
AS
BEGIN
	SELECT numberPhone, Email, name, address, DiemTichLuy FROM NhanVien
END
go

-- procedure create account for user 
create PROCEDURE registerAccount
@Phone varchar(255), @Email varchar(255), @Name varchar(255), @Address varchar(255), @Password varchar(255)
AS
BEGIN
	INSERT INTO NhanVien (numberPhone, Email, name, address, password) VALUES ( @Phone , @Email , @Name , @Address , @Password )
END
go

-- procedure update account for user 
create PROCEDURE updateAccount
@Phone varchar(255), @Email varchar(255), @Name varchar(255), @Address varchar(255), @Password varchar(255), @numberPhone varchar(255)
AS
BEGIN
	UPDATE NhanVien SET numberPhone = @numberPhone , Email = @Email , name = @name , address = @address , password = @password where numberPhone = @numberPhone
END
go

-- procedure delete account for user 
create PROCEDURE deleteAccount
	@numberPhone varchar(255)
AS
BEGIN
	DELETE FROM NhanVien WHERE numberPhone = @numberPhone
END
go

-- procedure Login Account User 
create PROCEDURE loginAccount
	@numberPhone varchar(255)
AS
BEGIN
	SELECT numberPhone, Email, name, address, DiemTichLuy FROM NhanVien WHERE numberPhone = @numberPhone
END
go

-- procedure Check account exist 
create PROCEDURE checkAccount
	@numberPhone varchar(255)
AS
BEGIN
	SELECT COUNT(numberPhone) AS 'Tontai' FROM NhanVien WHERE numberPhone LIKE @numberPhone
END
go

-- procedure update point for user 
create PROCEDURE updatePoint
	@numberPhone varchar(255),
	@DiemTichLuy int
AS
BEGIN
	update NhanVien Set DiemTichLuy = @DiemTichLuy where numberPhone = @numberPhone
END
go

-- procedure Insert Voucher 
create PROCEDURE insertVoucher
	@TenVoucher varchar(255), 
	@GiaVoucher int, 
	@HinhAnh varchar(255)
AS
BEGIN
	INSERT INTO Voucher (TenVoucher, GiaVoucher, HinhAnh) VALUES ( @TenVoucher , @GiaVoucher , @HinhAnh)
END
go

-- procedure Delete Voucher 
create PROCEDURE deleteVoucher
	@mavoucher varchar(255)
AS
BEGIN
	DELETE FROM Voucher WHERE MaVoucher = @mavoucher
END
go

-- procedure Update Voucher 
create PROCEDURE updateVoucher
	@TenVoucher varchar(255), 
	@GiaVoucher int, 
	@HinhAnh varchar(255),
	@mavoucher varchar(255)
AS
BEGIN
	UPDATE Voucher SET TenVoucher = @TenVoucher , GiaVoucher = @GiaVoucher , HinhAnh = @HinhAnh where MaVoucher = @mavoucher
END
go

-- procedure Check exists Voucher 
create PROCEDURE checkExistsVoucher
	@TenVoucher varchar(255), 
	@GiaVoucher int, 
	@HinhAnh varchar(255)
AS
BEGIN
	SELECT count(MaVoucher) FROM Voucher WHERE TenVoucher = @TenVoucher and GiaVoucher = @GiaVoucher and HinhAnh = @HinhAnh
END
go

CREATE PROC showTurnover
AS
BEGIN
	SELECT SUM(price) FROM OrderHistory WHERE MONTH(paydate) = MONTH(CURRENT_TIMESTAMP)
END
GO

-- Thêm dữ liệu vào bảng NhanVien
INSERT INTO NhanVien (numberPhone, Email, name, address, password)
VALUES
('0977756777', 'LeVanC@gmail.com', N'Lê Văn X',  N'Hồ Chí Minh', '11122222'),
('0987654321', 'NguyenVanA@gmail.com', N'Nguyễn Văn A', N'Hà Nội', '123456'),
('0912345678', 'TranThiB@gmail.com', N'Trần Thị B', N'Hải Phòng', 'abcdef'),
('0977777777', 'LeVanC@gmail.com', N'Lê Văn C', N'Hồ Chí Minh', '111222');

--Thêm dữ liệu vào bảng Product

INSERT INTO Product(nameProduct, amountProduct, priceProduct, imageProduct, typeProduct, shipment, shelflife)
VALUES
(N'Bánh Bắp Ngọt Oishi', 10,  14000, 'bno.jpeg', 'DAV', '290','4/28/2023'),
(N'Khoai Tây Chiên Vị Kim Chi OStar ', 10, 17000, 'kco.jpeg', 'DAV', '290','4/28/2023'),
(N'Khoai Tây Chiên Vị Bò Bít Tết Swing', 10, 28000, 'bts.jpeg', 'DAV', '290','4/28/2023'),
(N'Khoai Tây Chiên Vị Rong Biển OStar', 10, 17000, 'rbo.jpeg', 'DAV', '290','4/28/2023'),
(N'Mì Trộn Xúc Xích Trứng Chiên', 10, 34000, 'ccdc.jpeg', 'DA', '290','4/28/2023'),
(N'Mì Hảo Hảo', 10, 5000, 'mhh.jpg', 'DA', '290','4/28/2023'),
(N'Bánh Mì Ốp La 2 Trứng', 10, 19000, 'mtxxt.png', 'DA', '290','4/28/2023'),
(N'Xúc Xích', 10, 20000, 'xx.png', 'DA', '290','4/28/2023'),
(N'Bông Tẩy Trang Jomi', 10, 37000, 'jomi.jpeg', 'DGD', '290','4/28/2023'),
(N'Bật Lửa J3 Bic', 10, 16000, 'j3.jpeg', 'DGD', '290','4/28/2023'),
(N'Sữa tắm nước hoa Romano Classic sạch sảng khoái 650g', 10, 175000, 'romano.jpeg', 'DGD', '290','4/28/2023'),
(N'Nước Súc Miệng Listerine Bạc Hà 250ml', 10, 90000, 'bh.jpeg', 'DGD', '290','4/28/2023'),
(N'Khăn Giấy Ướt Yuniku Lài 90 Miếng', 10, 37000, 'yuni.jpeg', 'DGD', '290','4/28/2023'),
(N'Sữa tươi cà phê', 10, 25000, 'cps.png', 'DU', '290','4/28/2023'),
(N'Trà đào', 10, 30000, 'td.png', 'DU', '290','4/28/2023'),
(N'Cà phê đen đá', 10, 15000, 'cpd.png', 'DU', '290','4/28/2023'),
(N'Trà sữa thái', 10, 18000, 'ol.jpeg', 'DU', '290','4/28/2023'),
(N'Cà phê phin sữa đá', 10, 18000, 'psd.png', 'DU', '290','4/28/2023');


--Thêm dữ liệu vào bảng Voucher
INSERT INTO Voucher(TenVoucher, GiaVoucher, HinhAnh)
VALUES
(N'Giảm 10k cho đơn 0đ', 10000, ''),
(N'Giảm 20k cho đơn 0đ', 20000, ''),
(N'Giảm 30k cho đơn 0đ', 30000, ''),
(N'Giảm 40k cho đơn 0đ', 40000, ''),
(N'Giảm 50k cho đơn 0đ', 50000, '');

INSERT INTO NhanVien (numberPhone, Email, name, address, password, DiemTichLuy)
VALUES
('0387790894', 'lehuynhphat@gmail.com', N'Lê Huỳnh Phát',  N'Bến Tre', '12345678', 1000000);

insert into MyVoucher (numberPhone, MaVoucher) values ('0387790894', 1);

delete from MyVoucher where numberPhone = '0387790894' and MaVoucher = '1';

-- Thực thi stored procedure để kiểm tra đăng nhập
EXECUTE checkLogin '0977756777';

-- Thực thi stored procedure để kiểm tra sự tồn tại của tài khoản
EXECUTE checkExistAccount '0977756777', '11122222';

Execute InsertToMyVoucher '0387790894', '1';

select * from NhanVien
select * from Voucher
select * from MyVoucher
select * from Voucher
select * from Product
select * from Cart
select* from cart_item
select * from OrderHistory

update NhanVien set DiemTichLuy = 1000000000 where numberPhone = '0387790894'
	
exec listMyVoucher '0387790894'
exec showTurnover


exec usp_CheckExistCart '0387790894'

exec updatePoint '0387790894' , 1000000