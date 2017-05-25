namespace Watermelon_PlayTesting
{
    partial class Form1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.findATenButton = new System.Windows.Forms.Button();
            this.drawPileThreesButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.findATenButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.drawPileThreesButton, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(90, 81);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(251, 119);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(3, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "Replace Computer Cards with 4 of Clubs";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // findATenButton
            // 
            this.findATenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.findATenButton.Location = new System.Drawing.Point(128, 3);
            this.findATenButton.Name = "findATenButton";
            this.findATenButton.Size = new System.Drawing.Size(120, 53);
            this.findATenButton.TabIndex = 1;
            this.findATenButton.Text = "Pull a 10 out of Sleeve";
            this.findATenButton.UseVisualStyleBackColor = true;
            this.findATenButton.Click += new System.EventHandler(this.findATenButton_Click);
            // 
            // drawPileThreesButton
            // 
            this.drawPileThreesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawPileThreesButton.Location = new System.Drawing.Point(3, 3);
            this.drawPileThreesButton.Name = "drawPileThreesButton";
            this.drawPileThreesButton.Size = new System.Drawing.Size(119, 53);
            this.drawPileThreesButton.TabIndex = 0;
            this.drawPileThreesButton.Text = "Replace Draw Pile with Threes";
            this.drawPileThreesButton.UseVisualStyleBackColor = true;
            this.drawPileThreesButton.Click += new System.EventHandler(this.drawPileThreesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 284);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Playtest Tools";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button drawPileThreesButton;
        private System.Windows.Forms.Button findATenButton;
        private System.Windows.Forms.Button button1;
    }
}

