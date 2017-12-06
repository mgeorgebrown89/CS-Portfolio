-- Buyer Table
CREATE TABLE dbo.Buyers
(
	BuyerID			INT Identity (1,1) NOT NULL,
	Name			NVARCHAR(50) NOT NULL,

	CONSTRAINT [PK_dbo.Buyers] PRIMARY KEY CLUSTERED (BuyerID ASC)
);

-- Seller Table
CREATE TABLE dbo.Sellers
(
	SellerID		INT Identity (1,1) NOT NULL,
	Name			NVARCHAR(50) NOT NULL,
	CONSTRAINT [PK_dbo.Sellers] PRIMARY KEY CLUSTERED (SellerID ASC)
);

-- Items Table
CREATE TABLE dbo.Items
(
	ItemID		INT Identity (1,1) NOT NULL,
	Name		NVARCHAR(50) NOT NULL,
	Description NVARCHAR(150),
	SellerID	INT,

	CONSTRAINT [PK_dbo.Items] PRIMARY KEY CLUSTERED (ItemID ASC),
	CONSTRAINT [FK_dbo.Items_Sellers] FOREIGN KEY (SellerID)
		REFERENCES dbo.Sellers(SellerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

-- Bids Table
CREATE TABLE dbo.Bids
(
	BidID		INT Identity (1,1) NOT NULL,
	ItemID		INT NOT NULL,
	BuyerID		INT NOT NULL,
	Price		INT NOT NULL,
	TimeStamp	DATETIME NOT NULL,

	CONSTRAINT [PK_dbo.Bids] PRIMARY KEY CLUSTERED (BidID ASC),
	CONSTRAINT [FK_dbo.Bids_Items] FOREIGN KEY (ItemID)
		REFERENCES dbo.Items(ItemID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT [FK_dbo.Bids_Buyers] FOREIGN KEY (BuyerID)
		REFERENCES dbo.Buyers(BuyerID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
);

-- Insertions:

INSERT INTO dbo.Buyers(Name) VALUES
('Jane Stone'),
('Tom McMasters'),
('Otto Vanderwall');

INSERT INTO dbo.Sellers(Name) VALUES
('Gayle Hardy'),
('Lyle Banks'),
('Pearl Greene');

INSERT INTO dbo.Items(Name, Description) VALUES
('Abraham Lincoln Hammer'    ,'A bench mallet fashioned from a broken rail-splitting maul in 1829 and owned by Abraham Lincoln'),
('Albert Einsteins Telescope','A brass telescope owned by Albert Einstein in Germany, circa 1927'),
('Bob Dylan Love Poems'      ,'Five versions of an original unpublished, handwritten, love poem by Bob Dylan');

INSERT INTO dbo.Bids(ItemID, BuyerID, Price, TimeStamp) VALUES
(1, 3, 250000, '12/04/2017 09:04:22'),
(3, 1, 95000 , '12/04/2017 08:44:03');