﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.IO;

namespace Opera_Launcher
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo culture1 = CultureInfo.CurrentUICulture;
            string applicationPath = Application.StartupPath;
            if (File.Exists(applicationPath + "\\Opera\\opera.exe"))
            {
                var sb = new System.Text.StringBuilder();
                string[] CommandLineArgs = Environment.GetCommandLineArgs();
                for (int i = 1; i < CommandLineArgs.Length; i++)
                {
                    if (CommandLineArgs[i].Contains("="))
                    {
                        if (CommandLineArgs[i].Contains("LinkID"))
                        {
                            sb.Append(" " + CommandLineArgs[i]);
                        }
                        else if (CommandLineArgs[i].Contains("http"))
                        {
                            sb.Append(" \"" + CommandLineArgs[i] + "\"");
                        }
                        else
                        {
                            string[] test = CommandLineArgs[i].Split(new char[] { '=' }, 2);
                            sb.Append(" " + test[0] + "=\"" + test[1] + "\"");
                        }
                    }
                    else if (CommandLineArgs[i].Contains(".pdf"))
                    {
                        sb.Append(" \"" + CommandLineArgs[i] + "\"");
                    }
                    else
                    {
                        sb.Append(" " + CommandLineArgs[i]);
                    }
                }
                if (!File.Exists(applicationPath + "\\Opera\\Profile.txt"))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                    string Arguments = File.ReadAllText(applicationPath + "\\Opera\\Profile.txt") + sb.ToString();
                    if (Arguments.Contains("--user-data-dir="))
                    {
                        string[] Arguments2 = Arguments.Split(new char[] { '=' }, 2);
                        string Arguments3 = Arguments2[0] + "=\"" + applicationPath + "\\" + Arguments2[1].Remove(0, 1);
                        Process.Start(applicationPath + "\\Opera\\opera.exe", Arguments3);
                    }
                    else
                    {
                        Process.Start(applicationPath + "\\Opera\\opera.exe", Arguments);
                    }
                }
                else
                {
                    string Arguments = File.ReadAllText(applicationPath + "\\Opera\\Profile.txt") + sb.ToString();
                    if (Arguments.Contains("--user-data-dir="))
                    {
                        string[] Arguments2 = Arguments.Split(new char[] { '=' }, 2);
                        string Arguments3 = Arguments2[0] + "=\"" + applicationPath + "\\" + Arguments2[1].Remove(0, 1);
                        Process.Start(applicationPath + "\\Opera\\opera.exe", Arguments3);
                    }
                    else
                    {
                        Process.Start(applicationPath + "\\Opera\\opera.exe", Arguments);
                    }
                }
            }
            else if (culture1.TwoLetterISOLanguageName == "de")
            {
                MessageBox.Show("Opera ist nicht installiert", "Opera Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (culture1.TwoLetterISOLanguageName == "ru")
            {
                MessageBox.Show("Opera Portable не найден", "Opera Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Opera is not installed", "Opera Launcher", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
