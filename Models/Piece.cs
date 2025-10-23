using ChessVGC.BE.Models.Enums;

namespace ChessVGC.BE.Models
{
    public class Piece
    {
        public int Id { get; set; }
        public PieceType Type { get; set; }
        public int Speed => Type switch
        {
            PieceType.Pawn => 4,
            PieceType.King => 3,
            PieceType.Queen => 2,
       _    => 1
        };
        public string Position { get; set; } = string.Empty;
        public bool IsWhite { get; set; }
        public bool IsCaptured { get; set; }
        public Game Game { get; set; } = null!;
        public int GameId { get; set; }
  }
}