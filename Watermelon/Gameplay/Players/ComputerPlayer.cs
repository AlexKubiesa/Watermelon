using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay.Players
{
    abstract class ComputerPlayer : Player
    {
        public static ComputerPlayer Create(Game game)
        {
            switch (game.Difficulty)
            {
                case GameDifficulty.Easy:
                    return new EasyComputerPlayer(game);

                case GameDifficulty.Medium:
                    return new MediumComputerPlayer(game);

                case GameDifficulty.Hard:
                    throw new NotImplementedException();

                default:
                    return new EasyComputerPlayer(game);
            }
        }

        protected ComputerPlayer(Game game) : base(game)
        { }

        public abstract override void BeginTurn();
    }
}
