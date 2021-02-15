using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using DataBaseDates.View;
using DataBaseDates.Controller;

namespace DataBaseDates.Model
{
    class Method
    {
        //для запам’ятовування координат курсора при натисканні миші для переміщення вікна по екрану
        private Point lastPoint;

        public void MainPanelMouseMove(object sender, MouseEventArgs e, Form form)
        { //для переміщення вікна по екрану
            if (e.Button == MouseButtons.Left)
            {
                form.Left += e.X - lastPoint.X;
                form.Top += e.Y - lastPoint.Y;
            }
        }

        public void MainPanelMouseDown(object sender, MouseEventArgs e)
        { //запам’ятовування координат курсора на екрані
            lastPoint = new Point(e.X, e.Y);
        }

        public void PartnerButtonClick(object sender, EventArgs e, Form form)
        { //для переходу на вікно «Вимоги до партнера» при натисканні кнопки
            Loading loading = new Loading();
            loading.Show();
            AboutPartner aboutPartner = new AboutPartner();
            aboutPartner.Show();
            form.Hide();
        }

        public void BaseButtonClick(object sender, EventArgs e, Form form)
        { //для переходу на вікно «База профілів» в режимі пересічного користувача при натисканні кнопки
            Loading loading = new Loading();
            loading.Show();
            BaseProfiles baseProfiles = new BaseProfiles();
            baseProfiles.Show();
            form.Hide();
        }

        public void InvButtonClick(object sender, EventArgs e, Form form)
        { //для переходу на вікно «Мої запрошення» при натисканні кнопки
            Loading loading = new Loading();
            loading.Show();
            MyInvitations myInvitations = new MyInvitations();
            myInvitations.Show();
            form.Hide();
        }

        public void RemoveClick(object sender, EventArgs e)
        { //для переходу на вікно «Видалення профілю» при натисканні кнопки
            RemoveProfile remove = new RemoveProfile();
            remove.ShowDialog();
        }
        public void ToArchiveClick(object sender, EventArgs e, Form form)
        { //для переходу на вікно «Обрати свого партнера» при натисканні кнопки
            Loading loading = new Loading();
            loading.Show();
            ChooseYourPartner chooseYourPartner = new ChooseYourPartner();
            chooseYourPartner.Show();
            form.Hide();
        }

        public void ArchiveButtonClick(object sender, EventArgs e, Form form)
        { //для переходу на вікно «Архів» в режимі пересічного користувача при натисканні кнопки
            Loading loading = new Loading();
            loading.Show();
            Archive archive = new Archive();
            archive.Show();
            form.Hide();
        }

        public void ChangeButtonClick(object sender, EventArgs e)
        { //для переходу на вікно «Перевірка паролю» при натисканні кнопки
            CheckPassword checkPassword = new CheckPassword();
            checkPassword.ShowDialog();
        }

        public void Scroll(object sender, EventArgs e, Panel MainPanel)
        { //для автоматичного скрола вікна вгору при натисканні кнопки
            MainPanel.VerticalScroll.Value = MainPanel.VerticalScroll.Minimum;
            MainPanel.VerticalScroll.Value = MainPanel.VerticalScroll.Minimum;
        }

        public void ExiteProfileClick(object sender, EventArgs e)
        { //для виходу з облікового запису при натисканні кнопки
            ChangeAccount changeAccount = new ChangeAccount();
            changeAccount.ShowDialog();
        }

        public void ExitButtonClick(object sender, EventArgs e)
        { //для переходу на вікно «Вихід» при натисканні кнопки
            Exit exit = new Exit();
            exit.ShowDialog();
        }

        public void ChangeColorMouseEnter(object sender, EventArgs e, Label label)
        { //для зміни кольору напису при наведенні миші
            label.ForeColor = Color.FromArgb(164, 50, 107);
        }

        public void ChangeColorMouseLeave(object sender, EventArgs e, Label label)
        { //для зміни кольору напису при зведенні миші
            label.ForeColor = Color.FromArgb(255, 236, 227);
        }

        public void CloseLoading()
        { //для закривання форми «Завантаження
            foreach (Form form in Application.OpenForms)
                if (form is Loading)
                    form.Hide();
        }

        public void MeButtonClick(object sender, EventArgs e, Form form)
        { //для переходу на вікно «Про мене» при натисканні кнопки
            Loading loading = new Loading();
            loading.Show();
            AboutMe aboutMe = new AboutMe();
            aboutMe.Show();
            form.Hide();
        }

        public void SearchClick(object sender, EventArgs e, Form form)
        { //для переходу на вікно «Підбір ідеального партнера» при натисканні кнопки
            Loading loading = new Loading();
            loading.Show();
            IdealPartner idealPartner = new IdealPartner();
            idealPartner.Show();
            form.Hide();
        }

        public void BaseButtonAdminClick(object sender, EventArgs e, Form form)
        { //для переходу на вікно «База профілів» в режимі адміністратора при натисканні кнопки
            Loading loading = new Loading();
            loading.Show();
            AdminBaseProfiles adminBaseProfiles = new AdminBaseProfiles();
            adminBaseProfiles.Show();
            form.Hide();
        }

