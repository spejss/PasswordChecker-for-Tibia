﻿using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace PasswordChecker
{
    public partial class CheckerForm : Form
    {
        public CheckerForm()
        {
            InitializeComponent();
        }

        private void check_Click(object sender, EventArgs e)
        {
            Process Tibia = null;
            try
            {
                Tibia = Process.GetProcessesByName("Tibia")[0];
                UInt32 Base = (UInt32)Tibia.MainModule.BaseAddress.ToInt32();
                IntPtr Handle = Tibia.Handle;
                Checker Checker = new Checker();
                login.Text = Checker.findLogin(Base, Handle);
                password.Text = Checker.findPassword(Base, Handle);
            }
            catch(IndexOutOfRangeException exception)
            {
                login.Text = "Run Tibia first and login!";
                password.Text = "Run Tibia first and login!";
            }
        }
    }
}
