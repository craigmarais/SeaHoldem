using System.Collections.Concurrent;

namespace SeaHoldemLogic.Abstraction
{
    /// <summary>Stores the state of the current game</summary>
    public class GameState
    {
        public Deck Deck { get; set; }
        public ConcurrentDictionary<int, Player> Players { get; private set; } = new();
        public Player ActivePlayer {get; set; }
        public EventHub EventHub { get; }
        public Pot Pot { get; set; }

        public GameState() 
        { 
            EventHub = new EventHub();
            EventHub.OnPlayerPlacedBet += HandleBetPlaced;
            EventHub.OnPlayerFolded += HandlePlayerFolded;
        }

        public void ActivatePlayers()
        {
            foreach (var (id, player) in Players)
            {
                player.Active = true;
            }
        }

        public void PlayerJoined(Player player)
        {
            if (player == null || Players.ContainsKey(player.Id))
                return;

            Players.TryAdd(player.Id, player);
            EventHub.RaisePlayerJoined(player);
        }

        public void PlayerLeft(Player player)
        {
            if (player == null || !Players.ContainsKey(player.Id))
                return;

            Players.Remove(player.Id, out var removedPlayer);

            if (removedPlayer != null)
                EventHub.RaisePlayerLeft(removedPlayer);
        }

        public async Task HandleBetPlaced(Player player, ulong chips)
        {
            player.Chips -= chips;
            Pot.AddPlayerBet(player.Id, chips);
        }

        public async Task HandlePlayerFolded(Player player)
        {

        }

    }
}
