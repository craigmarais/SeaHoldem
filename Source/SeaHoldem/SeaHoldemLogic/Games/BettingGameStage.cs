using SeaHoldemLogic.Abstraction;
using SeaHoldemLogic.ModelsForNow;

namespace SeaHoldemLogic.Games
{
    public class BettingGameStage : GameStageBase
    {
        public BettingGameStage(List<GameStage> stages, GameState gameState, int offset = 0) : base(stages, gameState, offset)
        {
        }

        protected override void Execute()
        {
            foreach(var (id, player) in _gameState.Players)
            {
                _gameState.EventHub.RaisePlayerTurn(player);
                // break the sleep on response or on timeout.
                Thread.Sleep(1000);
            }
        }
    }
}
