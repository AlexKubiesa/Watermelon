using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay
{
    internal class GameSettings
    {
        public GameDifficulty Difficulty { get; set; }

        public int NumberOfComputerPlayers { get; set; }

        public int NumberOfHumanPlayers { get; set; }
    }
}
