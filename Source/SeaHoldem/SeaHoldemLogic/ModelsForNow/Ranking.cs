using SeaHoldemLogic.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaHoldemLogic.ModelsForNow
{
    public class Ranking
    {
        public Rank Rank { get; set; }
        public string Formula { get; set; }

        public Ranking(Rank rank, string formula)
        {
            Rank = rank;
            Formula = formula;
        }
    }
}
