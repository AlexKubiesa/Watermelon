using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watermelon.UI
{
    public partial class MainMenu : UserControl
    {
        public GameBoard GameBoard
        {
            get { return _gameBoard; }
            set { _gameBoard = value; }
        }

        private GameBoard _gameBoard;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _gameBoard.Visible = true;
            _gameBoard.Enabled = true;
            Visible = false;
            Enabled = false;
        }
    }
}
