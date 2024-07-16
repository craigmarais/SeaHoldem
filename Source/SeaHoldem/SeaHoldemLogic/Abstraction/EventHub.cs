namespace SeaHoldemLogic.Abstraction
{
    /// <summary>Serves the calling application events produced by the library</summary>
    public class EventHub
    {
        // public events
        public delegate Task AsyncEventHandler<TEventArgs>(object? sender, TEventArgs e);
        public delegate Task AsyncEventHandler();
        public delegate Task PlayerJoined(Player player);
        public delegate Task GameStarted();
        public delegate Task PlayerTurn(Player player);
        public delegate Task PlayerPlacedBet(Player player, ulong chips);
        public delegate Task PlayerFolded(Player player);
        public delegate Task PlayerLeft(Player player);
        public delegate Task PlayerCardsDealt(ushort[] cards);
        public delegate Task CommunityCardsDealt(ushort[] cards);
        public delegate Task WinnerDeclared(Player player);
        //public delegate void OddsNOuts();

        public event PlayerJoined OnPlayerJoined;
        public event GameStarted OnGameStarted;
        public event PlayerTurn OnPlayerTurn;
        public event PlayerPlacedBet OnPlayerPlacedBet;
        public event PlayerFolded OnPlayerFolded;
        public event PlayerLeft OnPlayerLeft;
        public event PlayerCardsDealt OnPlayerCardsDealt;
        public event CommunityCardsDealt OnCommunityCardsDealt;
        public event WinnerDeclared OnWinnerDeclared;
        //public event OddsNOuts OnOddsNOuts;

        #region Player Events
        internal async Task RaisePlayerJoined(Player player)
        {
            await OnPlayerJoined?.Invoke(player);
        }

        internal void RaisePlayerTurn(Player player)
        {
            OnPlayerTurn?.Invoke(player);
        }

        internal void RaisePlayerPlacedBet(Player player, ulong chips)
        {
            OnPlayerPlacedBet?.Invoke(player, chips);
        }

        internal void RaisePlayerFolded(Player player)
        {
            OnPlayerFolded?.Invoke(player);
        }

        internal void RaisePlayerLeft(Player player)
        {
            OnPlayerLeft?.Invoke(player);
        }
        #endregion

        #region Game Events
        internal void RaiseGameStarted()
        {
            OnGameStarted?.Invoke();
        }
        internal void RaisePlayerCardsDealt(ushort[] cards)
        {
            OnPlayerCardsDealt?.Invoke(cards);
        }

        internal void RaiseCommunityCardsDealt(ushort[] cards)
        {
            OnCommunityCardsDealt?.Invoke(cards);
        }

        internal void RaiseWinnerDeclared(Player player)
        {
            OnWinnerDeclared?.Invoke(player);
        }

        //internal void RaiseOddsNOuts()
        //{
        //    OnOddsNOuts?.Invoke();
        //}
        #endregion
    }
}
