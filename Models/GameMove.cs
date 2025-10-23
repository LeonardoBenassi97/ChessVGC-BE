using System;

namespace ChessVGC.BE.Models
{
    public class GameMove
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; } = null!;
        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;
        public string From { get; set; } = string.Empty;
        public string To { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public int? CapturedPieceId { get; set; }
        public Piece? CapturedPiece { get; set; }
        public int MovedPieceId { get; set; }
        public Piece MovedPiece { get; set; } = null!;
        public int MoveOrder { get; set; } // Per gestire l'ordine delle mosse multiple
    }
}