        public void StatisticClick(object sender, EventArgs e, Form form)
        { //для переходу на вікно «Статистика» при натисканні кнопки
            Loading loading = new Loading();
            loading.Show();
            Statistic statistic = new Statistic();
            statistic.Show();
            form.Hide();
        }

        public void ArchiveButtonAdminClick(object sender, EventArgs e, Form form)
        { //для переходу на вікно «Архів» в режимі адміністратора при натисканні кнопки
            Loading loading = new Loading();
            loading.Show();
            AdminArchive adminArchive = new AdminArchive();
            adminArchive.Show();
            form.Hide();
        }
        
        public void Clear(Query controller)
        { //для видалення даних про поточного користувача
            controller.CloseProgram("tempPartner");
            controller.CloseProgram();
        }

        public void CreateClick(object sender, EventArgs e, Form form)
        { // для переходу на вікно «Створити запрошення» 
            CreateInvitation invitation = new CreateInvitation();
            invitation.Show();
            form.Hide();
        }

        public Human GetHuman(int index, Query controller)
        { //для заповнення об’єкту «Human»
            Human human = new Human();
            human.Id = Convert.ToInt32(controller.ChooseById("id",index));
            human.Name = controller.ChooseById("name_", index);
            human.Lastname = controller.ChooseById("lastname", index);
            human.Post = controller.ChooseById("post", index);
            human.Phone = controller.ChooseById("phone", index);
            human.Birthday = Convert.ToDateTime(controller.ChooseById("birthday", index));
            human.Sex = Convert.ToInt32(controller.ChooseById("sex", index));
            human.Education = Convert.ToInt32(controller.ChooseById("education", index));
            human.Height = Convert.ToInt32(controller.ChooseById("height", index));
            human.Weight = Convert.ToInt32(controller.ChooseById("weight", index));
            human.Place = controller.ChooseById("place", index);
            human.Hair = Convert.ToInt32(controller.ChooseById("hair", index));
            human.Eyes = Convert.ToInt32(controller.ChooseById("eyes", index));
            human.Religioun = Convert.ToInt32(controller.ChooseById("religioun", index));
            human.Hobby = controller.ChooseById("hobby", index);
            human.Registration = Convert.ToDateTime(controller.ChooseById("registration", index));
            human.Politic = Convert.ToInt32(controller.ChooseById("politic", index));
            human.ImportantInLife = Convert.ToInt32(controller.ChooseById("impInLife", index));
            human.ImportantInHuman = Convert.ToInt32(controller.ChooseById("impInHuman", index));
            human.Smoking = Convert.ToInt32(controller.ChooseById("smoking", index));
            human.Alcohol = Convert.ToInt32(controller.ChooseById("alcohol", index));
            human.Inspiration = controller.ChooseById("inspiration", index);

            string help = Path.GetFullPath("DataBaseDates");
            human.Photo = help.Substring(0, help.IndexOf("bin"))+ controller.ChooseById("photo", index); 
            return human;
        }

