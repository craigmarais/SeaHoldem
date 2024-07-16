using Microsoft.AspNetCore.Mvc;
using SeaHoldemApi.Requests;
using SeaHoldemLogic.Abstraction;
using SeaHoldemWeb.WebSockets;

namespace SeaHoldemWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoldemController : ControllerBase
    {
        private readonly Game _game;
        PokerHandler _handler;
        Player _player;

        public HoldemController(Game game)
        {
            _game = game;
            _player = new Player()
            {
                Id = 1,
                Active = false,
                Chips = 1_000_000,
                Username = "Test"
            };
        }

        [HttpPost("bet")]
        public IActionResult Bet(Bet bet)
        {
            _game.PlaceBet(_player, bet.Value);
            return Ok(bet.Value);
        }

        [HttpPost("call")]
        public IActionResult Call(Bet bet)
        {
            return Ok(bet.Value);
        }

        [HttpPost("raise")]
        public IActionResult Raise(Bet bet)
        {
            return Ok(bet.Value);
        }

        [HttpPost("fold")]
        public IActionResult Fold(Bet bet)
        {
            return Ok(bet.Value);
        }

    }
}
