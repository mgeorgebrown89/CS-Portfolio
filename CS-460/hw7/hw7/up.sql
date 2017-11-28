-- SearchRequests table
CREATE TABLE dbo.SearchRequests
(
	ID				INT Identity (1,1) NOT NULL,
	Request			NVARCHAR(256)  NOT NULL,
	Timestamp		DateTime NOT NULL,
	IPAddress		NVARCHAR(128) NOT NULL,
	BrowserClient	NVARCHAR(128) NOT NULL,
	
	CONSTRAINT [PK_dbo.SearchRequests] PRIMARY KEY CLUSTERED (ID ASC)
);