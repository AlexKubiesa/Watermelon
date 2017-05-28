using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watermelon.Gameplay;

namespace Watermelon.UI
{
    public partial class DifficultyMenu : UserControl
    {
        private const string NOT_IMPLEMENTED_MESSAGE = "Not implemented yet. Stay tuned!";

        public GameBoard GameBoard { get => _gameBoard; set => _gameBoard = value; }

        private GameBoard _gameBoard;

        public DifficultyMenu()
        {
            InitializeComponent();
        }

        private void DifficultyMenu_Load(object sender, EventArgs e)
        {
            toolTip.SetToolTip(hardButton, NOT_IMPLEMENTED_MESSAGE);
        }

        private void EasyButton_Click(object sender, EventArgs e)
        {
            OnDifficultyChosen(new GameDifficultyEventArgs(GameDifficulty.Easy));
        }

        private void MediumButton_Click(object sender, EventArgs e)
        {
            OnDifficultyChosen(new GameDifficultyEventArgs(GameDifficulty.Medium));
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NOT_IMPLEMENTED_MESSAGE, "Not implemented", MessageBoxButtons.OK);
            hardButton.Enabled = false;
        }

        internal virtual void OnDifficultyChosen(GameDifficultyEventArgs e)
        {
            DifficultyChosen?.Invoke(this, e);
        }

        public event EventHandler<GameDifficultyEventArgs> DifficultyChosen;
    }
}