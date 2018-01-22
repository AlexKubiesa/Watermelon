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
        public DifficultyMenu DifficultyMenu
        {
            get { return _difficultyMenu; }
            set { _difficultyMenu = value; }
        }

        private DifficultyMenu _difficultyMenu;

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
            OnConfirmed(EventArgs.Empty);
        }

        protected virtual void OnConfirmed(EventArgs e)
        {
            Confirmed?.Invoke(this, e);
        }

        public event EventHandler Confirmed;
    }
}
