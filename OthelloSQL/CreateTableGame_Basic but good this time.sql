CREATE TABLE Game_Basic(
	GameID int NOT NULL IDENTITY PRIMARY KEY,
	NumberOfTurns int NOT NULL DEFAULT 0,
	Winner char,
	BlackConnection varchar(50),
	WhiteConnection varchar(50),
)
