USE [master]
GO
/****** Object:  Database [FiveP]    Script Date: 07/09/2020 4:12:41 PM ******/
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
/****** Object:  Table [dbo].[Comment]    Script Date: 07/09/2020 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[comment_id] [int] IDENTITY(1,1) NOT NULL,
	[comment_content] [nvarchar](250) NULL,
	[post_id] [int] NULL,
	[comment_datecreated] [datetime] NULL,
	[comment_dateedit] [datetime] NULL,
	[user_id] [int] NULL,
	[comment_option] [int] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Friend]    Script Date: 07/09/2020 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Friend](
	[friend_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[user_friend_id] [int] NULL,
 CONSTRAINT [PK_Friend] PRIMARY KEY CLUSTERED 
(
	[friend_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Like]    Script Date: 07/09/2020 4:12:42 PM ******/
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
/****** Object:  Table [dbo].[Like_Reply_Post]    Script Date: 07/09/2020 4:12:42 PM ******/
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
/****** Object:  Table [dbo].[Post]    Script Date: 07/09/2020 4:12:42 PM ******/
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
	[post_view] [nchar](10) NULL,
	[user_id] [int] NULL,
	[post_activate] [bit] NULL,
	[post_option] [int] NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Reply_Comment]    Script Date: 07/09/2020 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reply_Comment](
	[reply_comment_id] [int] NOT NULL,
	[reply_comment_content] [nvarchar](max) NULL,
	[reply_comment_datecreated] [datetime] NULL,
	[reply_comment_dateedit] [datetime] NULL,
	[comment_id] [int] NULL,
	[user_id] [int] NULL,
	[reply_comment_option] [int] NULL,
 CONSTRAINT [PK_Reply_Comment] PRIMARY KEY CLUSTERED 
(
	[reply_comment_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reply_Post]    Script Date: 07/09/2020 4:12:42 PM ******/
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
 CONSTRAINT [PK_Reply_Post] PRIMARY KEY CLUSTERED 
(
	[reply_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Search]    Script Date: 07/09/2020 4:12:42 PM ******/
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
/****** Object:  Table [dbo].[Technology_Care]    Script Date: 07/09/2020 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Technology_Care](
	[technology_care_id] [int] IDENTITY(1,1) NOT NULL,
	[technology_care_name] [varchar](50) NULL,
	[user_id] [int] NULL,
 CONSTRAINT [PK_Technology_Care] PRIMARY KEY CLUSTERED 
(
	[technology_care_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Type_Post]    Script Date: 07/09/2020 4:12:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type_Post](
	[type_post_id] [int] IDENTITY(1,1) NOT NULL,
	[type_post_name] [nvarchar](100) NULL,
	[post_id] [int] NULL,
 CONSTRAINT [PK_Type_Post] PRIMARY KEY CLUSTERED 
(
	[type_post_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 07/09/2020 4:12:42 PM ******/
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
	[user_born] [datetime] NULL,
	[user_link_facebok] [nvarchar](max) NULL,
	[user_link_github] [nvarchar](max) NULL,
	[user_hobby_work] [nvarchar](500) NULL,
	[user_hobby] [nvarchar](500) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([user_id], [user_pass], [user_nicename], [user_email], [user_datecreated], [user_token], [user_role], [user_datelogin], [user_activate], [user_phone], [user_address], [user_img], [user_sex], [user_born], [user_link_facebok], [user_link_github], [user_hobby_work], [user_hobby]) VALUES (1, N'123', N'cuonghoang', N'hoangmaicuong99@gmail.com', CAST(0x0000AB7900000000 AS DateTime), N'0f3a9812-6e61-4845-ad54-1f6e7c2cdf7f', 0, CAST(0x0000AC2F010A13CF AS DateTime), 1, 377416055, N'ben cat', N'mhhh.pg', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([user_id], [user_pass], [user_nicename], [user_email], [user_datecreated], [user_token], [user_role], [user_datelogin], [user_activate], [user_phone], [user_address], [user_img], [user_sex], [user_born], [user_link_facebok], [user_link_github], [user_hobby_work], [user_hobby]) VALUES (21, N'qwe123', NULL, N'hoangmaicuong9@gmail.com', CAST(0x0000AC2F00B9C9E7 AS DateTime), N'229d3731-cf23-4015-a7b5-5fd46fe7c84b', 0, CAST(0x0000AC2F00B9C9E7 AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([user_id], [user_pass], [user_nicename], [user_email], [user_datecreated], [user_token], [user_role], [user_datelogin], [user_activate], [user_phone], [user_address], [user_img], [user_sex], [user_born], [user_link_facebok], [user_link_github], [user_hobby_work], [user_hobby]) VALUES (22, N'1', NULL, N'hoangmaicuong999@gmail.com', CAST(0x0000AC2F00B9EED3 AS DateTime), N'fb11e060-5190-4a31-a96e-40159ba890d6', 0, CAST(0x0000AC2F00B9EED3 AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([user_id], [user_pass], [user_nicename], [user_email], [user_datecreated], [user_token], [user_role], [user_datelogin], [user_activate], [user_phone], [user_address], [user_img], [user_sex], [user_born], [user_link_facebok], [user_link_github], [user_hobby_work], [user_hobby]) VALUES (23, N'123', NULL, N'hoangmaicuong9999@gmail.com', CAST(0x0000AC2F00BA09E9 AS DateTime), N'e8390897-8e08-4231-9a58-86c8093ecd67', 0, CAST(0x0000AC2F00BA09E9 AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[User] ([user_id], [user_pass], [user_nicename], [user_email], [user_datecreated], [user_token], [user_role], [user_datelogin], [user_activate], [user_phone], [user_address], [user_img], [user_sex], [user_born], [user_link_facebok], [user_link_github], [user_hobby_work], [user_hobby]) VALUES (24, N'Trung2010203@', NULL, N'hoangmaicuo@gmail.com', CAST(0x0000AC2F00BC13D8 AS DateTime), N'50876737-72b4-4359-9ec9-34a5006acaba', 0, CAST(0x0000AC2F00BC13D8 AS DateTime), 1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Post]
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
ALTER TABLE [dbo].[Reply_Comment]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Comment_Comment] FOREIGN KEY([comment_id])
REFERENCES [dbo].[Comment] ([comment_id])
GO
ALTER TABLE [dbo].[Reply_Comment] CHECK CONSTRAINT [FK_Reply_Comment_Comment]
GO
ALTER TABLE [dbo].[Reply_Comment]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Comment_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Reply_Comment] CHECK CONSTRAINT [FK_Reply_Comment_User]
GO
ALTER TABLE [dbo].[Reply_Post]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Post_Like_Reply_Post] FOREIGN KEY([like_reply_post_id])
REFERENCES [dbo].[Like_Reply_Post] ([like_reply_post_id])
GO
ALTER TABLE [dbo].[Reply_Post] CHECK CONSTRAINT [FK_Reply_Post_Like_Reply_Post]
GO
ALTER TABLE [dbo].[Reply_Post]  WITH CHECK ADD  CONSTRAINT [FK_Reply_Post_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Reply_Post] CHECK CONSTRAINT [FK_Reply_Post_User]
GO
ALTER TABLE [dbo].[Technology_Care]  WITH CHECK ADD  CONSTRAINT [FK_Technology_Care_User] FOREIGN KEY([user_id])
REFERENCES [dbo].[User] ([user_id])
GO
ALTER TABLE [dbo].[Technology_Care] CHECK CONSTRAINT [FK_Technology_Care_User]
GO
ALTER TABLE [dbo].[Type_Post]  WITH CHECK ADD  CONSTRAINT [FK_Type_Post_Post] FOREIGN KEY([post_id])
REFERENCES [dbo].[Post] ([post_id])
GO
ALTER TABLE [dbo].[Type_Post] CHECK CONSTRAINT [FK_Type_Post_Post]
GO
USE [master]
GO
ALTER DATABASE [FiveP] SET  READ_WRITE 
GO
