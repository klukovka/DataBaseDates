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
    public partial class GoToArchive : Form
    {
        Query controller;

        public GoToArchive()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);

        }

        private void no_Click(object sender, EventArgs e)
        {
            this.Hide();
            controller.CloseProgram("tempPartner");
        }

        private void yes_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            Couple couple = new Couple(controller.GetUser(), controller.GetUser("tempPartner"));
            controller.ToArchive(couple.First.Id);
            controller.ToArchive(couple.Second.Id);
            controller.AddArchive(couple);
            controller.RemoveInvitation(true, controller.GetUser());
            controller.RemoveInvitation(true, controller.GetUser("tempPartner"));
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
