
CREATE DATABASE [prueba]

USE [prueba]
CREATE PROCEDURE [dbo].[InsertDetalle]
(
@id nvarchar(15),
	@producto nvarchar(20),
	@cantidad int,
	@preciove money	,
	@subtotal money
)
AS
	SET NOCOUNT OFF;
	
	Declare @co nvarchar(20);
	set @co=(Select top 1 Numeroventa from Encabezado order by Numeroventa desc) 

INSERT INTO Detalle
                  (Id, codigoproducto, Cantidad, PrecioVenta, Subtotal, Idencabezado)
VALUES ((@id),@producto,@cantidad,@preciove,@subtotal,@co)

GO
/****** Object:  StoredProcedure [dbo].[InsertEncabezado]    Script Date: 9/07/2019 18:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertEncabezado]
(
	
	@cliente nvarchar(50),
	@total money,
	@obser nvarchar(100)
)
AS
	SET NOCOUNT OFF;
declare @codi int;
declare @vari int = 1001;	
set @codi =(select COUNT(Numeroventa) from Encabezado);

INSERT INTO Encabezado
                  (Numeroventa, Cliente, Fecha, Total, Observaciones)
VALUES ((@codi+@vari),@cliente,GETDATE(),@total,@obser)
GO
/****** Object:  StoredProcedure [dbo].[InsertProducto]    Script Date: 9/07/2019 18:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[InsertProducto]
(
	@codigo nvarchar(20),
	@descripcion nvarchar(100),
	@precioventa1 money,
	@precioventa2 money,
	@preciocosto money,
	@observaciones nvarchar(100)
)
AS
	SET NOCOUNT OFF;
INSERT INTO Producto
                  (Codigo, Descripcion, Precioventa1, Precioventa2, Preciocosto, Observaciones)
VALUES (@codigo,@descripcion,@precioventa1,@precioventa2,@preciocosto,@observaciones)
GO
/****** Object:  Table [dbo].[Detalle]    Script Date: 9/07/2019 18:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle](
	[Id] [nvarchar](15) NOT NULL,
	[codigoproducto] [nvarchar](20) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioVenta] [money] NOT NULL,
	[Subtotal] [nchar](10) NULL,
	[Idencabezado] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_Detalle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Encabezado]    Script Date: 9/07/2019 18:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Encabezado](
	[Numeroventa] [nvarchar](10) NOT NULL,
	[Cliente] [nvarchar](50) NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Total] [money] NOT NULL,
	[Observaciones] [nvarchar](100) NULL,
 CONSTRAINT [PK_Encabezado] PRIMARY KEY CLUSTERED 
(
	[Numeroventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Producto]    Script Date: 9/07/2019 18:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Codigo] [nvarchar](20) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
	[Precioventa1] [money] NOT NULL,
	[Precioventa2] [money] NULL,
	[Preciocosto] [money] NOT NULL,
	[Observaciones] [nvarchar](100) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Detalle] ([Id], [codigoproducto], [Cantidad], [PrecioVenta], [Subtotal], [Idencabezado]) VALUES (N'1001-1', N'1111', 10, 23.0000, N'    230.00', N'1001')
INSERT [dbo].[Detalle] ([Id], [codigoproducto], [Cantidad], [PrecioVenta], [Subtotal], [Idencabezado]) VALUES (N'1001-2', N'1111', 10, 26.0000, N'    260.00', N'1001')
INSERT [dbo].[Detalle] ([Id], [codigoproducto], [Cantidad], [PrecioVenta], [Subtotal], [Idencabezado]) VALUES (N'1002-1', N'1111', 10, 23.0000, N'    230.00', N'1002')
INSERT [dbo].[Detalle] ([Id], [codigoproducto], [Cantidad], [PrecioVenta], [Subtotal], [Idencabezado]) VALUES (N'1002-2', N'1111', 10, 26.0000, N'    260.00', N'1002')
INSERT [dbo].[Detalle] ([Id], [codigoproducto], [Cantidad], [PrecioVenta], [Subtotal], [Idencabezado]) VALUES (N'1002-3', N'21354', 10, 69.0000, N'    690.00', N'1002')
INSERT [dbo].[Encabezado] ([Numeroventa], [Cliente], [Fecha], [Total], [Observaciones]) VALUES (N'1001', N'', CAST(0xAA85044C AS SmallDateTime), 490.0000, N'')
INSERT [dbo].[Encabezado] ([Numeroventa], [Cliente], [Fecha], [Total], [Observaciones]) VALUES (N'1002', N'edgar', CAST(0xAA85044C AS SmallDateTime), 1180.0000, N'')
INSERT [dbo].[Producto] ([Codigo], [Descripcion], [Precioventa1], [Precioventa2], [Preciocosto], [Observaciones]) VALUES (N'1111', N'hakjska;s', 23.0000, 26.0000, 1111.0000, N'')
INSERT [dbo].[Producto] ([Codigo], [Descripcion], [Precioventa1], [Precioventa2], [Preciocosto], [Observaciones]) VALUES (N'21354', N'opomlkjinmjljk', 69.0000, 25.0000, 21354.0000, N'')
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Encabezado] FOREIGN KEY([Idencabezado])
REFERENCES [dbo].[Encabezado] ([Numeroventa])
GO
ALTER TABLE [dbo].[Detalle] CHECK CONSTRAINT [FK_Detalle_Encabezado]
GO
ALTER TABLE [dbo].[Detalle]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_Producto] FOREIGN KEY([codigoproducto])
REFERENCES [dbo].[Producto] ([Codigo])
GO
ALTER TABLE [dbo].[Detalle] CHECK CONSTRAINT [FK_Detalle_Producto]
GO
USE [master]
GO
ALTER DATABASE [prueba] SET  READ_WRITE 
GO
