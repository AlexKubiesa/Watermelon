namespace Watermelon.UI
{
    partial class GameWindow
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
            this.components = new System.ComponentModel.Container();
            this.drawGroupBox = new System.Windows.Forms.GroupBox();
            this.drawPilePictureBox = new System.Windows.Forms.PictureBox();
            this.discardGroupBox = new System.Windows.Forms.GroupBox();
            this.discardPilePictureBox = new System.Windows.Forms.PictureBox();
            this.playerHandGroupBox = new System.Windows.Forms.GroupBox();
            this.playerHandPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.playerUpDownCardsGroupBox = new System.Windows.Forms.GroupBox();
            this.playerUpDownCardsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.humanUpDownCardBox3 = new Watermelon.UI.CardSelectionBox();
            this.humanUpDownCardBox2 = new Watermelon.UI.CardSelectionBox();
            this.humanUpDownCardBox1 = new Watermelon.UI.CardSelectionBox();
            this.computerHandPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.computerHandGroupBox = new System.Windows.Forms.GroupBox();
            this.computerUpDownCardsGroupBox = new System.Windows.Forms.GroupBox();
            this.computerUpDownCardsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.computerUpDownCardPictureBox1 = new System.Windows.Forms.PictureBox();
            this.computerUpDownCardPictureBox2 = new System.Windows.Forms.PictureBox();
            this.computerUpDownCardPictureBox3 = new System.Windows.Forms.PictureBox();
            this.gameActionTimer = new System.Windows.Forms.Timer(this.components);
            this.drawGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawPilePictureBox)).BeginInit();
            this.discardGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.discardPilePictureBox)).BeginInit();
            this.playerHandGroupBox.SuspendLayout();
            this.playerUpDownCardsGroupBox.SuspendLayout();
            this.playerUpDownCardsPanel.SuspendLayout();
            this.computerHandGroupBox.SuspendLayout();
            this.computerUpDownCardsGroupBox.SuspendLayout();
            this.computerUpDownCardsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.computerUpDownCardPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerUpDownCardPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerUpDownCardPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // drawGroupBox
            // 
            this.drawGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.drawGroupBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.drawGroupBox.Controls.Add(this.drawPilePictureBox);
            this.drawGroupBox.Location = new System.Drawing.Point(299, 220);
            this.drawGroupBox.Name = "drawGroupBox";
            this.drawGroupBox.Size = new System.Drawing.Size(90, 120);
            this.drawGroupBox.TabIndex = 0;
            this.drawGroupBox.TabStop = false;
            this.drawGroupBox.Text = "Draw";
            // 
            // drawPilePictureBox
            // 
            this.drawPilePictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.drawPilePictureBox.Location = new System.Drawing.Point(6, 19);
            this.drawPilePictureBox.Name = "drawPilePictureBox";
            this.drawPilePictureBox.Size = new System.Drawing.Size(78, 95);
            this.drawPilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.drawPilePictureBox.TabIndex = 0;
            this.drawPilePictureBox.TabStop = false;
            // 
            // discardGroupBox
            // 
            this.discardGroupBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.discardGroupBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.discardGroupBox.Controls.Add(this.discardPilePictureBox);
            this.discardGroupBox.Location = new System.Drawing.Point(395, 220);
            this.discardGroupBox.Name = "discardGroupBox";
            this.discardGroupBox.Size = new System.Drawing.Size(90, 120);
            this.discardGroupBox.TabIndex = 1;
            this.discardGroupBox.TabStop = false;
            this.discardGroupBox.Text = "Discard";
            // 
            // discardPilePictureBox
            // 
            this.discardPilePictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.discardPilePictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.discardPilePictureBox.Location = new System.Drawing.Point(6, 19);
            this.discardPilePictureBox.Name = "discardPilePictureBox";
            this.discardPilePictureBox.Size = new System.Drawing.Size(78, 95);
            this.discardPilePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.discardPilePictureBox.TabIndex = 1;
            this.discardPilePictureBox.TabStop = false;
            this.discardPilePictureBox.Click += new System.EventHandler(this.DiscardPilePictureBox_Click);
            // 
            // playerHandGroupBox
            // 
            this.playerHandGroupBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.playerHandGroupBox.Controls.Add(this.playerHandPanel);
            this.playerHandGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.playerHandGroupBox.Location = new System.Drawing.Point(0, 461);
            this.playerHandGroupBox.Name = "playerHandGroupBox";
            this.playerHandGroupBox.Size = new System.Drawing.Size(784, 100);
            this.playerHandGroupBox.TabIndex = 2;
            this.playerHandGroupBox.TabStop = false;
            this.playerHandGroupBox.Text = "Player\'s Hand";
            // 
            // playerHandPanel
            // 
            this.playerHandPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.playerHandPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerHandPanel.Location = new System.Drawing.Point(3, 16);
            this.playerHandPanel.Name = "playerHandPanel";
            this.playerHandPanel.Size = new System.Drawing.Size(778, 81);
            this.playerHandPanel.TabIndex = 0;
            // 
            // playerUpDownCardsGroupBox
            // 
            this.playerUpDownCardsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerUpDownCardsGroupBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.playerUpDownCardsGroupBox.Controls.Add(this.playerUpDownCardsPanel);
            this.playerUpDownCardsGroupBox.Location = new System.Drawing.Point(216, 349);
            this.playerUpDownCardsGroupBox.Name = "playerUpDownCardsGroupBox";
            this.playerUpDownCardsGroupBox.Size = new System.Drawing.Size(352, 106);
            this.playerUpDownCardsGroupBox.TabIndex = 3;
            this.playerUpDownCardsGroupBox.TabStop = false;
            this.playerUpDownCardsGroupBox.Text = "Player\'s Up/Down Cards";
            // 
            // playerUpDownCardsPanel
            // 
            this.playerUpDownCardsPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.playerUpDownCardsPanel.ColumnCount = 3;
            this.playerUpDownCardsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.playerUpDownCardsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.playerUpDownCardsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.playerUpDownCardsPanel.Controls.Add(this.humanUpDownCardBox3, 2, 0);
            this.playerUpDownCardsPanel.Controls.Add(this.humanUpDownCardBox2, 1, 0);
            this.playerUpDownCardsPanel.Controls.Add(this.humanUpDownCardBox1, 0, 0);
            this.playerUpDownCardsPanel.Location = new System.Drawing.Point(6, 16);
            this.playerUpDownCardsPanel.Name = "playerUpDownCardsPanel";
            this.playerUpDownCardsPanel.RowCount = 1;
            this.playerUpDownCardsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.playerUpDownCardsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.playerUpDownCardsPanel.Size = new System.Drawing.Size(340, 84);
            this.playerUpDownCardsPanel.TabIndex = 0;
            // 
            // humanUpDownCardBox3
            // 
            this.humanUpDownCardBox3.BackColor = System.Drawing.Color.Transparent;
            this.humanUpDownCardBox3.CheckedColor = System.Drawing.Color.Black;
            this.humanUpDownCardBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.humanUpDownCardBox3.HoverColor = System.Drawing.Color.White;
            this.humanUpDownCardBox3.Image = null;
            this.humanUpDownCardBox3.Location = new System.Drawing.Point(229, 3);
            this.humanUpDownCardBox3.Name = "humanUpDownCardBox3";
            this.humanUpDownCardBox3.Padding = new System.Windows.Forms.Padding(4);
            this.humanUpDownCardBox3.QuickConfirm = false;
            this.humanUpDownCardBox3.Size = new System.Drawing.Size(107, 78);
            this.humanUpDownCardBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.humanUpDownCardBox3.TabIndex = 2;
            // 
            // humanUpDownCardBox2
            // 
            this.humanUpDownCardBox2.BackColor = System.Drawing.Color.Transparent;
            this.humanUpDownCardBox2.CheckedColor = System.Drawing.Color.Black;
            this.humanUpDownCardBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.humanUpDownCardBox2.HoverColor = System.Drawing.Color.White;
            this.humanUpDownCardBox2.Image = null;
            this.humanUpDownCardBox2.Location = new System.Drawing.Point(116, 3);
            this.humanUpDownCardBox2.Name = "humanUpDownCardBox2";
            this.humanUpDownCardBox2.Padding = new System.Windows.Forms.Padding(4);
            this.humanUpDownCardBox2.QuickConfirm = false;
            this.humanUpDownCardBox2.Size = new System.Drawing.Size(107, 78);
            this.humanUpDownCardBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.humanUpDownCardBox2.TabIndex = 1;
            // 
            // humanUpDownCardBox1
            // 
            this.humanUpDownCardBox1.BackColor = System.Drawing.Color.Transparent;
            this.humanUpDownCardBox1.CheckedColor = System.Drawing.Color.Black;
            this.humanUpDownCardBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.humanUpDownCardBox1.HoverColor = System.Drawing.Color.White;
            this.humanUpDownCardBox1.Image = null;
            this.humanUpDownCardBox1.Location = new System.Drawing.Point(3, 3);
            this.humanUpDownCardBox1.Name = "humanUpDownCardBox1";
            this.humanUpDownCardBox1.Padding = new System.Windows.Forms.Padding(4);
            this.humanUpDownCardBox1.QuickConfirm = false;
            this.humanUpDownCardBox1.Size = new System.Drawing.Size(107, 78);
            this.humanUpDownCardBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.humanUpDownCardBox1.TabIndex = 0;
            // 
            // computerHandPanel
            // 
            this.computerHandPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.computerHandPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.computerHandPanel.Location = new System.Drawing.Point(3, 16);
            this.computerHandPanel.Name = "computerHandPanel";
            this.computerHandPanel.Size = new System.Drawing.Size(778, 81);
            this.computerHandPanel.TabIndex = 0;
            // 
            // computerHandGroupBox
            // 
            this.computerHandGroupBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.computerHandGroupBox.Controls.Add(this.computerHandPanel);
            this.computerHandGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.computerHandGroupBox.Location = new System.Drawing.Point(0, 0);
            this.computerHandGroupBox.Name = "computerHandGroupBox";
            this.computerHandGroupBox.Size = new System.Drawing.Size(784, 100);
            this.computerHandGroupBox.TabIndex = 4;
            this.computerHandGroupBox.TabStop = false;
            this.computerHandGroupBox.Text = "Computer\'s Hand";
            // 
            // computerUpDownCardsGroupBox
            // 
            this.computerUpDownCardsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.computerUpDownCardsGroupBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.computerUpDownCardsGroupBox.Controls.Add(this.computerUpDownCardsPanel);
            this.computerUpDownCardsGroupBox.Location = new System.Drawing.Point(216, 107);
            this.computerUpDownCardsGroupBox.Name = "computerUpDownCardsGroupBox";
            this.computerUpDownCardsGroupBox.Size = new System.Drawing.Size(352, 106);
            this.computerUpDownCardsGroupBox.TabIndex = 4;
            this.computerUpDownCardsGroupBox.TabStop = false;
            this.computerUpDownCardsGroupBox.Text = "Computer\'s Up/Down Cards";
            // 
            // computerUpDownCardsPanel
            // 
            this.computerUpDownCardsPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.computerUpDownCardsPanel.ColumnCount = 3;
            this.computerUpDownCardsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.computerUpDownCardsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.computerUpDownCardsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.computerUpDownCardsPanel.Controls.Add(this.computerUpDownCardPictureBox1, 0, 0);
            this.computerUpDownCardsPanel.Controls.Add(this.computerUpDownCardPictureBox2, 1, 0);
            this.computerUpDownCardsPanel.Controls.Add(this.computerUpDownCardPictureBox3, 2, 0);
            this.computerUpDownCardsPanel.Location = new System.Drawing.Point(6, 16);
            this.computerUpDownCardsPanel.Name = "computerUpDownCardsPanel";
            this.computerUpDownCardsPanel.RowCount = 1;
            this.computerUpDownCardsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.computerUpDownCardsPanel.Size = new System.Drawing.Size(340, 84);
            this.computerUpDownCardsPanel.TabIndex = 0;
            // 
            // computerUpDownCardPictureBox1
            // 
            this.computerUpDownCardPictureBox1.Location = new System.Drawing.Point(3, 3);
            this.computerUpDownCardPictureBox1.Name = "computerUpDownCardPictureBox1";
            this.computerUpDownCardPictureBox1.Size = new System.Drawing.Size(107, 78);
            this.computerUpDownCardPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.computerUpDownCardPictureBox1.TabIndex = 0;
            this.computerUpDownCardPictureBox1.TabStop = false;
            // 
            // computerUpDownCardPictureBox2
            // 
            this.computerUpDownCardPictureBox2.Location = new System.Drawing.Point(116, 3);
            this.computerUpDownCardPictureBox2.Name = "computerUpDownCardPictureBox2";
            this.computerUpDownCardPictureBox2.Size = new System.Drawing.Size(107, 78);
            this.computerUpDownCardPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.computerUpDownCardPictureBox2.TabIndex = 1;
            this.computerUpDownCardPictureBox2.TabStop = false;
            // 
            // computerUpDownCardPictureBox3
            // 
            this.computerUpDownCardPictureBox3.Location = new System.Drawing.Point(229, 3);
            this.computerUpDownCardPictureBox3.Name = "computerUpDownCardPictureBox3";
            this.computerUpDownCardPictureBox3.Size = new System.Drawing.Size(108, 78);
            this.computerUpDownCardPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.computerUpDownCardPictureBox3.TabIndex = 2;
            this.computerUpDownCardPictureBox3.TabStop = false;
            // 
            // gameActionTimer
            // 
            this.gameActionTimer.Interval = 300;
            this.gameActionTimer.Tick += new System.EventHandler(this.GameActionTimer_Tick);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.computerUpDownCardsGroupBox);
            this.Controls.Add(this.computerHandGroupBox);
            this.Controls.Add(this.playerUpDownCardsGroupBox);
            this.Controls.Add(this.playerHandGroupBox);
            this.Controls.Add(this.discardGroupBox);
            this.Controls.Add(this.drawGroupBox);
            this.Name = "GameWindow";
            this.Text = "Watermelon";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.drawGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.drawPilePictureBox)).EndInit();
            this.discardGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.discardPilePictureBox)).EndInit();
            this.playerHandGroupBox.ResumeLayout(false);
            this.playerUpDownCardsGroupBox.ResumeLayout(false);
            this.playerUpDownCardsPanel.ResumeLayout(false);
            this.computerHandGroupBox.ResumeLayout(false);
            this.computerUpDownCardsGroupBox.ResumeLayout(false);
            this.computerUpDownCardsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.computerUpDownCardPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerUpDownCardPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.computerUpDownCardPictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox drawGroupBox;
        private System.Windows.Forms.GroupBox discardGroupBox;
        private System.Windows.Forms.PictureBox drawPilePictureBox;
        private System.Windows.Forms.GroupBox playerHandGroupBox;
        private System.Windows.Forms.FlowLayoutPanel playerHandPanel;
        private System.Windows.Forms.PictureBox discardPilePictureBox;
        private System.Windows.Forms.GroupBox playerUpDownCardsGroupBox;
        private System.Windows.Forms.TableLayoutPanel playerUpDownCardsPanel;
        private System.Windows.Forms.FlowLayoutPanel computerHandPanel;
        private System.Windows.Forms.GroupBox computerHandGroupBox;
        private System.Windows.Forms.GroupBox computerUpDownCardsGroupBox;
        private System.Windows.Forms.TableLayoutPanel computerUpDownCardsPanel;
        private System.Windows.Forms.PictureBox computerUpDownCardPictureBox1;
        private System.Windows.Forms.PictureBox computerUpDownCardPictureBox2;
        private System.Windows.Forms.PictureBox computerUpDownCardPictureBox3;
        private System.Windows.Forms.Timer gameActionTimer;
        private CardSelectionBox humanUpDownCardBox3;
        private CardSelectionBox humanUpDownCardBox2;
        private CardSelectionBox humanUpDownCardBox1;
    }
}