USE [master]
GO
/****** Object:  Database [QLPhongTroChungCu]    Script Date: 9/25/2020 1:29:53 PM ******/
CREATE DATABASE [QLPhongTroChungCu]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLPhongTroChungCu', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLPhongTroChungCu.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'QLPhongTroChungCu_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\QLPhongTroChungCu_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [QLPhongTroChungCu] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLPhongTroChungCu].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLPhongTroChungCu] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [QLPhongTroChungCu] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLPhongTroChungCu] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLPhongTroChungCu] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLPhongTroChungCu] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLPhongTroChungCu] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLPhongTroChungCu] SET  MULTI_USER 
GO
ALTER DATABASE [QLPhongTroChungCu] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLPhongTroChungCu] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLPhongTroChungCu] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLPhongTroChungCu] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [QLPhongTroChungCu]
GO
/****** Object:  Table [dbo].[ChiTietThueChungCu]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietThueChungCu](
	[MaCC] [nchar](10) NOT NULL,
	[MaKH] [nchar](10) NULL,
	[ThoiGianVao] [date] NULL,
	[MaThoiHan] [int] NULL,
	[MaKhuVuc] [nchar](10) NULL,
	[MaDichVu] [int] NULL,
	[GiaPhong] [int] NULL,
 CONSTRAINT [PK_ChiTietThueChungCu] PRIMARY KEY CLUSTERED 
(
	[MaCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietThueTro]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietThueTro](
	[MaTro] [nchar](10) NOT NULL,
	[MaKH] [nchar](10) NULL,
	[ThoiGianVao] [date] NULL,
	[MaThoiHan] [int] NULL,
	[MaKhuVuc] [nchar](10) NULL,
	[MaLoaiDichVu] [int] NULL,
	[GiaPhong] [int] NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_ChiTietThueTro] PRIMARY KEY CLUSTERED 
(
	[MaTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Day]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Day](
	[MaDay] [int] NOT NULL,
	[MaKV] [nchar](10) NULL,
	[TenDay] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[MaDichVu] [int] NOT NULL,
	[TenDichVu] [nvarchar](50) NULL,
	[DonGia] [int] NULL,
	[MaLoaiDV] [nchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDichVu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [nchar](10) NOT NULL,
	[HoTenKH] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SDT] [nchar](10) NULL,
	[CMND] [nchar](20) NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhuVuc]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuVuc](
	[MaKV] [nchar](10) NOT NULL,
	[TenKhuVuc] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SoPhong] [int] NULL,
	[SoDay] [int] NULL,
	[SoTang] [int] NULL,
	[MaTK] [nchar](10) NULL,
	[MaTrangThai] [int] NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_KhuVuc] PRIMARY KEY CLUSTERED 
(
	[MaKV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiDichVu]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiDichVu](
	[MaLoaiDV] [nchar](10) NOT NULL,
	[TenLoaiDV] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiDichVu] PRIMARY KEY CLUSTERED 
(
	[MaLoaiDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NguoiThan]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiThan](
	[MaNT] [nchar](10) NOT NULL,
	[MaKH] [nchar](10) NULL,
	[HoTenNT] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[DiaChi] [nvarchar](max) NULL,
	[SDT] [nchar](10) NULL,
	[CMND] [nchar](20) NULL,
	[GhiChu] [nvarchar](max) NULL,
 CONSTRAINT [PK_NguoiThan] PRIMARY KEY CLUSTERED 
(
	[MaNT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhongChungCu]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongChungCu](
	[MaCC] [nchar](10) NOT NULL,
	[MaKV] [nchar](10) NULL,
	[MaDay] [nchar](10) NULL,
	[MaTang] [nchar](10) NULL,
	[MaTrangThai] [int] NULL,
	[TenPhongCC] [nchar](10) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[MaTTThue] [int] NULL,
 CONSTRAINT [PK_PhongChungCu] PRIMARY KEY CLUSTERED 
(
	[MaCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhongTro]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongTro](
	[MaPhongTro] [nchar](10) NOT NULL,
	[MaKV] [nchar](10) NULL,
	[MaDay] [nchar](10) NULL,
	[MaTang] [nchar](10) NULL,
	[MaTrangThai] [int] NULL,
	[TenPhongTro] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](max) NULL,
	[MaTTThue] [int] NULL,
 CONSTRAINT [PK_PhongTro] PRIMARY KEY CLUSTERED 
(
	[MaPhongTro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTK] [nchar](10) NOT NULL,
	[HoTenTK] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [bit] NULL,
	[SDT] [nchar](10) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[CMND] [nchar](20) NULL,
	[MaQuyen] [bit] NULL,
	[UserName] [nvarchar](50) NULL,
	[PassWord] [nvarchar](50) NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tang]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tang](
	[MaTang] [nchar](10) NOT NULL,
	[MaKV] [nchar](10) NULL,
	[TenTang] [nvarchar](50) NULL,
 CONSTRAINT [PK_Tang] PRIMARY KEY CLUSTERED 
(
	[MaTang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThoiHanThue]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThoiHanThue](
	[MaThoiHan] [int] NULL,
	[TenThoiHan] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrangThai]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThai](
	[MaTrangThai] [int] NOT NULL,
	[TenTrangThai] [nvarchar](50) NULL,
 CONSTRAINT [PK_TrangThai] PRIMARY KEY CLUSTERED 
(
	[MaTrangThai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TrangThaiThue]    Script Date: 9/25/2020 1:29:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrangThaiThue](
	[MaTTThue] [int] NOT NULL,
	[TenTrangThaiThue] [nvarchar](50) NULL,
 CONSTRAINT [PK_TrangThaiThue] PRIMARY KEY CLUSTERED 
(
	[MaTTThue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Day] ([MaDay], [MaKV], [TenDay]) VALUES (2, N'kv1       ', N'Dãy A')
INSERT [dbo].[Day] ([MaDay], [MaKV], [TenDay]) VALUES (4, N'kv2       ', N'Dãy B')
INSERT [dbo].[Day] ([MaDay], [MaKV], [TenDay]) VALUES (5, N'kv1       ', N'Dãy C')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonGia], [MaLoaiDV]) VALUES (1, N'Điện', 3000, N'DV1       ')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonGia], [MaLoaiDV]) VALUES (2, N'Nước', 18000, N'DV1       ')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonGia], [MaLoaiDV]) VALUES (3, N'Wifi', 50000, N'DV1       ')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonGia], [MaLoaiDV]) VALUES (4, N'Giữ Xe', 50000, N'DV1       ')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonGia], [MaLoaiDV]) VALUES (5, N'Rác', 20000, N'DV1       ')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonGia], [MaLoaiDV]) VALUES (6, N'Thiện', 20000, N'DV1       ')
INSERT [dbo].[DichVu] ([MaDichVu], [TenDichVu], [DonGia], [MaLoaiDV]) VALUES (7, N'Phượng', 100000, N'DV1       ')
INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [NgaySinh], [GioiTinh], [DiaChi], [SDT], [CMND], [GhiChu]) VALUES (N'kh1       ', N'Thiện', CAST(0x62230B00 AS Date), 1, N'71', N'0327869533', N'24176433            ', N'')
INSERT [dbo].[KhachHang] ([MaKH], [HoTenKH], [NgaySinh], [GioiTinh], [DiaChi], [SDT], [CMND], [GhiChu]) VALUES (N'kh2       ', N'Phượng', CAST(0x62230B00 AS Date), 0, N'Đồng Nai', N'0123456789', N'0123456             ', N'Péo Ú')
INSERT [dbo].[KhuVuc] ([MaKV], [TenKhuVuc], [DiaChi], [SoPhong], [SoDay], [SoTang], [MaTK], [MaTrangThai], [GhiChu]) VALUES (N'kv1       ', N'Khu Vực 1', N'71 Đường Số 2', 30, 3, 1, N'tk1       ', 1, N'ghichu')
INSERT [dbo].[KhuVuc] ([MaKV], [TenKhuVuc], [DiaChi], [SoPhong], [SoDay], [SoTang], [MaTK], [MaTrangThai], [GhiChu]) VALUES (N'kv2       ', N'Khu Vực 2', N'địa chỉ', 50, 2, 1, N'tk2       ', 3, N'không có ghi chú')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDV], [TenLoaiDV]) VALUES (N'DV1       ', N'VIP')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDV], [TenLoaiDV]) VALUES (N'DV2       ', N'Thường')
INSERT [dbo].[LoaiDichVu] ([MaLoaiDV], [TenLoaiDV]) VALUES (N'DV3       ', N'Thấp')
INSERT [dbo].[TaiKhoan] ([MaTK], [HoTenTK], [NgaySinh], [GioiTinh], [SDT], [DiaChi], [CMND], [MaQuyen], [UserName], [PassWord]) VALUES (N'tk1       ', N'Trần Quang Thiện', CAST(0x8F410B00 AS Date), 1, N'0327869533', N'71 Đường Số 2', N'241764433           ', 1, N'tqthien', N'123')
INSERT [dbo].[TaiKhoan] ([MaTK], [HoTenTK], [NgaySinh], [GioiTinh], [SDT], [DiaChi], [CMND], [MaQuyen], [UserName], [PassWord]) VALUES (N'tk2       ', N'Bích Phượng', CAST(0x8F410B00 AS Date), 0, N'0123456789', N'Đồng Nai', N'1                   ', 0, N'bichphuong', N'123')
INSERT [dbo].[ThoiHanThue] ([MaThoiHan], [TenThoiHan]) VALUES (1, N'1 Năm')
INSERT [dbo].[ThoiHanThue] ([MaThoiHan], [TenThoiHan]) VALUES (2, N'5 Năm')
INSERT [dbo].[ThoiHanThue] ([MaThoiHan], [TenThoiHan]) VALUES (3, N'10 Năm')
INSERT [dbo].[ThoiHanThue] ([MaThoiHan], [TenThoiHan]) VALUES (4, N'Vĩnh Viễn')
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai]) VALUES (1, N'Bảo Trì')
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai]) VALUES (2, N'Nâng Cấp')
INSERT [dbo].[TrangThai] ([MaTrangThai], [TenTrangThai]) VALUES (3, N'Bình Thường')
INSERT [dbo].[TrangThaiThue] ([MaTTThue], [TenTrangThaiThue]) VALUES (1, N'Đã Cho Thuê')
INSERT [dbo].[TrangThaiThue] ([MaTTThue], [TenTrangThaiThue]) VALUES (2, N'Chưa có người thuê')
USE [master]
GO
ALTER DATABASE [QLPhongTroChungCu] SET  READ_WRITE 
GO
