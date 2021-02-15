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
    public partial class AdminArchive : Form
    {
        Query controller;
        Method method = new Method();
        public AdminArchive()
        {
            InitializeComponent();
            this.Size = new Size(800, 570);
            controller = new Query(ConnectionString.ConnStr);

            Point point = new Point(5, 45);
            Couple[] couples = controller.ArrayArchive();

            for (int i = 0; i < couples.Length; i++)
            {

                couples[i].First = method.GetHuman(couples[i].First.Id, controller);
                couples[i].Second = method.GetHuman(couples[i].Second.Id, controller);
                AddPanel(ref point, i, ref couples);
            }

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

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }

        private void baseButton_Click(object sender, EventArgs e)
        {
            method.BaseButtonAdminClick(sender, e, this);
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            method.Scroll(sender, e, MainPanel);
        }

        private void statistic_Click(object sender, EventArgs e)
        {
            method.StatisticClick(sender, e, this);
        }
        private void AddPanel(ref Point point, int i, ref Couple[] couples)
        {
            Button innerPanel = new Button();
            innerPanel.Name = couples[i].First.Id + "and" + couples[i].Second.Id;
            innerPanel.Size = new Size(575, 465);
            innerPanel.Location = point;
            point.Y += 470;
            innerPanel.BackColor = Color.FromArgb(254, 235, 226);
            PictureBox pictureFirstBox = new PictureBox();
            TextBox nameFirstBox = new TextBox();        
            TextBox sexFirstBox = new TextBox();
            TextBox ageFirstBox = new TextBox();
            TextBox bdayFirstBox = new TextBox();
            TextBox placeFirstBox = new TextBox();            
            PictureBox pictureSecondBox = new PictureBox();
            TextBox nameSecondBox = new TextBox();
            TextBox sexSecondBox = new TextBox();
            TextBox ageSecondBox = new TextBox();
            TextBox bdaySecondBox = new TextBox();
            TextBox placeSecondBox = new TextBox();
            TextBox dateArchive = new TextBox();

            method.AddArchiveCouple(ref point, i, ref couples, out pictureFirstBox,out nameFirstBox, out sexFirstBox,
                out ageFirstBox, out bdayFirstBox, out placeFirstBox, out pictureSecondBox, out nameSecondBox,
                out sexSecondBox, out ageSecondBox, out bdaySecondBox, out placeSecondBox, out dateArchive);

            MainPanel.Controls.Add(innerPanel);
            innerPanel.Controls.Add(pictureFirstBox);
            innerPanel.Controls.Add(nameFirstBox);
            innerPanel.Controls.Add(sexFirstBox);
            innerPanel.Controls.Add(ageFirstBox);
            innerPanel.Controls.Add(bdayFirstBox);
            innerPanel.Controls.Add(placeFirstBox);
            innerPanel.Controls.Add(pictureSecondBox);
            innerPanel.Controls.Add(nameSecondBox);
            innerPanel.Controls.Add(sexSecondBox);
            innerPanel.Controls.Add(ageSecondBox);
            innerPanel.Controls.Add(bdaySecondBox);
            innerPanel.Controls.Add(placeSecondBox);
            innerPanel.Controls.Add(dateArchive);

            innerPanel.Click += Couple_Click;
        }

        private void Couple_Click(object sender, EventArgs e)
        {
            Loading loading = new Loading();
            loading.Show();
            string name = ((Button)sender).Name;
            int idFirst = Convert.ToInt32(name.Substring(0, name.IndexOf('a')));
            int idSecond = Convert.ToInt32(name.Substring(name.IndexOf('d') + 1));
            controller.StartProgram(idFirst);
            controller.StartProgram(idSecond, "tempPartner");
            AdminCouple adminCouple = new AdminCouple();
            adminCouple.Show();
            this.Hide();
        }
    }

}

