﻿USE [master]
GO
/****** Object:  Database [QLBanDT]    Script Date: 11/7/2023 11:00:08 AM ******/
CREATE DATABASE [QLBanDT]

USE [QLBanDT]
GO
/****** Object:  Table [dbo].[Nguoidung]    Script Date: 11/7/2023 11:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nguoidung](
	[MaNguoiDung] [int] IDENTITY(1,1) NOT NULL,
	[Hoten] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Dienthoai] [nchar](10) NULL,
	[Matkhau] [varchar](50) NULL,
	[IDQuyen] [int] NULL,
	[Diachi] [nvarchar](100) NULL,
	[Anhdaidien] [nchar](30) NULL,
 CONSTRAINT [PK_Khachhang] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 11/7/2023 11:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[IDQuyen] [int] NOT NULL,
	[TenQuyen] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tChiTietHDB]    Script Date: 11/7/2023 11:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChiTietHDB](
	[SoHDB] [nvarchar](10) NOT NULL,
	[MaSP] [nvarchar](10) NOT NULL,
	[SLBan] [int] NULL,
	[KhuyenMai] [nvarchar](100) NULL,
 CONSTRAINT [PK_tChiTietHDB] PRIMARY KEY CLUSTERED 
(
	[SoHDB] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tChiTietHDN]    Script Date: 11/7/2023 11:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tChiTietHDN](
	[SoHDN] [nvarchar](10) NOT NULL,
	[MaSP] [nvarchar](10) NOT NULL,
	[SLNhap] [int] NULL,
	[KhuyenMai] [nvarchar](100) NULL,
 CONSTRAINT [PK_tChiTietHDN] PRIMARY KEY CLUSTERED 
(
	[SoHDN] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tHang]    Script Date: 11/7/2023 11:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHang](
	[MaHang] [nvarchar](10) NOT NULL,
	[TenHang] [nvarchar](100) NULL,
 CONSTRAINT [PK_tTheLoai] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tHoaDonBan]    Script Date: 11/7/2023 11:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHoaDonBan](
	[SoHDB] [nvarchar](10) NOT NULL,
	[NgayBan] [datetime] NULL,
	[TongHDB] [money] NULL,
	[MaNguoiDung] [nvarchar](10) NULL,
 CONSTRAINT [PK_tHoaDonBan] PRIMARY KEY CLUSTERED 
(
	[SoHDB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tHoaDonNhap]    Script Date: 11/7/2023 11:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tHoaDonNhap](
	[SoHDN] [nvarchar](10) NOT NULL,
	[NgayNhap] [datetime] NULL,
	[MaNCC] [nvarchar](10) NULL,
	[TongHDN] [money] NULL,
 CONSTRAINT [PK_tHoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[SoHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tNhaCungCap]    Script Date: 11/7/2023 11:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tNhaCungCap](
	[MaNCC] [nvarchar](10) NOT NULL,
	[TenNCC] [nvarchar](200) NULL,
 CONSTRAINT [PK_tNhaCungCap] PRIMARY KEY CLUSTERED 
(
	[MaNCC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tSP]    Script Date: 11/7/2023 11:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tSP](
	[MaSP] [nvarchar](10) NOT NULL,
	[TenSP] [nvarchar](200) NULL,
	[MaTL] [nvarchar](10) NULL,
	[MaHang] [nvarchar](10) NULL,
	[DonGiaNhap] [money] NULL,
	[DonGiaBan] [money] NULL,
	[SoLuong] [int] NULL,
	[Anh] [nvarchar](100) NULL,
 CONSTRAINT [PK_tSach] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tTheLoai]    Script Date: 11/7/2023 11:00:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tTheLoai](
	[MaTL] [nvarchar](10) NOT NULL,
	[TenTL] [nvarchar](100) NULL,
 CONSTRAINT [PK_tNhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaTL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Nguoidung] ON 

INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi], [Anhdaidien]) VALUES (1, N'Dương Thị Hằng', N'sherryvippro@gmail.com', NULL, N'123', 1, NULL, NULL)
INSERT [dbo].[Nguoidung] ([MaNguoiDung], [Hoten], [Email], [Dienthoai], [Matkhau], [IDQuyen], [Diachi], [Anhdaidien]) VALUES (2, N'Chu Thị Hồng Nhung', N'chunhung509@gmail.com', NULL, N'12345678', 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Nguoidung] OFF
GO
INSERT [dbo].[PhanQuyen] ([IDQuyen], [TenQuyen]) VALUES (1, N'Admin')
INSERT [dbo].[PhanQuyen] ([IDQuyen], [TenQuyen]) VALUES (2, N'Khách hàng')
GO
INSERT [dbo].[tChiTietHDB] ([SoHDB], [MaSP], [SLBan], [KhuyenMai]) VALUES (N'HDB01', N'SP0015', 10, N'0')
GO
INSERT [dbo].[tChiTietHDN] ([SoHDN], [MaSP], [SLNhap], [KhuyenMai]) VALUES (N'HD01', N'SP0015', 20, N'0')
INSERT [dbo].[tChiTietHDN] ([SoHDN], [MaSP], [SLNhap], [KhuyenMai]) VALUES (N'HD02', N'SP0015', 10, N'0')
GO
INSERT [dbo].[tHang] ([MaHang], [TenHang]) VALUES (N'HG01', N'Apple')
INSERT [dbo].[tHang] ([MaHang], [TenHang]) VALUES (N'HG02', N'Samsung')
GO
INSERT [dbo].[tHoaDonBan] ([SoHDB], [NgayBan], [TongHDB], [MaNguoiDung]) VALUES (N'HDB01', CAST(N'2023-11-02T00:00:00.000' AS DateTime), 20000000.0000, NULL)
GO
INSERT [dbo].[tHoaDonNhap] ([SoHDN], [NgayNhap], [MaNCC], [TongHDN]) VALUES (N'HD01', CAST(N'2023-10-26T18:37:00.000' AS DateTime), N'NCC01', NULL)
INSERT [dbo].[tHoaDonNhap] ([SoHDN], [NgayNhap], [MaNCC], [TongHDN]) VALUES (N'HD02', CAST(N'2023-10-07T18:42:00.000' AS DateTime), N'NCC01', NULL)
INSERT [dbo].[tHoaDonNhap] ([SoHDN], [NgayNhap], [MaNCC], [TongHDN]) VALUES (N'HD1121592', CAST(N'2023-11-01T23:10:00.000' AS DateTime), N'NCC01', NULL)
INSERT [dbo].[tHoaDonNhap] ([SoHDN], [NgayNhap], [MaNCC], [TongHDN]) VALUES (N'HD1125311', CAST(N'2023-11-02T23:41:00.000' AS DateTime), N'NCC01', NULL)
GO
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC]) VALUES (N'NCC01', N'FPT')
INSERT [dbo].[tNhaCungCap] ([MaNCC], [TenNCC]) VALUES (N'NCC02', N'TGDD')
GO
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP001', N'iPhone 15 Pro Max', N'DT', N'HG01', 20000000.0000, 50000000.0000, 40, N'OIP.jpg')
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP0015', N'iPhone 13 Pro', N'DT', N'HG01', 20000000.0000, 50000000.0000, 45, N'Apple-MLPG3HN-A-SmartPhones-491997700-i-1-1200Wx1200H-300Wx300H.jpg')
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP002', N'iPhone 14 Pro Max', N'DT', N'HG01', 20000000.0000, 50000000.0000, 40, N'50082914_829949.webp')
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP0021', N'Dell Inspiron', N'DT', N'HG01', 20000000.0000, 50000000.0000, 0, NULL)
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP0023', N'iPhone 15 Pro Max', N'DT', N'HG01', 20000000.0000, 50000000.0000, 20, N'OIP.jpg')
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP003', N'iPhone 14 Pro', N'DT', N'HG01', 20000000.0000, 50000000.0000, 45, N'iphone_14_pro_max_1tb_gold_1664203407_6d4dddd0_progressive.jpg')
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP004', N'iPhone 12', N'DT', N'HG01', 20000000.0000, 50000000.0000, 26, N'OIP.jpg')
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP005', N'iPhone 13', N'DT', N'HG01', 20000000.0000, 50000000.0000, 20, N'iphone_14_pro_max_1tb_gold_1664203407_6d4dddd0_progressive.jpg')
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP006', N'iPhone 13 Pro', N'DT', N'HG01', NULL, NULL, NULL, NULL)
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP007', N'iPhone 13 Pro', N'DT', N'HG01', NULL, NULL, 15, N'OIP (1).jpg')
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP008', N'Dell Inspiron', N'TN02', N'HG02', 20000000.0000, 50000000.0000, 7, N'Apple-MLPG3HN-A-SmartPhones-491997700-i-1-1200Wx1200H-300Wx300H.jpg')
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP009', N'Dell Inspiron', N'DT', N'HG01', 20000000.0000, 50000000.0000, 0, NULL)
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP022', NULL, N'DT', N'HG02', NULL, NULL, NULL, N'OIP (1).jpg')
INSERT [dbo].[tSP] ([MaSP], [TenSP], [MaTL], [MaHang], [DonGiaNhap], [DonGiaBan], [SoLuong], [Anh]) VALUES (N'SP024', NULL, N'DT', N'HG01', NULL, NULL, 20, N'Apple-MLPG3HN-A-SmartPhones-491997700-i-1-1200Wx1200H-300Wx300H.jpg')
GO
INSERT [dbo].[tTheLoai] ([MaTL], [TenTL]) VALUES (N'DT', N'Điện thoại')
INSERT [dbo].[tTheLoai] ([MaTL], [TenTL]) VALUES (N'SP01', N'Sạc không dây')
INSERT [dbo].[tTheLoai] ([MaTL], [TenTL]) VALUES (N'SP02', N'Sạc dự phòng')
INSERT [dbo].[tTheLoai] ([MaTL], [TenTL]) VALUES (N'TN01', N'Tai nghe')
INSERT [dbo].[tTheLoai] ([MaTL], [TenTL]) VALUES (N'TN02', N'Tai nghe bluetooth')
GO
ALTER TABLE [dbo].[tChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHDB_tHoaDonBan] FOREIGN KEY([SoHDB])
REFERENCES [dbo].[tHoaDonBan] ([SoHDB])
GO
ALTER TABLE [dbo].[tChiTietHDB] CHECK CONSTRAINT [FK_tChiTietHDB_tHoaDonBan]
GO
ALTER TABLE [dbo].[tChiTietHDB]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHDB_tSP] FOREIGN KEY([MaSP])
REFERENCES [dbo].[tSP] ([MaSP])
GO
ALTER TABLE [dbo].[tChiTietHDB] CHECK CONSTRAINT [FK_tChiTietHDB_tSP]
GO
ALTER TABLE [dbo].[tChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHDN_tHoaDonNhap] FOREIGN KEY([SoHDN])
REFERENCES [dbo].[tHoaDonNhap] ([SoHDN])
GO
ALTER TABLE [dbo].[tChiTietHDN] CHECK CONSTRAINT [FK_tChiTietHDN_tHoaDonNhap]
GO
ALTER TABLE [dbo].[tChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_tChiTietHDN_tSP] FOREIGN KEY([MaSP])
REFERENCES [dbo].[tSP] ([MaSP])
GO
ALTER TABLE [dbo].[tChiTietHDN] CHECK CONSTRAINT [FK_tChiTietHDN_tSP]
GO
ALTER TABLE [dbo].[tHoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_tHoaDonNhap_tNhaCungCap] FOREIGN KEY([MaNCC])
REFERENCES [dbo].[tNhaCungCap] ([MaNCC])
GO
ALTER TABLE [dbo].[tHoaDonNhap] CHECK CONSTRAINT [FK_tHoaDonNhap_tNhaCungCap]
GO
ALTER TABLE [dbo].[tSP]  WITH CHECK ADD  CONSTRAINT [FK_tSP_tHang] FOREIGN KEY([MaHang])
REFERENCES [dbo].[tHang] ([MaHang])
GO
ALTER TABLE [dbo].[tSP] CHECK CONSTRAINT [FK_tSP_tHang]
GO
ALTER TABLE [dbo].[tSP]  WITH CHECK ADD  CONSTRAINT [FK_tSP_tTheLoai] FOREIGN KEY([MaTL])
REFERENCES [dbo].[tTheLoai] ([MaTL])
GO
ALTER TABLE [dbo].[tSP] CHECK CONSTRAINT [FK_tSP_tTheLoai]
GO
USE [master]
GO
ALTER DATABASE [QLBanDT] SET  READ_WRITE 
GO
