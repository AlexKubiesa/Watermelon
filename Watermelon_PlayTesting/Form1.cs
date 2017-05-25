using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watermelon;
using Watermelon.UI;
using Watermelon.Gameplay;
using System.Reflection;

namespace Watermelon_PlayTesting
{
    public partial class Form1 : Form
    {
        private GameWindow _gameWindow;
        private Game _game;

        public Form1(GameWindow gameWindow)
        {
            InitializeComponent();

            _gameWindow = gameWindow;

            _game = _gameWindow.Game;
        }

        private void drawPileThreesButton_Click(object sender, EventArgs e)
        {
            _game.Cheat_ConvertDrawPileToThrees();
        }

        private void findATenButton_Click(object sender, EventArgs e)
        {
            _game.Cheat_PullATenOutOfSleeve();
        }
    }
}
