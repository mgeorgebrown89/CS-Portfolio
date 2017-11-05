-- DMVdb table
CREATE TABLE dbo.forms
(
	ODL				INT  NOT NULL,
	DOB				DateTime NOT NULL,
	Name			NVARCHAR(128) NOT NULL,
	StreetAddress	NVARCHAR(128) NOT NULL,
	City			NVARCHAR(64) NOT NULL,
	State			NVARCHAR(16) NOT NULL,
	Zip				INT	NOT NULL,
	Country			NVARCHAR(128) NOT NULL

	CONSTRAINT [PK_dbo.forms] PRIMARY KEY CLUSTERED (ODL ASC)
);

INSERT INTO dbo.forms(ODL,DOB,Name,StreetAddress,City,State,Zip,Country) VALUES 
	('1234567','1989-09-22 00:00:00', 'Michael Brown','12345 Meadow Ln','Monmouth','Oregon','97361','USA'),
	('8910111','1990-07-27 00:00:00', 'Korenet Brown','12345 Meadow Ln','Monmouth','Oregon','97361','USA'),
	('2131415','2014-06-28 00:00:00', 'Nora Brown','12345 Meadow Ln','Monmouth','Oregon','97361','USA'),
	('1617181','2015-08-14 00:00:00', 'Jane Brown','12345 Meadow Ln','Monmouth','Oregon','97361','USA'),
	('9202122','2007-03-21 00:00:00', 'Margot Brown','12345 Meadow Ln','Monmouth','Oregon','97361','USA');


GO