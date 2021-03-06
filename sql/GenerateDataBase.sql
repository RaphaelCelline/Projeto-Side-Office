USE [SideOffice_Homolog]
GO
/****** Object:  Table [dbo].[Rents]    Script Date: 18/05/2019 20:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rents](
	[rent_id] [uniqueidentifier] NOT NULL,
	[room_id] [uniqueidentifier] NOT NULL,
	[user_id] [uniqueidentifier] NOT NULL,
	[title] [varchar](50) NOT NULL,
	[description] [varchar](250) NULL,
	[start_datetime] [datetime] NOT NULL,
	[end_datetime] [datetime] NOT NULL,
	[status] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[rent_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rooms]    Script Date: 18/05/2019 20:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rooms](
	[room_id] [uniqueidentifier] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](250) NULL,
	[seats] [int] NOT NULL,
	[square_meters] [numeric](10, 2) NULL,
	[hour_price] [decimal](10, 2) NULL,
	[has_wifi] [bit] NOT NULL,
	[has_ethernet] [bit] NOT NULL,
	[has_tv] [bit] NOT NULL,
	[has_webcam] [bit] NOT NULL,
	[has_air_conditioning] [bit] NOT NULL,
	[status] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[room_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/05/2019 20:52:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [uniqueidentifier] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[email] [varchar](150) NOT NULL,
	[document] [varchar](50) NOT NULL,
	[password] [varbinary](max) NOT NULL,
	[registration_datetime] [datetime] NOT NULL,
	[country_code] [char](3) NOT NULL,
	[last_login_datetime] [datetime] NULL,
	[status] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Rents]  WITH CHECK ADD  CONSTRAINT [fk_rents_rooms] FOREIGN KEY([room_id])
REFERENCES [dbo].[Rooms] ([room_id])
GO
ALTER TABLE [dbo].[Rents] CHECK CONSTRAINT [fk_rents_rooms]
GO
ALTER TABLE [dbo].[Rents]  WITH CHECK ADD  CONSTRAINT [fk_rents_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[Rents] CHECK CONSTRAINT [fk_rents_users]
GO
