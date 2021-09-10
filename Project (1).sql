CREATE DATABASE Project
GO
USE Project
GO

CREATE TABLE [dbo].[Category](
	id varchar(40) PRIMARY KEY NOT NULL,
	name nvarchar(40) NOT NULL,
	slug varchar(40) NOT NULL,
	createAt date DEFAULT GETDATE(),
	modifyAt date DEFAULT GETDATE()
)
GO
INSERT INTO Category VALUES('6607bf03-c946-4009-948f-ce53188ccfb8','DELL', 'dell','12-15-2021', default )
GO
INSERT INTO Category VALUES('6307bf03-c946-4009-948f-ce53188ccfb8','LENOVO', 'lenovo','7-15-2021', default )


GO
INSERT INTO Category VALUES('f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d','MAC', 'mac', default, default)
/* SELECT * FROM Category; */
/* DROP TABLE Category */
/* ======================================== */


CREATE TABLE [dbo].[SubCategory](
	id varchar(40) PRIMARY KEY NOT NULL,
	parent_category varchar(40) NOT NULL FOREIGN KEY REFERENCES CATEGORY(id),
	name nvarchar(40) NOT NULL,
	slug varchar(40) NOT NULL,
	createAt date DEFAULT GETDATE(),
	modifyAt date DEFAULT GETDATE()
	)
GO
INSERT INTO SubCategory VALUES('5b3b02a4-b676-4255-a816-5c4362333e01','6607bf03-c946-4009-948f-ce53188ccfb8','Dell Inspirion', 'dell-inspirion',default, default )
/* SELECT * FROM SubCategory; */
/* ======================================== */

CREATE TABLE [dbo].[Product](
	id varchar(40) PRIMARY KEY NOT NULL,
	name nvarchar(40) NOT NULL,
	slug varchar(40) NOT NULL,
	thumbnail varchar(100) NOT NULL ,
	category varchar(40) NOT NULL FOREIGN KEY REFERENCES [Category](id),
	sub_category varchar(40) FOREIGN KEY REFERENCES [SubCategory](id),
	quantity int NOT NULL,
	description nvarchar(150) NOT NULL,
	createAt date DEFAULT GETDATE(),
	modifyAt date DEFAULT GETDATE(),
 )
 --Them Price và bang Product
 ALTER TABLE [dbo].[Product]
  ADD price FLOAT;
 --Chinh sua đo daai trường thumbnail
 Alter table [dbo].[Product] ALTER Column thumbnail nvarchar(250) not NULL
 
SELECT * FROM PRODUCT

 GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3a0','Dell Inspiron N3501','dell-inspiron-n3501','Style/default/img/images/dell-inspiron-n3501','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell', default, default,20000000 )
 GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f1','Dell G3','dell-g3','Style/default/img/images/dell-g3 .jpg"','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,21000000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f2','Dell Inspiron N7490','dell-inspiron-n7490','Style/default/img/images/dell-inspiron-n7490.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,23000000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f4','Dell-Inspiron-3501','dell-inspiron-3501','Style/default/img/images/dell-inspiron-3501.jpg"','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default ,23500000)
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f5','Dell-Vostro-5402','dell-vostro-5402','Style/default/img/images/dell-vostro-5402.jpg"','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,14000000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f6','Dell-Inspiron-N3593','dell-inspiron-n3593','Style/default/img/images/dell-inspiron-n3593.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,14600000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f7','Dell-Xps-9700','dell-xps-9700','Style/default/img/images/dell-xps-9700.jpg"','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,21300000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f8','Dell-Latitude-3520','dell-latitude-3520','Style/default/img/images/dell-latitude-3520.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,19000000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f9','Dell-Inspiron-5447','dell-inspiron-5447','Style/default/img/images/dell-inspiron-5447.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,18000000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f10','Dell-Inspiron-3580','dell-inspiron-3580','Style/default/img/images/dell-inspiron-3580.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,17460000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f11','Dell-Precision-5750','dell-precision-5750','Style/default/img/images/dell-precision-5750.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,16700000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f12','Dell-Latitude-7490','dell-latitude-7490','Style/default/img/images/dell-latitude-7490.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,15500000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f13','Dell-Vostro-V5502','dell-vostro-v5502','Style/default/img/images/dell-vostro-v5502.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,18760000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f14','Dell-Inspiron-5502','dell-inspiron-5502','Style/default/img/images/dell-inspiron-5502.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default ,16780000)
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f15','Dell-Vostro-V5402','dell-vostro-v5402','Style/default/img/images/dell-vostro-v5402.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,19786397 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f16','Dell-Inspiron-14-5406','Dell-Inspiron-14-5406','Style/default/img/images/Dell-Inspiron-14-5406.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,14500000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f17','Dell-G3500','dell-g3500','Style/default/img/images/dell-g3500.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,23400000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f18','Dell-Xps-13','dell-xps-13','Style/default/img/images/" + dell-xps-13.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,16700000 )
GO
INSERT INTO [Product] VALUES('193eeff4-925f-4211-84d3-5e3936b6f3f19','Dell-Xps-9300','dell-xps-9300','Style/default/img/images/dell-xps-9300.jpg','6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Laptop Dell có đường nét thiết kế mạnh mẽ tạo ấn tượng khi nhìn vào. Vỏ máy được phủ sơn màu trắng tinh tế điểm xuyến logo Dell bằng kim loại sáng bóng nằm ngay trung tâm mặt lưng nổi bật.', default, default,15690000 )
GO

INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d','Macbook-Pro-2020','macbook-pro-2020', 'Style/default/img/images/macbook-pro-2020 jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,32000000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d1','Macbook-Pro-13.','macbook-pro-13', 'Style/default/img/images/macbook-pro-13.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,34000000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d2','Macbook-Pro-M1','macbook-pro-m1', 'Style/default/img/images/macbook-pro-m1.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,29000000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d3','Macbook-Pro-13in-M1','macbook-pro-13in-m1', 'Style/default/img/images/macbook-pro-13in-m1.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,31340000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d4','Macbook-Air-2020','macbook-air-2020', 'Style/default/img/images/macbook-air-2020.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,33490000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d5','Macbook-Air-2018','macbook-air-2018', 'Style/default/img/images/macbook-air-2018.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default ,35800000)
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d6','Macbook-Air-2019','macbook-air-2019', 'Style/default/img/images/macbook-air-2019.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,36000000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d7','Macbook-Air-2017','macbook-air-2017', 'Style/default/img/images/macbook-air-2017.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,36780000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d8','Macbook-Pro-13-2017','macbook-pro-13-2017', 'Style/default/img/images/macbook-pro-13-2017.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,28900000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d9','Macbook-Pro-2018','macbook-pro-2018', 'Style/default/img/images/macbook-pro-2018.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,27890000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d10','MacBook-Pro-2016','MacBook-Pro-2016', 'Style/default/img/images/MacBook-Pro-2016.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,26789999 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d11','Macbook-Pro-2015','macbook-pro-2015', 'Style/default/img/images/macbook-pro-2015.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,25789000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d12','Macbook-Pro-2019','macbook-pro-2019', 'Style/default/img/images/macbook-pro-2019.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,31378000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d13','Macbook-Pro-2014','macbook-pro-2014', 'Style/default/img/images/macbook-pro-2014.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,24000000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d14','Macbook-Pro-2013','macbook-pro-2013', 'Style/default/img/images/macbook-pro-2013.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,34600000 )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d15','Macbook-Air-2013','macbook-air-2013', 'Style/default/img/images/macbook-air-2013.jpg', 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Với thiết kế nhỏ gọn , mỏng , trọng lượng chỉ khoảng 1.1kg, thiết kế cực kì sang trọng, với cấu hình … và hiện đại mang đến hiệu năng chạy…, mượt, hệ thống bảo mật máy cao.', default, default,35799900 )

 GO