        public Partner GetPartner(string table,int index,Query controller)
        { //для заповнення об’єкту «Partner»
            Partner partner = new Partner();
            table = "Partner";
            partner.MinAge = Convert.ToInt32(controller.ChooseById("minAge", index, table));
            partner.MaxAge = Convert.ToInt32(controller.ChooseById("maxAge", index, table));
            partner.MinHeight = Convert.ToInt32(controller.ChooseById("minHeight", index, table));
            partner.MaxHeight = Convert.ToInt32(controller.ChooseById("maxHeight", index, table));
            partner.MinWeight = Convert.ToInt32(controller.ChooseById("minWeight", index, table));
            partner.MaxWeight = Convert.ToInt32(controller.ChooseById("maxWeight", index, table));

            partner.Sex = new Sex(Convert.ToBoolean(controller.ChooseById("man", index, "Sex" + table)),
                Convert.ToBoolean(controller.ChooseById("woman", index, "Sex" + table)),
                Convert.ToBoolean(controller.ChooseById("other", index, "Sex" + table)));

            partner.Eyes = new Eyes(Convert.ToBoolean(controller.ChooseById("brown", index, "Eyes" + table)),
                Convert.ToBoolean(controller.ChooseById("blue", index, "Eyes" + table)),
                Convert.ToBoolean(controller.ChooseById("gray", index, "Eyes" + table)),
                Convert.ToBoolean(controller.ChooseById("green", index, "Eyes" + table)));

            partner.Education = new Education(Convert.ToBoolean(controller.ChooseById("nSecondary", index, "Education" + table)),
                Convert.ToBoolean(controller.ChooseById("secondary", index, "Education" + table)),
                Convert.ToBoolean(controller.ChooseById("prof", index, "Education" + table)),
                Convert.ToBoolean(controller.ChooseById("nHigh", index, "Education" + table)),
                Convert.ToBoolean(controller.ChooseById("high", index, "Education" + table)));

            partner.Hair = new Hair(Convert.ToBoolean(controller.ChooseById("black", index, "Hair" + table)),
                Convert.ToBoolean(controller.ChooseById("white", index, "Hair" + table)),
                Convert.ToBoolean(controller.ChooseById("brown", index, "Hair" + table)),
                Convert.ToBoolean(controller.ChooseById("lightBrown", index, "Hair" + table)),
                Convert.ToBoolean(controller.ChooseById("darkBrown", index, "Hair" + table)),
                Convert.ToBoolean(controller.ChooseById("colour", index, "Hair" + table)),
                Convert.ToBoolean(controller.ChooseById("other", index, "Hair" + table)));

            partner.Religioun = new Religioun(Convert.ToBoolean(controller.ChooseById("iud", index, "Religioun" + table)),
                Convert.ToBoolean(controller.ChooseById("prav", index, "Religioun" + table)),
                Convert.ToBoolean(controller.ChooseById("katol", index, "Religioun" + table)),
                Convert.ToBoolean(controller.ChooseById("prot", index, "Religioun" + table)),
                Convert.ToBoolean(controller.ChooseById("islam", index, "Religioun" + table)),
                Convert.ToBoolean(controller.ChooseById("budd", index, "Religioun" + table)),
                Convert.ToBoolean(controller.ChooseById("konf", index, "Religioun" + table)),
                Convert.ToBoolean(controller.ChooseById("past", index, "Religioun" + table)),
                Convert.ToBoolean(controller.ChooseById("ate", index, "Religioun" + table)));

            partner.Political = new Political(Convert.ToBoolean(controller.ChooseById("kom", index, "Political" + table)),
                Convert.ToBoolean(controller.ChooseById("sots", index, "Political" + table)),
                Convert.ToBoolean(controller.ChooseById("pom", index, "Political" + table)),
                Convert.ToBoolean(controller.ChooseById("lib", index, "Political" + table)),
                Convert.ToBoolean(controller.ChooseById("cons", index, "Political" + table)),
                Convert.ToBoolean(controller.ChooseById("mon", index, "Political" + table)),
                Convert.ToBoolean(controller.ChooseById("ultra", index, "Political" + table)));

            partner.Smoking = new Smoking(Convert.ToBoolean(controller.ChooseById("komp", index, "Smoking" + table)),
                Convert.ToBoolean(controller.ChooseById("neyt", index, "Smoking" + table)),
                Convert.ToBoolean(controller.ChooseById("pozit", index, "Smoking" + table)),
                Convert.ToBoolean(controller.ChooseById("neg", index, "Smoking" + table)));

            partner.Alcohol = new Alcohol(Convert.ToBoolean(controller.ChooseById("komp", index, "Alcohol" + table)),
                Convert.ToBoolean(controller.ChooseById("neyt", index, "Alcohol" + table)),
                Convert.ToBoolean(controller.ChooseById("pozit", index, "Alcohol" + table)),
                Convert.ToBoolean(controller.ChooseById("neg", index, "Alcohol" + table)));

            return partner;
        }

