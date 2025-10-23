using System.Collections.Generic;

namespace ChessVGC.BE.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        // Navigation properties
        public UserStats Stats { get; set; } = null!;
        public List<Player> Players { get; set; } = new();
    }
}