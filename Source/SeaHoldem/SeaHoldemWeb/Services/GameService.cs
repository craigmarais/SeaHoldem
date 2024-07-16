
using SeaHoldemLogic.Abstraction;

namespace SeaHoldemWeb.Services
{
    public class GameService : BackgroundService
    {
        private readonly Game _game;

        public GameService(Game game)
        {
            _game = game;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            
            await _game.RunAsync(stoppingToken);
        }
    }
}
