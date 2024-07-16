using SeaHoldemApi.Enums;

namespace SeaHoldemApi.Responses
{
    [Serializable]
    public class PlayerActivity
    {
        public int Id { get; set; }
        public PlayerState State { get; set; }
        public PlayerAction Action { get; set; }
        public string Username { get; set; }
        public ulong Chips { get; set; }
        public ulong Bet { get; set; }

    }
}
