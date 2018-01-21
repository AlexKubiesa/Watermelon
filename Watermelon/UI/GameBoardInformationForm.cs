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
        public GameBoardInformationForm(IEnumerable<DiscardPileHistoryRecord> history)
        {
            InitializeComponent();
            FillCardHistoryListView(history);
        }

        private void FillCardHistoryListView(IEnumerable<DiscardPileHistoryRecord> history)
        {
            cardHistoryListView.Items.AddRange(history.Select(CreateListViewItem).ToArray());
        }

        private ListViewItem CreateListViewItem(DiscardPileHistoryRecord historyRecord)
        {
            var subItemStrings = new string[2];
            subItemStrings[0] = new CardConverter().ConvertToString(historyRecord.Card);
            subItemStrings[1] = historyRecord.Player.ToString();
            return new ListViewItem(subItemStrings);
        }
    }
}
