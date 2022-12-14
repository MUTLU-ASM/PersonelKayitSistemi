USE [TBL_Personel]
GO
/****** Object:  Table [dbo].[PersonelTBL]    Script Date: 15.08.2022 15:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonelTBL](
	[Perid] [smallint] IDENTITY(1,1) NOT NULL,
	[PerAdi] [varchar](50) NULL,
	[PerSoyad] [varchar](50) NULL,
	[PerSehir] [varchar](50) NULL,
	[PerMaas] [smallint] NULL,
	[PerDurum] [bit] NULL,
	[PerMeslek] [varchar](50) NULL,
 CONSTRAINT [PK_PersonelTBL] PRIMARY KEY CLUSTERED 
(
	[Perid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Yönetici]    Script Date: 15.08.2022 15:27:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Yönetici](
	[KullaniciAd] [varchar](50) NULL,
	[Sifre] [varchar](50) NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PersonelTBL] ON 

INSERT [dbo].[PersonelTBL] ([Perid], [PerAdi], [PerSoyad], [PerSehir], [PerMaas], [PerDurum], [PerMeslek]) VALUES (1, N'Baran', N'Yücedağ', N'Ankara', 2800, 1, N'Öğretmen')
INSERT [dbo].[PersonelTBL] ([Perid], [PerAdi], [PerSoyad], [PerSehir], [PerMaas], [PerDurum], [PerMeslek]) VALUES (2, N'Emel', N'Çınar', N'Bursa', 2900, 0, N'Hemşire')
INSERT [dbo].[PersonelTBL] ([Perid], [PerAdi], [PerSoyad], [PerSehir], [PerMaas], [PerDurum], [PerMeslek]) VALUES (9, N'Mesut', N'Mutlu', N'sakarya', 5500, 1, N'serbest')
SET IDENTITY_INSERT [dbo].[PersonelTBL] OFF
GO
INSERT [dbo].[TBL_Yönetici] ([KullaniciAd], [Sifre]) VALUES (N'admin34', N'001122')
INSERT [dbo].[TBL_Yönetici] ([KullaniciAd], [Sifre]) VALUES (N'personel01', N'123456')
GO
