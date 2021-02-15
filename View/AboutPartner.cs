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
    public partial class AboutPartner : Form
    {
        Query controller;
        Method method = new Method();

        public AboutPartner()
        {
            InitializeComponent();
            this.Size = new Size(800, 570);

            controller = new Query(ConnectionString.ConnStr);
            int index = controller.GetUser();
            string table = "Partner";
            Partner partner = method.GetPartner(table, index, controller);
            minAge.Text = partner.MinAge.ToString();
            maxAge.Text = partner.MaxAge.ToString();
            minHeight.Text = partner.MinHeight.ToString();
            maxHeight.Text = partner.MaxHeight.ToString();
            minWeight.Text = partner.MinWeight.ToString();
            maxWeight.Text = partner.MaxWeight.ToString();
            sex.Text = partner.Sex.GetSex();
            education.Text = partner.Education.GetEducation();
            religioun.Text = partner.Religioun.GetReligioun();
            eyes.Text = partner.Eyes.GetEyes();
            hair.Text = partner.Hair.GetHair();
            polit.Text = partner.Political.GetPolitical();
            smoking.Text = partner.Smoking.GetSmoking();
            alcohol.Text = partner.Alcohol.GetAlcohol();

            method.CloseLoading();
        }

        private void meButton_Click(object sender, EventArgs e)
        {
            method.MeButtonClick(sender, e, this);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            method.ExitButtonClick(sender, e);
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            method.ChangeColorMouseLeave(sender, e, exitButton);
        }

        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            method.ChangeColorMouseEnter(sender, e, exitButton);
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            method.MainPanelMouseMove(sender, e, this);
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            method.MainPanelMouseDown(sender, e);
        }

        private void baseButton_Click(object sender, EventArgs e)
        {
            method.BaseButtonClick(sender, e, this);
        }

        private void search_Click(object sender, EventArgs e)
        {
            method.SearchClick(sender, e, this);
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            method.ChangeButtonClick(sender, e);
        }

        private void invButton_Click(object sender, EventArgs e)
        {
            method.InvButtonClick(sender, e, this);
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            method.ArchiveButtonClick(sender, e, this);
        }

        private void partnerButton_Click(object sender, EventArgs e)
        {
            method.Scroll(sender, e, MainPanel);
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }
    }
}
