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
    public partial class ChangeInfo : Form
    {
        Query controller;
        string photo = "";        
        Method method = new Method();
        Human human;
        public ChangeInfo()
        {
            InitializeComponent();
            this.Size = new Size(800, 570);
            birthday.MaxDate = new DateTime(DateTime.Today.Year - 16, DateTime.Today.Month, DateTime.Today.Day);

            controller = new Query(ConnectionString.ConnStr);
            int index = controller.GetUser();

            human = method.GetHuman(index, controller);
            human.BestPartner = method.GetPartner("Partner", index, controller);
            FillMeForm("Human", index, ref human);
            FillPartnerForm("Partner", index, ref human);

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
            method.Scroll(sender, e, MainPanel);
        }

        private void meButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете вийти?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
                method.MeButtonClick(sender, e, this);

        }

        private void partnerButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете вийти?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)            
                method.PartnerButtonClick(sender, e, this);
            
        }

        private void invButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете вийти?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)            
                method.InvButtonClick(sender, e, this);
            
        }

        private void baseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете вийти?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)            
                method.BaseButtonClick(sender, e, this);
            
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви впевнені, що хочете вийти?", "Увага!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)            
                method.ArchiveButtonClick(sender, e, this);
            
        }

        private void FillMeForm(string table, int index, ref Human human)
        {
            name.Text = human.Name;
            lastname.Text = human.Lastname;
            post.Text = human.Post;
            phone.Text = human.Phone;
            birthday.Value = human.Birthday;
            sex.Text = human.MySex();
            education.Text = human.MyEducation();
            height.Text = human.Height.ToString();
            weight.Text = human.Weight.ToString();
            place.Text = human.Place;
            hair.Text = human.MyHair();
            eyes.Text = human.MyEyes();
            religioun.Text = human.MyReligioun();
            hobby.Text = human.Hobby;
            politics.Text = human.MyPolitition();
            importantInLife.Text = human.MyImportantInLife();
            importantInHuman.Text = human.MyImportantInHuman();
            smoking.Text = human.MyBadHabbit(human.Smoking);
            alcohol.Text = human.MyBadHabbit(human.Alcohol);
            inspiration.Text = human.Inspiration;
            Bitmap photo = new Bitmap(human.Photo);
            image.Image = photo;
            login.Text = controller.ChooseById("login", index, "User");
            password.Text = controller.ChooseById("password", index, "User");

        }
        private void FillPartnerForm(string table, int index, ref Human human)
        {
            minAge.Text = human.BestPartner.MinAge.ToString();
            maxAge.Text = human.BestPartner.MaxAge.ToString();
            minHeight.Text = human.BestPartner.MinHeight.ToString();
            maxHeight.Text = human.BestPartner.MaxHeight.ToString();
            minWeight.Text = human.BestPartner.MinWeight.ToString();
            maxWeight.Text = human.BestPartner.MaxWeight.ToString(); 
           
        }
        private void imageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.BMP; *.JPG; *.PNG; *.GIF; *.JPEG)|*.BMP; *.JPG; *.PNG; *.GIF; *.JPEG|" +
                "All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog.FileName.IndexOf("Images") > 0) 
                {
                    try
                    {
                        image.Image = new Bitmap(openFileDialog.FileName);
                        photo = openFileDialog.FileName;

                    }
                    catch
                    {
                        MessageBox.Show("Неможливо відкрити вибраний файл", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Ви не скопіювали фото у папку!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void post_Leave(object sender, EventArgs e)
        {
            if (post.Text.IndexOf("@") <= 0)
            {
                MessageBox.Show("Некоректне введення e-mail", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                post.Text = human.Post;
            }
        }

        private void height_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(height.Text);
            }
            catch
            {
                MessageBox.Show("Некоректне введення зросту", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                height.Text = human.Height.ToString();
            }
        }


        private void weight_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(weight.Text);
            }
            catch
            {
                MessageBox.Show("Некоректне введення ваги", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                weight.Text = human.Weight.ToString();
            }
        }
        private void minAge_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(minAge.Text);
            }
            catch
            {
                MessageBox.Show("Некоректне введення віку", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                minAge.Text = human.BestPartner.MinAge.ToString();
            }
        }

        private void maxAge_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(maxAge.Text);
            }
            catch
            {
                MessageBox.Show("Некоректне введення віку", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maxAge.Text = human.BestPartner.MaxAge.ToString();
            }
        }

        private void minHeight_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(minHeight.Text);
            }
            catch
            {
                MessageBox.Show("Некоректне введення зросту", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                minHeight.Text = human.BestPartner.MinHeight.ToString();
            }
        }

        private void maxHeight_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(maxHeight.Text);
            }
            catch
            {
                MessageBox.Show("Некоректне введення зросту", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maxHeight.Text = human.BestPartner.MaxHeight.ToString();
            }
        }

        private void minWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(minWeight.Text);
            }
            catch
            {
                MessageBox.Show("Некоректне введення ваги", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                minWeight.Text = human.BestPartner.MinWeight.ToString();
            }
        }

        private void maxWeight_Leave(object sender, EventArgs e)
        {
            try
            {
                Convert.ToInt32(maxWeight.Text);
            }
            catch
            {
                MessageBox.Show("Некоректне введення ваги", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                maxWeight.Text = human.BestPartner.MaxWeight.ToString();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            human.Id = controller.GetUser();
            human.Name = name.Text;
            human.Lastname = lastname.Text;
            human.Post = post.Text;
            human.Phone = phone.Text;
            human.Birthday = birthday.Value;
            human.Sex = sex.SelectedIndex + 1;
            human.Education = education.SelectedIndex + 1;
            human.Height = Convert.ToInt32(height.Text);
            human.Weight = Convert.ToInt32(weight.Text);
            human.Place = place.Text;
            human.Hair = hair.SelectedIndex + 1;
            human.Eyes = eyes.SelectedIndex + 1;
            human.Religioun = religioun.SelectedIndex + 1;
            human.Hobby = hobby.Text;
            human.Politic = politics.SelectedIndex + 1;
            human.ImportantInLife = importantInLife.SelectedIndex + 1;
            human.ImportantInHuman = importantInHuman.SelectedIndex + 1;
            human.Smoking = smoking.SelectedIndex + 1;
            human.Alcohol = alcohol.SelectedIndex + 1;
            human.Inspiration = inspiration.Text;
            if (photo == "")
                human.Photo = controller.ChooseById("photo", human.Id);
            else
                human.Photo = photo.Substring(photo.IndexOf("Image"));
            User user = new User(login.Text, password.Text);
                      

            controller.ChangeHuman(human);
            controller.ChageUser(user, human.Id);            

        }

        private void savePartner_Click(object sender, EventArgs e)
        {            
            this.healthSave_Click(sender, e);
            this.smokingSave_Click(sender, e);
            this.alcoholSave_Click(sender, e);
            this.sexSave_Click(sender, e);
            this.religiounSave_Click(sender, e);
            this.politicSave_Click(sender, e);
            this.hairSave_Click(sender, e);
            this.eyesSave_Click(sender, e);
            this.educationSave_Click(sender, e);
            
        }

        private void healthSave_Click(object sender, EventArgs e)
        {
            human.BestPartner.MinAge = Convert.ToInt32(minAge.Text);
            human.BestPartner.MaxAge = Convert.ToInt32(maxAge.Text);
            human.BestPartner.MinHeight = Convert.ToInt32(minHeight.Text);
            human.BestPartner.MaxHeight = Convert.ToInt32(maxHeight.Text);
            human.BestPartner.MinWeight = Convert.ToInt32(minWeight.Text);
            human.BestPartner.MaxWeight = Convert.ToInt32(maxWeight.Text);
            controller.ChangePartner(human.BestPartner, human.Id);

        }

        private void sexSave_Click(object sender, EventArgs e)
        {
            human.BestPartner.Sex = new Sex(sexPartner.GetItemChecked(0), sexPartner.GetItemChecked(1),
               sexPartner.GetItemChecked(2));
            human.BestPartner.Sex.Check();

            controller.ChangeSex(human.BestPartner.Sex, human.Id);
        }

        private void educationSave_Click(object sender, EventArgs e)
        {
            human.BestPartner.Education = new Education(educationPartner.GetItemChecked(0), educationPartner.GetItemChecked(1),
                educationPartner.GetItemChecked(2), educationPartner.GetItemChecked(3), educationPartner.GetItemChecked(4));
            human.BestPartner.Education.Check();

            controller.ChangeEducation(human.BestPartner.Education, human.Id);
        }

        private void hairSave_Click(object sender, EventArgs e)
        {
            human.BestPartner.Hair = new Hair(hairPartner.GetItemChecked(0), hairPartner.GetItemChecked(1), hairPartner.GetItemChecked(2),
                hairPartner.GetItemChecked(3), hairPartner.GetItemChecked(4), hairPartner.GetItemChecked(5), hairPartner.GetItemChecked(6));
            human.BestPartner.Hair.Check();

            controller.ChangeHair(human.BestPartner.Hair, human.Id);

        }

        private void eyesSave_Click(object sender, EventArgs e)
        {
            human.BestPartner.Eyes = new Eyes(eyesPartner.GetItemChecked(0), eyesPartner.GetItemChecked(1), eyesPartner.GetItemChecked(2),
               eyesPartner.GetItemChecked(3));
            human.BestPartner.Eyes.Check();

            controller.ChangeEyes(human.BestPartner.Eyes, human.Id);

        }

        private void religiounSave_Click(object sender, EventArgs e)
        {
            human.BestPartner.Religioun = new Religioun(religionPartner.GetItemChecked(0), religionPartner.GetItemChecked(1), religionPartner.GetItemChecked(2),
                religionPartner.GetItemChecked(3), religionPartner.GetItemChecked(4), religionPartner.GetItemChecked(5), religionPartner.GetItemChecked(6),
                religionPartner.GetItemChecked(7), religionPartner.GetItemChecked(8));
            human.BestPartner.Religioun.Check();

            controller.ChangeReligioun(human.BestPartner.Religioun, human.Id);

        }

        private void politicSave_Click(object sender, EventArgs e)
        {
            human.BestPartner.Political = new Political(politicPartner.GetItemChecked(0), politicPartner.GetItemChecked(1), politicPartner.GetItemChecked(2),
                politicPartner.GetItemChecked(3), politicPartner.GetItemChecked(4), politicPartner.GetItemChecked(5), politicPartner.GetItemChecked(6));
            human.BestPartner.Political.Check();

            controller.ChangePolitical(human.BestPartner.Political, human.Id);

        }

        private void smokingSave_Click(object sender, EventArgs e)
        {
            human.BestPartner.Smoking = new Smoking(smokingPartner.GetItemChecked(0), smokingPartner.GetItemChecked(1),
                    smokingPartner.GetItemChecked(2), smokingPartner.GetItemChecked(3));
            human.BestPartner.Smoking.Check();

            controller.ChangeSmoking(human.BestPartner.Smoking, human.Id);
        }

        private void alcoholSave_Click(object sender, EventArgs e)
        {
            human.BestPartner.Alcohol = new Alcohol(alcoholPartner.GetItemChecked(0), alcoholPartner.GetItemChecked(1),
                alcoholPartner.GetItemChecked(2), alcoholPartner.GetItemChecked(3));
            human.BestPartner.Alcohol.Check();

            controller.ChangeAlcohol(human.BestPartner.Alcohol, human.Id);
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            ChangeAccount changeAccount = new ChangeAccount();
            changeAccount.Show();
        }

        private void phone_Leave(object sender, EventArgs e)
        {
            if (phone.Text.Length != 10)
            {
                MessageBox.Show("Телефон має містити 10 цифр!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phone.Text = human.Phone;
            }
            else
            {
                if (phone.Text[0] != '0')
                {
                    MessageBox.Show("Телефон має починатись на 0", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    phone.Text = human.Phone;
                }
                else
                {
                    try
                    {
                        Convert.ToInt32(phone.Text.Substring(1));
                    }
                    catch
                    {
                        MessageBox.Show("Некоректне введення!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        phone.Text = human.Phone;

                    }
                }
            }
        }
    }
}
