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
    public partial class AdminIdealPartner : Form
    {
        Query controller;
        Method method = new Method();

        public AdminIdealPartner()
        {
            InitializeComponent();
            this.Size = new Size(800, 570);

            controller = new Query(ConnectionString.ConnStr);
            int index = controller.GetUser();
            Human human = method.GetHuman(index, controller);
            human.BestPartner = method.GetPartner("Partner", index, controller);

            HashSet<int> resultPartner = controller.ChoosePartner(human);
            method.IdealPartnerSet(ref resultPartner, human, controller);

            Point point = new Point(5, 105);
            Label forYou = new Label();
            forYou.Text = "Партнери, які підходять користувачу";
            forYou.Location = new Point(50, 55);
            forYou.Size = new Size(500, 40);
            forYou.Font = new Font("Monotype corsiva", 22, FontStyle.Bold);
            forYou.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(forYou);

            Human[] partner = method.FillArray(controller, resultPartner);
            Print(partner, ref point, "На жаль, за такими вимогами партнерів не знайдено", 30, 550);

            point.Y += 20;
            Label forThem = new Label();
            forThem.Text = "Партнери, яким підходить користувач";
            forThem.Location = new Point(50, point.Y);
            forThem.Size = new Size(520, 40);
            forThem.Font = new Font("Monotype corsiva", 22, FontStyle.Bold);
            forThem.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(forThem);
            point.Y += 40;

            HashSet<int> resultMe = controller.MyParametrs(human);
            method.ResultMeSet(ref resultMe, controller, human, "Partner");

            Human[] me = method.FillArray(controller, resultMe);
            Print(me, ref point, "На жаль, ви не підходите нікому", 140, 400);

            point.Y += 10;
            Label ideal = new Label();
            ideal.Text = "Ідеальне співпадіння";
            ideal.Location = new Point(150, point.Y);
            ideal.Size = new Size(300, 40);
            ideal.Font = new Font("Monotype corsiva", 22, FontStyle.Bold);
            ideal.ForeColor = Color.FromArgb(36, 0, 18);
            MainPanel.Controls.Add(ideal);
            point.Y += 40;

            resultMe.IntersectWith(resultPartner);
            Human[] result = method.FillArray(controller, resultMe);
            Print(result, ref point, "На жаль, ідеальних співпадінь немає", 110, 400);

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

        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            method.ChangeColorMouseLeave(sender, e, back);
        }

        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            method.ChangeColorMouseEnter(sender, e, back);
        }

        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            method.MainPanelMouseMove(sender, e, this);
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            method.MainPanelMouseDown(sender, e);
        }        

        private void AddPanel(ref Point point, int i, ref Human[] humen)
        {
            Panel innerPanel = new Panel();
            innerPanel.Name = "innerPanel" + humen[i].Id.ToString();
            innerPanel.Size = new Size(575, 215);
            innerPanel.Location = point;
            point.Y += 225;
            innerPanel.BackColor = Color.FromArgb(254, 235, 226);
            innerPanel.BorderStyle = BorderStyle.Fixed3D;

            PictureBox pictureBox = new PictureBox();
            TextBox nameBox = new TextBox();
            TextBox sexBox = new TextBox();
            TextBox ageBox = new TextBox();
            TextBox bdayBox = new TextBox();
            TextBox placeBox = new TextBox();

            method.AddHuman(ref point, i, ref humen, out pictureBox, out nameBox, out sexBox,
                out ageBox, out bdayBox, out placeBox);

            MainPanel.Controls.Add(innerPanel);
            innerPanel.Controls.Add(pictureBox);
            innerPanel.Controls.Add(nameBox);
            innerPanel.Controls.Add(sexBox);
            innerPanel.Controls.Add(ageBox);
            innerPanel.Controls.Add(bdayBox);
            innerPanel.Controls.Add(placeBox);

        }

        private void Print(Human[] partner, ref Point point, string sorry, int x, int len)
        {
            if (partner.Length == 0)
            {
                Label sorryYou = new Label();
                sorryYou.Text = sorry;
                sorryYou.Location = new Point(x, point.Y);
                sorryYou.Size = new Size(len, 60);
                sorryYou.Font = new Font("Monotype corsiva", 18, FontStyle.Bold);
                sorryYou.ForeColor = Color.FromArgb(36, 0, 18);
                MainPanel.Controls.Add(sorryYou);
                point.Y += 40;
            }
            else
            {
                for (int i = 0; i < partner.Length; i++)
                    AddPanel(ref point, i, ref partner);
            }
        }

       
        private void back_Click(object sender, EventArgs e)
        {
            Loading loading = new Loading();
            loading.Show();
            AdminProfile adminProfile = new AdminProfile();
            adminProfile.Show();
            this.Hide();
        }

        private void baseButton_Click(object sender, EventArgs e)
        {
            controller.CloseProgram();
            method.BaseButtonAdminClick(sender, e, this);
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            controller.CloseProgram();
            method.ArchiveButtonAdminClick(sender, e, this);
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }

        private void statistic_Click(object sender, EventArgs e)
        {
            controller.CloseProgram();
            method.StatisticClick(sender, e, this);
        }
    }
}
