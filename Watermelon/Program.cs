using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Watermelon.UI;
using Watermelon.ResourceManagement;

namespace Watermelon
{
    static class Program
    {
        public static string ImageDirectory
        {
            get { return _imageDirectory; }
        }

        private static string _imageDirectory = Directory.GetCurrentDirectory() + @"\Images\Playing Cards\";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CardImageHandler.Initialise();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
