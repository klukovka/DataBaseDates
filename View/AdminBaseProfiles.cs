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
    public partial class AdminBaseProfiles : Form
    {
        Query controller;
        Method method = new Method();
        public AdminBaseProfiles()
        {
            
            InitializeComponent();
            
            this.Size = new Size(800, 570);

            controller = new Query(ConnectionString.ConnStr);
            Human[] humen = new Human[controller.CountUser()];
            Point helpPoint = new Point(5, 45);
            method.FillArray(ref humen, controller);           
            for (int i = 0; i < humen.Length; i++)
            {
                if (humen[i].InBase == true)
                    AddPanel(ref helpPoint, i, ref humen);
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
       

        private void AddPanel(ref Point point, int i, ref Human[] humen)
        {
            Button innerPanel = new Button();
            innerPanel.Name = "innerPanel" + humen[i].Id;
            innerPanel.Size = new Size(575, 215);
            innerPanel.Location = point;
            point.Y += 225;
            innerPanel.BackColor = Color.FromArgb(254, 235, 226);

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

            innerPanel.Click += new EventHandler(UserClick);
        }
       
       
        private void archiveButton_Click(object sender, EventArgs e)
        {
            method.ArchiveButtonAdminClick(sender, e, this);
        }

        private void baseButton_Click(object sender, EventArgs e)
        {
            method.Scroll(sender, e, MainPanel);
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }

        private void UserClick(object sender, EventArgs e)
        {
            Loading loading = new Loading();
            loading.Show();
            string name = ((Button)sender).Name;
            int id = Convert.ToInt32(name.Substring(name.IndexOf("l") + 1, name.Length - name.IndexOf("l") - 1));
            controller.StartProgram(id);
            AdminProfile adminProfile = new AdminProfile();
            adminProfile.Show();
            this.Hide();
        }

        private void statistic_Click(object sender, EventArgs e)
        {
            method.StatisticClick(sender, e, this);
        }
    }
}
