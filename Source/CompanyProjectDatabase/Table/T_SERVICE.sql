/****** Object:  Table [dbo].[T_SERVICE]    Script Date: 01/25/2018 22:59:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[T_SERVICE]') AND type in (N'U'))
DROP TABLE [dbo].[T_SERVICE]
GO

/****** Object:  Table [dbo].[T_SERVICE]    Script Date: 01/25/2018 22:59:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[T_SERVICE](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[service_nm] [varchar](50) NOT NULL,
	[service_desc] [varchar](200) NOT NULL,
	[img] [image] NULL,
	[class_prop] [varchar](50) NULL,
	[created_by] [varchar](50) NOT NULL,
	[created_dt] [datetime] NOT NULL,
	[last_modified_by] [varchar](50) NULL,
	[last_modified_dt] [datetime] NULL,
	[row_status] [bit] NOT NULL,
	[time_span] [time](7) NOT NULL,
 CONSTRAINT [PK_T_SERVICE] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[T_SERVICE] ADD  CONSTRAINT [DF_T_SERVICE_C_DT]  DEFAULT (getdate()) FOR [created_dt]
GO

ALTER TABLE [dbo].[T_SERVICE] ADD  CONSTRAINT [DF_T_SERVICE_R_S]  DEFAULT ((0)) FOR [row_status]
GO

ALTER TABLE [dbo].[T_SERVICE] ADD  CONSTRAINT [DF_T_SERVICE_T_S]  DEFAULT (getdate()) FOR [time_span]
GO


