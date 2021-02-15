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
    public partial class AboutMe : Form
    {
        Query controller;
        Method method = new Method();
        public AboutMe()
        {
            
            InitializeComponent();
            
            this.Size = new Size(800, 570);
            controller = new Query(ConnectionString.ConnStr);
            int index = controller.GetUser();
            Human human = method.GetHuman(index, controller);
            id.Text = human.Id.ToString();
            name.Text = human.Name;
            lastname.Text = human.Lastname;
            post.Text = human.Post;
            phone.Text = human.Phone;
            birthday.Text = human.MyBirthday +" ("+human.Age.ToString()+" р.)";
            sex.Text = human.MySex();
            education.Text = human.MyEducation();
            height.Text = human.Height.ToString();
            weight.Text = human.Weight.ToString();
            place.Text = human.Place;
            hair.Text = human.MyHair();
            eyes.Text = human.MyEyes();
            religioun.Text = human.MyReligioun();
            hobby.Text = human.Hobby;
            registration.Text = human.Registration.ToString("MM/dd/yyyy");
            politic.Text = human.MyPolitition();
            inLife.Text = human.MyImportantInLife();
            inHuman.Text = human.MyImportantInHuman();
            smoking.Text = human.MyBadHabbit(human.Smoking);
            alcohol.Text = human.MyBadHabbit(human.Alcohol);
            inspiration.Text = human.Inspiration;
            Bitmap photo = new Bitmap(human.Photo);
            image.Image = photo;
            login.Text = controller.ChooseById("login", index, "User");

            method.CloseLoading();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            method.ExitButtonClick(sender, e);
        }
        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            method.ChangeColorMouseEnter(sender, e, exitButton);
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            method.ChangeColorMouseLeave(sender, e, exitButton);
        }
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            method.MainPanelMouseMove(sender, e, this);        
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            method.MainPanelMouseDown(sender, e);
        }

        private void partnerButton_Click(object sender, EventArgs e)
        {
            method.PartnerButtonClick(sender, e, this);
        }

        private void baseButton_Click(object sender, EventArgs e)
        {
            method.BaseButtonClick(sender, e, this);
        }

        private void invButton_Click(object sender, EventArgs e)
        {
            method.InvButtonClick(sender, e, this);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            method.RemoveClick(sender, e);
        }

        private void toArchive_Click(object sender, EventArgs e)
        {
            method.ToArchiveClick(sender, e, this);
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            method.ArchiveButtonClick(sender, e, this);
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            method.ChangeButtonClick(sender, e);
        }

        private void meButton_Click(object sender, EventArgs e)
        {
            method.Scroll(sender, e, MainPanel);
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            method.ExiteProfileClick(sender, e);
        }

    }
}
