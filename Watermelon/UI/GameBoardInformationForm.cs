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
    public partial class GameBoardInformationForm : Form
    {
        public GameBoardInformationForm(IEnumerable<Card> discardPile)
        {
            InitializeComponent();
            FillCardHistoryListView(discardPile);
        }

        private void FillCardHistoryListView(IEnumerable<Card> discardPile)
        {
            cardHistoryListView.Items.AddRange(discardPile.Select(CreateListViewItem).ToArray());
        }

        private ListViewItem CreateListViewItem(Card card)
        {
            var str = new CardConverter().ConvertToString(card);
            return new ListViewItem(str);
        }
    }
}
