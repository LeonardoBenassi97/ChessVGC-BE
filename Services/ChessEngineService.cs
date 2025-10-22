using System;
using Stockfish.NET; // placeholder for actual library

namespace ChessVGC.BE
{
 public class ChessEngineService : IDisposable
 {
 private readonly Stockfish _engine;
 public ChessEngineService()
 {
 // Initialize Stockfish engine
 _engine = new Stockfish();
 _engine.Start();
 }

 public string GetBestMove(string fen, int depth =15)
 {
 _engine.SetPosition(fen);
 var result = _engine.GetBestMoveTime(depth *100);
 return result;
 }

 public void Dispose()
 {
 _engine.Stop();
 _engine.Dispose();
 }
 }
}