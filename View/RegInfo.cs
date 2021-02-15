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
    public partial class RegInfo : Form
    {
        Query controller;
        string photo = @"E:\ІІ семестр\ООП\курсач\DataBaseDates\Images\Photos\base.png";
        Human human = new Human();
        Method method = new Method();

        public RegInfo()
        {
            InitializeComponent();
            this.Size = new Size(800, 570);
            controller = new Query(ConnectionString.ConnStr);
            birthday.MaxDate = new DateTime(DateTime.Today.Year - 16, DateTime.Today.Month, DateTime.Today.Day);

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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (height.Text == "у см" || minHeight.Text == "у см"|| maxHeight.Text == "у см" ||
                weight.Text == "у кг" || minWeight.Text == "у кг" || maxWeight.Text == "у кг" ||
                minAge.Text == "" || maxAge.Text == "")
            {
                MessageBox.Show("Введіть усі дані", "Увага!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
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
                human.Registration = DateTime.Today;
                human.Politic = politics.SelectedIndex + 1;
                human.ImportantInLife = importantInLife.SelectedIndex + 1;
                human.ImportantInHuman = importantInHuman.SelectedIndex + 1;
                human.Smoking = smoking.SelectedIndex + 1;
                human.Alcohol = alcohol.SelectedIndex + 1;
                human.Inspiration = inspiration.Text;
                human.Photo = photo.Substring(photo.IndexOf("Image"));
                human.InBase = true;
                human.InArchive = false;

                human.BestPartner.MinAge = Convert.ToInt32(minAge.Text);
                human.BestPartner.MaxAge = Convert.ToInt32(maxAge.Text);
                human.BestPartner.MinHeight = Convert.ToInt32(minHeight.Text);
                human.BestPartner.MaxHeight = Convert.ToInt32(maxHeight.Text);
                human.BestPartner.MinWeight = Convert.ToInt32(minWeight.Text);
                human.BestPartner.MaxWeight = Convert.ToInt32(maxWeight.Text);

                human.BestPartner.Smoking = new Smoking(smokingPartner.GetItemChecked(0), smokingPartner.GetItemChecked(1),
                    smokingPartner.GetItemChecked(2), smokingPartner.GetItemChecked(3));
                human.BestPartner.Smoking.Check();

                human.BestPartner.Alcohol = new Alcohol(alcoholPartner.GetItemChecked(0), alcoholPartner.GetItemChecked(1),
                    alcoholPartner.GetItemChecked(2), alcoholPartner.GetItemChecked(3));
                human.BestPartner.Alcohol.Check();

                human.BestPartner.Sex = new Sex(sexPartner.GetItemChecked(0), sexPartner.GetItemChecked(1),
                    sexPartner.GetItemChecked(2));
                human.BestPartner.Sex.Check();

                human.BestPartner.Religioun = new Religioun(religionPartner.GetItemChecked(0), religionPartner.GetItemChecked(1), religionPartner.GetItemChecked(2),
                    religionPartner.GetItemChecked(3), religionPartner.GetItemChecked(4), religionPartner.GetItemChecked(5), religionPartner.GetItemChecked(6),
                    religionPartner.GetItemChecked(7), religionPartner.GetItemChecked(8));
                human.BestPartner.Religioun.Check();

                human.BestPartner.Political = new Political(politicPartner.GetItemChecked(0), politicPartner.GetItemChecked(1), politicPartner.GetItemChecked(2),
                    politicPartner.GetItemChecked(3), politicPartner.GetItemChecked(4), politicPartner.GetItemChecked(5), politicPartner.GetItemChecked(6));
                human.BestPartner.Political.Check();

                human.BestPartner.Hair = new Hair(hairPartner.GetItemChecked(0), hairPartner.GetItemChecked(1), hairPartner.GetItemChecked(2),
                    hairPartner.GetItemChecked(3), hairPartner.GetItemChecked(4), hairPartner.GetItemChecked(5), hairPartner.GetItemChecked(6));
                human.BestPartner.Hair.Check();

                 human.BestPartner.Eyes = new Eyes(eyesPartner.GetItemChecked(0), eyesPartner.GetItemChecked(1), eyesPartner.GetItemChecked(2),
                    eyesPartner.GetItemChecked(3));
                human.BestPartner.Eyes.Check();

                human.BestPartner.Education = new Education(educationPartner.GetItemChecked(0), educationPartner.GetItemChecked(1), educationPartner.GetItemChecked(2),
                    educationPartner.GetItemChecked(3), educationPartner.GetItemChecked(4));
                human.BestPartner.Education.Check();


                controller.AddHuman(human.Name, human.Lastname, human.Post, human.Phone, human.Birthday, human.Sex, human.Education,
                    human.Height, human.Weight, human.Place, human.Hair, human.Eyes, human.Religioun, human.Hobby, human.Registration,
                    human.Politic, human.ImportantInLife, human.ImportantInHuman, human.Smoking, human.Alcohol, human.Inspiration, 
                    true, false, human.Photo);

                controller.AddPartner(human.BestPartner.MinAge, human.BestPartner.MaxAge, human.BestPartner.MinHeight,
                    human.BestPartner.MaxHeight, human.BestPartner.MinWeight, human.BestPartner.MaxWeight);

                controller.AddSmokingPartner(human.BestPartner.Smoking);
                controller.AddAlcoholPartner(human.BestPartner.Alcohol);
                controller.AddSexPartner(human.BestPartner.Sex);
                controller.AddReligiounPartner(human.BestPartner.Religioun);
                controller.AddPoliticalPartner(human.BestPartner.Political);
                controller.AddHairPartner(human.BestPartner.Hair);
                controller.AddEyesPartner(human.BestPartner.Eyes);
                controller.AddEducationPartner(human.BestPartner.Education);

                method.MeButtonClick(sender, e, this);
            }

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
                post.Text = "";
            }
        }

        private void height_Enter(object sender, EventArgs e)
        {
            height.Text = "";
            height.ForeColor = Color.FromArgb(36, 0, 18);
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
                height.ForeColor = Color.Silver;
                height.Text = "у см";                
            }
        }

        private void weight_Enter(object sender, EventArgs e)
        {
            weight.Text = "";
            weight.ForeColor = Color.FromArgb(36, 0, 18);
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
                weight.ForeColor = Color.Silver;
                weight.Text = "у кг";
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
                minAge.Text = "";
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
                maxAge.Text = "";
            }
        }

        private void minHeight_Enter(object sender, EventArgs e)
        {
            minHeight.Text = "";
            minHeight.ForeColor = Color.FromArgb(36, 0, 18);
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
                minHeight.ForeColor = Color.Silver;
                minHeight.Text = "у см";
            }
        }

        private void maxHeight_Enter(object sender, EventArgs e)
        {
            maxHeight.Text = "";
            maxHeight.ForeColor = Color.FromArgb(36, 0, 18);
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
                maxHeight.ForeColor = Color.Silver;
                maxHeight.Text = "у см";
            }
        }

        private void minWeight_Enter(object sender, EventArgs e)
        {
            minWeight.Text = "";
            minWeight.ForeColor = Color.FromArgb(36, 0, 18);
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
                minWeight.ForeColor = Color.Silver;
                minWeight.Text = "у кг";
            }
        }

        private void maxWeight_Enter(object sender, EventArgs e)
        {
            maxWeight.Text = "";
            maxWeight.ForeColor = Color.FromArgb(36, 0, 18);
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
                maxWeight.ForeColor = Color.Silver;
                maxWeight.Text = "у кг";
            }
        }

        private void meButton_Click(object sender, EventArgs e)
        {
            if (controller.CorrectProfile())
                MessageBox.Show("Збережіть ваші дані!","Помилка",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void reg_Click(object sender, EventArgs e)
        {
            if (controller.CorrectProfile())
                MessageBox.Show("Збережіть ваші дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void invButton_Click(object sender, EventArgs e)
        {
            if (controller.CorrectProfile())
                MessageBox.Show("Збережіть ваші дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void baseButton_Click(object sender, EventArgs e)
        {
            if (controller.CorrectProfile())
                MessageBox.Show("Збережіть ваші дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void archiveButton_Click(object sender, EventArgs e)
        {
            if (controller.CorrectProfile())
                MessageBox.Show("Збережіть ваші дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            method.Scroll(sender, e, MainPanel);
        }

        private void phone_Leave(object sender, EventArgs e)
        {
            if (phone.Text.Length != 10)
            {
                MessageBox.Show("Телефон має містити 10 цифр!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                phone.Text = "";
            }
            else
            {
                if (phone.Text[0] != '0')
                {
                    MessageBox.Show("Телефон має починатись на 0", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    phone.Text = "";
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
                    }
                }
            }
        }

        private void exiteProfile_Click(object sender, EventArgs e)
        {
            if (controller.CorrectProfile())
                MessageBox.Show("Збережіть ваші дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
