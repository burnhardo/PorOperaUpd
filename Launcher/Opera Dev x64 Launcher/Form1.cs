﻿using System;
using System.Windows.Forms;

namespace Opera_Dev_x64_Launcher
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                System.IO.File.WriteAllText(@"Opera Dev x64\Profile.txt", "--user-data-dir=\"profile\"");
                this.Close();
            }
            if (radioButton2.Checked)
            {
                System.IO.File.WriteAllText(@"Opera Dev x64\Profile.txt", "--user-data-dir=\"Opera Dev x64\\profile\"");
                this.Close();
            }
            if (radioButton3.Checked)
            {
                System.IO.File.WriteAllText(@"Opera Dev x64\Profile.txt", "");
                this.Close();
            }
        }
    }
}