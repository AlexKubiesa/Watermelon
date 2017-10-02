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
        private IList<Card> discardPile;

        public GameBoardInformationForm(IEnumerable<Card> discardPile)
        {
            InitializeComponent();
            this.discardPile = discardPile.ToList();
        }

        private DataTable DataTableFromDiscardPile(IList<Card> discardPile)
        {
            DataTable table = new DataTable();

            var column = new DataColumn
            {
                DataType = typeof(string),
                ReadOnly = true,
                ColumnName = "Card Summary"
            };
            table.Columns.Add(column);

            foreach (Card c in discardPile)
            {
                table.Rows.Add("Some card here.");
            }

            return table;
        }

        private void GameBoardInformationForm_Load(object sender, EventArgs e)
        {
            discardPileBindingSource.DataSource = DataTableFromDiscardPile(discardPile);
            //dataGridView1.Columns.GetFirstColumn(DataGridViewElementStates.None).DataPropertyName = "Card Summary";
        }
    }
}