        public void AddArchiveCouple(ref Point point, int i, ref Couple[] couples, out PictureBox pictureFirstBox,
            out TextBox nameFirstBox, out TextBox sexFirstBox, out TextBox ageFirstBox, out TextBox bdayFirstBox,
            out TextBox placeFirstBox, out PictureBox pictureSecondBox, out TextBox nameSecondBox,
            out TextBox sexSecondBox, out TextBox ageSecondBox, out TextBox bdaySecondBox, out TextBox placeSecondBox,
            out TextBox dateArchive)
        { //для створення плиток виведення інформації про пари в архіві
            pictureFirstBox = new PictureBox();
            pictureFirstBox.Name = "photo" + i.ToString();
            pictureFirstBox.Size = new Size(195, 195);
            pictureFirstBox.Location = new Point(5, 10);
            pictureFirstBox.BorderStyle = BorderStyle.Fixed3D;
            Bitmap photo = new Bitmap(couples[i].First.Photo);
            pictureFirstBox.Image = photo;
            pictureFirstBox.SizeMode = PictureBoxSizeMode.Zoom;

            nameFirstBox = new TextBox();
            nameFirstBox.Name = "name" + i.ToString();
            nameFirstBox.Size = new Size(360, 35);
            nameFirstBox.Multiline = true;
            nameFirstBox.Location = new Point(205, 10);
            nameFirstBox.ReadOnly = true;
            nameFirstBox.BackColor = Color.FromArgb(255, 236, 227);
            nameFirstBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            nameFirstBox.ForeColor = Color.FromArgb(36, 0, 18);
            nameFirstBox.Text = "Ім*я: " + couples[i].First.Name + " " + couples[i].First.Lastname;

            sexFirstBox = new TextBox();
            sexFirstBox.Name = "sex" + i.ToString();
            sexFirstBox.Size = new Size(360, 35);
            sexFirstBox.Multiline = true;
            sexFirstBox.Location = new Point(205, 50);
            sexFirstBox.ReadOnly = true;
            sexFirstBox.BackColor = Color.FromArgb(255, 236, 227);
            sexFirstBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            sexFirstBox.ForeColor = Color.FromArgb(36, 0, 18);
            sexFirstBox.Text = "Стать: " + couples[i].First.MySex();

            ageFirstBox = new TextBox();
            ageFirstBox.Name = "age" + i.ToString();
            ageFirstBox.Size = new Size(360, 35);
            ageFirstBox.Multiline = true;
            ageFirstBox.Location = new Point(205, 90);
            ageFirstBox.ReadOnly = true;
            ageFirstBox.BackColor = Color.FromArgb(255, 236, 227);
            ageFirstBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            ageFirstBox.ForeColor = Color.FromArgb(36, 0, 18);
            ageFirstBox.Text = "Вік: " + couples[i].First.Age + " р.";

            bdayFirstBox = new TextBox();
            bdayFirstBox.Name = "age" + i.ToString();
            bdayFirstBox.Size = new Size(360, 35);
            bdayFirstBox.Multiline = true;
            bdayFirstBox.Location = new Point(205, 130);
            bdayFirstBox.ReadOnly = true;
            bdayFirstBox.BackColor = Color.FromArgb(255, 236, 227);
            bdayFirstBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            bdayFirstBox.ForeColor = Color.FromArgb(36, 0, 18);
            bdayFirstBox.Text = "Дата народження: " + couples[i].First.MyBirthday;

            placeFirstBox = new TextBox();
            placeFirstBox.Name = "place" + i.ToString();
            placeFirstBox.Size = new Size(360, 35);
            placeFirstBox.Multiline = true;
            placeFirstBox.Location = new Point(205, 170);
            placeFirstBox.ReadOnly = true;
            placeFirstBox.BackColor = Color.FromArgb(255, 236, 227);
            placeFirstBox.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            placeFirstBox.ForeColor = Color.FromArgb(36, 0, 18);
            placeFirstBox.Text = "Місце проживання: " + couples[i].First.Place;
            
            pictureSecondBox = new PictureBox();
            pictureSecondBox.Name = "photo" + i.ToString();
            pictureSecondBox.Size = new Size(195, 195);
            pictureSecondBox.Location = new Point(370, 225);
            pictureSecondBox.BorderStyle = BorderStyle.Fixed3D;
            Bitmap photo1 = new Bitmap(couples[i].Second.Photo);
            pictureSecondBox.Image = photo1;
            pictureSecondBox.SizeMode = PictureBoxSizeMode.Zoom;

            nameSecondBox = new TextBox();
            nameSecondBox.Name = "name" + i.ToString();
            nameSecondBox.Size = new Size(360, 35);
            nameSecondBox.Multiline = true;
            nameSecondBox.Location = new Point(5, 225);
            nameSecondBox.ReadOnly = true;
            nameSecondBox.BackColor = Color.FromArgb(255, 236, 227);
            nameSecondBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            nameSecondBox.ForeColor = Color.FromArgb(36, 0, 18);
            nameSecondBox.Text = "Ім*я: " + couples[i].Second.Name + " " + couples[i].Second.Lastname;

            sexSecondBox = new TextBox();
            sexSecondBox.Name = "sex" + i.ToString();
            sexSecondBox.Size = new Size(360, 35);
            sexSecondBox.Multiline = true;
            sexSecondBox.Location = new Point(5, 265);
            sexSecondBox.ReadOnly = true;
            sexSecondBox.BackColor = Color.FromArgb(255, 236, 227);
            sexSecondBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            sexSecondBox.ForeColor = Color.FromArgb(36, 0, 18);
            sexSecondBox.Text = "Стать: " + couples[i].Second.MySex();

            ageSecondBox = new TextBox();
            ageSecondBox.Name = "age" + i.ToString();
            ageSecondBox.Size = new Size(360, 35);
            ageSecondBox.Multiline = true;
            ageSecondBox.Location = new Point(5, 305);
            ageSecondBox.ReadOnly = true;
            ageSecondBox.BackColor = Color.FromArgb(255, 236, 227);
            ageSecondBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            ageSecondBox.ForeColor = Color.FromArgb(36, 0, 18);
            ageSecondBox.Text = "Вік: " + couples[i].Second.Age + " р.";

            bdaySecondBox = new TextBox();
            bdaySecondBox.Name = "age" + i.ToString();
            bdaySecondBox.Size = new Size(360, 35);
            bdaySecondBox.Multiline = true;
            bdaySecondBox.Location = new Point(5, 345);
            bdaySecondBox.ReadOnly = true;
            bdaySecondBox.BackColor = Color.FromArgb(255, 236, 227);
            bdaySecondBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            bdaySecondBox.ForeColor = Color.FromArgb(36, 0, 18);
            bdaySecondBox.Text = "Дата народження: " + couples[i].Second.MyBirthday;

            placeSecondBox = new TextBox();
            placeSecondBox.Name = "place" + i.ToString();
            placeSecondBox.Size = new Size(360, 35);
            placeSecondBox.Multiline = true;
            placeSecondBox.Location = new Point(5, 385);
            placeSecondBox.ReadOnly = true;
            placeSecondBox.BackColor = Color.FromArgb(255, 236, 227);
            placeSecondBox.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            placeSecondBox.ForeColor = Color.FromArgb(36, 0, 18);
            placeSecondBox.Text = "Місце проживання: " + couples[i].Second.Place;

            dateArchive = new TextBox();
            dateArchive.Name = "place" + i.ToString();
            dateArchive.Size = new Size(560, 35);
            dateArchive.Multiline = true;
            dateArchive.Location = new Point(5, 425);
            dateArchive.ReadOnly = true;
            dateArchive.BackColor = Color.FromArgb(255, 236, 227);
            dateArchive.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            dateArchive.ForeColor = Color.FromArgb(36, 0, 18);
            dateArchive.Text = "Дата додавання в архів: " + couples[i].DateArchive.ToString("dd.MM.yyyy");

        }

