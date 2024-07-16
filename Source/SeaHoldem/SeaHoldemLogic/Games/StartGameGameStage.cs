using SeaHoldemLogic.Abstraction;
using SeaHoldemLogic.Enums;
using SeaHoldemLogic.ModelsForNow;

namespace SeaHoldemLogic.Games
{
    public class StartGameGameStage : GameStageBase
    {
        public StartGameGameStage(List<GameStage> stages, GameState gameState, int offset = 0) : base(stages, gameState, offset)
        {
        }

        protected override void Execute()
        {
            _gameState.Pot = new Pot();
            _gameState.Deck = new Deck();
            _gameState.EventHub.RaiseGameStarted();
        }
    }
}
