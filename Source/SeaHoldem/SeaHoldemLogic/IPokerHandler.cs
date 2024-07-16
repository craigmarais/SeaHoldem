using SeaHoldemLogic.Abstraction;

namespace SeaHoldemLogic
{
    public interface IPokerHandler
    {
        void Join(Player player);
        void Leave(Player player);
        void PlaceBet(Player player, ulong chips);
        void Fold(Player player);

        Task HandlePlayerJoined(Player player);
        Task HandlePlayerLeft(Player player);
        Task HandlePlayerCardsDealt(ushort[] cards);
        Task HandleCommunityCardsDealt(ushort[] cards);

        Task HandlePlayerPlacedBet(Player player, ulong chips);
        Task HandlePlayerFolded(Player player);
        Task HandleWinnerDeclared(Player player);
    }
}
