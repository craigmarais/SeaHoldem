using SeaHoldemLogic.Enums;

namespace SeaHoldemLogic.ModelsForNow
{
    public class GameStage
    {
        public int Id { get; set; }
        public GameStageType GameStageType { get; set; }
        public ushort NumberOfCards { get; set; }
        public Face DrawFace { get; set; }

        public GameStage(int id, GameStageType type, ushort numberOfCards, Face drawFace)
        {
            Id = id;
            GameStageType = type;
            NumberOfCards = numberOfCards;
            DrawFace = drawFace;
        }
    }
}
