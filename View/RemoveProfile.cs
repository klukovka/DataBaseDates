using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseDates.Controller;
using DataBaseDates.Model;

namespace DataBaseDates.View
{
    public partial class RemoveProfile : Form
    {
        Query controller;

        public RemoveProfile()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);

        }

        private void no_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void yes_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            controller.RemoveInvitation(false, controller.GetUser());
            controller.Remove();
            controller.CloseProgram();
            controller.CloseProgram("tempPartner");
            foreach (Form f in Application.OpenForms)
            {
                if (!(f is LoginForm))
                    f.Hide();
            }
        }
    }
}
