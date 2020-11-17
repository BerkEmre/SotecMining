CREATE TABLE [dbo].[FIYATLAR](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[urunid] [int] NULL,
	[pazaryeriid] [int] NULL,
	[kaynak] [int] NULL,
	[fiyat] [float] NULL,
	[kayitzamani] [datetime] NULL,
	[link] [nvarchar](max) NULL,
	[resimurl1] [nvarchar](max) NULL,
	[resimurl2] [nvarchar](max) NULL,
	[resimurl3] [nvarchar](max) NULL
) ON [PRIMARY]
CREATE TABLE [dbo].[PAZAR_YERLERI](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[adi] [nvarchar](100) NULL,
	[pasifmi] [bit] NULL,
	[search_url] [nvarchar](500) NULL,
	[fiyat_regex] [nvarchar](250) NULL,
	[resim_regex] [nvarchar](250) NULL,
	[link_regex] [nvarchar](250) NULL,
	[node_text] [nvarchar](250) NULL,
	[node_item] [nvarchar](250) NULL,
	[urun_adi] [bit] NULL,
	[barkod] [bit] NULL,
	[urun_kodu] [bit] NULL
) ON [PRIMARY]
CREATE TABLE [dbo].[URUNLER](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[barkod] [nvarchar](100) NULL,
	[urunismi] [nvarchar](500) NULL,
	[urunkodu] [nvarchar](100) NULL,
	[pasifmi] [bit] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[PAZAR_YERLERI] ON 
GO
INSERT [dbo].[PAZAR_YERLERI] ([id], [adi], [pasifmi], [search_url], [fiyat_regex], [resim_regex], [link_regex], [node_text], [node_item], [urun_adi], [barkod], [urun_kodu]) VALUES (1, N'Amazon', 1, N'https://www.amazon.com.tr/s?k={0}', N'//span[contains(@class, ''a-offscreen'')]', N'<img src="([^\"]*)" class="s-image" alt="[^"]*" srcset="[^"]*" data-image-index', N'<a class="a-link-normal s-no-outline" href="([^\"]*)">', N'//div[contains(@class, ''s-main-slot s-result-list s-search-results sg-row'')]', N'//span[contains(@class, ''celwidget slot=MAIN template=SEARCH_RESULTS widgetId=search-results'')]', 1, 1, 1)
GO
INSERT [dbo].[PAZAR_YERLERI] ([id], [adi], [pasifmi], [search_url], [fiyat_regex], [resim_regex], [link_regex], [node_text], [node_item], [urun_adi], [barkod], [urun_kodu]) VALUES (2, N'Ebebek', 1, N'https://www.e-bebek.com/search?text={0}', N'//div[contains(@class, ''price-new'')]', N'<img src=\"([^\"]*)\" alt="[^\"]*" title="[^\"]*" class="img-fluid" width="" height="">', N'<a href=\"([^\"]*)\" class="product-btn ">', N'//section[contains(@class, ''product-list'')]', N'//div[contains(@class, ''col-6 col-sm-6 col-md-4 col-lg-4 col-xl-2 px-1'')]', 1, 1, 1)
GO
INSERT [dbo].[PAZAR_YERLERI] ([id], [adi], [pasifmi], [search_url], [fiyat_regex], [resim_regex], [link_regex], [node_text], [node_item], [urun_adi], [barkod], [urun_kodu]) VALUES (3, N'Civilim', 1, N'https://www.civilim.com/urunara?srchtxt={0}', N'//span[contains(@class, ''price-sales'')]', N'<img data-src=''([^'']*)'' src=''[^'']*'' alt="[^"]*" class="img-responsive lazyload" title="[^"]*">', N'<a href=''([^'']*)'' title=''[^'']*''>', N'//div[contains(@class, ''listitems row'')]', N'//div[contains(@class, ''listitem item itemauto col-lg-8 col-md-8 col-sm-12 col-xs-12 col-xs-min-12'')]', 1, 1, 1)
GO
INSERT [dbo].[PAZAR_YERLERI] ([id], [adi], [pasifmi], [search_url], [fiyat_regex], [resim_regex], [link_regex], [node_text], [node_item], [urun_adi], [barkod], [urun_kodu]) VALUES (4, N'Babymall', 1, N'https://www.babymall.com.tr/arama?q={0}', N'//div[contains(@class, ''pgs-action-price pgs-action-price-new'')]', N'<img class="[^"]*" src="[^"]*" data-src="([^"]*)" alt', N'<a class="pgs-action-name" href="([^"]*)" title="[^"]*">', N'//ul[contains(@class, ''catalog-view'')]', N'//li[contains(@itemscope, ''itemscope'')]', 1, 1, 1)
GO
INSERT [dbo].[PAZAR_YERLERI] ([id], [adi], [pasifmi], [search_url], [fiyat_regex], [resim_regex], [link_regex], [node_text], [node_item], [urun_adi], [barkod], [urun_kodu]) VALUES (5, N'Hepsiburada', 1, N'https://www.hepsiburada.com/ara?q={0}', N'//span[contains(@class, ''price product-price'')]', N'<img data-src=''([^'']*)''', N'<a href="([^\"]*)"', N'//ul[contains(@class, ''product-list results-container do-flex list'')]', N'//li[contains(@class, ''search-item col lg-1 md-1 sm-1  custom-hover not-fashion-flex'')]', 1, 1, 1)
GO
INSERT [dbo].[PAZAR_YERLERI] ([id], [adi], [pasifmi], [search_url], [fiyat_regex], [resim_regex], [link_regex], [node_text], [node_item], [urun_adi], [barkod], [urun_kodu]) VALUES (6, N'N11', 1, N'https://www.n11.com/arama?q={0}', N'//ins[contains(@class, '''')]', N'<img data-original="([^"]*)"', N'<a href="([^"]*)" title="[^"]*"', N'//ul[contains(@class, ''clearfix'')]', N'//li[contains(@class, ''column '')]', 1, 1, 1)
GO
INSERT [dbo].[PAZAR_YERLERI] ([id], [adi], [pasifmi], [search_url], [fiyat_regex], [resim_regex], [link_regex], [node_text], [node_item], [urun_adi], [barkod], [urun_kodu]) VALUES (7, N'Joker', 1, N'https://www.joker.com.tr/arama/?keyword={0}', N'//span[contains(@class, ''discount-price '')]', N'<meta itemprop="image" content="(.*)">', N'<a href="(.*)" class="product-click-item">', N'//ul[contains(@class, ''j-product-list grid-4col'')]', N'//li[contains(@class, ''item product col-md-4 col-sm-4 col-xs-6   stock-out-state-active '')]', 1, 1, 1)
GO
INSERT [dbo].[PAZAR_YERLERI] ([id], [adi], [pasifmi], [search_url], [fiyat_regex], [resim_regex], [link_regex], [node_text], [node_item], [urun_adi], [barkod], [urun_kodu]) VALUES (8, N'Trendyol', 0, N'https://www.trendyol.com/tum--urunler?q={0}', N'//div[contains(@class, ''prc-box-sllng'')]', N'<img class="p-card-img" src="([^"]*)" alt="[^"]*">', N'<a href="(.*)" ', N'//div[contains(@class, ''prdct-cntnr-wrppr'')]', N'//div[contains(@class, ''p-card-wrppr add-to-bs-card'')]', 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[PAZAR_YERLERI] OFF
GO
SET IDENTITY_INSERT [dbo].[URUNLER] ON 
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2700, N'8681049225450', N'BABYJEM KATLI TOZ MAMA KABI MAVİ', N'110.03.545.0002', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2701, N'8681049235459', N'BABYJEM KATLI TOZ MAMA KABI BEYAZ', N'110.03.545.0003', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2702, N'8681049245458', N'BABYJEM KATLI TOZ MAMA KABI RENKLİ', N'110.03.545.0004', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2703, N'8681049215468', N'BABYJEM 3LÜ MAMA KASESİ KIZ ', N'110.03.546.0001', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2704, N'8681049225467', N'BABYJEM 3LÜ MAMA KASESİ ERKEK', N'110.03.546.0002', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2705, N'8681049215635', N'BABYJEM SİLİKON MAMA KAŞIĞI PEMBE/MOR', N'110.03.563.0001', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2706, N'8681049225634', N'BABYJEM SİLİKON MAMA KAŞIĞI TURUNCU KIRMIZI', N'110.03.563.0002', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2707, N'8681049235633', N'BABYJEM SİLİKON MAMA KAŞIĞI YEŞİL/MAVİ', N'110.03.563.0003', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2708, N'8681049215666', N'BABYJEM 5''Lİ MAMA KAŞIĞI ', N'110.03.566.0001', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2709, N'8681049215734', N'BABY&PLUS  DÖKÜLMEYEN TABAK TURUNCU', N'110.03.573.001', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2710, N'8681049216007', N'BABYJEM SİLİKON UÇLU MEYVE SEBZE EMZİĞİ PEMBE', N'110.03.600.000', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2711, N'8681049226006', N'BABYJEM SİLİKON UÇLU MEYVE SEBZE EMZİĞİ MAVİ', N'110.03.600.001', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2712, N'8681049236005', N'BABYJEM SİLİKON UÇLU MEYVE SEBZE EMZİĞİ TURUNCU', N'110.03.600.002', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2713, N'8681049216199', N'BABYJEM 4''LÜ SÜT VE MAMA SAKLAMA KABI', N'110.03.619.000', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2714, N'8681049716200', N'BABYJEM MİNİ ALIŞTIRMA BARDAĞI VE SULUK', N'110.03.620.000', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2715, N'8699203310102', N'BABYJEM ÇAMAŞIR YIKAMA TORBASI', N'110.04.010.BEY.00000', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2716, N'8699208310237', N'BABYJEM ÇOK Yönlü ALT AÇMA BEYAZ MAVİ', N'110.04.023.BMA.00000', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2717, N'', N'BABYJEM ÇOK Yönlü ALT AÇMA BEYAZ ', N'110.04.023.BMA.00001', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2718, N'8699207310238', N'BABYJEM ÇOK Yönlü ALT AÇMA BEYAZ PEMBE', N'110.04.023.BPE.00000', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2719, N'8699209310236', N'BABYJEM ÇOK Yönlü ALT AÇMA BEYAZ SARI', N'110.04.023.BSA.00000', 0)
GO
INSERT [dbo].[URUNLER] ([id], [barkod], [urunismi], [urunkodu], [pasifmi]) VALUES (2720, N'8699202310233', N'BABYJEM ÇOK Yönlü ALT AÇMA BEYAZ YEŞİL', N'110.04.023.BYE.00000', 0)
GO
SET IDENTITY_INSERT [dbo].[URUNLER] OFF
