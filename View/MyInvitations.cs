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
using System.IO;

namespace DataBaseDates.View
{
    public partial class MyInvitations : Form
    {
        Query controller;
        Method method = new Method();
        
        public MyInvitations()
        {
            InitializeComponent();
            this.Size = new Size(800, 570);

            controller = new Query(ConnectionString.ConnStr);
            int id = controller.GetUser();
            int toMeFuture = 0;
            int fromMeFuture = 0;
            int toMePast = 0;
            int fromMePast = 0;
            Invitation[] invitations = controller.GetInvitation(id);
            method.PrintInvitation(ref invitations, controller, id, ref fromMeFuture, ref toMeFuture,
                ref fromMePast, ref toMePast);

            Point point = new Point(5, 60);
            Label byMe = new Label();
            byMe.Text = "Запрошення, надіслані вами";
            byMe.Location = new Point(120, 10);
            byMe.Size = new Size(450, 40);
            byMe.Font = new Font("Monotype corsiva", 22, FontStyle.Bold);
            byMe.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(byMe);

            Print(ref invitations, ref point, "from", true, true, id, fromMeFuture);

            point.Y += 20;
            Label forMe = new Label();
            forMe.Text = "Запрошення, надіслані мені";
            forMe.Location = new Point(120, point.Y);
            forMe.Size = new Size(450, 40);
            forMe.Font = new Font("Monotype corsiva", 22, FontStyle.Bold);
            forMe.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(forMe);
            point.Y += 40;

            Print(ref invitations, ref point, "to", true, false, id, toMeFuture);

            point.Y += 20;
            Label byMePast = new Label();
            byMePast.Text = "Назначені мною зустрічі, які відбулись";
            byMePast.Location = new Point(60, point.Y);
            byMePast.Size = new Size(500, 40);
            byMePast.Font = new Font("Monotype corsiva", 22, FontStyle.Bold);
            byMePast.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(byMePast);
            point.Y += 40;

            Print(ref invitations, ref point, "from", false, true, id, fromMePast);

            point.Y += 20;
            Label forMePast = new Label();
            forMePast.Text = "Назначені мені зустрічі, які відбулись";
            forMePast.Location = new Point(60, point.Y);
            forMePast.Size = new Size(500, 40);
            forMePast.Font = new Font("Monotype corsiva", 22, FontStyle.Bold);
            forMePast.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(forMePast);
            point.Y += 40;

            Print(ref invitations, ref point, "to", false, false, id, toMePast);

            foreach (Form form in Application.OpenForms)
                if (form is Loading)
                    form.Hide();
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
      
        private void Print(ref Invitation[] invitations, ref Point point, string correct, bool date, bool person, int id, int ind)
        {
            if (ind == 0)
            {
                Label sorryYou = new Label();
                sorryYou.Text = "Нічого не знайдено";
                sorryYou.Location = new Point(200, point.Y);
                sorryYou.Size = new Size(350, 60);
                sorryYou.Font = new Font("Monotype corsiva", 18, FontStyle.Bold);
                sorryYou.ForeColor = Color.FromArgb(36, 0, 18);
                MainPanel.Controls.Add(sorryYou);
                point.Y += 40;
            }
            else
            {

                for (int i = 0; i < invitations.Length; i++)
                {
                    bool tempDate = invitations[i].Date > DateTime.Now;
                    bool tempPerson = invitations[i].From.Id == id;
                    if (tempDate == date && tempPerson == person)
                        method.AddInvitation(correct, ref point, ref invitations, i, MainPanel);

                }
            }
        }

        private void meButton_Click(object sender, EventArgs e)
        {
            method.MeButtonClick(sender, e, this);
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            method.ChangeButtonClick(sender, e);
        }

        private void partnerButton_Click(object sender, EventArgs e)
        {
            method.PartnerButtonClick(sender, e, this);
        }

        private void invButton_Click(object sender, EventArgs e)
        {
            method.Scroll(sender, e, MainPanel);
        }

        private void baseButton_Click(object sender, EventArgs e)
        {
            method.BaseButtonClick(sender, e, this);
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            method.ArchiveButtonClick(sender, e, this);
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }
    }
}
