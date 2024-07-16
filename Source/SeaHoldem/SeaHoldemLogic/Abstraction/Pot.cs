using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaHoldemLogic.Abstraction
{
    public class Pot
    {
        private ulong _potValue;
        private Dictionary<int, ulong> _playerChips = new();

        public void AddPlayerBet(int playerId, ulong value)
        {
            _potValue += value;
            _playerChips.TryAdd(playerId, 0);
            _playerChips[playerId] += value;
        }
    }
}
