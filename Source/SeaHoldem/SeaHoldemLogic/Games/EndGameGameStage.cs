using SeaHoldemLogic.Abstraction;
using SeaHoldemLogic.Enums;
using SeaHoldemLogic.ModelsForNow;

namespace SeaHoldemLogic.Games
{
    public class EndGameGameStage : GameStageBase
    {
        public EndGameGameStage(List<GameStage> stages, GameState gameState, int offset = 0) : base(stages, gameState, offset)
        {
        }

        protected override void Execute()
        {
            // record game stats
            // declare winner and distribute pot
            foreach(var player in _gameState.Players)
            {
                var rank = 
            }

            _gameState.EventHub.RaiseWinnerDeclared(_gameState.Players.First().Value);
        }
    }
}
