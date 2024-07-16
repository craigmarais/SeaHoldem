using SeaHoldemLogic.Abstraction;
using SeaHoldemLogic.Enums;
using SeaHoldemLogic.ModelsForNow;

namespace SeaHoldemLogic.Games
{
    public class PendingPlayersGameStage : GameStageBase
    {
        public PendingPlayersGameStage(List<GameStage> stages, GameState gameState, int offset = 0) : base(stages, gameState, offset)
        {
        }

        protected override void Execute()
        {
            while (_gameState.Players.Count < 1)
            {
                _gameState.ActivatePlayers();
                Thread.Sleep(100);
            }
        }
    }
}
