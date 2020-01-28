﻿using System.Windows.Forms;

namespace Opera_Launcher
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            if (radioButton1.Checked)
            {
                System.IO.File.WriteAllText(@"Opera\Profile.txt", "--user-data-dir=\"profile\"");
                this.Close();
            }
            if (radioButton2.Checked)
            {
                System.IO.File.WriteAllText(@"Opera\Profile.txt", "--user-data-dir=\"Opera\\profile\"");
                this.Close();
            }
            if (radioButton3.Checked)
            {
                System.IO.File.WriteAllText(@"Opera\Profile.txt", "");
                this.Close();
            }
        }
    }
}
