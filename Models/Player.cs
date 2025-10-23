namespace ChessVGC.BE.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; } = string.Empty;
        public bool IsWhite { get; set; }
        
   // Reference to User
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        
        // Reference to Game
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
        
        // Navigation property for moves
        public List<GameMove> Moves { get; set; } = new();
    }
}