SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Node](
	[Id] [int] NOT NULL,
	[ParentId] [int] NULL,
	[NodeType] [smallint] NOT NULL,
	[Title] [nvarchar](MAX) NOT NULL,
 CONSTRAINT [PK_Node] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(1, null, 0, 'Root')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(2, 1, 1, 'Repo')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(3, 1, 1, 'Docs')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(4, 2, 1, 'Project')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(5, 4, 1, 'Source')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(6, 3, 2, 'doc.txt')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(7, 5, 2, 'source file.txt')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(8, 1, 1, 'Init')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(9, 2, 1, 'Data')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(10, 5, 2, 'readme.txt')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(11, 9, 2, 'readme.rm')
INSERT INTO [dbo].[Node](Id, ParentId, NodeType, Title) VALUES(12, 8, 2, 'sn.txt')