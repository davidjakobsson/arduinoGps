CREATE TABLE [dbo].[gprmc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageType] [nvarchar](5) NULL,
	[Data] [nvarchar](1000) NOT NULL,
	[Device] [nvarchar](50) NOT NULL,
	[Parsed] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
)

GO

ALTER TABLE [dbo].[gprmc] ADD  DEFAULT ((0)) FOR [Parsed]
GO
