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

namespace DataBaseDates.View
{
    public partial class LoginForm : Form
    {
        Query controller;
        Method method = new Method();
        public LoginForm()
        {
            InitializeComponent();
            this.Size = new Size(800, 570);

            controller = new Query(ConnectionString.ConnStr);

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

        private void visible_CheckedChanged(object sender, EventArgs e)
        {            
                if (visible.Checked)
                    password.UseSystemPasswordChar = false;
                else
                    password.UseSystemPasswordChar = true;
            }

        private void avt_Click(object sender, EventArgs e)
        {
            login.Text = "";
            password.Text = "";
        }

        private void reg_Click(object sender, EventArgs e)
        {
            RegForm regForm = new RegForm();
            regForm.Show();
            this.Hide();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            User user = new User(login.Text, password.Text);
            if (user.Login.ToUpper() != "ADMIN" && user.Password.ToUpper() != "ADMIN")
            {
                if (controller.CorrectEnter(user))
                {
                    controller.StartProgram(controller.GetId(login.Text));
                    if (!controller.InArchive(controller.GetUser()))
                    {
                        Loading loading = new Loading();
                        loading.Show();
                        AboutMe aboutMe = new AboutMe();
                        aboutMe.Show();                        
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Цей користувач в архіві!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        controller.CloseProgram();
                    }
                }
                else
                {
                    MessageBox.Show("Перевірте правильність вводу даних", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (user.Login.ToUpper() == "ADMIN" && user.Password.ToUpper() == "ADMIN")
            {
                Loading loading = new Loading();
                loading.Show();
                AdminBaseProfiles adminBase = new AdminBaseProfiles();
                adminBase.Show();                
                this.Hide();
            }
            else
            {
                MessageBox.Show("Перевірте правильність вводу даних", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