INSERT INTO [Product] VALUES('b83eeff4-925f-4211-84d3-5e3936b6f3f3','Lenovo-Legion','lenovo-legion','Style/default/img/images/lenovo-legion.jpg','6307bf03-c946-4009-948f-ce53188ccfb8',null, 100, N'Laptop Lenovo sở hữu kiểu dáng đơn giản, hiện đại, vẻ ngoài thanh lịch, mang đến cho người dùng sự sang trọng đầy tinh tế, có độ mỏng nhẹ nên dễ mang đi mọi nơi.', default, default,21000000 )
 GO
INSERT INTO [Product] VALUES('b83eeff4-925f-4211-84d3-5e3936b6f3f1','Lenovo-Ideapad-3','lenovo-ideapad-3','Style/default/img/images/lenovo-ideapad-3.jpg','6307bf03-c946-4009-948f-ce53188ccfb8',null, 100, N'Laptop Lenovo sở hữu kiểu dáng đơn giản, hiện đại, vẻ ngoài thanh lịch, mang đến cho người dùng sự sang trọng đầy tinh tế, có độ mỏng nhẹ nên dễ mang đi mọi nơi.', default, default,23000000 )
 GO
INSERT INTO [Product] VALUES('b83eeff4-925f-4211-84d3-5e3936b6f3f2','Lenovo-Ideapad-5','lenovo-ideapad-5','Style/default/img/images/lenovo-ideapad-5.jpg','6307bf03-c946-4009-948f-ce53188ccfb8',null, 100, N'Laptop Lenovo sở hữu kiểu dáng đơn giản, hiện đại, vẻ ngoài thanh lịch, mang đến cho người dùng sự sang trọng đầy tinh tế, có độ mỏng nhẹ nên dễ mang đi mọi nơi.', default, default ,22000000)
 GO
INSERT INTO [Product] VALUES('b83eeff4-925f-4211-84d3-5e3936b6f3f4','Lenovo-ThinkPad-X1-Nano','Lenovo-ThinkPad-X1-Nano','Style/default/img/images/Lenovo-ThinkPad-X1-Nano.jpg','6307bf03-c946-4009-948f-ce53188ccfb8',null, 100, N'Laptop Lenovo sở hữu kiểu dáng đơn giản, hiện đại, vẻ ngoài thanh lịch, mang đến cho người dùng sự sang trọng đầy tinh tế, có độ mỏng nhẹ nên dễ mang đi mọi nơi.', default, default,26700000 )
 GO
INSERT INTO [Product] VALUES('b83eeff4-925f-4211-84d3-5e3936b6f3f5','Lenovo_Thinkpad_x13_Gen_1','lenovo_thinkpad_x13_gen_1','Style/default/img/images/lenovo_thinkpad_x13_gen_1.jpg','6307bf03-c946-4009-948f-ce53188ccfb8',null, 100, N'Laptop Lenovo sở hữu kiểu dáng đơn giản, hiện đại, vẻ ngoài thanh lịch, mang đến cho người dùng sự sang trọng đầy tinh tế, có độ mỏng nhẹ nên dễ mang đi mọi nơi.', default, default,22900000 )
 GO
INSERT INTO [Product] VALUES('b83eeff4-925f-4211-84d3-5e3936b6f3f6','Lenovo-Thinkpad-x1-Carbon','lenovo-thinkpad-x1-carbon','Style/default/img/images/lenovo-thinkpad-x1-carbon.jpg','6307bf03-c946-4009-948f-ce53188ccfb8',null, 100, N'Laptop Lenovo sở hữu kiểu dáng đơn giản, hiện đại, vẻ ngoài thanh lịch, mang đến cho người dùng sự sang trọng đầy tinh tế, có độ mỏng nhẹ nên dễ mang đi mọi nơi.', default, default,21340000 )
 GO
INSERT INTO [Product] VALUES('b83eeff4-925f-4211-84d3-5e3936b6f3f7','Lenovo-Yoga','lenovo-yoga','Style/default/img/images/lenovo-yoga.jpg','6307bf03-c946-4009-948f-ce53188ccfb8',null, 100, N'Laptop Lenovo sở hữu kiểu dáng đơn giản, hiện đại, vẻ ngoài thanh lịch, mang đến cho người dùng sự sang trọng đầy tinh tế, có độ mỏng nhẹ nên dễ mang đi mọi nơi.', default, default,22390000 )
 GO
