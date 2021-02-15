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
    public partial class ChangeAccount : Form
    {
        Query controller;
        public ChangeAccount()
        {
            InitializeComponent();
            controller = new Query(ConnectionString.ConnStr);
        }

        private void yes_Click(object sender, EventArgs e)
        {
            if (controller.CorrectProfile())
            {
                Partner partner = new Partner();
                controller.AddHuman("", "", "", "", DateTime.Today, 1, 1, 1, 1, "", 1, 1, 1, "", DateTime.Today,
                    1, 1, 1, 1, 1, "", false, false, "");
                controller.AddPartner(0, 0, 0, 0, 0, 0);
                controller.AddSmokingPartner(partner.Smoking);
                controller.AddAlcoholPartner(partner.Alcohol);
                controller.AddSexPartner(partner.Sex);
                controller.AddReligiounPartner(partner.Religioun);
                controller.AddPoliticalPartner(partner.Political);
                controller.AddHairPartner(partner.Hair);
                controller.AddEyesPartner(partner.Eyes);
                controller.AddEducationPartner(partner.Education);
                controller.Remove();
            }
            controller.CloseProgram();
            controller.CloseProgram("tempPartner");
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            foreach (Form f in Application.OpenForms)
            {
                if (!(f is LoginForm))
                    f.Hide();
            }
        }

        private void no_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
