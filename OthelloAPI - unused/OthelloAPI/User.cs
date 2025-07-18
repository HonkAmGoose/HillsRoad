namespace OthelloAPI
{
    public class User
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public int GamesPlayed { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
    }
}
