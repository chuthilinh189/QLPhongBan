USE [QL_Phòng_Ban]
GO
/****** Object:  Table [dbo].[department]    Script Date: 16/08/2021 10:08:46 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[department](
	[code] [varchar](10) NOT NULL,
	[name] [nvarchar](200) NOT NULL,
	[parentcode] [varchar](10) NULL,
	[phone] [varchar](20) NULL,
	[email] [varchar](100) NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [varchar](50) NULL,
	[edittime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[departmentpositionhis]    Script Date: 16/08/2021 10:08:46 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departmentpositionhis](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NOT NULL,
	[departmentcode] [varchar](10) NOT NULL,
	[positioncode] [varchar](10) NOT NULL,
	[effect] [bit] NOT NULL,
	[approvedby] [varchar](10) NULL,
	[approvaltime] [datetime] NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [nvarchar](50) NULL,
	[edittime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[managegroup]    Script Date: 16/08/2021 10:08:46 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[managegroup](
	[code] [varchar](10) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [nvarchar](50) NULL,
	[edittime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[position]    Script Date: 16/08/2021 10:08:46 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[position](
	[code] [varchar](10) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[comparelevel] [int] NOT NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [nvarchar](50) NULL,
	[edittime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[staff]    Script Date: 16/08/2021 10:08:46 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staff](
	[code] [varchar](10) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[birthday] [datetime] NULL,
	[address] [nvarchar](300) NULL,
	[hometown] [nvarchar](300) NULL,
	[mobiphone] [varchar](20) NULL,
	[photo] [nvarchar](200) NULL,
	[email] [varchar](100) NULL,
	[sex] [bit] NOT NULL,
	[departmentcode] [varchar](10) NULL,
	[positioncode] [varchar](10) NULL,
	[left] [smallint] NOT NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [nvarchar](50) NULL,
	[edittime] [datetime] NULL,
 CONSTRAINT [PK__staff__357D4CF821A28B29] PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[staffmanagergroup]    Script Date: 16/08/2021 10:08:46 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[staffmanagergroup](
	[code] [varchar](10) NOT NULL,
	[staffcode] [varchar](10) NOT NULL,
	[managegroupcode] [varchar](10) NOT NULL,
	[lock] [smallint] NOT NULL,
	[note] [nvarchar](200) NULL,
	[edituser] [nvarchar](50) NULL,
	[edittime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[department] ([code], [name], [parentcode], [phone], [email], [note], [edituser], [edittime]) VALUES (N'DPM0001', N'Ban Giám Đốc', NULL, N'962154', N'bgd@gmail.com', NULL, NULL, NULL)
INSERT [dbo].[department] ([code], [name], [parentcode], [phone], [email], [note], [edituser], [edittime]) VALUES (N'DPM0002', N'Phòng Tài Chính', N'DPM0001', N'962781', N'ptg@gmaill.com', NULL, NULL, NULL)
INSERT [dbo].[department] ([code], [name], [parentcode], [phone], [email], [note], [edituser], [edittime]) VALUES (N'DPM0003', N'Phòng Kỹ Thuật', N'DPM0001', N'962100', N'pkt@gmail.com', NULL, NULL, NULL)
INSERT [dbo].[department] ([code], [name], [parentcode], [phone], [email], [note], [edituser], [edittime]) VALUES (N'DPM0004', N'KT1', N'DPM0003', N'962444', N'kt1@gmail.com', N'Tổ 1', NULL, NULL)
INSERT [dbo].[department] ([code], [name], [parentcode], [phone], [email], [note], [edituser], [edittime]) VALUES (N'DPM0005', N'KT2', N'DPM0003', N'901332', N'kt2@gmail.com', N'Tổ 2', NULL, NULL)
GO
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000001', N'STA000001', N'DPM0001', N'POS0003', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000002', N'STA000002', N'DPM0001', N'POS0005', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000003', N'STA000003', N'DPM0002', N'POS0002', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000004', N'STA000004', N'DPM0003', N'POS0006', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000005', N'STA000005', N'DPM0002', N'POS0005', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000006', N'STA000006', N'DPM0005', N'POS0004', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000007', N'STA000007', N'DPM0003', N'POS0004', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000008', N'STA000008', N'DPM0004', N'POS0004', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000009', N'STA000009', N'DPM0003', N'POS0003', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000010', N'STA000010', N'DPM0005', N'POS0006', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000011', N'STA000011', N'DPM0004', N'POS0005', 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[departmentpositionhis] ([code], [staffcode], [departmentcode], [positioncode], [effect], [approvedby], [approvaltime], [note], [edituser], [edittime]) VALUES (N'DPH0000012', N'STA000012', N'DPM0005', N'POS0005', 1, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[managegroup] ([code], [name], [note], [edituser], [edittime]) VALUES (N'MAG0001', N'Nhóm Lịch', NULL, NULL, NULL)
INSERT [dbo].[managegroup] ([code], [name], [note], [edituser], [edittime]) VALUES (N'MAG0002', N'Nhóm Tài Liệu', NULL, NULL, NULL)
INSERT [dbo].[managegroup] ([code], [name], [note], [edituser], [edittime]) VALUES (N'MAG0003', N'Nhóm Tin', NULL, NULL, NULL)
GO
INSERT [dbo].[position] ([code], [name], [comparelevel], [note], [edituser], [edittime]) VALUES (N'POS0001', N'Chủ Tịch', 0, NULL, NULL, NULL)
INSERT [dbo].[position] ([code], [name], [comparelevel], [note], [edituser], [edittime]) VALUES (N'POS0002', N'Phó Chủ Tịch', 0, NULL, NULL, NULL)
INSERT [dbo].[position] ([code], [name], [comparelevel], [note], [edituser], [edittime]) VALUES (N'POS0003', N'Giám Đốc', 0, NULL, NULL, NULL)
INSERT [dbo].[position] ([code], [name], [comparelevel], [note], [edituser], [edittime]) VALUES (N'POS0004', N'Phó Giám Đốc', 0, NULL, NULL, NULL)
INSERT [dbo].[position] ([code], [name], [comparelevel], [note], [edituser], [edittime]) VALUES (N'POS0005', N'Thư Ký', 0, NULL, NULL, NULL)
INSERT [dbo].[position] ([code], [name], [comparelevel], [note], [edituser], [edittime]) VALUES (N'POS0006', N'Trợ Lý', 0, NULL, NULL, NULL)
INSERT [dbo].[position] ([code], [name], [comparelevel], [note], [edituser], [edittime]) VALUES (N'POS0007', N'Trưởng Phòng', 0, NULL, NULL, NULL)
INSERT [dbo].[position] ([code], [name], [comparelevel], [note], [edituser], [edittime]) VALUES (N'POS0008', N'Kỹ Thuật Viên', 0, NULL, NULL, NULL)
INSERT [dbo].[position] ([code], [name], [comparelevel], [note], [edituser], [edittime]) VALUES (N'POS0009', N'Nhân Viên', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000001', N'Nguyễn Văn Mạnh', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0001', N'POS0003', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000002', N'Bùi Hồng Nhân', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0001', N'POS0005', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000003', N'Cao Văn Thương', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0002', N'POS0002', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000004', N'Nguyễn Thị Thu', NULL, NULL, NULL, NULL, NULL, NULL, 1, N'DPM0003', N'POS0006', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000005', N'Trần Hồng Đại', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0002', N'POS0005', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000006', N'Bùi Quang Sáng', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0005', N'POS0004', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000007', N'Nguyễn Ngọc Cảnh', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0003', N'POS0004', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000008', N'Lê Bá Qúy', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0004', N'POS0004', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000009', N'Ma Văn Diệp', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0003', N'POS0003', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000010', N'Nguyễn Thái Sơn', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0005', N'POS0006', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000011', N'Trần Văn Công', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0004', N'POS0005', 0, NULL, NULL, NULL)
INSERT [dbo].[staff] ([code], [name], [birthday], [address], [hometown], [mobiphone], [photo], [email], [sex], [departmentcode], [positioncode], [left], [note], [edituser], [edittime]) VALUES (N'STA000012', N'Nguyễn Ngọc Xuân', NULL, NULL, NULL, NULL, NULL, NULL, 0, N'DPM0005', N'POS0005', 0, NULL, NULL, NULL)
GO
INSERT [dbo].[staffmanagergroup] ([code], [staffcode], [managegroupcode], [lock], [note], [edituser], [edittime]) VALUES (N'SMG0000001', N'STA000001', N'MAG0001', 0, NULL, NULL, NULL)
INSERT [dbo].[staffmanagergroup] ([code], [staffcode], [managegroupcode], [lock], [note], [edituser], [edittime]) VALUES (N'SMG0000002', N'STA000001', N'MAG0003', 0, NULL, NULL, NULL)
INSERT [dbo].[staffmanagergroup] ([code], [staffcode], [managegroupcode], [lock], [note], [edituser], [edittime]) VALUES (N'SMG0000003', N'STA000006', N'MAG0001', 0, NULL, NULL, NULL)
INSERT [dbo].[staffmanagergroup] ([code], [staffcode], [managegroupcode], [lock], [note], [edituser], [edittime]) VALUES (N'SMG0000004', N'STA000004', N'MAG0002', 0, NULL, NULL, NULL)
INSERT [dbo].[staffmanagergroup] ([code], [staffcode], [managegroupcode], [lock], [note], [edituser], [edittime]) VALUES (N'SMG0000005', N'STA000008', N'MAG0002', 0, NULL, NULL, NULL)
GO
ALTER TABLE [dbo].[departmentpositionhis] ADD  DEFAULT ((1)) FOR [effect]
GO
ALTER TABLE [dbo].[position] ADD  DEFAULT ((0)) FOR [comparelevel]
GO
ALTER TABLE [dbo].[staff] ADD  CONSTRAINT [DF__staff__sex__36B12243]  DEFAULT ((0)) FOR [sex]
GO
ALTER TABLE [dbo].[staff] ADD  CONSTRAINT [DF__staff__left__398D8EEE]  DEFAULT ((0)) FOR [left]
GO
ALTER TABLE [dbo].[staffmanagergroup] ADD  DEFAULT ((0)) FOR [lock]
GO
ALTER TABLE [dbo].[department]  WITH CHECK ADD FOREIGN KEY([parentcode])
REFERENCES [dbo].[department] ([code])
GO
ALTER TABLE [dbo].[departmentpositionhis]  WITH CHECK ADD FOREIGN KEY([departmentcode])
REFERENCES [dbo].[department] ([code])
GO
ALTER TABLE [dbo].[departmentpositionhis]  WITH CHECK ADD FOREIGN KEY([positioncode])
REFERENCES [dbo].[position] ([code])
GO
ALTER TABLE [dbo].[departmentpositionhis]  WITH CHECK ADD  CONSTRAINT [FK__departmen__staff__3C69FB99] FOREIGN KEY([staffcode])
REFERENCES [dbo].[staff] ([code])
GO
ALTER TABLE [dbo].[departmentpositionhis] CHECK CONSTRAINT [FK__departmen__staff__3C69FB99]
GO
ALTER TABLE [dbo].[staff]  WITH CHECK ADD  CONSTRAINT [FK__staff__departmen__37A5467C] FOREIGN KEY([departmentcode])
REFERENCES [dbo].[department] ([code])
GO
ALTER TABLE [dbo].[staff] CHECK CONSTRAINT [FK__staff__departmen__37A5467C]
GO
ALTER TABLE [dbo].[staff]  WITH CHECK ADD  CONSTRAINT [FK__staff__positionc__38996AB5] FOREIGN KEY([positioncode])
REFERENCES [dbo].[position] ([code])
GO
ALTER TABLE [dbo].[staff] CHECK CONSTRAINT [FK__staff__positionc__38996AB5]
GO
ALTER TABLE [dbo].[staffmanagergroup]  WITH CHECK ADD  CONSTRAINT [FK__staffmana__staff__4222D4EF] FOREIGN KEY([staffcode])
REFERENCES [dbo].[staff] ([code])
GO
ALTER TABLE [dbo].[staffmanagergroup] CHECK CONSTRAINT [FK__staffmana__staff__4222D4EF]
GO
ALTER TABLE [dbo].[staffmanagergroup]  WITH CHECK ADD  CONSTRAINT [FK_staffmanagergroup_managegroup] FOREIGN KEY([managegroupcode])
REFERENCES [dbo].[managegroup] ([code])
GO
ALTER TABLE [dbo].[staffmanagergroup] CHECK CONSTRAINT [FK_staffmanagergroup_managegroup]
GO
