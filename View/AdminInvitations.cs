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
    public partial class AdminInvitations : Form
    {
        Query controller;
        Method method = new Method();

        public AdminInvitations()
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
            byMe.Text = "Запрошення, надіслані користувачем";
            byMe.Location = new Point(50, 10);
            byMe.Size = new Size(520, 40);
            byMe.Font = new Font("Monotype corsiva", 22, FontStyle.Bold);
            byMe.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(byMe);

            Print(ref invitations, ref point, "from", true, true, id, fromMeFuture);

            point.Y += 20;
            Label forMe = new Label();
            forMe.Text = "Запрошення, надіслані користувачу";
            forMe.Location = new Point(50, point.Y);
            forMe.Size = new Size(520, 40);
            forMe.Font = new Font("Monotype corsiva", 22, FontStyle.Bold);
            forMe.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(forMe);
            point.Y += 40;

            Print(ref invitations, ref point, "to", true, false, id, toMeFuture);

            point.Y += 20;
            Label byMePast = new Label();
            byMePast.Text = "Назначені користувачем зустрічі, які відбулись";
            byMePast.Location = new Point(15, point.Y);
            byMePast.Size = new Size(570, 40);
            byMePast.Font = new Font("Monotype corsiva", 20, FontStyle.Bold);
            byMePast.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(byMePast);
            point.Y += 40;

            Print(ref invitations, ref point, "from", false, true, id, fromMePast);

            point.Y += 20;
            Label forMePast = new Label();
            forMePast.Text = "Назначені користувачу зустрічі, які відбулись";
            forMePast.Location = new Point(15, point.Y);
            forMePast.Size = new Size(570, 40);
            forMePast.Font = new Font("Monotype corsiva", 20, FontStyle.Bold);
            forMePast.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(forMePast);
            point.Y += 40;

            Print(ref invitations, ref point, "to", false, false, id, toMePast);

            method.CloseLoading();
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
        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            method.ChangeColorMouseLeave(sender, e, back);
        }

        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            method.ChangeColorMouseEnter(sender, e, back);
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

        private void button3_Click(object sender, EventArgs e)
        {
            controller.CloseProgram();
            method.BaseButtonAdminClick(sender, e, this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.CloseProgram();
            method.ArchiveButtonAdminClick(sender, e, this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }

        private void statistic_Click(object sender, EventArgs e)
        {
            controller.CloseProgram();
            method.StatisticClick(sender, e, this);
        }

        private void back_Click(object sender, EventArgs e)
        {
            Loading loading = new Loading();
            loading.Show();
            AdminProfile adminProfile = new AdminProfile();
            adminProfile.Show();
            this.Hide();
        }
    }
}
