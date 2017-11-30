-- Artists table
CREATE TABLE dbo.Artists
(
	ArtistID		INT Identity (1,1) NOT NULL,
	Name			NVARCHAR(64)  NOT NULL,
	BirthDate		NVARCHAR(64) NOT NULL,
	BirthCity		NVARCHAR(64) NOT NULL,
	
	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY CLUSTERED (ArtistID ASC)
);

-- Artworks table
CREATE TABLE dbo.Artworks
(
	ArtworkID		INT Identity (1,1) NOT NULL,
	Title			NVARCHAR(64) NOT NULL,
	ArtistID		INT NOT NULL,
	CONSTRAINT[PK_dbo.Artworks] PRIMARY KEY CLUSTERED (ArtworkID ASC),
	CONSTRAINT[FK_dbo.Artworks_Artists] FOREIGN KEY (ArtistID)
		REFERENCES dbo.Artists(ArtistID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

-- Genres table
CREATE TABLE dbo.Genres
(
	GenreID			INT Identity (1,1) NOT NULL,
	Name			NVARCHAR(64) NOT NULL,
	CONSTRAINT[PK_dbo.Genres] PRIMARY KEY CLUSTERED (GenreID ASC)
);

-- Classifications table
CREATE TABLE dbo.Classifications
(
	ClassificationID	INT Identity(1,1) NOT NULL,
	ArtworkID			INT NOT NULL,
	GenreID				INT NOT NULL,
	CONSTRAINT[PK_dbo.Classifications] PRIMARY KEY CLUSTERED (ClassificationID ASC),
	CONSTRAINT[FK_dbo.Artworks_Classifications] FOREIGN KEY (ArtworkID)
		REFERENCES dbo.Artworks (ArtworkID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT[FK_dbo.Genres_Classifications] FOREIGN KEY (GenreID)
		References dbo.Genres (GenreID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

-- Insertions
INSERT INTO dbo.Artists(Name,BirthDate,BirthCity) VALUES 
	('M C Escher','June 17, 1898', 'Leeuwarden, Netherlands'),
	('Leonardo Da Vinci','May 2, 1519','Vinci, Italy'),
	('Hatip Mehmed Efendi','November 11, 1680','Unknown'),
	('Salvador Dali','May 11, 1904','Figueres,Spain');

INSERT INTO dbo.Artworks (Title, ArtistID) VALUES
('Circle Limit III','1'),
('Twon Tree','1'),
('Mono Lisa','2'),
('The Vitruvian Man','2'),
('Ebru','3'),
('Honey Is Sweeter Than Blood','4');

INSERT INTO dbo.Genres(Name) VALUES
('Tesselation'),
('Surrealism'),
('Portrait'),
('Renaissance');

INSERT INTO dbo.Classifications(ArtworkID, GenreID) VALUES
('1','1'),
('2','1'),
('2','2'),
('3','3'),
('3','4'),
('4','4'),
('5','4'),
('6','2');

GO