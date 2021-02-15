using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseDates.Model;
using DataBaseDates.Controller;

namespace DataBaseDates.View
{
    public partial class CheckPassword : Form
    {
        Query controller;

        public CheckPassword()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);

        }
        private void visible_CheckedChanged(object sender, EventArgs e)
        {
            if (visible.Checked)
                password.UseSystemPasswordChar = false;
            else
                password.UseSystemPasswordChar = true;
        }

        private void no_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void yes_Click(object sender, EventArgs e)
        {
            if (controller.CorrectPassword(password.Text, controller.GetUser()))
            {
                Loading loading = new Loading();
                loading.Show();
                ChangeInfo changeInfo = new ChangeInfo();
                changeInfo.Show();
                controller.CloseProgram("tempPartner");
                foreach (Form f in Application.OpenForms)
                {
                    if (!(f is ChangeInfo))
                        f.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неправильний пароль!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