INSERT INTO [Product] VALUES('b83eeff4-925f-4211-84d3-5e3936b6f3f8','Lenovoyoga-C940','lenovoyoga-c940','Style/default/img/images/lenovoyoga-c940.jpg','6307bf03-c946-4009-948f-ce53188ccfb8',null, 100, N'Laptop Lenovo sở hữu kiểu dáng đơn giản, hiện đại, vẻ ngoài thanh lịch, mang đến cho người dùng sự sang trọng đầy tinh tế, có độ mỏng nhẹ nên dễ mang đi mọi nơi.', default, default,22000000 )
 GO
INSERT INTO [Product] VALUES('b83eeff4-925f-4211-84d3-5e3936b6f3f10','Lenovo-Yoga-Duet-7-13iml05-I7','lenovo-yoga-duet-7-13iml05-i7','Style/default/img/images/lenovo-yoga-duet-7-13iml05-i7.jpg','6307bf03-c946-4009-948f-ce53188ccfb8',null, 100, N'Laptop Lenovo sở hữu kiểu dáng đơn giản, hiện đại, vẻ ngoài thanh lịch, mang đến cho người dùng sự sang trọng đầy tinh tế, có độ mỏng nhẹ nên dễ mang đi mọi nơi.', default, default,21340000 )


/* SELECT * FROM [Product]; */
/* ======================================== */

CREATE TABLE [dbo].[User](
	id varchar(40) PRIMARY KEY NOT NULL,
	fullname nvarchar(40) NOT NULL,
	email varchar(40) NOT NULL UNIQUE,
	password varchar(40),
	googleID varchar(40),
	facebookID varchar(40),
	role int NOT NULl,
	createAt date DEFAULT GETDATE(),
	modifyAt date DEFAULT GETDATE()
)
GO

GO
INSERT INTO [User] VALUES('c42dad68-a28c-4bbb-ae6d-4fe630b115e3',N'Admin nè','admin@gmail.com','password123',null, null, 0, default, default)
GO
INSERT INTO [User] VALUES('badbe376-f279-4a5c-84b1-d35e864c2e82',N'Nguyễn Văn A','nguyenvana@gmail.com','password123',null, null, 1, default, default)
GO
INSERT INTO [User] VALUES('e4732768-9837-4553-9811-d2a4544a5f41',N'User đăng nhập google','google@gmail.com',null,'ID_GOOGLE_123', null, 1, default, default)
GO
INSERT INTO [User] VALUES('1fdcc462-6341-49fb-b37f-f613347d0a03',N'User đăng nhập facebook','facebook@gmail.com',null,null, 'ID_FACEBOOK_123', 1, default, default)

/* SELECT * FROM [User] */
/* ======================================== */

CREATE TABLE [dbo].[History_Buy](
	idUser varchar(40) NOT NULL FOREIGN KEY REFERENCES [User](id),
	idProduct varchar(40) NOT NULL FOREIGN KEY REFERENCES Product(id),
	quantity int NOT NULL,
	address nvarchar(150) NOT NULL,
	createAt date DEFAULT GETDATE(),
	modifyAt date DEFAULT GETDATE()
)	
GO
INSERT INTO [History_Buy] VALUES('badbe376-f279-4a5c-84b1-d35e864c2e82','193eeff4-925f-4211-84d3-5e3936b6f3f3', 5 ,N'KTX Khu B, Đại Học Quốc Gia', default, default)
/* SELECT * FROM [History_Buy]; */
/* ======================================== */

CREATE TABLE [dbo].[Favorite](
	idUser varchar(40) NOT NULL FOREIGN KEY REFERENCES [User](id),
	idProduct varchar(40) NOT NULL FOREIGN KEY REFERENCES Product(id) UNIQUE,
	createAt date DEFAULT GETDATE(),
	modifyAt date DEFAULT GETDATE()
)

INSERT INTO [Favorite] VALUES('badbe376-f279-4a5c-84b1-d35e864c2e82','a63130fe-99c0-4e95-8a6f-7c73380ace2d', default, default)
/* SELECT * FROM [Favorite]; */
/* ======================================== */



