﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PegBoard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Board b;
            for (int i = 0; i < 15; i++)
            {
                b = new Board(i);
                display.Text += b.Solve() + "\r\n\r\n\r\n";
            }
        }

        private void display_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
