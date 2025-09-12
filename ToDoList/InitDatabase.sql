USE [ToDoListDB]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 11-09-2025 23:54:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[TaskId] [int] IDENTITY(1,1) NOT NULL,
	[TaskName] [nvarchar](50) NOT NULL,
	[TimeRemaining] [int] NOT NULL,
	[TaskStatusId] [tinyint] NOT NULL,
	[DueDate] [date] NOT NULL,
 CONSTRAINT [PK_Tasks] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskStatus]    Script Date: 11-09-2025 23:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskStatus](
	[StatusId] [tinyint] IDENTITY(1,1) NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TaskStatus] PRIMARY KEY CLUSTERED 
(
	[StatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_TaskStatus] FOREIGN KEY([TaskStatusId])
REFERENCES [dbo].[TaskStatus] ([StatusId])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_TaskStatus]
GO
/****** Object:  StoredProcedure [dbo].[DeleteTask]    Script Date: 11-09-2025 23:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteTask]
	@TaskId INT
AS
BEGIN
	DELETE FROM dbo.Tasks 
	WHERE TaskId = @TaskId
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllTasks]    Script Date: 11-09-2025 23:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTasks]
AS
BEGIN
	SELECT t.TaskId, t.TaskName, ts.StatusName, t.TimeRemaining, t.DueDate
	FROM dbo.Tasks AS t INNER JOIN dbo.TaskStatus AS ts
	ON t.TaskStatusId = ts.StatusId
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllTaskStatuses]    Script Date: 11-09-2025 23:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllTaskStatuses]
AS
BEGIN
	SELECT StatusId, StatusName
	FROM dbo.TaskStatus
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertTask]    Script Date: 11-09-2025 23:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertTask]
	@TaskName NVARCHAR(50),
	@TimeRemaining INT,
	@TaskStatusId INT,
	@DueDate DATE
AS
BEGIN
	INSERT INTO dbo.Tasks (TaskName, TimeRemaining, TaskStatusId, DueDate)
	VALUES (@TaskName, @TimeRemaining, @TaskStatusId, @DueDate);
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateTask]    Script Date: 11-09-2025 23:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateTask]  
 @TaskId INT,  
 @TaskName NVARCHAR(50),    
 @TimeRemaining INT,    
 @TaskStatusId INT,    
 @DueDate DATE    
AS    
BEGIN    
    UPDATE dbo.Tasks     
    SET TaskName = @TaskName,    
        TimeRemaining = @TimeRemaining,    
        TaskStatusId = CASE 
                          WHEN @TaskStatusId > 0 THEN @TaskStatusId 
                          ELSE TaskStatusId 
                       END,    
        DueDate = @DueDate  
    WHERE TaskId = @TaskId;  
END;
GO
