using SeaHoldemLogic.Abstraction;
using SeaHoldemLogic.Enums;
using SeaHoldemLogic.ModelsForNow;

namespace SeaHoldemLogic.Games
{
    public  class GameStageBase
    {
        protected int _gameStageId;
        protected GameStageType _gameStageType;
        protected ushort _numberOfCards;
        protected GameStageBase _next;
        protected GameState _gameState;        

        public GameStageBase(List<GameStage> stages, GameState gameState, int offset = 0)
        {
            var currentStage = stages[offset];
            _gameStageId = currentStage.Id;
            _gameStageType = currentStage.GameStageType;
            _gameState = gameState;
            _numberOfCards = currentStage.NumberOfCards;

            if (offset == stages.Count - 1)
            {
                // this is the last stage
                _next = null;
                return;
            }
            
            _next = Create(stages, gameState, ++offset);
        }

        public static GameStageBase Create(List<GameStage> stages, GameState gameState, int offset = 0)
        {
            return stages[offset].GameStageType switch
            {
                GameStageType.PendingPlayers => new PendingPlayersGameStage(stages, gameState, offset),
                GameStageType.StartGame => new StartGameGameStage(stages, gameState, offset),
                GameStageType.DealPlayerCards => new DealPlayerCardsGameStage(stages, gameState, offset),
                GameStageType.Betting => new BettingGameStage(stages, gameState, offset),
                GameStageType.DealCommunityCards => new DealCommunityCardsGameStage(stages, gameState, offset),
                GameStageType.EndGame => new EndGameGameStage(stages, gameState, offset),
                _ => Create(stages, gameState, ++offset),
            };
        }

        public GameState GetGameState() => _gameState;

        protected virtual void Execute() { }

        public void Run()
        {
            Execute();

            if (_next is null)
                return;

            _next.Run();
        }
    }
}