        public void FillArray(ref Human[] humen, Query controller)
        { //заповнення масиву користувачів
            string table = "Human";
            for (int i = 0; i < humen.Length; i++)
            {
                humen[i] = new Human();
                humen[i].Id = Convert.ToInt32(controller.CreateArray(table, 0, i));
                humen[i].Name = controller.CreateArray(table, 1, i);
                humen[i].Lastname = controller.CreateArray(table, 2, i);
                humen[i].Sex = Convert.ToInt32(controller.CreateArray(table, 6, i));
                humen[i].Birthday = Convert.ToDateTime(controller.CreateArray(table, 5, i));
                humen[i].InBase = Convert.ToBoolean(controller.CreateArray(table, 23, i));
                humen[i].Place = controller.CreateArray(table, 10, i);
                string help = Path.GetFullPath("DataBaseDates");
                help = help.Substring(0, help.IndexOf("bin")) + controller.CreateArray(table, 22, i);
                humen[i].Photo = help;
            }
        }

        public void AddHuman(ref Point point, int i, ref Human[] humen, out PictureBox pictureBox, out TextBox nameBox,
            out TextBox sexBox, out TextBox ageBox, out TextBox bdayBox, out TextBox placeBox)
        { //для створення плиток виведення інформації про користувача
            pictureBox = new PictureBox();
            pictureBox.Name = "photo" + i.ToString();
            pictureBox.Size = new Size(195, 195);
            pictureBox.Location = new Point(5, 10);
            Bitmap photo = new Bitmap(humen[i].Photo);
            pictureBox.Image = photo;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            nameBox = new TextBox();
            nameBox.Name = "name" + i.ToString();
            nameBox.Size = new Size(360, 35);
            nameBox.Multiline = true;
            nameBox.Location = new Point(205, 10);
            nameBox.ReadOnly = true;
            nameBox.BackColor = Color.FromArgb(255, 236, 227);
            nameBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            nameBox.ForeColor = Color.FromArgb(36, 0, 18);
            nameBox.Text = "Ім*я: " + humen[i].Name + " " + humen[i].Lastname;

            sexBox = new TextBox();
            sexBox.Name = "sex" + i.ToString();
            sexBox.Size = new Size(360, 35);
            sexBox.Multiline = true;
            sexBox.Location = new Point(205, 50);
            sexBox.ReadOnly = true;
            sexBox.BackColor = Color.FromArgb(255, 236, 227);
            sexBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            sexBox.ForeColor = Color.FromArgb(36, 0, 18);
            sexBox.Text = "Стать: " + humen[i].MySex();

            ageBox = new TextBox();
            ageBox.Name = "age" + i.ToString();
            ageBox.Size = new Size(360, 35);
            ageBox.Multiline = true;
            ageBox.Location = new Point(205, 90);
            ageBox.ReadOnly = true;
            ageBox.BackColor = Color.FromArgb(255, 236, 227);
            ageBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            ageBox.ForeColor = Color.FromArgb(36, 0, 18);
            ageBox.Text = "Вік: " + humen[i].Age + " р.";

            bdayBox = new TextBox();
            bdayBox.Name = "age" + i.ToString();
            bdayBox.Size = new Size(360, 35);
            bdayBox.Multiline = true;
            bdayBox.Location = new Point(205, 130);
            bdayBox.ReadOnly = true;
            bdayBox.BackColor = Color.FromArgb(255, 236, 227);
            bdayBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            bdayBox.ForeColor = Color.FromArgb(36, 0, 18);
            bdayBox.Text = "Дата народження: " + humen[i].MyBirthday;

            placeBox = new TextBox();
            placeBox.Name = "place" + i.ToString();
            placeBox.Size = new Size(360, 35);
            placeBox.Multiline = true;
            placeBox.Location = new Point(205, 170);
            placeBox.ReadOnly = true;
            placeBox.BackColor = Color.FromArgb(255, 236, 227);
            placeBox.Font = new Font("Times New Roman", 14, FontStyle.Bold);
            placeBox.ForeColor = Color.FromArgb(36, 0, 18);
            placeBox.Text = "Місце проживання: " + humen[i].Place;
        }

