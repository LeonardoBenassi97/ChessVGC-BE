using Microsoft.AspNetCore.Mvc;
using ChessVGC.BE.Services;

namespace ChessVGC.BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ChessEngineService _engine;
        public GameController(ChessEngineService engine)
        {
            _engine = engine;
        }

        [HttpPost("bestmove")]
        public ActionResult<string> BestMove([FromBody] BestMoveRequest req)
        {
            var move = _engine.GetBestMove(req.FEN, req.Depth);
            return Ok(move);
        }
    }

    public record BestMoveRequest(string FEN, int Depth = 15);
}