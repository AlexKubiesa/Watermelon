using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay.Players
{
    sealed class HumanPlayer : Player
    {
        public HumanPlayer(string name, Game game) : base(name, game)
        {
        }
    }
}