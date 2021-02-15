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
    public partial class AdminCouple : Form
    {
        Query controller;
        Method method = new Method();
        public AdminCouple()
        {
            InitializeComponent();
            this.Size = new Size(800, 570);
            controller = new Query(ConnectionString.ConnStr);
            Couple couple = new Couple();
            couple.First = GetUser(controller.GetUser());
            couple.Second = GetUser(controller.GetUser("tempPartner"));
            name.Text = couple.First.Name;
            lastname.Text = couple.First.Lastname;
            post.Text = couple.First.Post;
            phone.Text = couple.First.Phone;
            birthday.Text = couple.First.MyBirthday + "(" + couple.First.Age + " p.)";
            sex.Text = couple.First.MySex();
            education.Text = couple.First.MyEducation();
            height.Text = couple.First.Height.ToString();
            weight.Text = couple.First.Weight.ToString();
            place.Text = couple.First.Place;
            hair.Text = couple.First.MyHair();
            eyes.Text = couple.First.MyEyes();
            religioun.Text = couple.First.MyReligioun();
            politic.Text = couple.First.MyPolitition();
            inLife.Text = couple.First.MyImportantInLife();
            inHuman.Text = couple.First.MyImportantInHuman();
            smoking.Text = couple.First.MyBadHabbit(couple.First.Smoking);
            alcohol.Text = couple.First.MyBadHabbit(couple.First.Alcohol);
            inspiration.Text = couple.First.Inspiration;
            hobby.Text = couple.First.Hobby;
            id.Text = couple.First.Id.ToString();
            registration.Text = couple.First.Registration.ToString("MM.dd.yyyy");
            Bitmap photo = new Bitmap(couple.First.Photo);
            image.Image = photo;
            minAge.Text = couple.First.BestPartner.MinAge.ToString();
            maxAge.Text = couple.First.BestPartner.MaxAge.ToString();
            minHeight.Text = couple.First.BestPartner.MinHeight.ToString();
            maxHeight.Text = couple.First.BestPartner.MaxHeight.ToString();
            minWeight.Text = couple.First.BestPartner.MinWeight.ToString();
            maxWeight.Text = couple.First.BestPartner.MaxWeight.ToString();
            sexPartner.Text = couple.First.BestPartner.Sex.GetSex();
            eyesPartner.Text = couple.First.BestPartner.Eyes.GetEyes();
            educationPartner.Text = couple.First.BestPartner.Education.GetEducation();
            hairPartner.Text = couple.First.BestPartner.Hair.GetHair();
            relPartner.Text = couple.First.BestPartner.Religioun.GetReligioun();
            politPartner.Text = couple.First.BestPartner.Political.GetPolitical();
            smokingPartner.Text = couple.First.BestPartner.Smoking.GetSmoking();
            alcoholPartner.Text = couple.First.BestPartner.Alcohol.GetAlcohol();

            nameS.Text = couple.Second.Name;
            lastnameS.Text = couple.Second.Lastname;
            postS.Text = couple.Second.Post;
            phoneS.Text = couple.Second.Phone;
            birthdayS.Text = couple.Second.MyBirthday + "(" + couple.Second.Age + " p.)";
            sexS.Text = couple.Second.MySex();
            educationS.Text = couple.Second.MyEducation();
            heightS.Text = couple.Second.Height.ToString();
            weightS.Text = couple.Second.Weight.ToString();
            placeS.Text = couple.Second.Place;
            hairS.Text = couple.Second.MyHair();
            eyesS.Text = couple.Second.MyEyes();
            religiounS.Text = couple.Second.MyReligioun();
            politicS.Text = couple.Second.MyPolitition();
            inLifeS.Text = couple.Second.MyImportantInLife();
            inHumanS.Text = couple.Second.MyImportantInHuman();
            smokingS.Text = couple.Second.MyBadHabbit(couple.Second.Smoking);
            alcoholS.Text = couple.Second.MyBadHabbit(couple.Second.Alcohol);
            inspirationS.Text = couple.Second.Inspiration;
            hobbyS.Text = couple.Second.Hobby;
            idS.Text = couple.Second.Id.ToString();
            registrationS.Text = couple.Second.Registration.ToString("MM.dd.yyyy");
            photo = new Bitmap(couple.Second.Photo);
            imageS.Image = photo;
            minAgeS.Text = couple.Second.BestPartner.MinAge.ToString();
            maxAgeS.Text = couple.Second.BestPartner.MaxAge.ToString();
            minHeightS.Text = couple.Second.BestPartner.MinHeight.ToString();
            maxHeightS.Text = couple.Second.BestPartner.MaxHeight.ToString();
            minWeightS.Text = couple.Second.BestPartner.MinWeight.ToString();
            maxWeightS.Text = couple.Second.BestPartner.MaxWeight.ToString();
            sexPartnerS.Text = couple.Second.BestPartner.Sex.GetSex();
            eyesPartnerS.Text = couple.Second.BestPartner.Eyes.GetEyes();
            educationPartnerS.Text = couple.Second.BestPartner.Education.GetEducation();
            hairPartnerS.Text = couple.Second.BestPartner.Hair.GetHair();
            relPartnerS.Text = couple.Second.BestPartner.Religioun.GetReligioun();
            politPartnerS.Text = couple.Second.BestPartner.Political.GetPolitical();
            smokingPartnerS.Text = couple.Second.BestPartner.Smoking.GetSmoking();
            alcoholPartnerS.Text = couple.Second.BestPartner.Alcohol.GetAlcohol();

            login.Text = controller.ChooseById("login", couple.First.Id, "User");
            loginS.Text = controller.ChooseById("login", couple.Second.Id, "User");

            couple.DateArchive = Convert.ToDateTime(controller.ChooseById("dateArchive", couple.First.Id, "Archive", "first"));
            dateArchive.Text = couple.DateArchive.ToString("MM.dd.yyyy");

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
            method.Clear(controller);
            method.BaseButtonAdminClick(sender, e, this);
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            method.Clear(controller);
            method.ArchiveButtonAdminClick(sender, e, this);
        }

        private void statistic_Click(object sender, EventArgs e)
        {           
            method.Clear(controller);
            method.StatisticClick(sender, e, this);
        }

        private Human GetUser(int index)
        {
            Human human = method.GetHuman(index, controller);
            human.BestPartner = method.GetPartner("Partner", index, controller);          
            return human;
        }

        private void backButton_MouseLeave(object sender, EventArgs e)
        {
            method.ChangeColorMouseLeave(sender, e, back);
        }

        private void backButton_MouseEnter(object sender, EventArgs e)
        {
            method.ChangeColorMouseEnter(sender, e, back);
        }

        private void back_Click(object sender, EventArgs e)
        {
            method.Clear(controller);
            method.ArchiveButtonAdminClick(sender, e, this);
        }
    }
}
