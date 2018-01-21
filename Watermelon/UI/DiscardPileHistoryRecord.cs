using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermelon.Gameplay;
using Watermelon.Gameplay.Players;

namespace Watermelon.UI
{
    public class DiscardPileHistoryRecord
    {
        public Card Card { get; set; }

        internal Player Player { get; set; }
    }
}
