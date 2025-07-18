CREATE TABLE dbo.Game
(
	GameID INT NOT NULL PRIMARY KEY,
	NumberOfTurns INT,
	Winner CHAR,
	HandicapNo INT,
	HandicapPlayer CHAR
)