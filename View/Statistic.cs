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
    public partial class Statistic : Form
    {
        Query controller;
        Method method = new Method();

        public Statistic()
        {

            InitializeComponent();
            this.Size = new Size(800, 570);
            controller = new Query(ConnectionString.ConnStr);
            all.Text = controller.CountUser().ToString();
            inbase.Text = controller.CountActive(true).ToString();
            inarchive.Text = controller.CountActive(false).ToString();
            invitation.Text = controller.CountUser("Invitation").ToString();

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

        private void baseButton_Click(object sender, EventArgs e)
        {
            method.BaseButtonAdminClick(sender, e, this);

        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            method.ArchiveButtonAdminClick(sender, e, this);
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
