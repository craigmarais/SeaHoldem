using SeaHoldemApi.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaHoldemApi.Responses
{
    public class CardSet
    {
        public CardType CardType { get; set; }
        public Card[] Cards { get; set; }

        public CardSet()
        {
        }
    }

    public class Card
    {
        public ushort Id { get; set; }
        public bool Show { get; set; }
        public Card()
        { }
    }
}
