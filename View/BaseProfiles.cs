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
    public partial class BaseProfiles : Form
    {
        Query controller;
        Method method = new Method();
        public BaseProfiles()
        {
            InitializeComponent();
            this.Size = new Size(800, 570);

            controller = new Query(ConnectionString.ConnStr);
            Human[] humen = new Human[controller.CountUser()];
            Point helpPoint = new Point(5, 45);
            method.FillArray(ref humen, controller);
            for (int i = 0; i < humen.Length; i++)
            {
                if (humen[i].Id != controller.GetUser() && humen[i].InBase == true)
                    AddPanel(ref helpPoint, i, ref humen);
            }

            method.CloseLoading();

        }

        private void meButton_Click(object sender, EventArgs e)
        {
            method.MeButtonClick(sender, e, this);
        }

        private void partnerButton_Click(object sender, EventArgs e)
        {
            method.PartnerButtonClick(sender, e, this);
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
            Panel innerPanel = new Panel();
            innerPanel.Name = "innerPanel" + i.ToString();
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

        private void baseButton_Click(object sender, EventArgs e)
        {
            method.Scroll(sender, e, MainPanel);
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }
    }
}