        public void IdealPartnerSet(ref HashSet<int> resultPartner, Human human, Query controller)
        { //для підбору ідеального партнера для користувача
            HashSet<int> resultSexPartner = new HashSet<int>();

            if (human.BestPartner.Sex.Man)
                resultSexPartner.UnionWith(controller.ChoosePartnerBy("sex", "1", "Human"));
            if (human.BestPartner.Sex.Woman)
                resultSexPartner.UnionWith(controller.ChoosePartnerBy("sex", "2", "Human"));
            if (human.BestPartner.Sex.Other)
                resultSexPartner.UnionWith(controller.ChoosePartnerBy("sex", "3", "Human"));

            HashSet<int> resultEducationPartner = new HashSet<int>();

            if (human.BestPartner.Education.NSecondary)
                resultEducationPartner.UnionWith(controller.ChoosePartnerBy("education", "1", "Human"));
            if (human.BestPartner.Education.Secondary)
                resultEducationPartner.UnionWith(controller.ChoosePartnerBy("education", "2", "Human"));
            if (human.BestPartner.Education.Prof)
                resultEducationPartner.UnionWith(controller.ChoosePartnerBy("education", "3", "Human"));
            if (human.BestPartner.Education.NHigh)
                resultEducationPartner.UnionWith(controller.ChoosePartnerBy("education", "4", "Human"));
            if (human.BestPartner.Education.High)
                resultEducationPartner.UnionWith(controller.ChoosePartnerBy("education", "5", "Human"));

            HashSet<int> resultReligiounPartner = new HashSet<int>();

            if (human.BestPartner.Religioun.Iud)
                resultReligiounPartner.UnionWith(controller.ChoosePartnerBy("religioun", "1", "Human"));
            if (human.BestPartner.Religioun.Prav)
                resultReligiounPartner.UnionWith(controller.ChoosePartnerBy("religioun", "2", "Human"));
            if (human.BestPartner.Religioun.Katol)
                resultReligiounPartner.UnionWith(controller.ChoosePartnerBy("religioun", "3", "Human"));
            if (human.BestPartner.Religioun.Prot)
                resultReligiounPartner.UnionWith(controller.ChoosePartnerBy("religioun", "4", "Human"));
            if (human.BestPartner.Religioun.Islam)
                resultReligiounPartner.UnionWith(controller.ChoosePartnerBy("religioun", "5", "Human"));
            if (human.BestPartner.Religioun.Budd)
                resultReligiounPartner.UnionWith(controller.ChoosePartnerBy("religioun", "6", "Human"));
            if (human.BestPartner.Religioun.Konf)
                resultReligiounPartner.UnionWith(controller.ChoosePartnerBy("religioun", "7", "Human"));
            if (human.BestPartner.Religioun.Past)
                resultReligiounPartner.UnionWith(controller.ChoosePartnerBy("religioun", "8", "Human"));
            if (human.BestPartner.Religioun.Ate)
                resultReligiounPartner.UnionWith(controller.ChoosePartnerBy("religioun", "9", "Human"));

            HashSet<int> resultEyesPartner = new HashSet<int>();

            if (human.BestPartner.Eyes.Brown)
                resultEyesPartner.UnionWith(controller.ChoosePartnerBy("eyes", "1", "Human"));
            if (human.BestPartner.Eyes.Blue)
                resultEyesPartner.UnionWith(controller.ChoosePartnerBy("eyes", "2", "Human"));
            if (human.BestPartner.Eyes.Green)
                resultEyesPartner.UnionWith(controller.ChoosePartnerBy("eyes", "3", "Human"));
            if (human.BestPartner.Eyes.Gray)
                resultEyesPartner.UnionWith(controller.ChoosePartnerBy("eyes", "4", "Human"));

            HashSet<int> resultHairPartner = new HashSet<int>();

            if (human.BestPartner.Hair.Black)
                resultHairPartner.UnionWith(controller.ChoosePartnerBy("hair", "1", "Human"));
            if (human.BestPartner.Hair.White)
                resultHairPartner.UnionWith(controller.ChoosePartnerBy("hair", "2", "Human"));
            if (human.BestPartner.Hair.Brown)
                resultHairPartner.UnionWith(controller.ChoosePartnerBy("hair", "3", "Human"));
            if (human.BestPartner.Hair.LightBrown)
                resultHairPartner.UnionWith(controller.ChoosePartnerBy("hair", "4", "Human"));
            if (human.BestPartner.Hair.DarkBrown)
                resultHairPartner.UnionWith(controller.ChoosePartnerBy("hair", "5", "Human"));
            if (human.BestPartner.Hair.Colour)
                resultHairPartner.UnionWith(controller.ChoosePartnerBy("hair", "6", "Human"));
            if (human.BestPartner.Hair.Other)
                resultHairPartner.UnionWith(controller.ChoosePartnerBy("hair", "7", "Human"));

            HashSet<int> resultPolitPartner = new HashSet<int>();

            if (human.BestPartner.Political.Kom)
                resultPolitPartner.UnionWith(controller.ChoosePartnerBy("politic", "1", "Human"));
            if (human.BestPartner.Political.Sots)
                resultPolitPartner.UnionWith(controller.ChoosePartnerBy("politic", "2", "Human"));
            if (human.BestPartner.Political.Pom)
                resultPolitPartner.UnionWith(controller.ChoosePartnerBy("politic", "3", "Human"));
            if (human.BestPartner.Political.Lib)
                resultPolitPartner.UnionWith(controller.ChoosePartnerBy("politic", "4", "Human"));
            if (human.BestPartner.Political.Cons)
                resultPolitPartner.UnionWith(controller.ChoosePartnerBy("politic", "5", "Human"));
            if (human.BestPartner.Political.Mon)
                resultPolitPartner.UnionWith(controller.ChoosePartnerBy("politic", "6", "Human"));
            if (human.BestPartner.Political.Ultra)
                resultPolitPartner.UnionWith(controller.ChoosePartnerBy("politic", "7", "Human"));

            HashSet<int> resultSmokingPartner = new HashSet<int>();

            if (human.BestPartner.Smoking.Komp)
                resultSmokingPartner.UnionWith(controller.ChoosePartnerBy("smoking", "1", "Human"));
            if (human.BestPartner.Smoking.Neyt)
                resultSmokingPartner.UnionWith(controller.ChoosePartnerBy("smoking", "2", "Human"));
            if (human.BestPartner.Smoking.Pozit)
                resultSmokingPartner.UnionWith(controller.ChoosePartnerBy("smoking", "3", "Human"));
            if (human.BestPartner.Smoking.Neg)
                resultSmokingPartner.UnionWith(controller.ChoosePartnerBy("smoking", "4", "Human"));

            HashSet<int> resultAlcoholPartner = new HashSet<int>();

            if (human.BestPartner.Alcohol.Komp)
                resultAlcoholPartner.UnionWith(controller.ChoosePartnerBy("alcohol", "1", "Human"));
            if (human.BestPartner.Alcohol.Neyt)
                resultAlcoholPartner.UnionWith(controller.ChoosePartnerBy("alcohol", "2", "Human"));
            if (human.BestPartner.Alcohol.Pozit)
                resultAlcoholPartner.UnionWith(controller.ChoosePartnerBy("alcohol", "3", "Human"));
            if (human.BestPartner.Alcohol.Neg)
                resultAlcoholPartner.UnionWith(controller.ChoosePartnerBy("alcohol", "4", "Human"));


            resultPartner.IntersectWith(resultSexPartner);
            resultPartner.IntersectWith(resultEducationPartner);
            resultPartner.IntersectWith(resultEyesPartner);
            resultPartner.IntersectWith(resultHairPartner);
            resultPartner.IntersectWith(resultPolitPartner);
            resultPartner.IntersectWith(resultSmokingPartner);
            resultPartner.IntersectWith(resultAlcoholPartner);
            resultPartner.IntersectWith(resultReligiounPartner);
        }

