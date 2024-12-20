USE [master]
GO
/****** Object:  Database [QuanLyDiemSinhVien]    Script Date: 30/11/2024 5:15:07 PM ******/
CREATE DATABASE [QuanLyDiemSinhVien]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyDiemSinhVien', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\QuanLyDiemSinhVien.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyDiemSinhVien_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\QuanLyDiemSinhVien_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyDiemSinhVien].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET QUERY_STORE = ON
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QuanLyDiemSinhVien]
GO
/****** Object:  Table [dbo].[ChuyenNganh]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuyenNganh](
	[MaChuyenNganh] [nvarchar](20) NOT NULL,
	[ChuyenNganh] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_ChuyenNganh] PRIMARY KEY CLUSTERED 
(
	[MaChuyenNganh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DangNhap]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DangNhap](
	[username] [nvarchar](50) NOT NULL,
	[password] [nvarchar](50) NULL,
 CONSTRAINT [PK_DangNhap] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiemDauDiem]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemDauDiem](
	[MaDauDiem] [int] IDENTITY(1,1) NOT NULL,
	[MaMonHoc] [nvarchar](10) NULL,
	[TenDauDiem] [nvarchar](50) NOT NULL,
	[TyLe] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDauDiem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DiemSinhVien]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DiemSinhVien](
	[MaSinhVien] [nvarchar](10) NOT NULL,
	[MaLopHoc] [int] NOT NULL,
	[MaDauDiem] [int] NOT NULL,
	[Diem] [float] NULL,
	[LanThi] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSinhVien] ASC,
	[MaLopHoc] ASC,
	[MaDauDiem] ASC,
	[LanThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DieuKienMonHoc]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DieuKienMonHoc](
	[MaMonHoc] [nvarchar](10) NOT NULL,
	[DiemToiThieu] [float] NULL,
	[DieuKienDiThi] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocKy]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocKy](
	[MaHocKy] [nvarchar](10) NOT NULL,
	[HocKy] [nvarchar](10) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_HocKy] PRIMARY KEY CLUSTERED 
(
	[MaHocKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LopHoc]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LopHoc](
	[MaLopHoc] [int] IDENTITY(1,1) NOT NULL,
	[MaMonHoc] [nvarchar](10) NULL,
	[TenLopHoc] [nvarchar](50) NOT NULL,
	[HocKy] [nvarchar](10) NULL,
	[NamHoc] [int] NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK__LopHoc__FEE0578400EAFA64] PRIMARY KEY CLUSTERED 
(
	[MaLopHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MonHoc]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MonHoc](
	[MaMonHoc] [nvarchar](10) NOT NULL,
	[TenMonHoc] [nvarchar](50) NOT NULL,
	[SoTinChi] [int] NOT NULL,
	[PhanLoai] [nvarchar](20) NULL,
	[TongSoBuoiHoc] [int] NOT NULL,
	[TrangThai] [bit] NULL,
	[MaNhomMon] [nvarchar](10) NULL,
 CONSTRAINT [PK__MonHoc__4127737FFFBF8F51] PRIMARY KEY CLUSTERED 
(
	[MaMonHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomMonHoc]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomMonHoc](
	[MaNhomMon] [nvarchar](10) NOT NULL,
	[TenNhomMon] [nvarchar](50) NULL,
	[TrangThai] [bit] NULL,
 CONSTRAINT [PK_NhomMonHoc_1] PRIMARY KEY CLUSTERED 
(
	[MaNhomMon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien](
	[MaSinhVien] [nvarchar](10) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](15) NULL,
	[ChuyenNganh] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](10) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[KhoaHoc] [nvarchar](10) NULL,
	[CCCD] [nvarchar](20) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSinhVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SinhVien_LopHoc]    Script Date: 30/11/2024 5:15:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SinhVien_LopHoc](
	[MaSinhVien] [nvarchar](10) NOT NULL,
	[MaLopHoc] [int] NOT NULL,
	[SoBuoiHocDaNghi] [int] NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSinhVien] ASC,
	[MaLopHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [ChuyenNganh], [TrangThai]) VALUES (N'CN01', N'CNTT', 1)
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [ChuyenNganh], [TrangThai]) VALUES (N'CN02', N'Kế toán', 1)
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [ChuyenNganh], [TrangThai]) VALUES (N'CN03', N'Kinh tế', 1)
INSERT [dbo].[ChuyenNganh] ([MaChuyenNganh], [ChuyenNganh], [TrangThai]) VALUES (N'CN04', N'Ô Tô', 1)
GO
INSERT [dbo].[DangNhap] ([username], [password]) VALUES (N'admin', N'1')
GO
SET IDENTITY_INSERT [dbo].[DiemDauDiem] ON 

INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (33, N'MH07', N'Điểm Thi', 60)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (34, N'MH06', N'Điểm Thi', 60)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (35, N'MH05', N'Điểm Thi', 60)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (36, N'MH04', N'Điểm Thi', 60)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (37, N'MH03', N'Điểm Thi', 60)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (40, N'MH01', N'Điểm Thi', 60)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (42, N'MH07', N'lab 1', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (43, N'MH07', N'lab 2', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (44, N'MH06', N'quiz 1', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (45, N'MH06', N'quiz 2', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (46, N'MH05', N'assi 1', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (47, N'MH05', N'assi 2', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (48, N'MH04', N'lab 1', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (49, N'MH04', N'lab 2', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (50, N'MH03', N'quiz 1', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (51, N'MH03', N'quiz 2', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (52, N'MH02', N'assiment', 1)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (53, N'MH02', N'lab 1', 20)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (54, N'MH02', N'lab 2', 19)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (55, N'MH01', N'quiz 1', 10)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (56, N'MH01', N'quiz 2', 10)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (57, N'MH01', N'quiz 3', 10)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (58, N'MH01', N'quiz 4', 10)
INSERT [dbo].[DiemDauDiem] ([MaDauDiem], [MaMonHoc], [TenDauDiem], [TyLe]) VALUES (59, N'MH02', N'Điểm Thi', 60)
SET IDENTITY_INSERT [dbo].[DiemDauDiem] OFF
GO
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV001', 15, 40, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV001', 15, 55, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV001', 15, 56, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV001', 15, 57, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV001', 15, 58, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV002', 15, 40, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV002', 15, 55, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV002', 15, 56, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV002', 15, 57, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV002', 15, 58, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV003', 15, 40, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV003', 15, 55, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV003', 15, 56, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV003', 15, 57, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV003', 15, 58, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV004', 15, 40, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV004', 15, 55, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV004', 15, 56, 5, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV004', 15, 57, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV004', 15, 58, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV005', 15, 40, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV005', 15, 55, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV005', 15, 56, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV005', 15, 57, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV005', 15, 58, 4, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV006', 16, 52, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV006', 16, 53, 4, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV006', 16, 54, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV006', 16, 59, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV007', 16, 52, 5, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV007', 16, 53, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV007', 16, 54, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV007', 16, 59, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV008', 16, 52, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV008', 16, 53, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV008', 16, 54, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV008', 16, 59, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV009', 16, 52, 5, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV009', 16, 53, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV009', 16, 54, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV009', 16, 59, 8, 2)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV010', 16, 52, 4, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV010', 16, 53, 5, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV010', 16, 54, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV010', 16, 59, 7, 2)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV011', 17, 37, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV011', 17, 50, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV011', 17, 51, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV013', 17, 37, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV013', 17, 50, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV013', 17, 51, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV016', 17, 37, 6, 2)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV016', 17, 50, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV016', 17, 51, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV019', 18, 36, 8, 2)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV019', 18, 48, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV019', 18, 49, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV020', 18, 36, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV020', 18, 48, 9, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV020', 18, 49, 7, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV025', 21, 33, 6, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV025', 21, 42, 8, 1)
INSERT [dbo].[DiemSinhVien] ([MaSinhVien], [MaLopHoc], [MaDauDiem], [Diem], [LanThi]) VALUES (N'SV025', 21, 43, 9, 1)
GO
INSERT [dbo].[DieuKienMonHoc] ([MaMonHoc], [DiemToiThieu], [DieuKienDiThi]) VALUES (N'MH01', 5, N'5')
INSERT [dbo].[DieuKienMonHoc] ([MaMonHoc], [DiemToiThieu], [DieuKienDiThi]) VALUES (N'MH02', 4, N'4')
INSERT [dbo].[DieuKienMonHoc] ([MaMonHoc], [DiemToiThieu], [DieuKienDiThi]) VALUES (N'MH03', 5, N'5')
INSERT [dbo].[DieuKienMonHoc] ([MaMonHoc], [DiemToiThieu], [DieuKienDiThi]) VALUES (N'MH04', 4, N'4')
INSERT [dbo].[DieuKienMonHoc] ([MaMonHoc], [DiemToiThieu], [DieuKienDiThi]) VALUES (N'MH05', 4, N'4')
INSERT [dbo].[DieuKienMonHoc] ([MaMonHoc], [DiemToiThieu], [DieuKienDiThi]) VALUES (N'MH06', 5, N'5')
INSERT [dbo].[DieuKienMonHoc] ([MaMonHoc], [DiemToiThieu], [DieuKienDiThi]) VALUES (N'MH07', 5, N'5')
GO
INSERT [dbo].[HocKy] ([MaHocKy], [HocKy], [TrangThai]) VALUES (N'HK01', N'Học Kỳ 1', 1)
INSERT [dbo].[HocKy] ([MaHocKy], [HocKy], [TrangThai]) VALUES (N'HK02', N'Học Kỳ 2', 1)
INSERT [dbo].[HocKy] ([MaHocKy], [HocKy], [TrangThai]) VALUES (N'HK03', N'Học Kỳ Phụ', 1)
GO
SET IDENTITY_INSERT [dbo].[LopHoc] ON 

INSERT [dbo].[LopHoc] ([MaLopHoc], [MaMonHoc], [TenLopHoc], [HocKy], [NamHoc], [TrangThai]) VALUES (15, N'MH01', N'Lớp 1A', N'Học Kỳ 1', 2024, 1)
INSERT [dbo].[LopHoc] ([MaLopHoc], [MaMonHoc], [TenLopHoc], [HocKy], [NamHoc], [TrangThai]) VALUES (16, N'MH02', N'Lớp 1B', N'Học Kỳ 1', 2024, 1)
INSERT [dbo].[LopHoc] ([MaLopHoc], [MaMonHoc], [TenLopHoc], [HocKy], [NamHoc], [TrangThai]) VALUES (17, N'MH03', N'Lớp 1C', N'Học Kỳ 2', 2024, 1)
INSERT [dbo].[LopHoc] ([MaLopHoc], [MaMonHoc], [TenLopHoc], [HocKy], [NamHoc], [TrangThai]) VALUES (18, N'MH04', N'Lớp 1D', N'Học Kỳ 2', 2024, 1)
INSERT [dbo].[LopHoc] ([MaLopHoc], [MaMonHoc], [TenLopHoc], [HocKy], [NamHoc], [TrangThai]) VALUES (19, N'MH05', N'Lớp 1E', N'Học Kỳ 1', 2024, 1)
INSERT [dbo].[LopHoc] ([MaLopHoc], [MaMonHoc], [TenLopHoc], [HocKy], [NamHoc], [TrangThai]) VALUES (20, N'MH06', N'Lớp 1G', N'Học Kỳ 2', 2024, 1)
INSERT [dbo].[LopHoc] ([MaLopHoc], [MaMonHoc], [TenLopHoc], [HocKy], [NamHoc], [TrangThai]) VALUES (21, N'MH07', N'Lớp 1H', N'Học Kỳ Phụ', 2024, 1)
SET IDENTITY_INSERT [dbo].[LopHoc] OFF
GO
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTinChi], [PhanLoai], [TongSoBuoiHoc], [TrangThai], [MaNhomMon]) VALUES (N'MH01', N'Điện Tử số', 4, N'Truyền Thống', 15, 1, N'NMH02')
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTinChi], [PhanLoai], [TongSoBuoiHoc], [TrangThai], [MaNhomMon]) VALUES (N'MH02', N'Thực Hành .Net', 4, N'Blended', 15, 1, N'NMH02')
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTinChi], [PhanLoai], [TongSoBuoiHoc], [TrangThai], [MaNhomMon]) VALUES (N'MH03', N'Tư tưởng HCM', 2, N'Blended', 13, 1, N'NMH01')
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTinChi], [PhanLoai], [TongSoBuoiHoc], [TrangThai], [MaNhomMon]) VALUES (N'MH04', N'Lý luận văn học', 2, N'Online', 13, 1, N'NMH01')
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTinChi], [PhanLoai], [TongSoBuoiHoc], [TrangThai], [MaNhomMon]) VALUES (N'MH05', N'Lập trình Androi', 4, N'ORIT', 13, 1, N'NMH01')
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTinChi], [PhanLoai], [TongSoBuoiHoc], [TrangThai], [MaNhomMon]) VALUES (N'MH06', N'SQL sever', 4, N'Truyền Thống', 13, 1, N'NMH01')
INSERT [dbo].[MonHoc] ([MaMonHoc], [TenMonHoc], [SoTinChi], [PhanLoai], [TongSoBuoiHoc], [TrangThai], [MaNhomMon]) VALUES (N'MH07', N'Kinh tế số', 4, N'Blended', 13, 1, N'NMH02')
GO
INSERT [dbo].[NhomMonHoc] ([MaNhomMon], [TenNhomMon], [TrangThai]) VALUES (N'NMH01', N'Nhóm Môn Học Kinh Tế', 1)
INSERT [dbo].[NhomMonHoc] ([MaNhomMon], [TenNhomMon], [TrangThai]) VALUES (N'NMH02', N'Nhóm Môn Học Kỹ Thuật', 1)
GO
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV001', N'Anh Bao', N'anhbao@example.com', N'0123456789', N'CNTT', N'Nam', CAST(N'2001-01-15' AS Date), N'123 Ðường A', N'2020', N'123456789001', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV002', N'Binh Cam', N'binhcam@example.com', N'0123456790', N'Kế toán', N'Nam', CAST(N'2001-02-16' AS Date), N'234 Ðường B', N'2020', N'123456789002', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV003', N'Chau Dao', N'chaudao@example.com', N'0123456791', N'Kinh tế', N'Nữ', CAST(N'2001-03-17' AS Date), N'345 Ðường C', N'2020', N'123456789003', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV004', N'Duc En', N'ducen@example.com', N'0123456792', N'Ô Tô', N'Nam', CAST(N'2001-04-18' AS Date), N'456 Ðường D', N'2020', N'123456789004', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV005', N'Em Phuong', N'emphuong@example.com', N'0123456793', N'CNTT', N'Nữ', CAST(N'2001-05-19' AS Date), N'567 Ðường E', N'2020', N'123456789005', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV006', N'Gia Hoang', N'giahoang@example.com', N'0123456794', N'Kế toán', N'Nam', CAST(N'2001-06-20' AS Date), N'678 Ðường F', N'2020', N'123456789006', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV007', N'Hien Ky', N'hienky@example.com', N'0123456795', N'Kinh tế', N'Nữ', CAST(N'2001-07-21' AS Date), N'789 ÐườngG', N'2020', N'123456789007', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV008', N'Khai Linh', N'khailinh@example.com', N'0123456796', N'Ô Tô', N'Nam', CAST(N'2001-08-22' AS Date), N'890 Ðường H', N'2020', N'123456789008', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV009', N'Lam Minh', N'lamminh@example.com', N'0123456797', N'CNTT', N'Nữ', CAST(N'2001-09-23' AS Date), N'901 Ðường I', N'2020', N'123456789009', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV010', N'Nam Nghi', N'namnghi@example.com', N'0123456798', N'Kế toán', N'Nam', CAST(N'2001-10-24' AS Date), N'012 Ðường J', N'2020', N'123456789010', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV011', N'Oanh Phat', N'oanhphat@example.com', N'0123456799', N'Kinh tế', N'Nữ', CAST(N'2001-11-25' AS Date), N'123 Ðường K', N'2020', N'123456789011', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV012', N'Phuc Quang', N'phucquang@example.com', N'0123456800', N'Ô Tô', N'Nam', CAST(N'2001-12-26' AS Date), N'234 Ðường L', N'2020', N'123456789012', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV013', N'Quoc Sang', N'quocsang@example.com', N'0123456801', N'CNTT', N'Nam', CAST(N'2001-01-27' AS Date), N'345 Ðường M', N'2020', N'123456789013', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV014', N'Son Thanh', N'sonthanh@example.com', N'0123456802', N'Kế toán', N'Nam', CAST(N'2001-02-28' AS Date), N'456 Ðường N', N'2020', N'123456789014', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV015', N'Tuan Uyen', N'tuanuyen@example.com', N'0123456803', N'Kinh tế', N'Nam', CAST(N'2001-03-01' AS Date), N'567 Ðường O', N'2020', N'123456789015', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV016', N'Van Vu', N'vanvu@example.com', N'0123456804', N'Ô Tô', N'Nam', CAST(N'2001-04-02' AS Date), N'678 Ðường P', N'2020', N'123456789016', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV017', N'Xuan Y', N'xuany@example.com', N'0123456805', N'CNTT', N'Nữ', CAST(N'2001-05-03' AS Date), N'789 Ðường Q', N'2020', N'123456789017', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV018', N'Yen Dao', N'yendao@example.com', N'0123456806', N'Kế toán', N'Nữ', CAST(N'2001-06-04' AS Date), N'890 Ðường R', N'2020', N'123456789018', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV019', N'Anh Bao', N'anhbao2@example.com', N'0123456807', N'Kinh tế', N'Nam', CAST(N'2001-07-05' AS Date), N'901 Ðường S', N'2020', N'123456789019', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV020', N'Binh Cam', N'binhcam2@example.com', N'0123456808', N'Ô Tô', N'Nam', CAST(N'2001-08-06' AS Date), N'012 ÐườngT', N'2020', N'123456789020', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV021', N'Chau Dao', N'chaudao2@example.com', N'0123456809', N'CNTT', N'Nữ', CAST(N'2001-09-07' AS Date), N'123 Ðường U', N'2020', N'123456789021', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV022', N'Duc En', N'ducen2@example.com', N'0123456810', N'Kế toán', N'Nam', CAST(N'2001-10-08' AS Date), N'234 Ðường V', N'2020', N'123456789022', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV023', N'Em Phuong', N'emphuong2@example.com', N'0123456811', N'Kinh tế', N'Nữ', CAST(N'2001-11-09' AS Date), N'345 Ðường W', N'2020', N'123456789023', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV024', N'Gia Hoang', N'giahoang2@example.com', N'0123456812', N'Ô Tô', N'Nam', CAST(N'2001-12-10' AS Date), N'456 Ðường X', N'2020', N'123456789024', 1)
INSERT [dbo].[SinhVien] ([MaSinhVien], [HoTen], [Email], [SoDienThoai], [ChuyenNganh], [GioiTinh], [NgaySinh], [DiaChi], [KhoaHoc], [CCCD], [TrangThai]) VALUES (N'SV025', N'Hien Ky', N'hienky2@example.com', N'0123456813', N'CNTT', N'Nữ', CAST(N'2001-01-11' AS Date), N'567 Ðường Y', N'2020', N'123456789025', 1)
GO
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV001', 15, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV002', 15, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV003', 15, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV004', 15, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV005', 15, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV006', 16, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV007', 16, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV008', 16, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV009', 16, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV010', 16, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV011', 17, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV012', 17, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV013', 17, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV014', 17, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV015', 17, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV016', 17, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV017', 18, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV018', 18, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV019', 18, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV020', 18, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV021', 19, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV022', 19, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV023', 20, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV024', 20, 0, 1)
INSERT [dbo].[SinhVien_LopHoc] ([MaSinhVien], [MaLopHoc], [SoBuoiHocDaNghi], [TrangThai]) VALUES (N'SV025', 21, 0, 1)
GO
ALTER TABLE [dbo].[ChuyenNganh] ADD  CONSTRAINT [DF_ChuyenNganh_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[DiemSinhVien] ADD  DEFAULT ((1)) FOR [LanThi]
GO
ALTER TABLE [dbo].[HocKy] ADD  CONSTRAINT [DF_HocKy_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[LopHoc] ADD  CONSTRAINT [DF__LopHoc__TrangTha__4222D4EF]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[MonHoc] ADD  CONSTRAINT [DF__MonHoc__TrangTha__3A81B327]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[NhomMonHoc] ADD  CONSTRAINT [DF_NhomMonHoc_TrangThai]  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[SinhVien] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[SinhVien_LopHoc] ADD  DEFAULT ((0)) FOR [SoBuoiHocDaNghi]
GO
ALTER TABLE [dbo].[SinhVien_LopHoc] ADD  DEFAULT ((1)) FOR [TrangThai]
GO
ALTER TABLE [dbo].[DiemDauDiem]  WITH CHECK ADD  CONSTRAINT [FK__DiemDauDi__MaMon__3D5E1FD2] FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MonHoc] ([MaMonHoc])
GO
ALTER TABLE [dbo].[DiemDauDiem] CHECK CONSTRAINT [FK__DiemDauDi__MaMon__3D5E1FD2]
GO
ALTER TABLE [dbo].[DiemSinhVien]  WITH CHECK ADD FOREIGN KEY([MaDauDiem])
REFERENCES [dbo].[DiemDauDiem] ([MaDauDiem])
GO
ALTER TABLE [dbo].[DiemSinhVien]  WITH CHECK ADD  CONSTRAINT [FK__DiemSinhV__MaLop__4BAC3F29] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[DiemSinhVien] CHECK CONSTRAINT [FK__DiemSinhV__MaLop__4BAC3F29]
GO
ALTER TABLE [dbo].[DiemSinhVien]  WITH CHECK ADD FOREIGN KEY([MaSinhVien])
REFERENCES [dbo].[SinhVien] ([MaSinhVien])
GO
ALTER TABLE [dbo].[DieuKienMonHoc]  WITH CHECK ADD  CONSTRAINT [FK__DieuKienM__MaMon__5165187F] FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MonHoc] ([MaMonHoc])
GO
ALTER TABLE [dbo].[DieuKienMonHoc] CHECK CONSTRAINT [FK__DieuKienM__MaMon__5165187F]
GO
ALTER TABLE [dbo].[LopHoc]  WITH CHECK ADD  CONSTRAINT [FK__LopHoc__MaMonHoc__412EB0B6] FOREIGN KEY([MaMonHoc])
REFERENCES [dbo].[MonHoc] ([MaMonHoc])
GO
ALTER TABLE [dbo].[LopHoc] CHECK CONSTRAINT [FK__LopHoc__MaMonHoc__412EB0B6]
GO
ALTER TABLE [dbo].[MonHoc]  WITH CHECK ADD  CONSTRAINT [FK_MonHoc_NhomMonHoc] FOREIGN KEY([MaNhomMon])
REFERENCES [dbo].[NhomMonHoc] ([MaNhomMon])
GO
ALTER TABLE [dbo].[MonHoc] CHECK CONSTRAINT [FK_MonHoc_NhomMonHoc]
GO
ALTER TABLE [dbo].[SinhVien_LopHoc]  WITH CHECK ADD  CONSTRAINT [FK__SinhVien___MaLop__45F365D3] FOREIGN KEY([MaLopHoc])
REFERENCES [dbo].[LopHoc] ([MaLopHoc])
GO
ALTER TABLE [dbo].[SinhVien_LopHoc] CHECK CONSTRAINT [FK__SinhVien___MaLop__45F365D3]
GO
ALTER TABLE [dbo].[SinhVien_LopHoc]  WITH CHECK ADD FOREIGN KEY([MaSinhVien])
REFERENCES [dbo].[SinhVien] ([MaSinhVien])
GO
ALTER TABLE [dbo].[DiemDauDiem]  WITH CHECK ADD CHECK  (([TyLe]>=(0) AND [TyLe]<=(100)))
GO
ALTER TABLE [dbo].[DiemSinhVien]  WITH CHECK ADD CHECK  (([Diem]>=(0) AND [Diem]<=(10)))
GO
ALTER TABLE [dbo].[DieuKienMonHoc]  WITH CHECK ADD CHECK  (([DiemToiThieu]>=(0) AND [DiemToiThieu]<=(10)))
GO
USE [master]
GO
ALTER DATABASE [QuanLyDiemSinhVien] SET  READ_WRITE 
GO
