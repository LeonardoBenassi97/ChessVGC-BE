using System;
using System.Collections.Generic;
using ChessVGC.BE.Models.Enums;

namespace ChessVGC.BE.Models
{
    public class Game
    {
        public int Id { get; set; }
        public GameType Type { get; set; }
        public GameStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        
        // Current game state
        public List<Piece> Pieces { get; set; } = new();
        public List<Player> Players { get; set; } = new();
        public List<GameMove> Moves { get; set; } = new();
  
        // Board state is represented as a JSON string storing the FEN notation
        // plus additional custom state information
        public string CurrentBoardState { get; set; } = string.Empty;
    }
}