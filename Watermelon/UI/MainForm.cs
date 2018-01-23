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
        private GameSettings gameSettings;

        private DifficultyMenu difficultyMenu;
        private GameBoardControl gameBoardControl;

        public MainForm()
        {
            InitializeComponent();

            gameSettings = new GameSettings();

            SuspendLayout();

            difficultyMenu = new DifficultyMenu(gameSettings)
            {
                Visible = false,
                BackColor = Color.WhiteSmoke,
                Dock = DockStyle.Fill
            };

            difficultyMenu.Confirmed += DifficultyMenu_Confirmed;

            Controls.Add(difficultyMenu);

            gameBoardControl = new GameBoardControl(gameSettings)
            {
                BackColor = Color.WhiteSmoke,
                Dock = DockStyle.Fill,
                Visible = false
            };

            Controls.Add(gameBoardControl);

            ResumeLayout();
        }

        private void MainMenu_Confirmed(object sender, EventArgs e)
        {
            var menu = sender as MainMenu;

            difficultyMenu.Visible = true;
            menu.Visible = false;
        }

        private void DifficultyMenu_Confirmed(object sender, EventArgs e)
        {
            var menu = sender as DifficultyMenu;

            gameBoardControl.Visible = true;
            menu.Visible = false;

            gameBoardControl.StartGame();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameBoardControl.Enabled)
            {
                gameBoardControl.ProcessKeyDown(sender, e);
            }
        }
    }
}