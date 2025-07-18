CREATE TABLE dbo.GameMove
(
	GameID INT NOT NULL,
	TurnNumber INT NOT NULL,
	[Location] VARCHAR(2),
	
	PRIMARY KEY (GameID, TurnNumber)
)