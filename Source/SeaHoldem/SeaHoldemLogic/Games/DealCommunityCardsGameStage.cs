using SeaHoldemLogic.Abstraction;
using SeaHoldemLogic.Enums;
using SeaHoldemLogic.ModelsForNow;

namespace SeaHoldemLogic.Games
{
    public class DealCommunityCardsGameStage : GameStageBase
    {
        public DealCommunityCardsGameStage(List<GameStage> stages, GameState gameState, int offset = 0) : base(stages, gameState, offset)
        {
        }

        protected override void Execute()
        {
            // Deal X community cards
            var cards = _gameState.Deck.Draw(_numberOfCards);
            _gameState.EventHub.RaiseCommunityCardsDealt(cards);
        }
    }
}
