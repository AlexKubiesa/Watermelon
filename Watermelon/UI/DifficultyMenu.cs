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
        private GameSettings gameSettings;

        /// <summary>
        /// Provided for designer support.
        /// </summary>
        public DifficultyMenu() : this(new GameSettings())
        {
        }

        internal DifficultyMenu(GameSettings gameSettings)
        {
            InitializeComponent();

            this.gameSettings = gameSettings;
        }

        private void EasyButton_Click(object sender, EventArgs e)
        {
            gameSettings.Difficulty = GameDifficulty.Easy;
            OnConfirmed(EventArgs.Empty);
        }

        private void MediumButton_Click(object sender, EventArgs e)
        {
            gameSettings.Difficulty = GameDifficulty.Medium;
            OnConfirmed(EventArgs.Empty);
        }

        private void HardButton_Click(object sender, EventArgs e)
        {
            gameSettings.Difficulty = GameDifficulty.Hard;
            OnConfirmed(EventArgs.Empty);
        }

        internal virtual void OnConfirmed(EventArgs e)
        {
            Confirmed?.Invoke(this, e);
        }

        public event EventHandler Confirmed;
    }
}