        public Human[] FillArray(Query controller, HashSet<int> idSet)
        { //для заповнення масиву користувачів на основі HashSet
            Human[] humen = new Human[0];
            int i = 0;
            foreach (int id in idSet)
            {
                if (id != controller.GetUser() && !(controller.InArchive(id)))
                {
                    Array.Resize(ref humen, humen.Length + 1);
                    humen[i] = new Human();
                    humen[i].Id = id;
                    humen[i].Name = controller.ChooseById("name_", id);
                    humen[i].Lastname = controller.ChooseById("lastname", id);
                    humen[i].Sex = Convert.ToInt32(controller.ChooseById("sex", id));
                    humen[i].Birthday = Convert.ToDateTime(controller.ChooseById("birthday", id));
                    humen[i].Place = controller.ChooseById("place", id);
                    string help = Path.GetFullPath("DataBaseDates");
                    help = help.Substring(0, help.IndexOf("bin")) + controller.ChooseById("photo", id);
                    humen[i].Photo = help;
                    i++;
                }
            }
            return humen;
        }

        public void ResultMeSet (ref HashSet<int> resultMe, Query controller, Human human, string table)
        { //для підбору партнерів, яким підходить користувач
            resultMe.IntersectWith(controller.ChoosePartnerBy(human.SexTable, "True", "Sex" + table));
            resultMe.IntersectWith(controller.ChoosePartnerBy(human.ReligiounTable, "True", "Religioun" + table));
            resultMe.IntersectWith(controller.ChoosePartnerBy(human.EducationTable, "True", "Education" + table));
            resultMe.IntersectWith(controller.ChoosePartnerBy(human.PoliticalTable, "True", "Political" + table));
            resultMe.IntersectWith(controller.ChoosePartnerBy(human.EyesTable, "True", "Eyes" + table));
            resultMe.IntersectWith(controller.ChoosePartnerBy(human.HairTable, "True", "Hair" + table));
            resultMe.IntersectWith(controller.ChoosePartnerBy(human.BadHabbitTable(human.Smoking), "True", "Smoking" + table));
            resultMe.IntersectWith(controller.ChoosePartnerBy(human.BadHabbitTable(human.Alcohol), "True", "Alcohol" + table));
        }

