namespace Watermelon.UI
{
    partial class GameBoardInformationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameBoardInformationForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cardHistoryListView = new System.Windows.Forms.ListView();
            this.cardColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playerColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.headingLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel1.Controls.Add(this.cardHistoryListView);
            this.panel1.Controls.Add(this.headingLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 261);
            this.panel1.TabIndex = 0;
            // 
            // cardHistoryListView
            // 
            this.cardHistoryListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardHistoryListView.BackColor = System.Drawing.Color.SteelBlue;
            this.cardHistoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cardColumnHeader,
            this.playerColumnHeader});
            this.cardHistoryListView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardHistoryListView.Location = new System.Drawing.Point(12, 36);
            this.cardHistoryListView.Name = "cardHistoryListView";
            this.cardHistoryListView.Size = new System.Drawing.Size(260, 213);
            this.cardHistoryListView.TabIndex = 3;
            this.cardHistoryListView.UseCompatibleStateImageBehavior = false;
            this.cardHistoryListView.View = System.Windows.Forms.View.Details;
            // 
            // cardColumnHeader
            // 
            this.cardColumnHeader.Text = "Card";
            this.cardColumnHeader.Width = 141;
            // 
            // playerColumnHeader
            // 
            this.playerColumnHeader.Text = "Player";
            this.playerColumnHeader.Width = 104;
            // 
            // headingLabel
            // 
            this.headingLabel.BackColor = System.Drawing.Color.MidnightBlue;
            this.headingLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headingLabel.ForeColor = System.Drawing.Color.White;
            this.headingLabel.Location = new System.Drawing.Point(0, 0);
            this.headingLabel.Name = "headingLabel";
            this.headingLabel.Size = new System.Drawing.Size(281, 33);
            this.headingLabel.TabIndex = 1;
            this.headingLabel.Text = "Cards on Discard Pile";
            this.headingLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // GameBoardInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameBoardInformationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Game Info";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label headingLabel;
        private System.Windows.Forms.ListView cardHistoryListView;
        private System.Windows.Forms.ColumnHeader cardColumnHeader;
        private System.Windows.Forms.ColumnHeader playerColumnHeader;
    }
}