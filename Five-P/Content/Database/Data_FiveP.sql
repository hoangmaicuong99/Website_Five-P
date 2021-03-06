USE [master]
GO
/****** Object:  Database [FiveP]    Script Date: 30/09/2020 11:01:25 AM ******/
CREATE DATABASE [FiveP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FiveP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FiveP.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'FiveP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\FiveP_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [FiveP] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FiveP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FiveP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FiveP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FiveP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FiveP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FiveP] SET ARITHABORT OFF 
GO
ALTER DATABASE [FiveP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FiveP] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [FiveP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FiveP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FiveP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FiveP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FiveP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FiveP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FiveP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FiveP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FiveP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FiveP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FiveP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FiveP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FiveP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FiveP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FiveP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FiveP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FiveP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FiveP] SET  MULTI_USER 
GO
ALTER DATABASE [FiveP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FiveP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FiveP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FiveP] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [FiveP]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[comment_content] [nvarchar](250) NULL,
	[comment_datecreated] [datetime] NULL,
	[comment_dateedit] [datetime] NULL,
	[user_id] [int] NULL,
	[comment_option] [int] NULL,
	[reply_post_id] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Friend]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friend](
	[friend_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[user_friend_id] [int] NULL,
	[friend_status] [bit] NULL,
 CONSTRAINT [PK_Friend] PRIMARY KEY CLUSTERED 
(
	[friend_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Like]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like](
	[like_id] [int] IDENTITY(1,1) NOT NULL,
	[post_id] [int] NULL,
	[user_id] [int] NULL,
	[like_view] [int] NULL,
 CONSTRAINT [PK_Like] PRIMARY KEY CLUSTERED 
(
	[like_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Like_Reply_Post]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like_Reply_Post](
	[like_reply_post_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[like_reply_post_likeORdis] [bit] NULL,
	[like_reply_post_datecreated] [datetime] NULL,
	[like_reply_post_dateedit] [datetime] NULL,
 CONSTRAINT [PK_Like_Reply_Post] PRIMARY KEY CLUSTERED 
(
	[like_reply_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Post]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Post](
	[post_id] [int] IDENTITY(1,1) NOT NULL,
	[post_content] [nvarchar](max) NULL,
	[post_img] [varchar](max) NULL,
	[post_datecreated] [datetime] NULL,
	[post_dateedit] [datetime] NULL,
	[user_id] [int] NULL,
	[post_activate] [bit] NULL,
	[post_activate_admin] [bit] NULL,
	[post_title] [nvarchar](200) NULL,
	[post_sum_reply] [int] NULL,
	[post_sum_comment] [int] NULL,
	[post_view] [int] NULL,
	[post_popular] [int] NULL,
	[post_calculate_medal] [int] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Rate_Post]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate_Post](
	[rate_post_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[post_id] [int] NULL,
	[rate_post] [bit] NULL,
	[rate_post_datetime] [datetime] NULL,
 CONSTRAINT [PK_Rate_Post] PRIMARY KEY CLUSTERED 
(
	[rate_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Rate_Reply_Post]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate_Reply_Post](
	[rate_reply_post_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[reply_post_id] [int] NULL,
	[rate_reply_post] [bit] NULL,
	[rate_reply_post_datetime] [datetime] NULL,
 CONSTRAINT [PK_Rate_Reply_Post] PRIMARY KEY CLUSTERED 
(
	[rate_reply_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reply_Post]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reply_Post](
	[reply_post_id] [int] IDENTITY(1,1) NOT NULL,
	[reply_post_content] [nvarchar](max) NULL,
	[reply_post_datecreated] [datetime] NULL,
	[reply_post_dateedit] [datetime] NULL,
	[user_id] [int] NULL,
	[reply_post_activate] [bit] NULL,
	[like_reply_post_id] [int] NULL,
	[post_id] [int] NULL,
	[reply_post_title] [nvarchar](200) NULL,
	[reply_post_popular] [int] NULL,
	[reply_post__calculate_medal] [int] NULL,
 CONSTRAINT [PK_Reply_Post] PRIMARY KEY CLUSTERED 
(
	[reply_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reviews_User]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews_User](
	[reviews_user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[reviews_id_user] [int] NULL,
	[Review] [bit] NULL,
 CONSTRAINT [PK_Reviews_User] PRIMARY KEY CLUSTERED 
(
	[reviews_user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Search]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Search](
	[search_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Search] PRIMARY KEY CLUSTERED 
(
	[search_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Show_Activate_Post]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Show_Activate_Post](
	[show_activate_post_id] [int] IDENTITY(1,1) NOT NULL,
	[post_id] [int] NULL,
	[user_id] [int] NULL,
	[show_activate_post_datetime] [datetime] NULL,
	[show_activate_post_Readed] [bit] NULL,
 CONSTRAINT [PK_Show_Activate_Post] PRIMARY KEY CLUSTERED 
(
	[show_activate_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Show_Activate_Reply_Post]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Show_Activate_Reply_Post](
	[show_activate_reply_post_id] [int] IDENTITY(1,1) NOT NULL,
	[reply_post_id] [int] NULL,
	[user_id] [int] NULL,
	[show_activate_reply_post_datetime] [datetime] NULL,
	[show_activate_reply_post_readed] [bit] NULL,
 CONSTRAINT [PK_Show_Activate_Reply_Post] PRIMARY KEY CLUSTERED 
(
	[show_activate_reply_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tags](
	[tags_id] [int] IDENTITY(1,1) NOT NULL,
	[tags_name] [varchar](50) NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[tags_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Technology]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Technology](
	[technology_id] [int] IDENTITY(1,1) NOT NULL,
	[technology_name] [varchar](250) NULL,
	[technology_datetime] [datetime] NULL,
 CONSTRAINT [PK_Technology] PRIMARY KEY CLUSTERED 
(
	[technology_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Technology_Care]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Technology_Care](
	[technology_care_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[technology_id] [int] NULL,
 CONSTRAINT [PK_Technology_Care] PRIMARY KEY CLUSTERED 
(
	[technology_care_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Technology_Post]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Technology_Post](
	[post_technology_id] [int] IDENTITY(1,1) NOT NULL,
	[post_id] [int] NULL,
	[technology_id] [int] NULL,
 CONSTRAINT [PK_Technology_Post] PRIMARY KEY CLUSTERED 
(
	[post_technology_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tick_Post]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tick_Post](
	[tick_post_id] [int] IDENTITY(1,1) NOT NULL,
	[post_id] [int] NULL,
	[user_id] [int] NULL,
	[tick_post_datetime] [datetime] NULL,
 CONSTRAINT [PK_Tick_Post] PRIMARY KEY CLUSTERED 
(
	[tick_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 30/09/2020 11:01:25 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[user_pass] [varchar](255) NULL,
	[user_nicename] [varchar](50) NULL,
	[user_email] [varchar](100) NULL,
	[user_datecreated] [datetime] NULL,
	[user_token] [varchar](200) NULL,
	[user_role] [int] NULL,
	[user_datelogin] [datetime] NULL,
	[user_activate] [bit] NULL,
	[user_phone] [int] NULL,
	[user_address] [nvarchar](200) NULL,
	[user_img] [varchar](max) NULL,
	[user_sex] [int] NULL,
	[user_link_facebok] [nvarchar](max) NULL,
	[user_link_github] [nvarchar](max) NULL,
	[user_hobby_work] [nvarchar](500) NULL,
	[user_hobby] [nvarchar](500) NULL,
	[user_activate_admin] [bit] NULL,
	[user_date_born] [date] NULL,
	[user_popular] [int] NULL,
	[user_gold_medal] [int] NULL,
	[user_silver_medal] [int] NULL,
	[user_bronze_medal] [int] NULL,
	[user_vip_medal] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (6, N'qwe', CAST(0x0000AC3C016EF96E AS DateTime), CAST(0x0000AC3C016EF96E AS DateTime), 1, 0, 3)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (127, N'123', CAST(0x0000AC3D01695DF5 AS DateTime), CAST(0x0000AC3D01695DF5 AS DateTime), 1, 0, 4)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (128, N'qwe', CAST(0x0000AC3D01696C64 AS DateTime), CAST(0x0000AC3D01696C64 AS DateTime), 1, 0, 4)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (129, N'ok', CAST(0x0000AC3D016977B4 AS DateTime), CAST(0x0000AC3D016977B4 AS DateTime), 1, 0, 4)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (130, N'tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt', CAST(0x0000AC3D0169DE75 AS DateTime), CAST(0x0000AC3D0169DE75 AS DateTime), 1, 0, 4)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (131, N'tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt', CAST(0x0000AC3D0169F10B AS DateTime), CAST(0x0000AC3D0169F10B AS DateTime), 1, 0, 4)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (132, N'tttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt', CAST(0x0000AC3D0169F73B AS DateTime), CAST(0x0000AC3D0169F73B AS DateTime), 1, 0, 4)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (133, N'123', CAST(0x0000AC3D016CE8BC AS DateTime), CAST(0x0000AC3D016CE8BC AS DateTime), 1, 0, 3)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (134, N'qwe', CAST(0x0000AC3D016CEE74 AS DateTime), CAST(0x0000AC3D016CEE74 AS DateTime), 1, 0, 3)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (135, N'qwe', CAST(0x0000AC3D016CF0B9 AS DateTime), CAST(0x0000AC3D016CF0B9 AS DateTime), 1, 0, 3)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (136, N'123', CAST(0x0000AC3E00EAFB5F AS DateTime), CAST(0x0000AC3E00EAFB5F AS DateTime), 1, 0, 7)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (137, N'qweqweqweqwe', CAST(0x0000AC3E015A8ACA AS DateTime), CAST(0x0000AC3E015A8ACA AS DateTime), 1, 0, 7)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (138, N'gì m', CAST(0x0000AC3E015A8F67 AS DateTime), CAST(0x0000AC3E015A8F67 AS DateTime), 1, 0, 7)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (139, N'không thích oke', CAST(0x0000AC3E015A9AE9 AS DateTime), CAST(0x0000AC3E015A9AE9 AS DateTime), 1, 0, 7)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (140, N'không thích oke', CAST(0x0000AC3E015A9AE9 AS DateTime), CAST(0x0000AC3E015A9AE9 AS DateTime), 63, 0, 7)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (141, N'qweqw213', CAST(0x0000AC40017B30ED AS DateTime), CAST(0x0000AC40017B30ED AS DateTime), 1, 0, 24)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (142, N'123123', CAST(0x0000AC40017C4EC8 AS DateTime), CAST(0x0000AC40017C4EC8 AS DateTime), 63, 0, 24)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (143, N'12312', CAST(0x0000AC40017C831C AS DateTime), CAST(0x0000AC40017C831C AS DateTime), 63, 0, 24)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (144, N'qweqwasdas', CAST(0x0000AC40017C89C0 AS DateTime), CAST(0x0000AC40017C89C0 AS DateTime), 63, 0, 24)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (145, N'123', CAST(0x0000AC40017F30ED AS DateTime), CAST(0x0000AC40017F30ED AS DateTime), 1, 0, 7)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (146, N'qwe', CAST(0x0000AC40017FD882 AS DateTime), CAST(0x0000AC40017FD882 AS DateTime), 63, 0, 7)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (147, N'123123', CAST(0x0000AC400181F115 AS DateTime), CAST(0x0000AC400181F115 AS DateTime), 1, 0, 7)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (148, N'cc', CAST(0x0000AC410005D7AF AS DateTime), CAST(0x0000AC410005D7AF AS DateTime), 1, 0, 7)
INSERT [dbo].[Comment] ([comment_id], [comment_content], [comment_datecreated], [comment_dateedit], [user_id], [comment_option], [reply_post_id]) VALUES (149, N'qweqwe', CAST(0x0000AC410005E2EB AS DateTime), CAST(0x0000AC410005E2EB AS DateTime), 1, 0, 7)
SET IDENTITY_INSERT [dbo].[Comment] OFF
SET IDENTITY_INSERT [dbo].[Post] ON 

INSERT [dbo].[Post] ([post_id], [post_content], [post_img], [post_datecreated], [post_dateedit], [user_id], [post_activate], [post_activate_admin], [post_title], [post_sum_reply], [post_sum_comment], [post_view], [post_popular], [post_calculate_medal]) VALUES (1, N'I need help with creating a regex that removes all special characters, including commas, but not periods. What I have tried to do is escape all the characters, symbols and punctuation I do not want. It is not working as intended.', N'mm.jpg', CAST(0x0000AC3500000000 AS DateTime), CAST(0x0000AC3600000000 AS DateTime), 1, 1, 1, N'Cuong', 14, 3, 546, 121, 16)
INSERT [dbo].[Post] ([post_id], [post_content], [post_img], [post_datecreated], [post_dateedit], [user_id], [post_activate], [post_activate_admin], [post_title], [post_sum_reply], [post_sum_comment], [post_view], [post_popular], [post_calculate_medal]) VALUES (2, N'I need help with creating a regex that removes all special characters, including commas, but not periods. What I have tried to do is escape all the characters, symbols and punctuation I do not want. It is not working as intended.', N'mm.jpg', CAST(0x0000AC3600000000 AS DateTime), CAST(0x0000AC3600000000 AS DateTime), 1, 1, 1, N'Hoang', 8, 10, 516, 152, 30)
INSERT [dbo].[Post] ([post_id], [post_content], [post_img], [post_datecreated], [post_dateedit], [user_id], [post_activate], [post_activate_admin], [post_title], [post_sum_reply], [post_sum_comment], [post_view], [post_popular], [post_calculate_medal]) VALUES (3, N'I need help with creating a regex that removes all special characters, including commas, but not periods. What I have tried to do is escape all the characters, symbols and punctuation I do not want. It is not working as intended.', N'mm.jpg', CAST(0x0000AC3600000000 AS DateTime), CAST(0x0000AC3600000000 AS DateTime), 1, 1, 1, N'Regex to remove all special characters except periods', 0, 5, 405, 104, 8)
INSERT [dbo].[Post] ([post_id], [post_content], [post_img], [post_datecreated], [post_dateedit], [user_id], [post_activate], [post_activate_admin], [post_title], [post_sum_reply], [post_sum_comment], [post_view], [post_popular], [post_calculate_medal]) VALUES (4, N'I need help with creating a regex that removes all special characters, including commas, but not periods. What I have tried to do is escape all the characters, symbols and punctuation I do not want. It is not working as intended.', N'mm.jpg', CAST(0x0000AC3600000000 AS DateTime), CAST(0x0000AC3600000000 AS DateTime), 1, 1, 1, N's periods', 4, 5, 408, 3, 8)
INSERT [dbo].[Post] ([post_id], [post_content], [post_img], [post_datecreated], [post_dateedit], [user_id], [post_activate], [post_activate_admin], [post_title], [post_sum_reply], [post_sum_comment], [post_view], [post_popular], [post_calculate_medal]) VALUES (5, N'<p>123123123wqeqweqweqweqweqweqweqw</p>
', NULL, CAST(0x0000AC450156091A AS DateTime), CAST(0x0000AC450156091A AS DateTime), 1, 1, 1, N'123123123wqeqweqweqweqweqweqweqw', 0, 0, 0, 0, 0)
INSERT [dbo].[Post] ([post_id], [post_content], [post_img], [post_datecreated], [post_dateedit], [user_id], [post_activate], [post_activate_admin], [post_title], [post_sum_reply], [post_sum_comment], [post_view], [post_popular], [post_calculate_medal]) VALUES (6, N'<p>qweqweasdas213123asdasd12312312eqweqweqweqwe</p>
', NULL, CAST(0x0000AC45015681C5 AS DateTime), CAST(0x0000AC45015681C5 AS DateTime), 1, 1, 1, N'123123123123123213123', 0, 0, 0, 0, 0)
INSERT [dbo].[Post] ([post_id], [post_content], [post_img], [post_datecreated], [post_dateedit], [user_id], [post_activate], [post_activate_admin], [post_title], [post_sum_reply], [post_sum_comment], [post_view], [post_popular], [post_calculate_medal]) VALUES (24, N'<p>123fdsfsdf123fdsfsdf</p>
', NULL, CAST(0x0000AC450182C0CB AS DateTime), CAST(0x0000AC450182C0CB AS DateTime), 63, 1, 1, N'123fdsfsdf123fdsfsdf123fdsfsdf', 0, 0, 0, 0, 0)
INSERT [dbo].[Post] ([post_id], [post_content], [post_img], [post_datecreated], [post_dateedit], [user_id], [post_activate], [post_activate_admin], [post_title], [post_sum_reply], [post_sum_comment], [post_view], [post_popular], [post_calculate_medal]) VALUES (25, N'<p>123123qweq123qwe123123qweq123qwe123123qweq123qwe</p>
', NULL, CAST(0x0000AC450184466A AS DateTime), CAST(0x0000AC450184466A AS DateTime), 63, 1, 1, N'123123qweq123qwe123123qweq123qwe123123qweq123qwe', 0, 0, 0, 0, 0)
INSERT [dbo].[Post] ([post_id], [post_content], [post_img], [post_datecreated], [post_dateedit], [user_id], [post_activate], [post_activate_admin], [post_title], [post_sum_reply], [post_sum_comment], [post_view], [post_popular], [post_calculate_medal]) VALUES (26, N'<p>123123</p>
', NULL, CAST(0x0000AC450185B13B AS DateTime), CAST(0x0000AC450185B13B AS DateTime), 63, 1, 1, N'12312', 20, 0, 61, 81, 0)
SET IDENTITY_INSERT [dbo].[Post] OFF
SET IDENTITY_INSERT [dbo].[Rate_Post] ON 

INSERT [dbo].[Rate_Post] ([rate_post_id], [user_id], [post_id], [rate_post], [rate_post_datetime]) VALUES (65, 1, 1, 1, CAST(0x0000AC38018A9D2B AS DateTime))
INSERT [dbo].[Rate_Post] ([rate_post_id], [user_id], [post_id], [rate_post], [rate_post_datetime]) VALUES (66, 1, 2, 0, CAST(0x0000AC390000561B AS DateTime))
INSERT [dbo].[Rate_Post] ([rate_post_id], [user_id], [post_id], [rate_post], [rate_post_datetime]) VALUES (67, 63, 2, 1, CAST(0x0000AC4100BFB719 AS DateTime))
INSERT [dbo].[Rate_Post] ([rate_post_id], [user_id], [post_id], [rate_post], [rate_post_datetime]) VALUES (68, 63, 3, NULL, CAST(0x0000AC4100C06AFB AS DateTime))
INSERT [dbo].[Rate_Post] ([rate_post_id], [user_id], [post_id], [rate_post], [rate_post_datetime]) VALUES (69, 63, 1, 1, CAST(0x0000AC4100C0E689 AS DateTime))
INSERT [dbo].[Rate_Post] ([rate_post_id], [user_id], [post_id], [rate_post], [rate_post_datetime]) VALUES (70, 63, 4, 1, CAST(0x0000AC4100C1396F AS DateTime))
INSERT [dbo].[Rate_Post] ([rate_post_id], [user_id], [post_id], [rate_post], [rate_post_datetime]) VALUES (71, 1, 4, NULL, CAST(0x0000AC4100E696DF AS DateTime))
SET IDENTITY_INSERT [dbo].[Rate_Post] OFF
SET IDENTITY_INSERT [dbo].[Rate_Reply_Post] ON 

INSERT [dbo].[Rate_Reply_Post] ([rate_reply_post_id], [user_id], [reply_post_id], [rate_reply_post], [rate_reply_post_datetime]) VALUES (5, 1, 3, 1, CAST(0x0000AC3900AFAB58 AS DateTime))
INSERT [dbo].[Rate_Reply_Post] ([rate_reply_post_id], [user_id], [reply_post_id], [rate_reply_post], [rate_reply_post_datetime]) VALUES (6, 1, 4, 1, CAST(0x0000AC3900C00261 AS DateTime))
INSERT [dbo].[Rate_Reply_Post] ([rate_reply_post_id], [user_id], [reply_post_id], [rate_reply_post], [rate_reply_post_datetime]) VALUES (7, 63, 3, 1, CAST(0x0000AC390189EA7A AS DateTime))
INSERT [dbo].[Rate_Reply_Post] ([rate_reply_post_id], [user_id], [reply_post_id], [rate_reply_post], [rate_reply_post_datetime]) VALUES (8, 63, 4, 1, CAST(0x0000AC39018A17B0 AS DateTime))
INSERT [dbo].[Rate_Reply_Post] ([rate_reply_post_id], [user_id], [reply_post_id], [rate_reply_post], [rate_reply_post_datetime]) VALUES (9, 1, 7, 1, CAST(0x0000AC3E00C65CAE AS DateTime))
INSERT [dbo].[Rate_Reply_Post] ([rate_reply_post_id], [user_id], [reply_post_id], [rate_reply_post], [rate_reply_post_datetime]) VALUES (10, 1, 17, 1, CAST(0x0000AC3F014C1977 AS DateTime))
INSERT [dbo].[Rate_Reply_Post] ([rate_reply_post_id], [user_id], [reply_post_id], [rate_reply_post], [rate_reply_post_datetime]) VALUES (11, 1, 20, 1, CAST(0x0000AC4100020D91 AS DateTime))
INSERT [dbo].[Rate_Reply_Post] ([rate_reply_post_id], [user_id], [reply_post_id], [rate_reply_post], [rate_reply_post_datetime]) VALUES (12, 63, 7, 0, CAST(0x0000AC4200026FA8 AS DateTime))
INSERT [dbo].[Rate_Reply_Post] ([rate_reply_post_id], [user_id], [reply_post_id], [rate_reply_post], [rate_reply_post_datetime]) VALUES (13, 63, 17, 1, CAST(0x0000AC4200034182 AS DateTime))
SET IDENTITY_INSERT [dbo].[Rate_Reply_Post] OFF
SET IDENTITY_INSERT [dbo].[Reply_Post] ON 

INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (3, N'The [\p{P}\p{S}&&[^.]]+ pattern matches one or more (+) punctuation proper (\p{P}) or symbol (\p{S}) chars other than dots (&&[^.], using character class subtraction).', CAST(0x0000AC3600000000 AS DateTime), CAST(0x0000AC3600000000 AS DateTime), 1, 1, NULL, 1, NULL, 0, 0)
INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (4, N'The [\p{P}\p{S}&&[^.]]+ pattern matches one or more (+) punctuation proper (\p{P}) or symbol (\p{S}) chars other than dots (&&[^.], using character class subtraction).', CAST(0x0000AC3600000000 AS DateTime), CAST(0x0000AC3600000000 AS DateTime), 1, 1, NULL, 1, NULL, 0, 0)
INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (7, N'123', CAST(0x0000AC3E00C64E7F AS DateTime), CAST(0x0000AC3E00C64E7F AS DateTime), 1, 1, NULL, 2, N'1', 0, 28)
INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (17, N'<p>alo alo<img alt="broken heart" src="https://localhost:44345/Content/ckeditor/plugins/smiley/images/broken_heart.png" style="height:23px; width:23px" title="broken heart" />&nbsp;ch&aacute;n</p>
', CAST(0x0000AC3E015AE526 AS DateTime), CAST(0x0000AC3E015AE526 AS DateTime), 1, 1, NULL, 2, N'không biết là gì nữa', 0, 4)
INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (18, N'<p>qweqweqweadasdasda</p>
', CAST(0x0000AC40017663AB AS DateTime), CAST(0x0000AC40017663AB AS DateTime), 1, 1, NULL, 3, N'1123', 0, 0)
INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (19, N'<p>asdfsadfw</p>

<form action="qwe" enctype="multipart/form-data" id="q" name="qwe">qweqweqweqwe</form>

<p>&nbsp;</p>
', CAST(0x0000AC400176B46B AS DateTime), CAST(0x0000AC400176B46B AS DateTime), 1, 1, NULL, 3, N'safsafdasdf', 0, 0)
INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (20, N'<p>123edddd<input name="aaa" type="checkbox" value="1" /></p>
', CAST(0x0000AC4001779110 AS DateTime), CAST(0x0000AC4001779110 AS DateTime), 1, 1, NULL, 2, N'qwqqq', 0, 0)
INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (21, N'<p>qweqweqweqweqw</p>
', CAST(0x0000AC400177F55D AS DateTime), CAST(0x0000AC400177F55D AS DateTime), 1, 1, NULL, 1, N'qwe', 0, 0)
INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (22, N'<p>asdasdqwe1</p>
', CAST(0x0000AC4001780941 AS DateTime), CAST(0x0000AC4001780941 AS DateTime), 1, 1, NULL, 1, N'asdas', 0, 0)
INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (23, N'<p>qqqq<em>qeqweqweqw<u>asdasdasdas<s>qweqwe</s></u></em></p>
', CAST(0x0000AC400178EA87 AS DateTime), CAST(0x0000AC400178EA87 AS DateTime), 1, 1, NULL, 1, N'qweqweqw', 0, 0)
INSERT [dbo].[Reply_Post] ([reply_post_id], [reply_post_content], [reply_post_datecreated], [reply_post_dateedit], [user_id], [reply_post_activate], [like_reply_post_id], [post_id], [reply_post_title], [reply_post_popular], [reply_post__calculate_medal]) VALUES (24, N'<p>123</p>
', CAST(0x0000AC40017AF537 AS DateTime), CAST(0x0000AC40017AF537 AS DateTime), 1, 1, NULL, 1, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Reply_Post] OFF
SET IDENTITY_INSERT [dbo].[Show_Activate_Post] ON 

INSERT [dbo].[Show_Activate_Post] ([show_activate_post_id], [post_id], [user_id], [show_activate_post_datetime], [show_activate_post_Readed]) VALUES (12, 1, 63, CAST(0x0000AC3B000ACF70 AS DateTime), 1)
INSERT [dbo].[Show_Activate_Post] ([show_activate_post_id], [post_id], [user_id], [show_activate_post_datetime], [show_activate_post_Readed]) VALUES (23, 1, 1, CAST(0x0000AC3D010158FE AS DateTime), 1)
INSERT [dbo].[Show_Activate_Post] ([show_activate_post_id], [post_id], [user_id], [show_activate_post_datetime], [show_activate_post_Readed]) VALUES (26, 2, 1, CAST(0x0000AC40018B39DC AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Show_Activate_Post] OFF
SET IDENTITY_INSERT [dbo].[Show_Activate_Reply_Post] ON 

INSERT [dbo].[Show_Activate_Reply_Post] ([show_activate_reply_post_id], [reply_post_id], [user_id], [show_activate_reply_post_datetime], [show_activate_reply_post_readed]) VALUES (21, 20, 1, CAST(0x0000AC410004F842 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Show_Activate_Reply_Post] OFF
SET IDENTITY_INSERT [dbo].[Technology] ON 

INSERT [dbo].[Technology] ([technology_id], [technology_name], [technology_datetime]) VALUES (1, N'C#', CAST(0x0000AC3700000000 AS DateTime))
INSERT [dbo].[Technology] ([technology_id], [technology_name], [technology_datetime]) VALUES (2, N'Java', CAST(0x0000AC3700000000 AS DateTime))
INSERT [dbo].[Technology] ([technology_id], [technology_name], [technology_datetime]) VALUES (3, N'PHP', CAST(0x0000AC3700000000 AS DateTime))
INSERT [dbo].[Technology] ([technology_id], [technology_name], [technology_datetime]) VALUES (4, N'Khác', CAST(0x0000AC3700000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[Technology] OFF
SET IDENTITY_INSERT [dbo].[Technology_Care] ON 

INSERT [dbo].[Technology_Care] ([technology_care_id], [user_id], [technology_id]) VALUES (1, 1, 1)
INSERT [dbo].[Technology_Care] ([technology_care_id], [user_id], [technology_id]) VALUES (2, 1, 2)
INSERT [dbo].[Technology_Care] ([technology_care_id], [user_id], [technology_id]) VALUES (3, 1, 3)
SET IDENTITY_INSERT [dbo].[Technology_Care] OFF
SET IDENTITY_INSERT [dbo].[Technology_Post] ON 

INSERT [dbo].[Technology_Post] ([post_technology_id], [post_id], [technology_id]) VALUES (1, 24, 1)
INSERT [dbo].[Technology_Post] ([post_technology_id], [post_id], [technology_id]) VALUES (2, 24, 2)
INSERT [dbo].[Technology_Post] ([post_technology_id], [post_id], [technology_id]) VALUES (3, 24, 3)
INSERT [dbo].[Technology_Post] ([post_technology_id], [post_id], [technology_id]) VALUES (4, 25, 2)
INSERT [dbo].[Technology_Post] ([post_technology_id], [post_id], [technology_id]) VALUES (5, 25, 4)
INSERT [dbo].[Technology_Post] ([post_technology_id], [post_id], [technology_id]) VALUES (6, 26, 2)
SET IDENTITY_INSERT [dbo].[Technology_Post] OFF
SET IDENTITY_INSERT [dbo].[Tick_Post] ON 

INSERT [dbo].[Tick_Post] ([tick_post_id], [post_id], [user_id], [tick_post_datetime]) VALUES (39, 2, 1, CAST(0x0000AC4100D31BB8 AS DateTime))
SET IDENTITY_INSERT [dbo].[Tick_Post] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [user_pass], [user_nicename], [user_email], [user_datecreated], [user_token], [user_role], [user_datelogin], [user_activate], [user_phone], [user_address], [user_img], [user_sex], [user_link_facebok], [user_link_github], [user_hobby_work], [user_hobby], [user_activate_admin], [user_date_born], [user_popular], [user_gold_medal], [user_silver_medal], [user_bronze_medal], [user_vip_medal]) VALUES (1, N'123', N'Cuong Hoàng', N'hoangmaicuong99@gmail.com', CAST(0x0000AB7900000000 AS DateTime), N'27f2ce4e-e59a-446f-8869-2abd039667dd', 0, CAST(0x0000AC45018B1C56 AS DateTime), 1, 21, N'thị Trấn Lại Uyên, huyện Bàu Bàng, tỉnh Bình Dương', N'team-5.jpg', 0, N'12', N'12', N'12', N'12', 1, CAST(0x6EDF0600 AS Date), 30, 1, 1, 0, 1)
INSERT [dbo].[User] ([user_id], [user_pass], [user_nicename], [user_email], [user_datecreated], [user_token], [user_role], [user_datelogin], [user_activate], [user_phone], [user_address], [user_img], [user_sex], [user_link_facebok], [user_link_github], [user_hobby_work], [user_hobby], [user_activate_admin], [user_date_born], [user_popular], [user_gold_medal], [user_silver_medal], [user_bronze_medal], [user_vip_medal]) VALUES (63, N'123', N'Mi', N'cuongembaubang@gmail.com', CAST(0x0000AB7900000000 AS DateTime), N'7061ada7-6ce7-49ed-a2da-92eaa269162e', 0, CAST(0x0000AC460007A75B AS DateTime), 1, 21, N'thị Trấn Lại Uyên, huyện Bàu Bàng, tỉnh Bình Dương', N'team-5.jpg', 0, N'12', N'12', N'12', N'12', 1, CAST(0x6EDF0600 AS Date), 117, 0, 0, 0, 0)
INSERT [dbo].[User] ([user_id], [user_pass], [user_nicename], [user_email], [user_datecreated], [user_token], [user_role], [user_datelogin], [user_activate], [user_phone], [user_address], [user_img], [user_sex], [user_link_facebok], [user_link_github], [user_hobby_work], [user_hobby], [user_activate_admin], [user_date_born], [user_popular], [user_gold_medal], [user_silver_medal], [user_bronze_medal], [user_vip_medal]) VALUES (64, N'Trung2010203@', NULL, N'n@gmail.com', CAST(0x0000AC400147EEE6 AS DateTime), N'b9368038-0172-4b0c-858e-b62709cb3b0e', 0, CAST(0x0000AC400147EEE6 AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL, 0, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Reply_Post] FOREIGN KEY([reply_post_id])
REFERENCES [dbo].[Reply_Post] ([reply_post_id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Reply_Post]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_User]
GO
ALTER TABLE [dbo].[Friend]  WITH CHECK ADD  CONSTRAINT [FK_Friend_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [FK_Friend_User]
GO
ALTER TABLE [dbo].[Friend]  WITH CHECK ADD  CONSTRAINT [FK_Friend_User1] FOREIGN KEY([user_friend_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Friend] CHECK CONSTRAINT [FK_Friend_User1]
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD  CONSTRAINT [FK_Like_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Like] CHECK CONSTRAINT [FK_Like_Post]
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD  CONSTRAINT [FK_Like_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Like] CHECK CONSTRAINT [FK_Like_User]
GO
ALTER TABLE [dbo].[Like_Reply_Post]  WITH CHECK ADD  CONSTRAINT [FK_Like_Reply_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Like_Reply_Post] CHECK CONSTRAINT [FK_Like_Reply_Post_User]
GO
ALTER TABLE [dbo].[Post]  WITH CHECK ADD  CONSTRAINT [FK_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Post] CHECK CONSTRAINT [FK_Post_User]
GO
ALTER TABLE [dbo].[Rate_Post]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Post_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Rate_Post] CHECK CONSTRAINT [FK_Rate_Post_Post]
GO
ALTER TABLE [dbo].[Rate_Post]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Rate_Post] CHECK CONSTRAINT [FK_Rate_Post_User]
GO
ALTER TABLE [dbo].[Rate_Reply_Post]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Reply_Post_Reply_Post] FOREIGN KEY([reply_post_id])
REFERENCES [dbo].[Reply_Post] ([reply_post_id])
GO
ALTER TABLE [dbo].[Rate_Reply_Post] CHECK CONSTRAINT [FK_Rate_Reply_Post_Reply_Post]
GO
ALTER TABLE [dbo].[Rate_Reply_Post]  WITH CHECK ADD  CONSTRAINT [FK_Rate_Reply_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Rate_Reply_Post] CHECK CONSTRAINT [FK_Rate_Reply_Post_User]
GO
ALTER TABLE [dbo].[Reply_Post]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Post_Like_Reply_Post] FOREIGN KEY([like_reply_post_id])
REFERENCES [dbo].[Like_Reply_Post] ([like_reply_post_id])
GO
ALTER TABLE [dbo].[Reply_Post] CHECK CONSTRAINT [FK_Reply_Post_Like_Reply_Post]
GO
ALTER TABLE [dbo].[Reply_Post]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Post_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Reply_Post] CHECK CONSTRAINT [FK_Reply_Post_Post]
GO
ALTER TABLE [dbo].[Reply_Post]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Reply_Post] CHECK CONSTRAINT [FK_Reply_Post_User]
GO
ALTER TABLE [dbo].[Reviews_User]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_User_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Reviews_User] CHECK CONSTRAINT [FK_Reviews_User_User]
GO
ALTER TABLE [dbo].[Reviews_User]  WITH CHECK ADD  CONSTRAINT [FK_Reviews_User_User1] FOREIGN KEY([reviews_id_user])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Reviews_User] CHECK CONSTRAINT [FK_Reviews_User_User1]
GO
ALTER TABLE [dbo].[Show_Activate_Post]  WITH CHECK ADD  CONSTRAINT [FK_Show_Activate_Post_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Show_Activate_Post] CHECK CONSTRAINT [FK_Show_Activate_Post_Post]
GO
ALTER TABLE [dbo].[Show_Activate_Post]  WITH CHECK ADD  CONSTRAINT [FK_Show_Activate_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Show_Activate_Post] CHECK CONSTRAINT [FK_Show_Activate_Post_User]
GO
ALTER TABLE [dbo].[Show_Activate_Reply_Post]  WITH CHECK ADD  CONSTRAINT [FK_Show_Activate_Reply_Post_Reply_Post] FOREIGN KEY([reply_post_id])
REFERENCES [dbo].[Reply_Post] ([reply_post_id])
GO
ALTER TABLE [dbo].[Show_Activate_Reply_Post] CHECK CONSTRAINT [FK_Show_Activate_Reply_Post_Reply_Post]
GO
ALTER TABLE [dbo].[Show_Activate_Reply_Post]  WITH CHECK ADD  CONSTRAINT [FK_Show_Activate_Reply_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Show_Activate_Reply_Post] CHECK CONSTRAINT [FK_Show_Activate_Reply_Post_User]
GO
ALTER TABLE [dbo].[Technology_Care]  WITH CHECK ADD  CONSTRAINT [FK_Technology_Care_Technology] FOREIGN KEY([technology_id])
REFERENCES [dbo].[Technology] ([technology_id])
GO
ALTER TABLE [dbo].[Technology_Care] CHECK CONSTRAINT [FK_Technology_Care_Technology]
GO
ALTER TABLE [dbo].[Technology_Care]  WITH CHECK ADD  CONSTRAINT [FK_Technology_Care_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Technology_Care] CHECK CONSTRAINT [FK_Technology_Care_User]
GO
ALTER TABLE [dbo].[Technology_Post]  WITH CHECK ADD  CONSTRAINT [FK_Technology_Post_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Technology_Post] CHECK CONSTRAINT [FK_Technology_Post_Post]
GO
ALTER TABLE [dbo].[Technology_Post]  WITH CHECK ADD  CONSTRAINT [FK_Technology_Post_Technology] FOREIGN KEY([technology_id])
REFERENCES [dbo].[Technology] ([technology_id])
GO
ALTER TABLE [dbo].[Technology_Post] CHECK CONSTRAINT [FK_Technology_Post_Technology]
GO
ALTER TABLE [dbo].[Tick_Post]  WITH CHECK ADD  CONSTRAINT [FK_Tick_Post_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Tick_Post] CHECK CONSTRAINT [FK_Tick_Post_Post]
GO
ALTER TABLE [dbo].[Tick_Post]  WITH CHECK ADD  CONSTRAINT [FK_Tick_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Tick_Post] CHECK CONSTRAINT [FK_Tick_Post_User]
GO
USE [master]
GO
ALTER DATABASE [FiveP] SET  READ_WRITE 
GO