        public void PrintInvitation(ref Invitation[] invitations, Query controller, int id,
            ref int fromMeFuture, ref int toMeFuture, ref int fromMePast, ref int toMePast)
        { //для роздруковування плиток із запрошеннями
            for (int i = 0; i < invitations.Length; i++)
            {
                invitations[i].From.Name = controller.ChooseById("name_", invitations[i].From.Id);
                invitations[i].To.Name = controller.ChooseById("name_", invitations[i].To.Id);
                invitations[i].From.Lastname = controller.ChooseById("lastname", invitations[i].From.Id);
                invitations[i].To.Lastname = controller.ChooseById("lastname", invitations[i].To.Id);
                string help = Path.GetFullPath("DataBaseDates");
                invitations[i].From.Photo = help.Substring(0, help.IndexOf("bin")) + controller.ChooseById("photo", invitations[i].From.Id);
                invitations[i].To.Photo = help.Substring(0, help.IndexOf("bin")) + controller.ChooseById("photo", invitations[i].To.Id);
                if (invitations[i].From.Id == id && invitations[i].Date > DateTime.Now)
                    fromMeFuture++;
                else if (invitations[i].To.Id == id && invitations[i].Date > DateTime.Now)
                    toMeFuture++;
                else if (invitations[i].From.Id == id && invitations[i].Date <= DateTime.Now)
                    fromMePast++;
                else if (invitations[i].To.Id == id && invitations[i].Date <= DateTime.Now)
                    toMePast++;

            }
        }

        public void AddInvitation(string correctPhoto, ref Point point, ref Invitation[] invitations, int i, Panel MainPanel)
        { //для створення плиток виведення інформації про запрошення
            Panel innerPanel = new Panel();
            innerPanel.Size = new Size(575, 215);
            innerPanel.Location = point;
            point.Y += 225;
            innerPanel.BackColor = Color.FromArgb(254, 235, 226);
            innerPanel.BorderStyle = BorderStyle.Fixed3D;

            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(195, 195);
            pictureBox.Location = new Point(5, 10);
            Bitmap photo;
            if (correctPhoto == "from")
                photo = new Bitmap(invitations[i].To.Photo);
            else
                photo = new Bitmap(invitations[i].From.Photo);
            pictureBox.Image = photo;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

            TextBox fromBox = new TextBox();
            fromBox.Size = new Size(360, 35);
            fromBox.Multiline = true;
            fromBox.Location = new Point(205, 10);
            fromBox.ReadOnly = true;
            fromBox.BackColor = Color.FromArgb(255, 236, 227);
            fromBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            fromBox.ForeColor = Color.FromArgb(36, 0, 18);
            fromBox.Text = "Від: " + invitations[i].From.Name + " " + invitations[i].From.Lastname;

            TextBox toBox = new TextBox();
            toBox.Size = new Size(360, 35);
            toBox.Multiline = true;
            toBox.Location = new Point(205, 50);
            toBox.ReadOnly = true;
            toBox.BackColor = Color.FromArgb(255, 236, 227);
            toBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            toBox.ForeColor = Color.FromArgb(36, 0, 18);
            toBox.Text = "До: " + invitations[i].To.Name + " " + invitations[i].To.Lastname;

            TextBox dateBox = new TextBox();
            dateBox.Size = new Size(360, 35);
            dateBox.Multiline = true;
            dateBox.Location = new Point(205, 90);
            dateBox.ReadOnly = true;
            dateBox.BackColor = Color.FromArgb(255, 236, 227);
            dateBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            dateBox.ForeColor = Color.FromArgb(36, 0, 18);
            string result = invitations[i].Date.ToString();
            dateBox.Text = "Дата: " + result.Substring(0, result.IndexOf(" "));

            TextBox timeBox = new TextBox();
            timeBox.Size = new Size(360, 35);
            timeBox.Multiline = true;
            timeBox.Location = new Point(205, 130);
            timeBox.ReadOnly = true;
            timeBox.BackColor = Color.FromArgb(255, 236, 227);
            timeBox.Font = new Font("Times New Roman", 18, FontStyle.Bold);
            timeBox.ForeColor = Color.FromArgb(36, 0, 18);
            timeBox.Text = "Час: " + invitations[i].Date.ToString("HH:MM");

            TextBox placeBox = new TextBox();
            placeBox.Name = "place" + i.ToString();
            placeBox.Size = new Size(360, 35);
            placeBox.Multiline = true;
            placeBox.Location = new Point(205, 170);
            placeBox.ReadOnly = true;
            placeBox.BackColor = Color.FromArgb(255, 236, 227);
            placeBox.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            placeBox.ForeColor = Color.FromArgb(36, 0, 18);
            placeBox.Text = "Місце : " + invitations[i].Place;

            MainPanel.Controls.Add(innerPanel);
            innerPanel.Controls.Add(pictureBox);
            innerPanel.Controls.Add(fromBox);
            innerPanel.Controls.Add(toBox);
            innerPanel.Controls.Add(dateBox);
            innerPanel.Controls.Add(timeBox);
            innerPanel.Controls.Add(placeBox);

        }

      
    }
}
