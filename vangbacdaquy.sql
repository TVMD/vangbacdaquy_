﻿USE [master]
GO
/****** Object:  Database [VangBacDaQuy]    Script Date: 10/17/2016 9:06:47 PM ******/
CREATE DATABASE [VangBacDaQuy]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'VangBacDaQuy', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\VangBacDaQuy.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'VangBacDaQuy_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\VangBacDaQuy_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [VangBacDaQuy] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VangBacDaQuy].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VangBacDaQuy] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET ARITHABORT OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [VangBacDaQuy] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [VangBacDaQuy] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VangBacDaQuy] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VangBacDaQuy] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VangBacDaQuy] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [VangBacDaQuy] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VangBacDaQuy] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET RECOVERY FULL 
GO
ALTER DATABASE [VangBacDaQuy] SET  MULTI_USER 
GO
ALTER DATABASE [VangBacDaQuy] SET PAGE_VERIFY NONE  
GO
ALTER DATABASE [VangBacDaQuy] SET DB_CHAINING OFF 
GO
ALTER DATABASE [VangBacDaQuy] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [VangBacDaQuy] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [VangBacDaQuy]
GO
/****** Object:  StoredProcedure [dbo].[CTPhieuMuaSearch]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CTPhieuMuaSearch]
    @SoPhieuMua int,
    @STT INT,
    @SoLuong INT,
    @DonGia DECIMAL,
    @TongTien decimal,
	@MaKieuSP INT,
	@MaLoaiSP INT
AS
SELECT P.*, TenKieuSP,TenLoaiSP,B.MaKieuSP,B.MaLoaiSP
FROM dbo.CTPHIEUMUA P JOIN SANPHAM B ON P.MaSP=B.MaSP
join KIEUSP C on B.MaKieuSP=C.MaKieuSP
JOIN LOAISP D ON B.MaLoaiSP=D.MaLoaiSP
WHERE (@SoPhieuMua IS NULL OR @SoPhieuMua=-1 OR P.SoPhieuMua =@SoPhieuMua)
AND (@STT IS NULL OR @STT=-1 OR P.STT = @STT)
AND (@SoLuong IS NULL OR  @SoLuong=-1 OR P.SoLuong =@SoLuong)
AND (@DonGia IS NULL OR  @DonGia=-1 OR P.DonGia =@DonGia)
AND (@TongTien IS NULL OR @TongTien=-1 OR P.ThanhTien =@TongTien)
AND (@MaKieuSP IS NULL OR  @MaKieuSP=-1 OR B.MaKieuSP =@MaKieuSP)
AND (@MaLoaiSP IS NULL OR  @MaLoaiSP=-1 OR B.MaLoaiSP =@MaLoaiSP)
GO
/****** Object:  StoredProcedure [dbo].[CTPhieuNhapSearch]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CTPhieuNhapSearch]
    @SoPhieuNhap int,
    @SoLuong INT,
    @DonGia DECIMAL,
    @TongTien decimal,
	@MaKieuSP INT,
	@MaLoaiSP INT
AS
SELECT P.*, TenKieuSP,TenLoaiSP,B.MaKieuSP,B.MaLoaiSP
FROM dbo.CTPHIEUNHAP P JOIN SANPHAM B ON P.MaSP=B.MaSP
join KIEUSP C on B.MaKieuSP=C.MaKieuSP
JOIN LOAISP D ON B.MaLoaiSP=D.MaLoaiSP
WHERE (@SoPhieuNhap IS NULL OR @SoPhieuNhap=-1 OR P.SoPhieuNhap =@SoPhieuNhap)
AND (@SoLuong IS NULL OR  @SoLuong=-1 OR P.SLNhap =@SoLuong)
AND (@DonGia IS NULL OR  @DonGia=-1 OR P.DonGia =@DonGia)
AND (@TongTien IS NULL OR @TongTien=-1 OR P.ThanhTien =@TongTien)
AND (@MaKieuSP IS NULL OR  @MaKieuSP=-1 OR B.MaKieuSP =@MaKieuSP)
AND (@MaLoaiSP IS NULL OR  @MaLoaiSP=-1 OR B.MaLoaiSP =@MaLoaiSP)
GO
/****** Object:  StoredProcedure [dbo].[MCT_PhieuBanHanh_Search]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEdure [dbo].[MCT_PhieuBanHanh_Search](
@p_sophieuban int,
@p_masanpham int,
@p_soluongmin int,
@p_soluongmax int,
@p_dongiamin decimal,
@p_dongiamax decimal,
@p_tongtienmin decimal,
@p_tongtienmax decimal
)
as
begin
select *
from CTPHIEUBAN A 
WHERE 1=1
	AND (SoPhieuBan = @p_sophieuban OR  @p_sophieuban IS NULL OR @p_sophieuban = 0)
	AND (A.MaSP = @p_masanpham OR  @p_masanpham IS NULL OR @p_masanpham = 0)
	
	AND (A.SoLuong >= @p_soluongmin OR  @p_soluongmin IS NULL OR @p_soluongmin = 0)
	AND (A.SoLuong <= @p_soluongmax OR  @p_soluongmax IS NULL OR @p_soluongmax = 0)
	
	AND (A.ThanhTien >= @p_tongtienmin OR  @p_tongtienmin IS NULL OR @p_tongtienmin = 0)
	AND (A.ThanhTien <= @p_tongtienmax OR  @p_tongtienmax IS NULL OR @p_tongtienmax = 0)

	AND (A.DonGia >= @p_dongiamin OR  @p_dongiamin IS NULL OR @p_dongiamin = 0)
	AND (A.DonGia <= @p_dongiamax OR  @p_dongiamax IS NULL OR @p_dongiamax = 0)
end
-------------



GO
/****** Object:  StoredProcedure [dbo].[MKhachHang_Search]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEdure [dbo].[MKhachHang_Search](
@p_makhachhang int,
@p_tenkhachhang nvarchar(50),
@p_ngaysinh date,
@p_diahchi nvarchar(100),
@p_sdt nvarchar(15),
@p_quen int,
@p_tsquen int
)
as
begin

if(@p_quen>=@p_tsquen)  --tsquen from thamso table // this is khach quen
select MaKH,TenKH,NgaySinh,DiaChi,SDT,Quen
from KHACHHANG 
WHERE 1=1
	AND (MaKH = @p_makhachhang OR  @p_makhachhang IS NULL OR @p_makhachhang = 0)
	AND (TenKh LIKE '%' + @p_tenkhachhang + '%' OR  @p_tenkhachhang IS NULL OR @p_tenkhachhang = '')
	AND (SDT LIKE '%' + @p_sdt + '%' OR  @p_sdt IS NULL OR @p_sdt = '')
	AND (DiaChi LIKE '%' + @p_diahchi + '%' OR  @p_diahchi IS NULL OR @p_diahchi = '')
	AND (Quen>=@p_tsquen or @p_quen IS NULL)
	AND (@p_ngaysinh = NgaySinh or @p_ngaysinh is NULL or YEAR(@p_ngaysinh)=YEAR(GETDATE()))

if(@p_quen<@p_tsquen) --khach van lai hoac search all
begin
	if(@p_quen<0) ---this is all khachang- 
select MaKH,TenKH,NgaySinh,DiaChi,SDT,Quen
from KHACHHANG 
WHERE 1=1
	AND (MaKH = @p_makhachhang OR  @p_makhachhang IS NULL OR @p_makhachhang = 0)
	AND (TenKh LIKE '%' + @p_tenkhachhang + '%' OR  @p_tenkhachhang IS NULL OR @p_tenkhachhang = '')
	AND (SDT LIKE '%' + @p_sdt + '%' OR  @p_sdt IS NULL OR @p_sdt = '')
	AND (DiaChi LIKE '%' + @p_diahchi + '%' OR  @p_diahchi IS NULL OR @p_diahchi = '')
	AND (@p_ngaysinh = NgaySinh or @p_ngaysinh is NULL or YEAR(@p_ngaysinh)=YEAR(GETDATE()))
	
	if (@p_quen>=0) --this is van lai
select MaKH,TenKH,NgaySinh,DiaChi,SDT,Quen
from KHACHHANG 
WHERE 1=1
	AND (MaKH = @p_makhachhang OR  @p_makhachhang IS NULL OR @p_makhachhang = 0)
	AND (TenKh LIKE '%' + @p_tenkhachhang + '%' OR  @p_tenkhachhang IS NULL OR @p_tenkhachhang = '')
	AND (SDT LIKE '%' + @p_sdt + '%' OR  @p_sdt IS NULL OR @p_sdt = '')
	AND (DiaChi LIKE '%' + @p_diahchi + '%' OR  @p_diahchi IS NULL OR @p_diahchi = '')
	AND (Quen<@p_tsquen or @p_quen IS NULL)
	AND (@p_ngaysinh = NgaySinh or @p_ngaysinh is NULL or YEAR(@p_ngaysinh)=YEAR(GETDATE()))
end
end

GO
/****** Object:  StoredProcedure [dbo].[MPhieuBanHang_Search]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEdure [dbo].[MPhieuBanHang_Search](
@p_sophieu int,
@p_makh int,
@p_tenkh nvarchar(100),
@p_ngayban date,
@p_ngaythanhtoan date,
@p_tongtienmin decimal,
@p_tongtienmax decimal,
@p_sotientramin decimal,
@p_sotientramax decimal
)
as
begin
select A.SoPhieuBan,A.MaKH,B.TenKh,A.NgayBan,A.NgayThanhToan,A.TongTien,A.SoTienTra
from PHIEUBANHANG A 
	 LEFT JOIN KHACHHANG B ON A.MAKH=B.MaKH
WHERE 1=1
	AND (SoPhieuBan = @p_sophieu OR  @p_sophieu IS NULL OR @p_sophieu = 0)
	AND (A.MaKH = @p_makh OR  @p_makh IS NULL OR @p_makh = 0)
	AND (@p_ngayban = A.NgayBan or @p_ngayban is NULL or YEAR(@p_ngayban)=YEAR(GETDATE()))
	AND (@p_ngaythanhtoan = A.NgayThanhToan or @p_ngaythanhtoan is NULL or YEAR(@p_ngaythanhtoan)=YEAR(GETDATE()))
	
	AND (A.SoTienTra >= @p_sotientramin OR  @p_sotientramin IS NULL OR @p_sotientramin = 0)
	AND (A.SoTienTra <= @p_sotientramax OR  @p_sotientramax IS NULL OR @p_sotientramax = 0)
	AND (A.TongTien >= @p_tongtienmin OR  @p_tongtienmin IS NULL OR @p_tongtienmin = 0)
	AND (A.TongTien <= @p_tongtienmax OR  @p_tongtienmax IS NULL OR @p_tongtienmax = 0)

	AND (B.TenKh LIKE '%' + @p_tenkh + '%' OR  @p_tenkh IS NULL OR @p_tenkh = '')
end

------
GO
/****** Object:  StoredProcedure [dbo].[MPhieuNo_Search]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create PROCEdure [dbo].[MPhieuNo_Search](
@p_sophieuno int,
@p_sophieuban int,
@p_tenkhachhang nvarchar(50),
@p_ngayno date,
@p_ngaythanhtoan date,
@p_sotientramin decimal,
@p_sotientramax decimal,
@p_conlaimin decimal,
@p_conlaimax decimal
)
as
begin
select A.SoPhieuNo,A.SoPhieuBan,C.TenKh,A.NgayNo,A.NgayThanhToan,A.SoTienTra,A.SoTienConLai
from PHIEUNO A 
	 LEFT JOIN PHIEUBANHANG B ON A.SoPhieuBan=B.SoPhieuBan
	 LEFT JOIN KHACHHANG C ON B.MaKH=C.MaKH
WHERE 1=1
	AND (A.SoPhieuNo = @p_sophieuno OR  @p_sophieuno IS NULL OR @p_sophieuno = 0)
	AND (A.SoPhieuBan = @p_sophieuban OR  @p_sophieuban IS NULL OR @p_sophieuban = 0)
	AND (@p_ngayno = A.NgayNo or @p_ngayno is NULL or YEAR(@p_ngayno)=YEAR(GETDATE()))
	AND (@p_ngaythanhtoan = A.NgayThanhToan or @p_ngaythanhtoan is NULL or YEAR(@p_ngaythanhtoan)=YEAR(GETDATE()))
	
	AND (A.SoTienTra >= @p_sotientramin OR  @p_sotientramin IS NULL OR @p_sotientramin = 0)
	AND (A.SoTienTra <= @p_sotientramax OR  @p_sotientramax IS NULL OR @p_sotientramax = 0)
	AND (A.SoTienConLai >= @p_conlaimin OR  @p_conlaimin IS NULL OR @p_conlaimin = 0)
	AND (A.SoTienConLai <= @p_conlaimax OR  @p_conlaimax IS NULL OR @p_conlaimax = 0)

	AND (C.TenKh LIKE '%' + @p_tenkhachhang + '%' OR  @p_tenkhachhang IS NULL OR @p_tenkhachhang = '')
end


GO
/****** Object:  StoredProcedure [dbo].[PhieuMuaSearch]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PhieuMuaSearch]
    @SoPhieuMua int,
    @MaKH INT,
    @NgayMua VARCHAR(50),
    @NgayThanhToan varchar(50),
	@DiaChi nvarchar(100),
    @TongTien decimal,
	@TenKH nvarchar(50)
AS
SELECT P.*,TenKh,DiaChi
FROM dbo.PHIEUMUAHANG P JOIN KHACHHANG K
ON P.MaKH=K.MaKH
WHERE (@SoPhieuMua IS NULL OR @SoPhieuMua=-1 OR P.SoPhieuMua =@SoPhieuMua)
AND (@MaKH IS NULL OR @MaKH=-1 OR P.MaKH = @MaKH)
AND (@NgayMua IS NULL OR  @NgayMua='' OR P.NgayMua =@NgayMua)
AND (@NgayThanhToan IS NULL OR  @NgayThanhToan=''OR P.NgayThanhToan =@NgayThanhToan)
AND (@TongTien IS NULL OR @TongTien=-1 OR P.TongTien =@TongTien)
AND(@DiaChi IS NULL OR K.DiaChi like '%'+@DiaChi+'%')
AND(@TenKH IS NULL OR K.TenKh like '%'+@TenKH+'%')
GO
/****** Object:  StoredProcedure [dbo].[PhieuNhapSearch]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PhieuNhapSearch]
    @SoPhieuNhap int,
    @NgayLap varchar(50),
    @TongTien decimal
AS
SELECT P.*
FROM dbo.PHIEUNHAP P
WHERE (@SoPhieuNhap IS NULL OR @SoPhieuNhap=-1 OR P.SoPhieuNhap =@SoPhieuNhap)

AND (@NgayLap IS NULL OR  @NgayLap=''OR P.NgayLap =@NgayLap)
AND (@TongTien IS NULL OR @TongTien=-1 OR P.TongTien =@TongTien)
GO
/****** Object:  StoredProcedure [dbo].[SanPham_Search]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEdure [dbo].[SanPham_Search](
@p_masanpham int,
@p_maloaisp int,
@p_makieusp int,
@p_soluongmin int,
@p_soluongmax int,
@p_dongiamin decimal,
@p_dongiamax decimal,
@p_trongluongmin float,
@p_trongluongmax float
)
as
begin
select *
from SANPHAM A 
WHERE 1=1
	AND (A.MaKieuSP = @p_makieusp OR  @p_makieusp IS NULL OR @p_makieusp = 0)
	AND (A.MaLoaiSP = @p_maloaisp OR  @p_maloaisp IS NULL OR @p_maloaisp = 0)
	AND (A.MaSP = @p_masanpham OR  @p_masanpham IS NULL OR @p_masanpham = 0)
	
	AND (A.SoLuongTon >= @p_soluongmin OR  @p_soluongmin IS NULL OR @p_soluongmin = 0)
	AND (A.SoLuongTon <= @p_soluongmax OR  @p_soluongmax IS NULL OR @p_soluongmax = 0)
	
	AND (A.TrongLuong >= @p_trongluongmin OR  @p_trongluongmin IS NULL OR @p_trongluongmin = 0)
	AND (A.TrongLuong <= @p_trongluongmax OR  @p_trongluongmax IS NULL OR @p_trongluongmax = 0)

	AND (A.DonGiaBan >= @p_dongiamin OR  @p_dongiamin IS NULL OR @p_dongiamin = 0)
	AND (A.DonGiaBan <= @p_dongiamax OR  @p_dongiamax IS NULL OR @p_dongiamax = 0)
end
GO
/****** Object:  Table [dbo].[BAOCAOTONKHO]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BAOCAOTONKHO](
	[MaBaoCao] [int] NOT NULL,
	[NgayLap] [date] NULL,
 CONSTRAINT [PK_BAOCAOTONKHO] PRIMARY KEY CLUSTERED 
(
	[MaBaoCao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTBAOCAO]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTBAOCAO](
	[MaBaoCao] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[TonDau] [int] NULL,
	[SLMua] [int] NULL,
	[SLBan] [int] NULL,
	[TonCuoi] [int] NULL,
 CONSTRAINT [PK_CTBAOCAO] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC,
	[MaBaoCao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTGIACONG]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTGIACONG](
	[SoPhieuGiaCong] [int] NOT NULL,
	[SoPhieuDV] [int] NOT NULL,
	[STT] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [money] NULL,
	[ThanhTien] [money] NULL,
	[MaTho] [int] NOT NULL,
 CONSTRAINT [PK_CTGIACONG] PRIMARY KEY CLUSTERED 
(
	[SoPhieuGiaCong] ASC,
	[STT] ASC,
	[SoPhieuDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTPHIEUBAN]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPHIEUBAN](
	[SoPhieuBan] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [money] NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_CTPHIEUBAN] PRIMARY KEY CLUSTERED 
(
	[SoPhieuBan] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTPHIEUDICHVU]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPHIEUDICHVU](
	[SoPhieuDV] [int] NOT NULL,
	[STT] [int] NOT NULL,
	[MaLoaiDV] [int] NOT NULL,
	[DonGia] [money] NULL,
	[SoLuong] [int] NULL,
	[ThanhTien] [money] NULL,
	[TinhTrang] [int] NULL,
	[NgayGiao] [date] NULL,
 CONSTRAINT [PK_CTPHIEUDICHVU] PRIMARY KEY CLUSTERED 
(
	[SoPhieuDV] ASC,
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTPHIEUMUA]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPHIEUMUA](
	[SoPhieuMua] [int] NOT NULL,
	[STT] [int] NOT NULL,
	[MaSP] [int] NULL,
	[SoLuong] [int] NULL,
	[DonGia] [money] NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_CTPHIEUMUA] PRIMARY KEY CLUSTERED 
(
	[STT] ASC,
	[SoPhieuMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTPHIEUNHAP]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTPHIEUNHAP](
	[SoPhieuNhap] [int] NOT NULL,
	[MaSP] [int] NOT NULL,
	[SLNhap] [int] NULL,
	[DonGia] [money] NULL,
	[ThanhTien] [money] NULL,
 CONSTRAINT [PK_CTPHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[SoPhieuNhap] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DONVITINH]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DONVITINH](
	[MaDonViTinh] [int] IDENTITY(1,1) NOT NULL,
	[TenDonViTinh] [nvarchar](50) NULL,
 CONSTRAINT [PK_DONVITINH] PRIMARY KEY CLUSTERED 
(
	[MaDonViTinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] NOT NULL,
	[TenKh] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [varchar](15) NULL,
	[Quen] [int] NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KIEUSP]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KIEUSP](
	[MaKieuSP] [int] IDENTITY(1,1) NOT NULL,
	[TenKieuSP] [nvarchar](50) NULL,
 CONSTRAINT [PK_KIEUSP] PRIMARY KEY CLUSTERED 
(
	[MaKieuSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAIDICHVU]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIDICHVU](
	[MaLoaiDV] [int] NOT NULL,
	[TenLoaiDV] [nvarchar](50) NULL,
	[DonGia] [money] NULL,
 CONSTRAINT [PK_LOAIDICHVU] PRIMARY KEY CLUSTERED 
(
	[MaLoaiDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAISP]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISP](
	[MaLoaiSP] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSP] [nvarchar](50) NULL,
	[MaDonViTinh] [int] NULL,
	[PhanTramLoiNhuan] [float] NULL,
 CONSTRAINT [PK_LOAISP] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NGUOIDUNG]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NGUOIDUNG](
	[USERNAME] [nvarchar](20) NOT NULL,
	[PASS] [nvarchar](200) NULL,
	[QUYEN] [nvarchar](20) NULL,
 CONSTRAINT [PK__NGUOIDUN__B15BE12F33CD05FA] PRIMARY KEY CLUSTERED 
(
	[USERNAME] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHANQUYEN]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHANQUYEN](
	[QUYEN] [nvarchar](20) NOT NULL,
	[PHIEUMUA] [int] NULL,
	[PHIEUBAN] [int] NULL,
	[QUANLY] [int] NULL,
	[THUKHO] [int] NULL,
	[DICHVU] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[QUYEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUBANHANG]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUBANHANG](
	[SoPhieuBan] [int] NOT NULL,
	[MaKH] [int] NULL,
	[NgayBan] [date] NULL,
	[NgayThanhToan] [date] NULL,
	[TongTien] [money] NULL,
	[SoTienTra] [money] NULL,
 CONSTRAINT [PK_PHIEUBANHANG] PRIMARY KEY CLUSTERED 
(
	[SoPhieuBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUCHI]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUCHI](
	[SoPhieuChi] [int] NOT NULL,
	[NoiDung] [nvarchar](200) NULL,
	[SoTienChi] [money] NULL,
	[NgayChi] [date] NULL,
 CONSTRAINT [PK_PHIEUCHI] PRIMARY KEY CLUSTERED 
(
	[SoPhieuChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUDICHVU]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUDICHVU](
	[SoPhieuDV] [int] NOT NULL,
	[MaKH] [int] NOT NULL,
	[NgayDangKy] [date] NULL,
	[NgayGiao] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[TongTien] [money] NULL,
	[TinhTrang] [int] NULL,
 CONSTRAINT [PK_PHIEUDICHVU] PRIMARY KEY CLUSTERED 
(
	[SoPhieuDV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUGIACONG]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUGIACONG](
	[SoPhieuGiaCong] [int] NOT NULL,
	[NgayLap] [date] NULL,
	[TongTien] [money] NULL,
 CONSTRAINT [PK_PHIEUGIACONG] PRIMARY KEY CLUSTERED 
(
	[SoPhieuGiaCong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUMUAHANG]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUMUAHANG](
	[SoPhieuMua] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NOT NULL,
	[NgayMua] [date] NULL,
	[NgayThanhToan] [date] NULL,
	[TongTien] [money] NULL,
 CONSTRAINT [PK_PHIEUMUAHANG] PRIMARY KEY CLUSTERED 
(
	[SoPhieuMua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUNHAP]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNHAP](
	[SoPhieuNhap] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [date] NULL,
	[TongTien] [money] NULL,
 CONSTRAINT [PK_PHIEUNHAP] PRIMARY KEY CLUSTERED 
(
	[SoPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PHIEUNO]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PHIEUNO](
	[SoPhieuNo] [int] NOT NULL,
	[SoPhieuBan] [int] NULL,
	[NgayNo] [date] NULL,
	[NgayThanhToan] [date] NULL,
	[SoTienTra] [money] NULL,
	[SoTienConLai] [money] NULL,
 CONSTRAINT [PK_PHIEUNO] PRIMARY KEY CLUSTERED 
(
	[SoPhieuNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SANPHAM]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SANPHAM](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[MaLoaiSP] [int] NULL,
	[MaKieuSP] [int] NULL,
	[TrongLuong] [float] NULL,
	[DonGiaBan] [money] NULL,
	[SoLuongTon] [int] NULL,
 CONSTRAINT [PK_SANPHAM] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[THAMSO]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMSO](
	[TEN] [nvarchar](20) NOT NULL,
	[KIEU] [nvarchar](20) NULL,
	[GIATRI] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TEN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[THOGIACONG]    Script Date: 10/17/2016 9:06:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THOGIACONG](
	[MaTho] [int] NOT NULL,
	[TenTho] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](100) NULL,
	[SDT] [nvarchar](15) NULL,
 CONSTRAINT [PK_THOGIACONG] PRIMARY KEY CLUSTERED 
(
	[MaTho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[BAOCAOTONKHO] ([MaBaoCao], [NgayLap]) VALUES (1, CAST(0x803B0B00 AS Date))
INSERT [dbo].[BAOCAOTONKHO] ([MaBaoCao], [NgayLap]) VALUES (2, CAST(0x803B0B00 AS Date))
INSERT [dbo].[BAOCAOTONKHO] ([MaBaoCao], [NgayLap]) VALUES (3, CAST(0x803B0B00 AS Date))
INSERT [dbo].[BAOCAOTONKHO] ([MaBaoCao], [NgayLap]) VALUES (4, CAST(0x803B0B00 AS Date))
INSERT [dbo].[BAOCAOTONKHO] ([MaBaoCao], [NgayLap]) VALUES (5, CAST(0x803B0B00 AS Date))
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (1, 1, 9, 0, 0, 9)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (2, 1, 9, 3, 0, 12)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (3, 1, 9, 3, 0, 12)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (4, 1, 9, 0, 0, 9)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (5, 1, 9, 3, 0, 12)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (1, 2, 0, 0, 0, 0)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (2, 2, 0, 0, 0, 0)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (3, 2, 0, 0, 0, 0)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (4, 2, 0, 0, 0, 0)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (5, 2, 0, 0, 0, 0)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (1, 3, 3, 0, 0, 3)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (2, 3, 3, 3, 0, 6)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (3, 3, 3, 3, 0, 6)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (4, 3, 3, 0, 0, 3)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (5, 3, 3, 3, 0, 6)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (4, 9, 1, 0, 0, 1)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (5, 9, 1, 0, 0, 1)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (4, 10, NULL, 0, 0, NULL)
INSERT [dbo].[CTBAOCAO] ([MaBaoCao], [MaSP], [TonDau], [SLMua], [SLBan], [TonCuoi]) VALUES (5, 10, 1, 0, 0, 1)
INSERT [dbo].[CTGIACONG] ([SoPhieuGiaCong], [SoPhieuDV], [STT], [SoLuong], [DonGia], [ThanhTien], [MaTho]) VALUES (1, 1, 1, 1, 100000.0000, 100000.0000, 1)
INSERT [dbo].[CTGIACONG] ([SoPhieuGiaCong], [SoPhieuDV], [STT], [SoLuong], [DonGia], [ThanhTien], [MaTho]) VALUES (1, 1, 2, 1, 30000.0000, 30000.0000, 1)
INSERT [dbo].[CTGIACONG] ([SoPhieuGiaCong], [SoPhieuDV], [STT], [SoLuong], [DonGia], [ThanhTien], [MaTho]) VALUES (1, 3, 4, 1, 250000.0000, 250000.0000, 1)
INSERT [dbo].[CTGIACONG] ([SoPhieuGiaCong], [SoPhieuDV], [STT], [SoLuong], [DonGia], [ThanhTien], [MaTho]) VALUES (2, 2, 3, 2, 200000.0000, 400000.0000, 3)
INSERT [dbo].[CTGIACONG] ([SoPhieuGiaCong], [SoPhieuDV], [STT], [SoLuong], [DonGia], [ThanhTien], [MaTho]) VALUES (2, 5, 7, 1, 90000.0000, 90000.0000, 2)
INSERT [dbo].[CTGIACONG] ([SoPhieuGiaCong], [SoPhieuDV], [STT], [SoLuong], [DonGia], [ThanhTien], [MaTho]) VALUES (3, 4, 6, 1, 250000.0000, 250000.0000, 5)
INSERT [dbo].[CTGIACONG] ([SoPhieuGiaCong], [SoPhieuDV], [STT], [SoLuong], [DonGia], [ThanhTien], [MaTho]) VALUES (3, 5, 8, 1, 30000.0000, 30000.0000, 5)
INSERT [dbo].[CTGIACONG] ([SoPhieuGiaCong], [SoPhieuDV], [STT], [SoLuong], [DonGia], [ThanhTien], [MaTho]) VALUES (4, 4, 5, 1, 100000.0000, 100000.0000, 4)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 1, 1, 10.0000, 10.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (2, 2, 1, 20.0000, 20.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (2, 14, 2, 4.0000, 8.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (3, 10, 1, 3.0000, 3.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (3, 14, 2, 4.0000, 8.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (4, 1, 2, 10.0000, 20.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (5, 15, 1, 4.0000, 4.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (6, 1, 2, 10.0000, 20.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (6, 2, 2, 20.0000, 40.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (6, 9, 2, 1.0000, 2.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (7, 9, 1, 1.0000, 1.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (8, 15, 1, 4.0000, 4.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (9, 16, 1, 4.0000, 4.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (10, 2, 1, 20.0000, 20.0000)
INSERT [dbo].[CTPHIEUBAN] ([SoPhieuBan], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (11, 1, 1, 10.0000, 10.0000)
INSERT [dbo].[CTPHIEUDICHVU] ([SoPhieuDV], [STT], [MaLoaiDV], [DonGia], [SoLuong], [ThanhTien], [TinhTrang], [NgayGiao]) VALUES (1, 1, 3, 120000.0000, 1, 120000.0000, 1, CAST(0x823B0B00 AS Date))
INSERT [dbo].[CTPHIEUDICHVU] ([SoPhieuDV], [STT], [MaLoaiDV], [DonGia], [SoLuong], [ThanhTien], [TinhTrang], [NgayGiao]) VALUES (1, 2, 2, 50000.0000, 1, 50000.0000, 1, CAST(0x823B0B00 AS Date))
INSERT [dbo].[CTPHIEUDICHVU] ([SoPhieuDV], [STT], [MaLoaiDV], [DonGia], [SoLuong], [ThanhTien], [TinhTrang], [NgayGiao]) VALUES (2, 3, 6, 250000.0000, 2, 500000.0000, 1, CAST(0x823B0B00 AS Date))
INSERT [dbo].[CTPHIEUDICHVU] ([SoPhieuDV], [STT], [MaLoaiDV], [DonGia], [SoLuong], [ThanhTien], [TinhTrang], [NgayGiao]) VALUES (3, 4, 7, 290000.0000, 1, 290000.0000, 1, CAST(0x823B0B00 AS Date))
INSERT [dbo].[CTPHIEUDICHVU] ([SoPhieuDV], [STT], [MaLoaiDV], [DonGia], [SoLuong], [ThanhTien], [TinhTrang], [NgayGiao]) VALUES (4, 5, 9, 130000.0000, 1, 130000.0000, 1, CAST(0x823B0B00 AS Date))
INSERT [dbo].[CTPHIEUDICHVU] ([SoPhieuDV], [STT], [MaLoaiDV], [DonGia], [SoLuong], [ThanhTien], [TinhTrang], [NgayGiao]) VALUES (4, 6, 1, 30000.0000, 1, 30000.0000, 1, CAST(0x823B0B00 AS Date))
INSERT [dbo].[CTPHIEUDICHVU] ([SoPhieuDV], [STT], [MaLoaiDV], [DonGia], [SoLuong], [ThanhTien], [TinhTrang], [NgayGiao]) VALUES (5, 7, 3, 120000.0000, 1, 120000.0000, 1, CAST(0x823B0B00 AS Date))
INSERT [dbo].[CTPHIEUDICHVU] ([SoPhieuDV], [STT], [MaLoaiDV], [DonGia], [SoLuong], [ThanhTien], [TinhTrang], [NgayGiao]) VALUES (5, 8, 2, 50000.0000, 1, 50000.0000, 1, CAST(0x823B0B00 AS Date))
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (11, 1, -1, 2, 1.0000, 2.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (12, 1, 1, 2, 1.0000, 2.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (13, 1, 1, 2, 2.0000, 4.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (14, 1, 3, 2, 1.0000, 2.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (15, 1, 1, 2, 3.0000, 6.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (16, 1, 18, 1, 3.0000, 3.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 2, 1, 1, 1.0000, 1.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (11, 2, 20, 3, 2.0000, 6.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (12, 2, 3, 2, 1.0000, 2.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (11, 3, 1, 3, 2.0000, 6.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 4, 1, 1, 1.0000, 1.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 5, 2, 2, 2.0000, 2.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 6, 3, 3, 3.0000, 3.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 7, 5, 2, 1.0000, 2.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 8, 9, 3, 2.0000, 6.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 9, 1, 3, 2.0000, 6.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (1, 10, 1, 2, 2.0000, 4.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (10, 12, 1, 3, 1.0000, 3.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (10, 13, 9, 2, 3.0000, 6.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (10, 14, 3, 2, 3.0000, 6.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (10, 15, 18, 2, 2.0000, 4.0000)
INSERT [dbo].[CTPHIEUMUA] ([SoPhieuMua], [STT], [MaSP], [SoLuong], [DonGia], [ThanhTien]) VALUES (10, 16, 1, 2, 2.0000, 4.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (6, 1, 3, 2.0000, 6.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (6, 3, 3, 1.0000, 3.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (6, 9, 2, 1.0000, 2.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (7, 1, 1, 2.0000, 2.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (7, 9, 3, 2.0000, 6.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (8, 1, 1, 2.0000, 2.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (8, 9, 1, 2.0000, 2.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (9, 3, 3, 2.0000, 6.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (9, 9, 4, 4.0000, 16.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (10, 21, 3, 2.0000, 6.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (10, 22, 3, 2.0000, 6.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (11, 1, 3, 2.0000, 6.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (11, 3, 2, 2.0000, 4.0000)
INSERT [dbo].[CTPHIEUNHAP] ([SoPhieuNhap], [MaSP], [SLNhap], [DonGia], [ThanhTien]) VALUES (12, 1, 1, 1.0000, 1.0000)
SET IDENTITY_INSERT [dbo].[DONVITINH] ON 

INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh]) VALUES (1, N'Lượng')
INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh]) VALUES (2, N'Cara')
INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh]) VALUES (7, N'Chỉ')
INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh]) VALUES (8, N'Viên')
INSERT [dbo].[DONVITINH] ([MaDonViTinh], [TenDonViTinh]) VALUES (9, N'Hạt')
SET IDENTITY_INSERT [dbo].[DONVITINH] OFF
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (1, N'Lý Tiểu Long', CAST(0x19E40A00 AS Date), N'Mỹ Tho', N'016537786', 5)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (2, N'Trần Mộng Cát', CAST(0xEEF70A00 AS Date), N'Hà Nội', N'0952903076', 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (3, N'Trần Thị Hạnh Phúc', CAST(0x811E0B00 AS Date), N'Kiến Đức', N'0165646412326', 3)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (4, N'Tây Môn Suy Tuyết', CAST(0x95B00A00 AS Date), N'Trúc Lâm', N'01567782365', 1)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (5, N'Châu Tinh Trì', CAST(0x201D0B00 AS Date), N'Quảng Ngãi', N'01652348979', 2)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (6, N'A Châu', CAST(0x741D0B00 AS Date), N'Lũng Cú', N'0905376220', 1)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (7, N'Minh', CAST(0x741D0B00 AS Date), N'HCM', N'01673353824', 0)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (8, N'Tý', CAST(0x6B3B0B00 AS Date), N'Lào', N'01253903756', 0)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (9, N'Jannani W', CAST(0xE71E0B00 AS Date), N'Thái Lan', N'0168298110', 1)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (10, N'Trần Hạo Nam', CAST(0x823B0B00 AS Date), N'Lạng Sơn', N'0123576880', 0)
INSERT [dbo].[KHACHHANG] ([MaKH], [TenKh], [NgaySinh], [DiaChi], [SDT], [Quen]) VALUES (11, N'Lý Quốc Cường', CAST(0x823B0B00 AS Date), N'Thái Nguyên', N'09763383520', 0)
SET IDENTITY_INSERT [dbo].[KIEUSP] ON 

INSERT [dbo].[KIEUSP] ([MaKieuSP], [TenKieuSP]) VALUES (1, N'Dây chuyền mặt trăng')
INSERT [dbo].[KIEUSP] ([MaKieuSP], [TenKieuSP]) VALUES (2, N'Nhẫn mắt mèo')
INSERT [dbo].[KIEUSP] ([MaKieuSP], [TenKieuSP]) VALUES (4, N'Hoa tai giọt nước')
INSERT [dbo].[KIEUSP] ([MaKieuSP], [TenKieuSP]) VALUES (5, N'Hoa tai bán nguyệt')
INSERT [dbo].[KIEUSP] ([MaKieuSP], [TenKieuSP]) VALUES (6, N'Nhẫn đại bàng')
INSERT [dbo].[KIEUSP] ([MaKieuSP], [TenKieuSP]) VALUES (7, N'Nhẫn hạt cườm')
INSERT [dbo].[KIEUSP] ([MaKieuSP], [TenKieuSP]) VALUES (8, N'Dây chuyền thổ dân')
INSERT [dbo].[KIEUSP] ([MaKieuSP], [TenKieuSP]) VALUES (9, N'Hoa tai hoa sen')
INSERT [dbo].[KIEUSP] ([MaKieuSP], [TenKieuSP]) VALUES (10, N'Lách tay')
SET IDENTITY_INSERT [dbo].[KIEUSP] OFF
INSERT [dbo].[LOAIDICHVU] ([MaLoaiDV], [TenLoaiDV], [DonGia]) VALUES (1, N'Hàn điểm', 30000.0000)
INSERT [dbo].[LOAIDICHVU] ([MaLoaiDV], [TenLoaiDV], [DonGia]) VALUES (2, N'Thu nhỏ size nhẫn cưới', 50000.0000)
INSERT [dbo].[LOAIDICHVU] ([MaLoaiDV], [TenLoaiDV], [DonGia]) VALUES (3, N'Thu nhỏ size vòng tay', 120000.0000)
INSERT [dbo].[LOAIDICHVU] ([MaLoaiDV], [TenLoaiDV], [DonGia]) VALUES (4, N'Thu nhỏ size vòng tay (có đá)', 180000.0000)
INSERT [dbo].[LOAIDICHVU] ([MaLoaiDV], [TenLoaiDV], [DonGia]) VALUES (5, N'Nới rộng size nhẫn cưới', 100000.0000)
INSERT [dbo].[LOAIDICHVU] ([MaLoaiDV], [TenLoaiDV], [DonGia]) VALUES (6, N'Nới rộng size vòng tay', 250000.0000)
INSERT [dbo].[LOAIDICHVU] ([MaLoaiDV], [TenLoaiDV], [DonGia]) VALUES (7, N'Làm thêm chi tiết dây tay, dây cổ', 290000.0000)
INSERT [dbo].[LOAIDICHVU] ([MaLoaiDV], [TenLoaiDV], [DonGia]) VALUES (8, N'Xi mạ (dưới 1 chỉ)', 90000.0000)
INSERT [dbo].[LOAIDICHVU] ([MaLoaiDV], [TenLoaiDV], [DonGia]) VALUES (9, N'Xi mạ (từ 1 - 1,99 chỉ)', 130000.0000)
SET IDENTITY_INSERT [dbo].[LOAISP] ON 

INSERT [dbo].[LOAISP] ([MaLoaiSP], [TenLoaiSP], [MaDonViTinh], [PhanTramLoiNhuan]) VALUES (1, N'Vàng', 1, 0.6)
INSERT [dbo].[LOAISP] ([MaLoaiSP], [TenLoaiSP], [MaDonViTinh], [PhanTramLoiNhuan]) VALUES (2, N'Kim cương', 2, 0.5)
INSERT [dbo].[LOAISP] ([MaLoaiSP], [TenLoaiSP], [MaDonViTinh], [PhanTramLoiNhuan]) VALUES (4, N'Hồng ngọc', 2, 0.40000000596046448)
INSERT [dbo].[LOAISP] ([MaLoaiSP], [TenLoaiSP], [MaDonViTinh], [PhanTramLoiNhuan]) VALUES (5, N'Ngọc trai đen', 8, 0.40000000596046448)
INSERT [dbo].[LOAISP] ([MaLoaiSP], [TenLoaiSP], [MaDonViTinh], [PhanTramLoiNhuan]) VALUES (6, N'Ngọc trai', 8, 0.40000000596046448)
INSERT [dbo].[LOAISP] ([MaLoaiSP], [TenLoaiSP], [MaDonViTinh], [PhanTramLoiNhuan]) VALUES (7, N'Ngọc bích', 2, 0.800000011920929)
INSERT [dbo].[LOAISP] ([MaLoaiSP], [TenLoaiSP], [MaDonViTinh], [PhanTramLoiNhuan]) VALUES (8, N'Bạc', 1, 0.5)
INSERT [dbo].[LOAISP] ([MaLoaiSP], [TenLoaiSP], [MaDonViTinh], [PhanTramLoiNhuan]) VALUES (9, N'Bạch kim', 1, 0.5)
INSERT [dbo].[LOAISP] ([MaLoaiSP], [TenLoaiSP], [MaDonViTinh], [PhanTramLoiNhuan]) VALUES (10, N'Cẩm thạch', 2, 0.30000001192092896)
SET IDENTITY_INSERT [dbo].[LOAISP] OFF
INSERT [dbo].[NGUOIDUNG] ([USERNAME], [PASS], [QUYEN]) VALUES (N'banhang', N'c6f057b86584942e415435ffb1fa93d4', N'NVBANHANG
')
INSERT [dbo].[NGUOIDUNG] ([USERNAME], [PASS], [QUYEN]) VALUES (N'dichvu', N'c6f057b86584942e415435ffb1fa93d4', N'NVDICHVU
')
INSERT [dbo].[NGUOIDUNG] ([USERNAME], [PASS], [QUYEN]) VALUES (N'kho', N'c6f057b86584942e415435ffb1fa93d4', N'NVKHO
')
INSERT [dbo].[NGUOIDUNG] ([USERNAME], [PASS], [QUYEN]) VALUES (N'muahang', N'c6f057b86584942e415435ffb1fa93d4', N'NVMUAHANG
')
INSERT [dbo].[NGUOIDUNG] ([USERNAME], [PASS], [QUYEN]) VALUES (N'quanly', N'c6f057b86584942e415435ffb1fa93d4', N'NVQUANLY
')
INSERT [dbo].[NGUOIDUNG] ([USERNAME], [PASS], [QUYEN]) VALUES (N'super', N'c6f057b86584942e415435ffb1fa93d4', N'BOSS
')
INSERT [dbo].[PHANQUYEN] ([QUYEN], [PHIEUMUA], [PHIEUBAN], [QUANLY], [THUKHO], [DICHVU]) VALUES (N'BOSS
', 3, 3, 3, 3, 3)
INSERT [dbo].[PHANQUYEN] ([QUYEN], [PHIEUMUA], [PHIEUBAN], [QUANLY], [THUKHO], [DICHVU]) VALUES (N'NVBANHANG
', 0, 1, 0, 0, 2)
INSERT [dbo].[PHANQUYEN] ([QUYEN], [PHIEUMUA], [PHIEUBAN], [QUANLY], [THUKHO], [DICHVU]) VALUES (N'NVDICHVU
', 0, 0, 0, 0, 1)
INSERT [dbo].[PHANQUYEN] ([QUYEN], [PHIEUMUA], [PHIEUBAN], [QUANLY], [THUKHO], [DICHVU]) VALUES (N'NVKHO
', 0, 0, 0, 1, 0)
INSERT [dbo].[PHANQUYEN] ([QUYEN], [PHIEUMUA], [PHIEUBAN], [QUANLY], [THUKHO], [DICHVU]) VALUES (N'NVMUAHANG
', 1, 0, 0, 0, 0)
INSERT [dbo].[PHANQUYEN] ([QUYEN], [PHIEUMUA], [PHIEUBAN], [QUANLY], [THUKHO], [DICHVU]) VALUES (N'NVQUANLY
', 2, 2, 3, 2, 2)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (1, 1, CAST(0x543B0B00 AS Date), CAST(0x543B0B00 AS Date), 10.0000, 10.0000)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (2, 9, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 28.0000, 28.0000)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (3, 7, CAST(0x9C390B00 AS Date), CAST(0x143A0B00 AS Date), 11.0000, 11.0000)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (4, 10, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 20.0000, 20.0000)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (5, 4, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 4.0000, 3.0000)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (6, 4, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 62.0000, 60.0000)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (7, 8, CAST(0x833B0B00 AS Date), CAST(0x833B0B00 AS Date), 1.0000, 1.0000)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (8, 11, CAST(0x7A3B0B00 AS Date), CAST(0x7A3B0B00 AS Date), 4.0000, 4.0000)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (9, 6, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 4.0000, 4.0000)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (10, 3, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 20.0000, 20.0000)
INSERT [dbo].[PHIEUBANHANG] ([SoPhieuBan], [MaKH], [NgayBan], [NgayThanhToan], [TongTien], [SoTienTra]) VALUES (11, 1, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 10.0000, 10.0000)
INSERT [dbo].[PHIEUCHI] ([SoPhieuChi], [NoiDung], [SoTienChi], [NgayChi]) VALUES (1, N'Thuê mặt bằng', 3500000.0000, CAST(0x363B0B00 AS Date))
INSERT [dbo].[PHIEUCHI] ([SoPhieuChi], [NoiDung], [SoTienChi], [NgayChi]) VALUES (2, N'Thuế , Thay biển hiệu', 2000000.0000, CAST(0x373B0B00 AS Date))
INSERT [dbo].[PHIEUCHI] ([SoPhieuChi], [NoiDung], [SoTienChi], [NgayChi]) VALUES (3, N'Trả lương nhân viên', 10000000.0000, CAST(0x3F3B0B00 AS Date))
INSERT [dbo].[PHIEUCHI] ([SoPhieuChi], [NoiDung], [SoTienChi], [NgayChi]) VALUES (4, N'Thuê mặt bằng', 3500000.0000, CAST(0x543B0B00 AS Date))
INSERT [dbo].[PHIEUCHI] ([SoPhieuChi], [NoiDung], [SoTienChi], [NgayChi]) VALUES (5, N'Thưởng nhân viên', 1000000.0000, CAST(0x543B0B00 AS Date))
INSERT [dbo].[PHIEUCHI] ([SoPhieuChi], [NoiDung], [SoTienChi], [NgayChi]) VALUES (6, N'Liên hoan', 2000000.0000, CAST(0x563B0B00 AS Date))
INSERT [dbo].[PHIEUCHI] ([SoPhieuChi], [NoiDung], [SoTienChi], [NgayChi]) VALUES (7, N'Mở rộng của hàng', 20000000.0000, CAST(0x613B0B00 AS Date))
INSERT [dbo].[PHIEUCHI] ([SoPhieuChi], [NoiDung], [SoTienChi], [NgayChi]) VALUES (8, N'Mở chi nhánh', 50000000.0000, CAST(0x733B0B00 AS Date))
INSERT [dbo].[PHIEUCHI] ([SoPhieuChi], [NoiDung], [SoTienChi], [NgayChi]) VALUES (9, N'Trả lương nhân viên', 15000000.0000, CAST(0x743B0B00 AS Date))
INSERT [dbo].[PHIEUCHI] ([SoPhieuChi], [NoiDung], [SoTienChi], [NgayChi]) VALUES (10, N'Quà tặng khách hàng may mắn', 500000.0000, CAST(0x7E3B0B00 AS Date))
INSERT [dbo].[PHIEUDICHVU] ([SoPhieuDV], [MaKH], [NgayDangKy], [NgayGiao], [DiaChi], [TongTien], [TinhTrang]) VALUES (1, 1, CAST(0x7B3B0B00 AS Date), CAST(0x833B0B00 AS Date), N'Biên Hòa - Đồng Nai', 170000.0000, 0)
INSERT [dbo].[PHIEUDICHVU] ([SoPhieuDV], [MaKH], [NgayDangKy], [NgayGiao], [DiaChi], [TongTien], [TinhTrang]) VALUES (2, 2, CAST(0x803B0B00 AS Date), CAST(0x843B0B00 AS Date), N'Quận 1 - tp.HCM', 500000.0000, 0)
INSERT [dbo].[PHIEUDICHVU] ([SoPhieuDV], [MaKH], [NgayDangKy], [NgayGiao], [DiaChi], [TongTien], [TinhTrang]) VALUES (3, 10, CAST(0x813B0B00 AS Date), CAST(0x853B0B00 AS Date), N'Võ Thị Sáu - tp.HCM', 290000.0000, 0)
INSERT [dbo].[PHIEUDICHVU] ([SoPhieuDV], [MaKH], [NgayDangKy], [NgayGiao], [DiaChi], [TongTien], [TinhTrang]) VALUES (4, 5, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), N'Suối Tiên - Thủ Đức', 160000.0000, 0)
INSERT [dbo].[PHIEUDICHVU] ([SoPhieuDV], [MaKH], [NgayDangKy], [NgayGiao], [DiaChi], [TongTien], [TinhTrang]) VALUES (5, 2, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), N'Quận 1 - tp.HCM', 170000.0000, 0)
INSERT [dbo].[PHIEUGIACONG] ([SoPhieuGiaCong], [NgayLap], [TongTien]) VALUES (1, CAST(0x823B0B00 AS Date), 0.0000)
INSERT [dbo].[PHIEUGIACONG] ([SoPhieuGiaCong], [NgayLap], [TongTien]) VALUES (2, CAST(0x823B0B00 AS Date), 490000.0000)
INSERT [dbo].[PHIEUGIACONG] ([SoPhieuGiaCong], [NgayLap], [TongTien]) VALUES (3, CAST(0x823B0B00 AS Date), 280000.0000)
INSERT [dbo].[PHIEUGIACONG] ([SoPhieuGiaCong], [NgayLap], [TongTien]) VALUES (4, CAST(0x823B0B00 AS Date), 100000.0000)
SET IDENTITY_INSERT [dbo].[PHIEUMUAHANG] ON 

INSERT [dbo].[PHIEUMUAHANG] ([SoPhieuMua], [MaKH], [NgayMua], [NgayThanhToan], [TongTien]) VALUES (1, 3, CAST(0xD4230B00 AS Date), CAST(0x42250B00 AS Date), 19.0000)
INSERT [dbo].[PHIEUMUAHANG] ([SoPhieuMua], [MaKH], [NgayMua], [NgayThanhToan], [TongTien]) VALUES (10, 6, CAST(0x793B0B00 AS Date), CAST(0x7B3B0B00 AS Date), 23.0000)
INSERT [dbo].[PHIEUMUAHANG] ([SoPhieuMua], [MaKH], [NgayMua], [NgayThanhToan], [TongTien]) VALUES (11, 3, CAST(0x833B0B00 AS Date), CAST(0x8A3B0B00 AS Date), 12.0000)
INSERT [dbo].[PHIEUMUAHANG] ([SoPhieuMua], [MaKH], [NgayMua], [NgayThanhToan], [TongTien]) VALUES (12, 1, CAST(0x803B0B00 AS Date), CAST(0x823B0B00 AS Date), 4.0000)
INSERT [dbo].[PHIEUMUAHANG] ([SoPhieuMua], [MaKH], [NgayMua], [NgayThanhToan], [TongTien]) VALUES (13, 5, CAST(0x7F3B0B00 AS Date), CAST(0x7F3B0B00 AS Date), 4.0000)
INSERT [dbo].[PHIEUMUAHANG] ([SoPhieuMua], [MaKH], [NgayMua], [NgayThanhToan], [TongTien]) VALUES (14, 9, CAST(0x803B0B00 AS Date), CAST(0x813B0B00 AS Date), 2.0000)
INSERT [dbo].[PHIEUMUAHANG] ([SoPhieuMua], [MaKH], [NgayMua], [NgayThanhToan], [TongTien]) VALUES (15, 6, CAST(0x7F3B0B00 AS Date), CAST(0x883B0B00 AS Date), 6.0000)
INSERT [dbo].[PHIEUMUAHANG] ([SoPhieuMua], [MaKH], [NgayMua], [NgayThanhToan], [TongTien]) VALUES (16, 2, CAST(0x803B0B00 AS Date), CAST(0x823B0B00 AS Date), 3.0000)
SET IDENTITY_INSERT [dbo].[PHIEUMUAHANG] OFF
SET IDENTITY_INSERT [dbo].[PHIEUNHAP] ON 

INSERT [dbo].[PHIEUNHAP] ([SoPhieuNhap], [NgayLap], [TongTien]) VALUES (6, CAST(0x723B0B00 AS Date), 11.0000)
INSERT [dbo].[PHIEUNHAP] ([SoPhieuNhap], [NgayLap], [TongTien]) VALUES (7, CAST(0x823B0B00 AS Date), 8.0000)
INSERT [dbo].[PHIEUNHAP] ([SoPhieuNhap], [NgayLap], [TongTien]) VALUES (8, CAST(0x743B0B00 AS Date), 4.0000)
INSERT [dbo].[PHIEUNHAP] ([SoPhieuNhap], [NgayLap], [TongTien]) VALUES (9, CAST(0x753B0B00 AS Date), 22.0000)
INSERT [dbo].[PHIEUNHAP] ([SoPhieuNhap], [NgayLap], [TongTien]) VALUES (10, CAST(0x763B0B00 AS Date), 12.0000)
INSERT [dbo].[PHIEUNHAP] ([SoPhieuNhap], [NgayLap], [TongTien]) VALUES (11, CAST(0x773B0B00 AS Date), 10.0000)
INSERT [dbo].[PHIEUNHAP] ([SoPhieuNhap], [NgayLap], [TongTien]) VALUES (12, CAST(0x793B0B00 AS Date), 1.0000)
SET IDENTITY_INSERT [dbo].[PHIEUNHAP] OFF
INSERT [dbo].[PHIEUNO] ([SoPhieuNo], [SoPhieuBan], [NgayNo], [NgayThanhToan], [SoTienTra], [SoTienConLai]) VALUES (1, 1, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 9.0000, 1.0000)
INSERT [dbo].[PHIEUNO] ([SoPhieuNo], [SoPhieuBan], [NgayNo], [NgayThanhToan], [SoTienTra], [SoTienConLai]) VALUES (2, 5, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 3.0000, 1.0000)
INSERT [dbo].[PHIEUNO] ([SoPhieuNo], [SoPhieuBan], [NgayNo], [NgayThanhToan], [SoTienTra], [SoTienConLai]) VALUES (3, 6, CAST(0x823B0B00 AS Date), CAST(0x823B0B00 AS Date), 60.0000, 2.0000)
SET IDENTITY_INSERT [dbo].[SANPHAM] ON 

INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (1, 1, 1, NULL, NULL, 28)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (2, 1, 2, NULL, NULL, 0)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (3, 2, 1, 0, 0.0000, 14)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (9, 4, 1, 1.6000000238418579, 1.0000, 13)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (10, 2, 2, 4, 3.0000, 1)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (11, 10, 1, 2, 4.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (12, 10, 9, 2, 4.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (13, 9, 1, 2, 4.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (14, 9, 4, 2, 4.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (15, 6, 5, 2, 4.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (16, 6, 6, 2, 4.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (17, 1, 6, 5, 2.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (18, 5, 1, 1, 2.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (19, 5, 5, 4, 1.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (20, 6, 9, 3, 2.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (21, 7, 1, 3, 1.0000, NULL)
INSERT [dbo].[SANPHAM] ([MaSP], [MaLoaiSP], [MaKieuSP], [TrongLuong], [DonGiaBan], [SoLuongTon]) VALUES (22, 8, 1, 3, 1.0000, NULL)
SET IDENTITY_INSERT [dbo].[SANPHAM] OFF
INSERT [dbo].[THAMSO] ([TEN], [KIEU], [GIATRI]) VALUES (N'NoToiDa', N'int', N'2')
INSERT [dbo].[THAMSO] ([TEN], [KIEU], [GIATRI]) VALUES (N'Quen', N'int', N'1')
INSERT [dbo].[THOGIACONG] ([MaTho], [TenTho], [DiaChi], [SDT]) VALUES (1, N'toan', N'aaa', N'000')
INSERT [dbo].[THOGIACONG] ([MaTho], [TenTho], [DiaChi], [SDT]) VALUES (2, N'Nguyễn Văn Ngà', N'Biên Hòa', N'01895432378')
INSERT [dbo].[THOGIACONG] ([MaTho], [TenTho], [DiaChi], [SDT]) VALUES (3, N'Trần Thanh Tinh Văn', N'Suối Tiên', N'01789654345')
INSERT [dbo].[THOGIACONG] ([MaTho], [TenTho], [DiaChi], [SDT]) VALUES (4, N'Lê Tâm Tâm Minh', N'34 - Võ Thị Sáu - TP. HCM', N'01567846298')
INSERT [dbo].[THOGIACONG] ([MaTho], [TenTho], [DiaChi], [SDT]) VALUES (5, N'Trần Đại Ca', N'Chợ Đầu Mối - Thủ Đức', N'01256765467')
ALTER TABLE [dbo].[CTBAOCAO]  WITH CHECK ADD  CONSTRAINT [FK_CTBAOCAO_BAOCAOTONKHO] FOREIGN KEY([MaBaoCao])
REFERENCES [dbo].[BAOCAOTONKHO] ([MaBaoCao])
GO
ALTER TABLE [dbo].[CTBAOCAO] CHECK CONSTRAINT [FK_CTBAOCAO_BAOCAOTONKHO]
GO
ALTER TABLE [dbo].[CTBAOCAO]  WITH CHECK ADD  CONSTRAINT [FK_CTBAOCAO_SANPHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[CTBAOCAO] CHECK CONSTRAINT [FK_CTBAOCAO_SANPHAM]
GO
ALTER TABLE [dbo].[CTGIACONG]  WITH CHECK ADD  CONSTRAINT [FK_CTGIACONG_PHIEUGIACONG] FOREIGN KEY([SoPhieuGiaCong])
REFERENCES [dbo].[PHIEUGIACONG] ([SoPhieuGiaCong])
GO
ALTER TABLE [dbo].[CTGIACONG] CHECK CONSTRAINT [FK_CTGIACONG_PHIEUGIACONG]
GO
ALTER TABLE [dbo].[CTGIACONG]  WITH CHECK ADD  CONSTRAINT [FK_CTGIACONG_THOGIACONG] FOREIGN KEY([MaTho])
REFERENCES [dbo].[THOGIACONG] ([MaTho])
GO
ALTER TABLE [dbo].[CTGIACONG] CHECK CONSTRAINT [FK_CTGIACONG_THOGIACONG]
GO
ALTER TABLE [dbo].[CTGIACONG]  WITH CHECK ADD  CONSTRAINT [FK_Table1_Table2] FOREIGN KEY([SoPhieuDV], [STT])
REFERENCES [dbo].[CTPHIEUDICHVU] ([SoPhieuDV], [STT])
GO
ALTER TABLE [dbo].[CTGIACONG] CHECK CONSTRAINT [FK_Table1_Table2]
GO
ALTER TABLE [dbo].[CTPHIEUBAN]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUBAN_PHIEUBANHANG] FOREIGN KEY([SoPhieuBan])
REFERENCES [dbo].[PHIEUBANHANG] ([SoPhieuBan])
GO
ALTER TABLE [dbo].[CTPHIEUBAN] CHECK CONSTRAINT [FK_CTPHIEUBAN_PHIEUBANHANG]
GO
ALTER TABLE [dbo].[CTPHIEUBAN]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUBAN_SANPHAM] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SANPHAM] ([MaSP])
GO
ALTER TABLE [dbo].[CTPHIEUBAN] CHECK CONSTRAINT [FK_CTPHIEUBAN_SANPHAM]
GO
ALTER TABLE [dbo].[CTPHIEUDICHVU]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUDICHVU_LOAIDICHVU] FOREIGN KEY([MaLoaiDV])
REFERENCES [dbo].[LOAIDICHVU] ([MaLoaiDV])
GO
ALTER TABLE [dbo].[CTPHIEUDICHVU] CHECK CONSTRAINT [FK_CTPHIEUDICHVU_LOAIDICHVU]
GO
ALTER TABLE [dbo].[CTPHIEUDICHVU]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUDICHVU_PHIEUDICHVU] FOREIGN KEY([SoPhieuDV])
REFERENCES [dbo].[PHIEUDICHVU] ([SoPhieuDV])
GO
ALTER TABLE [dbo].[CTPHIEUDICHVU] CHECK CONSTRAINT [FK_CTPHIEUDICHVU_PHIEUDICHVU]
GO
ALTER TABLE [dbo].[CTPHIEUMUA]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUMUA_PHIEUMUAHANG] FOREIGN KEY([SoPhieuMua])
REFERENCES [dbo].[PHIEUMUAHANG] ([SoPhieuMua])
GO
ALTER TABLE [dbo].[CTPHIEUMUA] CHECK CONSTRAINT [FK_CTPHIEUMUA_PHIEUMUAHANG]
GO
ALTER TABLE [dbo].[CTPHIEUNHAP]  WITH CHECK ADD  CONSTRAINT [FK_CTPHIEUNHAP_PHIEUNHAP] FOREIGN KEY([SoPhieuNhap])
REFERENCES [dbo].[PHIEUNHAP] ([SoPhieuNhap])
GO
ALTER TABLE [dbo].[CTPHIEUNHAP] CHECK CONSTRAINT [FK_CTPHIEUNHAP_PHIEUNHAP]
GO
ALTER TABLE [dbo].[LOAISP]  WITH CHECK ADD  CONSTRAINT [FK_LOAISP_DONVITINH] FOREIGN KEY([MaDonViTinh])
REFERENCES [dbo].[DONVITINH] ([MaDonViTinh])
GO
ALTER TABLE [dbo].[LOAISP] CHECK CONSTRAINT [FK_LOAISP_DONVITINH]
GO
ALTER TABLE [dbo].[NGUOIDUNG]  WITH CHECK ADD  CONSTRAINT [FK__NGUOIDUNG__QUYEN__4924D839] FOREIGN KEY([QUYEN])
REFERENCES [dbo].[PHANQUYEN] ([QUYEN])
GO
ALTER TABLE [dbo].[NGUOIDUNG] CHECK CONSTRAINT [FK__NGUOIDUNG__QUYEN__4924D839]
GO
ALTER TABLE [dbo].[PHIEUBANHANG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUBANHANG_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[PHIEUBANHANG] CHECK CONSTRAINT [FK_PHIEUBANHANG_KHACHHANG]
GO
ALTER TABLE [dbo].[PHIEUDICHVU]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUDICHVU_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[PHIEUDICHVU] CHECK CONSTRAINT [FK_PHIEUDICHVU_KHACHHANG]
GO
ALTER TABLE [dbo].[PHIEUMUAHANG]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUMUAHANG_KHACHHANG] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[PHIEUMUAHANG] CHECK CONSTRAINT [FK_PHIEUMUAHANG_KHACHHANG]
GO
ALTER TABLE [dbo].[PHIEUNO]  WITH CHECK ADD  CONSTRAINT [FK_PHIEUNO_PHIEUBANHANG] FOREIGN KEY([SoPhieuBan])
REFERENCES [dbo].[PHIEUBANHANG] ([SoPhieuBan])
GO
ALTER TABLE [dbo].[PHIEUNO] CHECK CONSTRAINT [FK_PHIEUNO_PHIEUBANHANG]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_KIEUSP] FOREIGN KEY([MaKieuSP])
REFERENCES [dbo].[KIEUSP] ([MaKieuSP])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_KIEUSP]
GO
ALTER TABLE [dbo].[SANPHAM]  WITH CHECK ADD  CONSTRAINT [FK_SANPHAM_LOAISP] FOREIGN KEY([MaLoaiSP])
REFERENCES [dbo].[LOAISP] ([MaLoaiSP])
GO
ALTER TABLE [dbo].[SANPHAM] CHECK CONSTRAINT [FK_SANPHAM_LOAISP]
GO
USE [master]
GO

