namespace SeaHoldemApi.Requests
{
    public class Bet
    {
        public int IdUser { get; set; }
        public ulong Value { get; set; }

        public Bet()
        {
            
        }
        public Bet(int userId, ulong value) 
        { 
            IdUser = userId;
            Value = value;
        }
    }
}
