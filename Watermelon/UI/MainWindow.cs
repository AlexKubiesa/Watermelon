﻿
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
    public partial class MainWindow : Form
    {
        private Stack<Card> _drawPile = new Stack<Card>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var gameWindow = new GameWindow();
            gameWindow.FormClosed += (s, args) => this.Close();
            gameWindow.Show();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

// ToDo: Have just one form for the game, but make the start menu and game window into user controls.
// ToDo: Make the start menu look pretty, with some nice styling.