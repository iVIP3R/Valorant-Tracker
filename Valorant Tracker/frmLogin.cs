using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Valorant_Tracker
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        string Username;
        string Password;
        public static Auth au { get; set; }

        private void chkPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var textBoxCollection = new[] { txtUsername, txtPassword };

            bool atleastOneTextboxEmpty = textBoxCollection
                                               .Any(t => String.IsNullOrWhiteSpace(t.Text));
            if (atleastOneTextboxEmpty == true && (string.IsNullOrEmpty(cmbRegions.Text)) || (cmbRegions.SelectedIndex == -1)) 
            {
                MessageBox.Show("Please enter all required fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Username = txtUsername.Text.Trim();
                Password = txtPassword.Text.Trim();
                region reg = region.EU;
                switch (cmbRegions.SelectedItem.ToString())
                {
                    case "Europe":
                    reg = region.EU;
                    break;
                    case "North America":
                    reg = region.NA;
                    break;
                    case "Asia Pacific":
                    reg = region.AP;
                    break;
                    case "Korea":
                    reg = region.KO;
                    break;
                }
                au = Auth.Login(Username, Password, reg);
                this.Visible = false;
                frmMain frmMain = new frmMain();
                frmMain.Show();
            }
        }
    }
}
