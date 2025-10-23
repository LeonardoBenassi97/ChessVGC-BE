namespace ChessVGC.BE.Models
{
    public class UserStats
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        
        public int TotalGames { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Rating { get; set; }
        
        // Stats specifiche per tipo di partita
        public int SingleGamesPlayed { get; set; }
        public int DoubleGamesPlayed { get; set; }
        public int SingleGamesWon { get; set; }
        public int DoubleGamesWon { get; set; }
    }
}