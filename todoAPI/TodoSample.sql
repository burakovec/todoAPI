CREATE DATABASE TodoSample;
GO
CREATE TABLE [dbo].[Todos](

[ID][INT] IDENTITY(1, 1) NOT NULL,

[Title] [NVARCHAR](50) NULL,
	[Description] [NVARCHAR](MAX)NULL,
	[CreatedDate] [DATETIME] NULL,
	[Status] [INT] NULL,
 CONSTRAINT[PK_Todos] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]

GO
INSERT INTO [dbo].[Todos]
([Title]
,[Description]
,[CreatedDate]
,[Status])

	 VALUES
		   ('Kullanıcı Güncelleme', 'Kullanıcıları güncellemek için yeni bir sayfa oluşturulması.', GETDATE(), 0),
		    ('Kullancı Oluşturma', 'Kullanıcı Oluşturma Sayfasının Yapılması.', GETDATE(), 1),
			('Kullanıcı Listesi', 'Kullanıcıların Liste Üzerinde Getirilmesi.', GETDATE(), 3)
GO