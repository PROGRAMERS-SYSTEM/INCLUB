USE [master]
GO

/****** Object:  Database [BD_INCLUB]    Script Date: 21/09/2022 09:21:24 ******/
CREATE DATABASE [BD_INCLUB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BD_INCLUB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BD_INCLUB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BD_INCLUB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BD_INCLUB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BD_INCLUB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BD_INCLUB] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BD_INCLUB] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BD_INCLUB] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BD_INCLUB] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BD_INCLUB] SET ARITHABORT OFF 
GO

ALTER DATABASE [BD_INCLUB] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BD_INCLUB] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BD_INCLUB] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BD_INCLUB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BD_INCLUB] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BD_INCLUB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BD_INCLUB] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BD_INCLUB] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BD_INCLUB] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BD_INCLUB] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BD_INCLUB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BD_INCLUB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BD_INCLUB] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BD_INCLUB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BD_INCLUB] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BD_INCLUB] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BD_INCLUB] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BD_INCLUB] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [BD_INCLUB] SET  MULTI_USER 
GO

ALTER DATABASE [BD_INCLUB] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BD_INCLUB] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BD_INCLUB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BD_INCLUB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BD_INCLUB] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BD_INCLUB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [BD_INCLUB] SET QUERY_STORE = OFF
GO

ALTER DATABASE [BD_INCLUB] SET  READ_WRITE 
GO


CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [varchar](200) NULL,
	[Password] [varchar](200) NULL,	
	[UsrReg] [int] NULL,
	[UsrMod] [int] NULL,
	[DateReg] [datetime] NULL,
	[DateMod] [datetime] NULL,
	[Estado] [bit] NULL
	)
	Go
	
	create procedure usp_Usuario_Get
	(@IdUsuario int)
	as
	begin
	if @IdUsuario>0
	begin
	select * from Usuario with(nolock) where IdUsuario=@IdUsuario
	end
	else
	begin
	select * from Usuario with(nolock)
	end
	end
	go
create procedure usp_Usuario_Insert
	(@Usuario varchar(200)
	,@Password varchar(200)
	,@UsrReg int
	,@IdSalida int output
	)
	as
	begin
	
	insert into Usuario(Usuario,Password,Estado,DateReg,UsrReg) 
	values(@Usuario,@Password,1,GETDATE(),@UsrReg)
	set @IdSalida=@@IDENTITY
	end

	Go
	create procedure usp_Usuario_Delete
	(@IdUsuario int
	)
	as
	begin
	
	Delete from Usuario where IdUsuario=@IdUsuario
	end
	Go
	create procedure usp_Usuario_Update
	(@IdUsuario int
	,@Usuario varchar(200)
	,@Password varchar(200)
	,@UsrMod int
	,@IdSalida int output
	)
	as
	begin
	
	update Usuario
	set Usuario=@Usuario
	,Password=@Password
	,DateMod=GETDATE()
	,UsrMod=@UsrMod
	where IdUsuario=@IdUsuario
	set @IdSalida=@IdUsuario
	end



	GO


	CREATE  TABLE [dbo].[Producto](
	[IdProducto] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](200) NULL,	
	[Precio] [decimal](9,2) NULL,	
	[UsrReg] [int] NULL,
	[UsrMod] [int] NULL,
	[DateReg] [datetime] NULL,
	[DateMod] [datetime] NULL,
	[Estado] [bit] NULL
	)
	Go
	
	create procedure usp_Producto_Get
	(@IdProducto int)
	as
	begin
	if @IdProducto>0
	begin
	select * from Producto with(nolock) where IdProducto=@IdProducto
	end
	else
	begin
	select * from Producto with(nolock)
	end
	end
	go
create procedure usp_Producto_Insert
	(@Descripcion varchar(200)
	,@Precio decimal(9,2)
	,@UsrReg int
	,@IdSalida int output
	)
	as
	begin
	
	insert into Producto(Descripcion,Precio,Estado,DateReg,UsrReg) 
	values(@Descripcion,@Precio,1,GETDATE(),@UsrReg)
	set @IdSalida=@@IDENTITY
	end

	Go
	create procedure usp_Producto_Delete
	(@IdProducto int
	)
	as
	begin
	
	Delete from Producto where IdProducto=@IdProducto
	end
	Go
	create procedure usp_Producto_Update
	(@IdProducto int
	,@Descripcion varchar(200)	
	,@Precio decimal(9,2)
	,@UsrMod int
	,@IdSalida int output
	)
	as
	begin
	
	update Producto
	set Descripcion=@Descripcion	
	,Precio=@Precio
	,DateMod=GETDATE()
	,UsrMod=@UsrMod
	where IdProducto=@IdProducto
	set @IdSalida=@IdProducto
	end

	GO
	
	CREATE TABLE [dbo].[Compra](
	[IdCompra] [int] IDENTITY(1,1) NOT NULL,
	[Boleta] [varchar](200) NULL,	
	[Total] [decimal](9,2) NULL,
	[Numero] [int] NULL,	
	[UsrReg] [int] NULL,
	[UsrMod] [int] NULL,
	[DateReg] [datetime] NULL,
	[DateMod] [datetime] NULL,
	[Estado] [bit] NULL
	)
	Go
	
	create procedure usp_Compra_Get
	(@IdCompra int)
	as
	begin
	if @IdCompra>0
	begin
	select * from Compra with(nolock) where IdCompra=@IdCompra
	end
	else
	begin
	select * from Compra with(nolock)
	end
	end
	go
