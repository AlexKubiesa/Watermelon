using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay.Players
{
    abstract class ComputerPlayer : Player
    {
        public static ComputerPlayer Create(string name, Game game)
        {
            switch (game.Difficulty)
            {
                case GameDifficulty.Easy:
                    return new EasyComputerPlayer(name, game);

                case GameDifficulty.Medium:
                    return new MediumComputerPlayer(name, game);

                case GameDifficulty.Hard:
                    throw new NotImplementedException();

                default:
                    return new EasyComputerPlayer(name, game);
            }
        }

        protected ComputerPlayer(string name, Game game) : base(name, game)
        {
        }

        public override void BeginTurn()
        {
            base.BeginTurn();
        }
    }
}
