using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Gameplay.Players
{
    abstract class ComputerPlayer : Player
    {
        public static ComputerPlayer Create(string name, GameDifficulty difficulty)
        {
            switch (difficulty)
            {
                case GameDifficulty.Easy:
                    return new EasyComputerPlayer(name);

                case GameDifficulty.Medium:
                    return new MediumComputerPlayer(name);

                case GameDifficulty.Hard:
                    throw new NotImplementedException();

                default:
                    return new EasyComputerPlayer(name);
            }
        }

        protected ComputerPlayer(string name) : base(name)
        {
        }

        public override void BeginTurn()
        {
            base.BeginTurn();
        }
    }
}
