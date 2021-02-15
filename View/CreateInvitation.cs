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
    public partial class CreateInvitation : Form
    {
        Query controller;
        Invitation invitation;
        bool correctH;
        bool correctM;
        Method method = new Method();
        public CreateInvitation()
        {
            controller = new Query(ConnectionString.ConnStr);
            InitializeComponent();
            this.Size = new Size(800, 570);

            invitation = new Invitation(controller.GetUser(), controller.GetUser("tempPartner"));
            invitation.From.Name = controller.ChooseById("name_", invitation.From.Id);
            invitation.From.Lastname = controller.ChooseById("lastname", invitation.From.Id);

            invitation.To.Name = controller.ChooseById("name_", invitation.To.Id);
            invitation.To.Lastname = controller.ChooseById("lastname", invitation.To.Id);

            from.Text = invitation.From.Name + " " + invitation.From.Lastname;
            to.Text = invitation.To.Name + " " + invitation.To.Lastname;

            DateTime minDay = DateTime.Today.AddDays(1);    
            date.MinDate = minDay;
            hour.MaxLength = 2;
            minute.MaxLength = 2;

            foreach (Form form in Application.OpenForms)
                if (form is Loading)
                    form.Hide();
        }
        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваше запрошення не збережено! Продовжити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
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

        private void back_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваше запрошення не збережено! Продовжити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Loading loading = new Loading();
                loading.Show();
                PartnerInfo partner = new PartnerInfo();
                partner.Show();
                this.Hide();
            }
        }
        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            method.ChangeColorMouseLeave(sender, e, back);
        }

        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            method.ChangeColorMouseEnter(sender, e, back);
        }

        private void create_Click(object sender, EventArgs e)
        {
            if (place.Text.Length == 0)
                MessageBox.Show("Введіть місце", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (!correctH || !correctM)
                MessageBox.Show("Введіть коректний час", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                
                invitation.Place = place.Text;
                int hours = ConvertTime(hour.Text);
                int minutes = ConvertTime(minute.Text);
                invitation.Date = new DateTime(date.Value.Year, date.Value.Month, date.Value.Day, hours, minutes, 0);
                controller.AddInvitation(invitation);
                controller.CloseProgram("tempPartner");
                method.InvButtonClick(sender, e, this);
            }
        }

        private void hour_Leave(object sender, EventArgs e)
        {            
            try
            {
                int hours = ConvertTime(hour.Text);
                correctH = true;
            }
            catch (Exception)
            {
                correctH = false;
                MessageBox.Show("Некоректний час", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (correctH)
            {
                int hours = ConvertTime(hour.Text);
                if (hours > 23 || hours < 0)
                {
                    correctH = false;
                    MessageBox.Show("Некоректний час", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }            
        }
        private void minute_Leave(object sender, EventArgs e)
        {
            try
            {
                int minutes = ConvertTime(minute.Text);
                correctM = true;
            }
            catch (Exception)
            {
                correctM = false;
                MessageBox.Show("Некоректний час", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (correctM)
            {
                int minutes = ConvertTime(minute.Text);
                if (minutes > 59 || minutes < 0)
                {
                    correctM = false;
                    MessageBox.Show("Некоректний час", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private int ConvertTime(string item)
        {
            int result;

            if (item.Length == 2 && item[0] == '0')
                item = item[1].ToString();            
            result = Convert.ToInt32(item);
            return result;
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваше запрошення не збережено! Продовжити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                method.ChangeButtonClick(sender, e);
        }

        private void meButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваше запрошення не збережено! Продовжити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                controller.CloseProgram("tempPartner");
                method.MeButtonClick(sender, e, this);
            }
            
        }

        private void partnerButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваше запрошення не збережено! Продовжити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                controller.CloseProgram("tempPartner");
                method.PartnerButtonClick(sender, e, this);
            }
        }

        private void invButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваше запрошення не збережено! Продовжити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                controller.CloseProgram("tempPartner");
                method.InvButtonClick(sender, e, this);
            }
        }

        private void baseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваше запрошення не збережено! Продовжити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                controller.CloseProgram("tempPartner");
                method.BaseButtonClick(sender, e, this);
            }
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ваше запрошення не збережено! Продовжити?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                controller.CloseProgram("tempPartner");
                method.ArchiveButtonClick(sender, e, this);  

            }
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }
    }
}
