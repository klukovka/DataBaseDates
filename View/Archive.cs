using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataBaseDates.Model;
using DataBaseDates.Controller;
using System.IO;

namespace DataBaseDates.View
{
    public partial class Archive : Form
    {
        Query controller;
        Method method = new Method();

        public Archive()
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

        private void changeButton_Click(object sender, EventArgs e)
        {
            method.ChangeButtonClick(sender, e);
        }

        private void meButton_Click(object sender, EventArgs e)
        {
            method.MeButtonClick(sender, e, this);
        }

        private void partnerButton_Click(object sender, EventArgs e)
        {
            method.PartnerButtonClick(sender, e, this);
        }

        private void invButton_Click(object sender, EventArgs e)
        {
            method.InvButtonClick(sender, e, this);
        }

        private void baseButton_Click(object sender, EventArgs e)
        {
            method.BaseButtonClick(sender, e, this);
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            method.Scroll(sender, e, MainPanel);
        }

        private void AddPanel(ref Point point, int i, ref Couple[] couples)
        {
            Panel innerPanel = new Panel();
            innerPanel.Name = "innerPanel" + i.ToString();
            innerPanel.Size = new Size(575, 465);
            innerPanel.Location = point;
            point.Y += 470;
            innerPanel.BackColor = Color.FromArgb(254, 235, 226);
            innerPanel.BorderStyle = BorderStyle.Fixed3D;

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

            method.AddArchiveCouple(ref point, i, ref couples, out pictureFirstBox, out nameFirstBox, out sexFirstBox,
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
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }
    }
}
