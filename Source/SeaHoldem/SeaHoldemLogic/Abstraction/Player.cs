namespace SeaHoldemLogic.Abstraction
{
    /// <summary>Maintains player state</summary>
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ulong Chips { get; set; }
        public bool Active { get; set; }

        public Player()
        {}
    }
}
