using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Watermelon;
using Watermelon.UI;

namespace Watermelon_PlayTesting
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GameWindow gameWindow = new GameWindow();
            Form1 playtestTools = new Form1(gameWindow);
            gameWindow.AddOwnedForm(playtestTools);
            gameWindow.Load += new EventHandler(delegate { playtestTools.Show(); });

            Application.Run(gameWindow);
        }
    }
}
