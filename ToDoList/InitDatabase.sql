USE [ToDoListDB]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 28-08-2025 23:08:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](50) NOT NULL,
	[TimeRemaining] [int] NOT NULL,
	[Status] [tinyint] NOT NULL,
	[DueDate] [date] NOT NULL
) ON [PRIMARY]
GO
