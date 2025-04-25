using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wave_Priject
{
    public partial class frmWave: Form
    {
        public frmWave()
        {
            InitializeComponent();
            LoginManager = new LoginManage();
        }

        private readonly LoginManage LoginManager;


        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginManager.UsernameValidation(txtUsername.Text))
            {
                if (LoginManager.PasswordValidation(txtPassword.Text))
                {
                    Form frm = new frmWaveOrder();
                    frm.Show();
                    this.Hide();  // this only hide the form it closes with the event of frmWaveOrder closing

                }

                else
                {
                    txtPassword.Focus();
                    errorProvider1.SetError(txtPassword, "Wrong Password");
                }
            }

            else 
            {
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Wrong Username");
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsername.Text))
            {
                e.Cancel = true;
                txtUsername.Focus();
                errorProvider1.SetError(txtUsername, "Username must be filled");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUsername, "");
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                txtPassword.Focus();
                errorProvider1.SetError(txtPassword, "Username must be filled");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void frmWave_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void frmWave_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    button1_Click(sender, e);
                    break;

                case Keys.Escape :
                    this.Close();
                    break;

            }
           


        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
