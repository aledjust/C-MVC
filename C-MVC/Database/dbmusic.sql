USE [dbmusic]
GO
/****** Object:  Table [dbo].[Artists]    Script Date: 4/19/2019 10:26:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artists](
	[ArtistID] [int] IDENTITY(1,1) NOT NULL,
	[ArtistName] [nvarchar](200) NOT NULL,
	[AlbumName] [nvarchar](200) NOT NULL,
	[ImageURL] [nvarchar](200) NULL,
	[ReleaseDate] [date] NOT NULL,
	[Price] [numeric](10, 2) NOT NULL,
	[SampleURL] [nvarchar](200) NULL,
 CONSTRAINT [PK_Artists] PRIMARY KEY CLUSTERED 
(
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Artists] ON 

INSERT [dbo].[Artists] ([ArtistID], [ArtistName], [AlbumName], [ImageURL], [ReleaseDate], [Price], [SampleURL]) VALUES (1, N'Japan Blauuuu', N'Wer Are Never Ever Getting Back Together', N'https://upload.wikimedia.org/wikipedia/en/4/40/We_Are_Never_Ever_Getting_Back_Together.png', CAST(N'2019-04-20' AS Date), CAST(6.00 AS Numeric(10, 2)), N'http://www.noiseaddicts.com/samples_1w72b820/4210.mp3')
INSERT [dbo].[Artists] ([ArtistID], [ArtistName], [AlbumName], [ImageURL], [ReleaseDate], [Price], [SampleURL]) VALUES (2, N'sample music 28', N'sample string 3', N'http://gakufu.gakki.me/a_music/data/DT10602-IC.jpg', CAST(N'2020-12-02' AS Date), CAST(6.00 AS Numeric(10, 2)), N'http://www.noiseaddicts.com/samples_1w72b820/4202.mp3')
SET IDENTITY_INSERT [dbo].[Artists] OFF
