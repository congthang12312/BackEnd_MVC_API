drop database Project
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
INSERT INTO Category VALUES('f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d','MAC', 'mac', default, default)
 SELECT * FROM Category; 
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
	thumbnail varchar(40) NOT NULL ,
	price int not null,
	category varchar(40) NOT NULL FOREIGN KEY REFERENCES [Category](id),
	sub_category varchar(40) FOREIGN KEY REFERENCES [SubCategory](id),
	quantity int NOT NULL,
	description nvarchar(150) NOT NULL,
	createAt date DEFAULT GETDATE(),
	modifyAt date DEFAULT GETDATE()
 )
 ALTER TABLE [dbo].[Product]
  ADD price FLOAT;
update Product set price=2000000 where name='Macbook Pro 2021'
update Product set price=2000000 where name='Dell Inspirion 5570'

 GO
INSERT INTO [Product]values('193eeff4-925f-4211-84d3-5e3936b6f3f3','Dell Inspirion 5570','dell-inspirion-5570','duong dan anh',20000000,'6607bf03-c946-4009-948f-ce53188ccfb8','5b3b02a4-b676-4255-a816-5c4362333e01', 100, N'Đây là sản phẩm mới thêm', default, default )
GO
INSERT INTO [Product] VALUES('a63130fe-99c0-4e95-8a6f-7c73380ace2d','Macbook Pro 2021','macbook-pro-2021', 'duong dan anh',20000000, 'f14eca32-9e5a-40b0-b16c-ab3d64c0ac6d',null, 100, N'Đây là cái Macbook mới thêm dô.', default, default )

INSERT INTO [Product]VALUES('193eeff4-925f-4211-84d3-5e3936b63f3','Dell Inspirion 60000','dell-inspirion-6000','duong dan anh',20000000,'6607bf03-c946-4009-948f-ce53188ccfb8',null, 100, N'Đây là sản phẩm mới thêm', default, default)
 SELECT * FROM [Product]; 
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
INSERT INTO [User] VALUES('c42dad68-a28c-4bbb-ae6d-4fe30b115e3',N'Admin nè','admin@gmail.com','password123',null, null, 0, default, default)
GO
INSERT INTO [User] VALUES('badbe376-f279-4a5c-84b1-d35e864c2e82',N'Nguyễn Văn A','nguyenvana@gmail.com','password123',null, null, 1, default, default)
GO
INSERT INTO [User] VALUES('e4732768-9837-4553-9811-d2a4544a5f41',N'User đăng nhập google','google@gmail.com',null,'ID_GOOGLE_123', null, 1, default, default)
GO
INSERT INTO [User] VALUES('1fdcc462-6341-49fb-b37f-f613347d0a03',N'User đăng nhập facebook','facebook@gmail.com',null,null, 'ID_FACEBOOK_123', 1, default, default)

DELETE FROM [User] WHERE id = '1fdcc462-6341-49fb-b37f-f613347d0a03'
select * from [User]

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
select * from [History_Buy]
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




