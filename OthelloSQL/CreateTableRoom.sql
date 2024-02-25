CREATE TABLE Room
(
	RoomID INT NOT NULL IDENTITY PRIMARY KEY,
	[Password] VARCHAR(5) NOT NULL, -- "Password" is reserved
	DateCreated INT NOT NULL
)
