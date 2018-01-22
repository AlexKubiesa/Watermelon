using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watermelon.Gameplay;

namespace Watermelon.UI
{
    public partial class MainForm : Form
    {
        private GameBoardControl _gameBoard;

        private GameSettings _gameSettings;

        public MainForm()
        {
            InitializeComponent();

            _gameSettings = new GameSettings();
        }

        private void MainMenu_StartButtonClicked(object sender, EventArgs e)
        {
            var menu = sender as MainMenu;

            menu.Enabled = false;
            difficultyMenu.Visible = true;
            menu.Visible = false;
            difficultyMenu.Enabled = true;
        }

        private void DifficultyMenu_DifficultyChosen(object sender, GameDifficultyEventArgs e)
        {
            var menu = sender as DifficultyMenu;

            menu.Enabled = false;

            SuspendLayout();
            _gameBoard = new GameBoardControl()
            {
                BackColor = Color.WhiteSmoke,
                Dock = DockStyle.Fill,
                Enabled = false,
                GameDifficulty = e.Difficulty,
                Location = new Point(0, 0),
                Name = "_gameBoard",
                Size = new Size(784, 561),
                TabIndex = 1,
                Visible = false
            };

            Controls.Add(_gameBoard);
            ResumeLayout();

            _gameBoard.Visible = true;
            menu.Visible = false;

            _gameBoard.StartGame();
            _gameBoard.Enabled = true;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_gameBoard.Enabled)
            {
                _gameBoard.ProcessKeyDown(sender, e);
            }
        }
    }
}