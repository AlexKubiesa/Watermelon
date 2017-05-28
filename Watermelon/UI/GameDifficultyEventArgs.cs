using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermelon.Gameplay;

namespace Watermelon.UI
{
    public class GameDifficultyEventArgs : EventArgs
    {
        internal GameDifficulty Difficulty { get => _difficulty; }

        private GameDifficulty _difficulty;

        internal GameDifficultyEventArgs(GameDifficulty difficulty)
        {
            _difficulty = difficulty;
        }
    }
}
