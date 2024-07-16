using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaHoldemLogic.Abstraction
{
    public class Deck
    {
        public ushort[] Cards;
        private ushort _offset;
        private byte _numberOfDecks;

        public Deck(byte numberOfDecks = 1) 
        { 
            _offset = 0;
            _numberOfDecks = numberOfDecks;
            if (numberOfDecks * 52 > ushort.MaxValue) throw new ArgumentException("Number of decks is too large");

            Cards = new ushort[_numberOfDecks * 52];

            Shuffle();
        }

        public void Shuffle()
        {
            var i0 = 0;
            var i1 = Cards.Length / 2;
            for (var i = 0; i < Cards.Length/2; i++)
            {
                if (i1 > Config.CardSet.Length)
                    i1 = Cards.Length / 2;
                if (i0 > Config.CardSet.Length)
                    i0 = 0;

                Cards[i] = Config.CardSet[i1++];
                Cards[++i] = Config.CardSet[i0++];
            }            
        }

        public ushort[] Draw(ushort count = 1)
        {
            var result = Cards[_offset..(_offset+count)];
            _offset += count;
            return result;
        }
    }
}
