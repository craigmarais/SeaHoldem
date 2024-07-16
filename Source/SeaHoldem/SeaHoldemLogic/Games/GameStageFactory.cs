using SeaHoldemLogic.Abstraction;
using SeaHoldemLogic.Enums;
using SeaHoldemLogic.ModelsForNow;

namespace SeaHoldemLogic.Games
{
    public static class GameStageFactory
    {
        private static bool _holdemGameStages_Changed;

        private static void Bound_GameStage_Factory_Triggered_Holdem_GameStageChanged_Magically()
        {
            Config.HoldemGameStages.Add(new GameStage(7, GameStageType.PendingPlayers, 0, Face.None));
            _holdemGameStages_Changed = true;
        }

        public static bool ValidateHoldemStages(ref GameStageBase liveGameStage)
        {
            if (!_holdemGameStages_Changed)
                return false;
            
            liveGameStage = Create(liveGameStage.GetGameState());
            _holdemGameStages_Changed = false;
            return true;
        }

        public static GameStageBase Create(GameState gameState)
        {
            // get the games stages from the source
            var gameStages = Config.HoldemGameStages;

            // recursively initiate the stage chain
            return GameStageBase.Create(gameStages, gameState);
        }
    }
}
