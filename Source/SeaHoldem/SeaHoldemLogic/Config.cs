using SeaHoldemLogic.Enums;
using SeaHoldemLogic.ModelsForNow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaHoldemLogic
{
    public static class Config
    {
        public static byte NumberOfDecks = 1;
        public static ushort[] CardSet = 
        {
            0,1,2,3,4,5,6,7,8,9,10,11,12,
            13,14,15,16,17,18,19,20,21,22,23,24,25,
            26,27,28,29,30,31,32,33,34,35,36,37,38,
            39,40,41,42,43,44,45,46,47,48,49,50,51
        };

        public static List<Ranking> Rankings = new List<Ranking>()
        {
            new Ranking(Rank.HighCard, "c1 > c2"),
            new Ranking(Rank.Pair, "(c1 - c2 % 13) = 0"),
            new Ranking(Rank.TwoPair, "2 x pair"),
            new Ranking(Rank.ThreeOfAKind, "(c1-c2)%13 = 0 AND (c2 - c3) % 13 = 0"),
            new Ranking(Rank.Straight, "(c1 - c2 - 1) % 13 = 0 AND (c2 - c3 - 1) % 13 = 0 AND (c3 - c4 - 1) % 13 = 0 AND (c4 - c5 - 1) % 13 = 0"),
            new Ranking(Rank.Flush, "c1 - c2 < 13 AND c2 - c3 < 13 AND c3 - c4 < 13 AND c4 - c5 < 13"),
            new Ranking(Rank.RoyalFlush, "Straight + Flush")
        };

        public static List<GameStage> HoldemGameStages = new List<GameStage>()
        {
            new (0, GameStageType.PendingPlayers, 0, Face.None),
            new (1, GameStageType.StartGame, 0, Face.None),
            new (2, GameStageType.DealPlayerCards, 2, Face.Down),
            new (3, GameStageType.Betting, 0, Face.None),
            new (4, GameStageType.DealCommunityCards, 3, Face.Up),
            new (5, GameStageType.Betting, 0, Face.None),
            new (6, GameStageType.DealCommunityCards, 1, Face.Up),
            new (7, GameStageType.Betting, 0, Face.None),
            new (8, GameStageType.DealCommunityCards, 1, Face.Up),
            new (9, GameStageType.Betting, 0, Face.None),
            new (10, GameStageType.EndGame, 0, Face.None)
        };

    }
}
