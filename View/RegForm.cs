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
    public partial class RegForm : Form
    {
        Query controller;
        Method method = new Method();
        public RegForm()
        {
            InitializeComponent();
            this.Size = new Size(800, 570);
            controller = new Query(ConnectionString.ConnStr);

        }

        private void avt_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void reg_Click(object sender, EventArgs e)
        {
            login.Text = "";
            password.Text = "";
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

        private void buttonReg_Click(object sender, EventArgs e)
        {
            
            User user = new User(login.Text,password.Text);
            if (user.Login.ToUpper() != "ADMIN")
            {
                bool corect;
                controller.CorrectLogin(login.Text, out corect);
                if (corect)
                {
                    if (user.Correct())
                    {
                        controller.AddUser(user.Password, user.Login);
                        controller.StartProgram(controller.GetId(user.Login));
                        RegInfo regInfo = new RegInfo();
                        regInfo.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Перевірте дані", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
            }
            else
            {
                MessageBox.Show("Ви не можете зареєструватися під іменем адміністратора", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void login_Leave(object sender, EventArgs e)
        {
            if (login.Text.Length < 5)
                MessageBox.Show("Логін має містити мінімум 5 символів", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (login.Text.IndexOf(" ")>-1)
                MessageBox.Show("Логін не може містити пробіл", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }

        private void password_Leave(object sender, EventArgs e)
        {

            if (password.Text.Length < 5 && password.Text!="")
                MessageBox.Show("Пароль має містити мінімум 5 символів", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (password.Text.IndexOf(" ") > -1)
                MessageBox.Show("Пароль не може містити пробіл", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
