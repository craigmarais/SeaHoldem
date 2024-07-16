using SeaHoldemLogic.Games;

namespace SeaHoldemLogic.Abstraction
{
    /// <summary>Drives the stages of the game and serves the executing assembly</summary>
    public class Game
    {
        private ISeaLogger _logger;
        private GameStageBase _gameStage;
        public GameState GameState { get; }
        
        public Game(ISeaLogger logger)
        {
            GameState = new GameState();
            _gameStage = GameStageFactory.Create(GameState);
        }

        public async Task RunAsync(CancellationToken token)
        {
            await Task.Run(() => Run(token), token);
        }

        public void Run(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    _gameStage.Run();
                    GameStageFactory.ValidateHoldemStages(ref _gameStage);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.ToString());
                }
            }
        }

        public void PlayerJoined(Player player)
        {
            GameState.PlayerJoined(player);
        }

        public void PlayerLeft(Player player)
        {
            GameState.PlayerLeft(player);
        }

        public void PlaceBet(Player player, ulong chips)
        {
            if (player.Chips < chips)
                return;

            GameState.EventHub.RaisePlayerPlacedBet(player, chips);
        }

        public void Fold(Player player)
        {
            GameState.EventHub.RaisePlayerFolded(player);
        }

    }
}
