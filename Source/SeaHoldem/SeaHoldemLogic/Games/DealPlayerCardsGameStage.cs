using SeaHoldemLogic.Abstraction;
using SeaHoldemLogic.Enums;
using SeaHoldemLogic.ModelsForNow;

namespace SeaHoldemLogic.Games
{
    public class DealPlayerCardsGameStage : GameStageBase
    {
        public DealPlayerCardsGameStage(List<GameStage> stages, GameState gameState, int offset = 0) : base(stages, gameState, offset)
        {
        }

        protected override void Execute()
        {
            // loop through active players and deal X cards raise event.
            foreach (var player in _gameState.Players)
            {
                var cards = _gameState.Deck.Draw(_numberOfCards);
                _gameState.EventHub.RaisePlayerCardsDealt(cards);
            }
        }
    }
}
