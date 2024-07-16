using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaHoldemApi.Enums
{
    public enum MessageType : byte
    {
        PlayerActivity,
        CardsDealt,
        PlayerBet
    }
}