create procedure usp_Compra_Insert
	(@Boleta varchar(200)
	,@Numero int
	,@Total decimal(9,2)
	,@UsrReg int
	,@IdSalida int output
	)
	as
	begin
	
	insert into Compra(Boleta,Numero,Total,Estado,DateReg,UsrReg) 
	values(@Boleta,@Numero,@Total,1,GETDATE(),@UsrReg)
	set @IdSalida=@@IDENTITY
	end

	Go
	create procedure usp_Compra_Delete
	(@IdCompra int
	)
	as
	begin
	
	Delete from Compra where IdCompra=@IdCompra
	end
	Go
	create procedure usp_Compra_Update
	(@IdCompra int
	,@Boleta varchar(200)	
	,@Numero int
	,@Total decimal(9,2)
	,@UsrMod int
	,@IdSalida int output
	)
	as
	begin
	
	update Compra
	set Boleta=@Boleta
	,Numero=@Numero
	,Total=@Total
	,DateMod=GETDATE()
	,UsrMod=@UsrMod
	where IdCompra=@IdCompra
	set @IdSalida=@IdCompra
	end


	GO




	CREATE  TABLE [dbo].[DetalleCompra](
	[IdDetalleCompra] [int] IDENTITY(1,1) NOT NULL,
	[IdCompra] [int] NULL,	
	[IdProducto] [int] NULL,		
	[UsrReg] [int] NULL,
	[UsrMod] [int] NULL,
	[DateReg] [datetime] NULL,
	[DateMod] [datetime] NULL,
	[Estado] [bit] NULL
	)
	Go
	
	create procedure usp_DetalleCompra_Get
	(@IdCompra int)
	as
	begin
	if @IdCompra>0
	begin
	select DC.*,P.Descripcion,P.Precio from DetalleCompra DC with(nolock)
	left join Producto P on P.IdProducto=DC.IdProducto
	where DC.IdCompra=@IdCompra
	end
	else
	begin
	select DC.*,P.Descripcion,P.Precio from DetalleCompra DC with(nolock)
	left join Producto P on P.IdProducto=DC.IdProducto
	end
	end
	go
create procedure usp_DetalleCompra_Insert
	(@IdCompra int
	,@IdProducto int
	,@UsrReg int
	,@IdSalida int output
	)
	as
	begin
	
	insert into DetalleCompra(IdCompra,IdProducto,Estado,DateReg,UsrReg) 
	values(@IdCompra,@IdProducto,1,GETDATE(),@UsrReg)
	set @IdSalida=@@IDENTITY
	end

	Go
	create procedure usp_DetalleCompra_Delete
	(@IdCompra int
	)
	as
	begin
	
	Delete from DetalleCompra where IdCompra=@IdCompra
	end
	Go

	create procedure usp_Compra_Get_ByUsuario
	(@IdUsuario int)
	as
	begin
	if @IdUsuario>0
	begin
	select * from Compra with(nolock) where UsrReg=@IdUsuario
	end
	else
	begin
	select * from Compra with(nolock)
	end
	end
	GO
	--Datos de Prueba
	Insert into Usuario(Usuario,Password,UsrReg,DateReg,Estado) values('Admin','123456',1,GETDATE(),1)
	Insert into Usuario(Usuario,Password,UsrReg,DateReg,Estado) values('Usuario','123456',1,GETDATE(),1)
	Insert into Usuario(Usuario,Password,UsrReg,DateReg,Estado) values('Compras','123456',1,GETDATE(),1)

	Insert into Producto(Descripcion,Precio,UsrReg,DateReg,Estado) values('Leche',10.5,1,GETDATE(),1)
	Insert into Producto(Descripcion,Precio,UsrReg,DateReg,Estado) values('Mayonesa',3.5,1,GETDATE(),1)
	Insert into Producto(Descripcion,Precio,UsrReg,DateReg,Estado) values('Huevos',13.5,1,GETDATE(),1)

	Insert into Compra(Boleta,Total,Numero,UsrReg,DateReg,Estado) values('B001',14.0,1,1,GETDATE(),1)
	Insert into Compra(Boleta,Total,Numero,UsrReg,DateReg,Estado) values('B002',24.0,2,1,GETDATE(),1)

	Insert into DetalleCompra(IdCompra,IdProducto,UsrReg,DateReg,Estado) values(1,1,1,GETDATE(),1)
	Insert into DetalleCompra(IdCompra,IdProducto,UsrReg,DateReg,Estado) values(1,2,1,GETDATE(),1)

	Insert into DetalleCompra(IdCompra,IdProducto,UsrReg,DateReg,Estado) values(2,1,1,GETDATE(),1)
	Insert into DetalleCompra(IdCompra,IdProducto,UsrReg,DateReg,Estado) values(2,3,1,GETDATE(),1)



