namespace Watermelon.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new Watermelon.UI.MainMenu();
            this.difficultyMenu = new Watermelon.UI.DifficultyMenu();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mainMenu.DifficultyMenu = this.difficultyMenu;
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(784, 561);
            this.mainMenu.TabIndex = 0;
            // 
            // difficultyMenu
            // 
            this.difficultyMenu.BackColor = System.Drawing.Color.WhiteSmoke;
            this.difficultyMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.difficultyMenu.Location = new System.Drawing.Point(0, 0);
            this.difficultyMenu.Name = "difficultyMenu";
            this.difficultyMenu.Size = new System.Drawing.Size(784, 561);
            this.difficultyMenu.TabIndex = 2;
            this.difficultyMenu.DifficultyChosen += new System.EventHandler<GameDifficultyEventArgs>(this.DifficultyMenu_DifficultyChosen);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.difficultyMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Watermelon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private MainMenu mainMenu;
        private DifficultyMenu difficultyMenu;
    }
}