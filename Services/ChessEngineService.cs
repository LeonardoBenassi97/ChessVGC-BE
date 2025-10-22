using System;

namespace ChessVGC.BE.Services
{
    public class ChessEngineService : IDisposable
    {
        private readonly Stockfish.NET.Stockfish _engine;
        
        public ChessEngineService()
      {
      // Initialize Stockfish engine
            _engine = new Stockfish.NET.Stockfish(@"stockfish");
        }

   public string GetBestMove(string fen, int depth = 15)
        {
        _engine.SetPosition(fen);
      return _engine.GetBestMove();
        }

    public void Dispose()
        {
            (_engine as IDisposable)?.Dispose();
        }
    }
}