USE [master]
GO
/****** Object:  Database [EjecutorFlujosInsttantt]    Script Date: 29/04/2023 12:01:38 a. m. ******/
CREATE DATABASE [EjecutorFlujosInsttantt]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EjecutorFlujosInsttantt', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\EjecutorFlujosInsttantt.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EjecutorFlujosInsttantt_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\EjecutorFlujosInsttantt_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EjecutorFlujosInsttantt].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET ARITHABORT OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET RECOVERY FULL 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET  MULTI_USER 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'EjecutorFlujosInsttantt', N'ON'
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET QUERY_STORE = OFF
GO
USE [EjecutorFlujosInsttantt]
GO
/****** Object:  Table [dbo].[tblCamposDisponibles]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCamposDisponibles](
	[IdCampoDisponible] [int] IDENTITY(1,1) NOT NULL,
	[CodigoCampoDispo] [varchar](15) NULL,
	[TituloCampo] [varchar](50) NULL,
	[TipoCampo] [varchar](15) NULL,
 CONSTRAINT [PK_tblCamposDisponibles] PRIMARY KEY CLUSTERED 
(
	[IdCampoDisponible] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCamposPasosPreviosRequeridos]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCamposPasosPreviosRequeridos](
	[CodigoPasoPrevioRequerido] [varchar](15) NOT NULL,
	[CodigoCampoPasoPrevioRequerido] [varchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCamposxPaso]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCamposxPaso](
	[CodigoCampoDispo] [varchar](15) NOT NULL,
	[CodigoPaso] [varchar](15) NOT NULL,
	[CodigoFlujo] [varchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblCamposxPasoxFlujoxUsuario]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblCamposxPasoxFlujoxUsuario](
	[IdCampoxPasoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [varchar](15) NOT NULL,
	[CodigoFlujoUsuario] [varchar](15) NOT NULL,
	[CodigoPasoUsuario] [varchar](15) NOT NULL,
	[TipoCampo] [varchar](15) NOT NULL,
	[DataCampo] [varchar](100) NOT NULL,
 CONSTRAINT [PK_tblCamposxPasoxFlujoxUsuario] PRIMARY KEY CLUSTERED 
(
	[IdCampoxPasoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblEstadoPasoUsuario]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblEstadoPasoUsuario](
	[CodigoEstadoPasoUsuario] [varchar](15) NOT NULL,
	[Nombre] [varchar](20) NULL,
 CONSTRAINT [PK_tblEstadoPasoUsuario] PRIMARY KEY CLUSTERED 
(
	[CodigoEstadoPasoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFlujos]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFlujos](
	[IdFlujo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoFlujo] [varchar](15) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Categoria] [varchar](50) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
	[CreadorFlujo] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblFlujos] PRIMARY KEY CLUSTERED 
(
	[IdFlujo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblFlujoUsuarios]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblFlujoUsuarios](
	[IdCodigoFlujoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[FechaVencimiento] [date] NULL,
	[EstadoFlujo] [varchar](15) NOT NULL,
	[CodigoUsuario] [varchar](15) NULL,
	[CodigoFlujoUsuario] [varchar](15) NOT NULL,
 CONSTRAINT [PK_tblFlujoUsuarios_1] PRIMARY KEY CLUSTERED 
(
	[IdCodigoFlujoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPasosFlujo]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPasosFlujo](
	[IdPasosFlujo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoPaso] [varchar](15) NOT NULL,
	[NombrePaso] [varchar](50) NOT NULL,
	[PasosPreviosRequeridos] [varchar](30) NOT NULL,
	[CodigoFlujo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_tblPasosFlujo_1] PRIMARY KEY CLUSTERED 
(
	[IdPasosFlujo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblPasosUsuarios]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblPasosUsuarios](
	[IdPasoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [varchar](15) NOT NULL,
	[CodigoFlujoUsuario] [varchar](15) NOT NULL,
	[CodigoPasoUsuario] [varchar](15) NOT NULL,
	[Estado] [varchar](15) NULL,
 CONSTRAINT [PK_tblPasosUsuarios_1] PRIMARY KEY CLUSTERED 
(
	[IdPasoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTipoCampo]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTipoCampo](
	[TipoCampo] [varchar](15) NOT NULL,
	[Descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tblTipoCampo] PRIMARY KEY CLUSTERED 
(
	[TipoCampo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblUsuarios]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblUsuarios](
	[IdUsuarios] [int] IDENTITY(1,1) NOT NULL,
	[CodigoUsuario] [varchar](15) NOT NULL,
	[NombreUsuario] [varchar](50) NOT NULL,
	[Clave] [varchar](15) NOT NULL,
	[FechaCreacion] [date] NOT NULL,
 CONSTRAINT [PK_tblUsuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuarios] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblValidacionesDisponibles]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblValidacionesDisponibles](
	[IdValidacionDisponible] [int] IDENTITY(1,1) NOT NULL,
	[CodigoValidacionDispo] [varchar](15) NOT NULL,
	[MsgErrorValidacion] [varchar](100) NOT NULL,
	[Tipo] [varchar](30) NOT NULL,
 CONSTRAINT [PK_tblValidacionesDisponibles] PRIMARY KEY CLUSTERED 
(
	[IdValidacionDisponible] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblValidacionesxPasoxCampo]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblValidacionesxPasoxCampo](
	[IdValidacionxCampo] [int] IDENTITY(1,1) NOT NULL,
	[CodigoValidacionxCampo] [varchar](15) NOT NULL,
	[MsgErrorValidacion] [varchar](50) NOT NULL,
	[Tipo] [varchar](30) NOT NULL,
	[CodigoCampoDispo] [varchar](15) NOT NULL,
	[CodigoPaso] [varchar](15) NOT NULL,
	[CodigoFlujo] [varchar](15) NOT NULL,
 CONSTRAINT [PK_tblValidacionesxCampo] PRIMARY KEY CLUSTERED 
(
	[IdValidacionxCampo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblValidacionesxTipoCampo]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblValidacionesxTipoCampo](
	[CodigoValidacionDisponible] [varchar](15) NOT NULL,
	[CodigoTipoCampo] [varchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarCamposDisponibles]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_BuscarCamposDisponibles] 

AS
BEGIN

	SET NOCOUNT ON;

    select  CD.CodigoCampoDispo, CD.TituloCampo, CD.TipoCampo, VTC.CodigoValidacionDisponible, VD.MsgErrorValidacion, VD.Tipo 
	from tblCamposDisponibles AS CD inner join tblValidacionesxTipoCampo AS VTC ON
	VTC.CodigoTipoCampo = CD.TipoCampo inner join tblValidacionesDisponibles AS VD ON
	VD.CodigoValidacionDispo = VTC.CodigoValidacionDisponible ORDER BY CD.CodigoCampoDispo ASC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarFlujo]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_BuscarFlujo] 
	@CodigoFlujo varchar(15)
AS
BEGIN

	SET NOCOUNT ON;

    select F.CodigoFlujo,F.Nombre, F.Categoria, F.FechaCreacion, F.CreadorFlujo, PF.CodigoPaso, PF.NombrePaso, PF.PasosPreviosRequeridos,CP.CodigoCampoDispo,VC.CodigoValidacionxCampo,
	VC.MsgErrorValidacion, VC.Tipo
	from tblFlujos AS F INNER JOIN tblPasosFlujo AS PF ON
	PF.CodigoFlujo = F.CodigoFlujo INNER JOIN tblCamposxPaso AS CP ON
	CP.CodigoPaso = PF.CodigoPaso INNER JOIN tblValidacionesxPasoxCampo AS VC ON
	VC.CodigoCampoDispo = CP.CodigoCampoDispo AND VC.CodigoPaso =CP.CodigoPaso
	where F.CodigoFlujo = @CodigoFlujo ORDER BY PF.CodigoPaso ASC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BuscarPasoFlujoUsuario]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BuscarPasoFlujoUsuario]
	@CodigoUsuario varchar(15),
	@CodigoPasoUsuario varchar(15),
	@CodigoFlujoUsuario varchar(15)
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @query varchar(max);
	DECLARE @aux varchar(15) ='';

	--Se consulta la existencia del paso
	set @query = (select  PU.CodigoPasoUsuario from tblPasosUsuarios AS PU 
	WHERE PU.CodigoUsuario = @CodigoUsuario AND PU.CodigoFlujoUsuario = @CodigoFlujoUsuario AND PU.CodigoPasoUsuario = @CodigoPasoUsuario);

	select @query;

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarCamposUsuario]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_GuardarCamposUsuario]
	@CodigoUsuario varchar(15),
	@CodigoFlujoUsuario varchar(15),
	@CodigoPasoUsuario varchar(15),
	@TipoCampo varchar(15),
	@DataCampo varchar(100)
AS
BEGIN

	SET NOCOUNT ON;

	insert into tblCamposxPasoxFlujoxUsuario(CodigoUsuario,CodigoFlujoUsuario,CodigoPasoUsuario,TipoCampo, DataCampo) 
	values(@CodigoUsuario,@CodigoFlujoUsuario,@CodigoPasoUsuario,@TipoCampo,@DataCampo)
	select @CodigoPasoUsuario

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarConfiguracionCampos]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GuardarConfiguracionCampos]
	@CodigoCampoDispo varchar(15),
	@CodigoPaso varchar(15),
	@CodigoFlujo varchar(15)
AS
BEGIN

	SET NOCOUNT ON;

	insert into tblCamposxPaso(CodigoCampoDispo,CodigoPaso,CodigoFlujo) 
	values(@CodigoCampoDispo,@CodigoPaso,@CodigoFlujo)

	--select @CodFlujo
END

GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarConfiguracionFlujo]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GuardarConfiguracionFlujo]
	@Nombre varchar(50),
	@Categoria varchar(50),
	@FechaCreacion datetime,
	@CreadorFlujo varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @CodFlujo varchar(15) ='';

	--Se consulta el último código de los flujo
	DECLARE @query varchar(max);
	set @query = (select top 1 CodigoFlujo from tblFlujos order by CodigoFlujo desc);


	set @CodFlujo = @query;
	print @CodFlujo;

	IF (@CodFlujo !='')
	  BEGIN

	    --Se extrae el número despúes del 4to caracter, del código del flujo, y se agrega un dígito más
		DECLARE @NumFlujo int;
		SET @NumFlujo = SUBSTRING(@CodFlujo, 5, LEN(@CodFlujo));
		set @NumFlujo = @NumFlujo + 1;
		print @NumFlujo;

		--Se agrega al código del flujo los ceros a la izquierda faltantes
		DECLARE @NumFlujoCompleto VARCHAR(8);
		SET @NumFlujoCompleto = REPLICATE('0', 4 - LEN(RIGHT(@NumFlujo, 4))) + CAST(@NumFlujo AS VARCHAR(4));

		--Se concatena la sila del flujo con el número correspondiente
		set @CodFlujo = 'FLJ-' + @NumFlujoCompleto;
		print @CodFlujo;


	END
	ELSE
	BEGIN

		set @CodFlujo = 'FLJ-0001'

	END

	insert into tblFlujos(CodigoFlujo,Nombre,Categoria,FechaCreacion,CreadorFlujo) 
	values(@CodFlujo,@Nombre,@Categoria,@FechaCreacion,@CreadorFlujo)

	select @CodFlujo
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarConfiguracionPaso]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GuardarConfiguracionPaso]
	@NombrePaso varchar(50),
	@PasosPreviosRequeridos varchar(50),
	@CodigoFlujo varchar(15)
AS
BEGIN

	SET NOCOUNT ON;

	DECLARE @CodPaso varchar(15) ='';

	--Se consulta el último código de los paso
	DECLARE @query varchar(max);
	set @query = (select top 1 CodigoPaso from tblPasosFlujo where CodigoFlujo = @CodigoFlujo order by CodigoPaso desc);


	set @CodPaso = @query;
	print @CodPaso;

	IF (@CodPaso !='')
	  BEGIN

		--Se extrae el número despúes del 4to caracter, del código del paso, y se agrega un dígito más
		DECLARE @NumPaso int;
		SET @NumPaso = SUBSTRING(@CodPaso, 5, LEN(@CodPaso));
		set @NumPaso = @NumPaso + 1;
		print @NumPaso;

		--Se agrega al código del flujo los ceros a la izquierda faltantes
		DECLARE @NumPasoCompleto VARCHAR(8);
		SET @NumPasoCompleto = REPLICATE('0', 4 - LEN(RIGHT(@NumPaso, 4))) + CAST(@NumPaso AS VARCHAR(4));

		--Se concatena la sila del flujo con el número correspondiente
		set @CodPaso = 'STP-' + @NumPasoCompleto;
		print @CodPaso;

	END
	ELSE
	BEGIN

		set @CodPaso = 'STP-0001'

	END


	insert into tblPasosFlujo(CodigoPaso,NombrePaso,PasosPreviosRequeridos,CodigoFlujo) 
	values(@CodPaso,@NombrePaso,@PasosPreviosRequeridos,@CodigoFlujo)

	select @CodPaso
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarConfiguracionValidaciones]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GuardarConfiguracionValidaciones]
	@CodigoValidacionxCampo varchar(15),
	@MsgErrorValidacion varchar(50),
	@Tipo varchar(30),
	@CodigoCampoDispo varchar(15),
	@CodigoPaso  varchar(15),
	@CodigoFlujo varchar(15)
AS
BEGIN

	SET NOCOUNT ON;

	insert into tblValidacionesxPasoxCampo(CodigoValidacionxCampo,MsgErrorValidacion,Tipo,CodigoCampoDispo,CodigoPaso,CodigoFlujo) 
	values(@CodigoValidacionxCampo,@MsgErrorValidacion,@Tipo,@CodigoCampoDispo,@CodigoPaso,@CodigoFlujo)

	--select @CodFlujo
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarFlujoUsuario]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GuardarFlujoUsuario]
	@FechaVencimiento datetime,
	@EstadoFlujo varchar(15),
	@CodigoUsuario varchar(15),
	@CodigoFlujoUsuario varchar(15)
AS
BEGIN

	SET NOCOUNT ON;

	insert into tblFlujoUsuarios(FechaVencimiento,EstadoFlujo,CodigoUsuario,CodigoFlujoUsuario) 
	values(@FechaVencimiento,@EstadoFlujo,@CodigoUsuario,@CodigoFlujoUsuario)
	select @CodigoFlujoUsuario

END
GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarPasosUsuario]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GuardarPasosUsuario]
	@CodigoUsuario varchar(15),
	@CodigoPasoUsuario varchar(15),
	@CodigoFlujoUsuario varchar(15),
	@Estado varchar(15)
AS
BEGIN

	SET NOCOUNT ON;

	insert into tblPasosUsuarios(CodigoUsuario,CodigoPasoUsuario,CodigoFlujoUsuario,Estado) 
	values(@CodigoUsuario,@CodigoPasoUsuario,@CodigoFlujoUsuario,@Estado)
	select @CodigoPasoUsuario
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GuardarUsuario]    Script Date: 29/04/2023 12:01:38 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GuardarUsuario]
	@CodigoUsuario varchar(15),
	@NombreUsuario varchar(50),
	@Clave varchar(15),
	@FechaCreacion datetime
AS
BEGIN

	SET NOCOUNT ON;

	insert into tblUsuarios(CodigoUsuario,NombreUsuario,Clave, FechaCreacion) 
	values(@CodigoUsuario,@NombreUsuario,@Clave,@FechaCreacion)
	select @CodigoUsuario

END
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código Campo Disponible' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblCamposxPaso', @level2type=N'COLUMN',@level2name=N'CodigoCampoDispo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código Flujo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFlujos', @level2type=N'COLUMN',@level2name=N'CodigoFlujo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Nombre Flujo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFlujos', @level2type=N'COLUMN',@level2name=N'Nombre'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fecha Creación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblFlujos', @level2type=N'COLUMN',@level2name=N'FechaCreacion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Codigo Paso' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPasosFlujo', @level2type=N'COLUMN',@level2name=N'CodigoPaso'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Paso Previo Requerido' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblPasosFlujo', @level2type=N'COLUMN',@level2name=N'PasosPreviosRequeridos'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código Validación' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblValidacionesxPasoxCampo', @level2type=N'COLUMN',@level2name=N'CodigoValidacionxCampo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Código Campo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'tblValidacionesxPasoxCampo', @level2type=N'COLUMN',@level2name=N'CodigoCampoDispo'
GO
USE [master]
GO
ALTER DATABASE [EjecutorFlujosInsttantt] SET  READ_WRITE 
GO
