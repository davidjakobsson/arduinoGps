CREATE TABLE [dbo].[GpsData](
	[Id] [int] IDENTITY (1,1) NOT NULL PRIMARY KEY,
	[Device] [nvarchar](50) NOT NULL,
	[Latitude] [nvarchar](50) NULL,
	[Longitude] [nvarchar](50) NULL,
	[SpeedKnots] [decimal](18, 0) NULL,
	[SpeedKph] [decimal](18, 0) NULL,
	[UtcDateTime] [datetime2](7) NULL
)