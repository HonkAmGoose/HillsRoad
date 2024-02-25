SELECT * FROM Room;
SELECT * FROM Connection_Basic;
SELECT * FROM Game_Basic;
--SELECT * FROM GameMove_Basic;

--SELECT COUNT(CurrentGame) FROM Room WHERE RoomID=26;
--SELECT RoomID FROM Connection_Basic WHERE ConnectionID='99bda9d249f445de92f1310f4df1424b';
--SELECT COUNT(*) FROM Connection_Basic WHERE RoomID = 28;
--SELECT CurrentGame FROM Room WHERE RoomID = 28;
--SELECT COUNT(BlackConnection) FROM Game_Basic WHERE GameID = ;
INSERT INTO Game_Basic(NumberOfTurns, BlackConnection) VALUES (0, '');