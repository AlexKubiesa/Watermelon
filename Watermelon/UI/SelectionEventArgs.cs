using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watermelon.UI
{
    public delegate void SelectionEventHandler(object sender, SelectionEventArgs e);

    public class SelectionEventArgs : EventArgs
    {
        public IEnumerable<Control> Selection { get; }

        public SelectionEventArgs(IEnumerable<Control> selection)
        {
            Selection = selection;
        }

        public SelectionEventArgs(Control item)
        {
            Selection = new List<Control>() { item };
        }
    }
}
