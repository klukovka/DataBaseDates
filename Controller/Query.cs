using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using DataBaseDates.Model;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace DataBaseDates.Controller
{
    class Query
    {
        private OleDbConnection connection; //для встановлення з’єднання з базою даних
        private OleDbCommand command; //для передачі SQL-команди для вибірки даних з таблиць
        private OleDbDataAdapter dataAdapter; //для встановлення моста між DataSet та джерелом даних для отримання та збереження даних
        private DataTable bufferTable; //для збереження тимчасової таблиці в пам’яті

        public Query(string conn)
        {
            connection = new OleDbConnection(conn);
            bufferTable = new DataTable();
        }
        public void AddUser(string password, string login) //для збереження логіна та паролю користувача
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [User]([login],[password]) VALUES(@login,@password)", connection);
            command.Parameters.AddWithValue("login", login);
            command.Parameters.AddWithValue("password", password);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AddHuman(string name, string lastname, string post, string phone, DateTime birthday, int sex, int education,
           int height, int weight, string place, int hair, int eyes, int religioun, string hobby, DateTime registration,
           int politic, int impInLife, int impInHuman, int smoking, int alcohol, string inspiration, bool inBase, bool inArchive,
            string photo) //для збереження особистих даних користувача
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [Human]([name_],[lastname],[post],[phone],[birthday],[sex],[education]," +
                $"[height],[weight],[place],[hair],[eyes],[religioun],[hobby],[registration],[politic],[impInLife],[impInHuman]," +
                $"[smoking],[alcohol],[inspiration],[inBase],[inArchive],[photo]) " +
                $"VALUES(@name,@lastname,@post,@phone,birthday,@sex,@education,@height,@weight,@place,@hair," +
                $"@eyes,@religioun,@hobby,registration,@politic,@impInLife,@impInHuman,@smoking,@alcohol,@inspiration," +
                $"@inBase,@inArchive,@photo)", connection);
            command.Parameters.AddWithValue("name_", name);
            command.Parameters.AddWithValue("lastname", lastname);
            command.Parameters.AddWithValue("post", post);
            command.Parameters.AddWithValue("phone", phone);
            command.Parameters.AddWithValue("birthday", birthday);
            command.Parameters.AddWithValue("sex", sex);
            command.Parameters.AddWithValue("education", education);
            command.Parameters.AddWithValue("height", height);
            command.Parameters.AddWithValue("weight", weight);
            command.Parameters.AddWithValue("place", place);
            command.Parameters.AddWithValue("hair", hair);
            command.Parameters.AddWithValue("eyes", eyes);
            command.Parameters.AddWithValue("religioun", religioun);
            command.Parameters.AddWithValue("hobby", hobby);
            command.Parameters.AddWithValue("registration", registration);
            command.Parameters.AddWithValue("politic", politic);
            command.Parameters.AddWithValue("impInLife", impInLife);
            command.Parameters.AddWithValue("impInHuman", impInHuman);
            command.Parameters.AddWithValue("smoking", smoking);
            command.Parameters.AddWithValue("alcohol", alcohol);
            command.Parameters.AddWithValue("inspiration", inspiration);
            command.Parameters.AddWithValue("inBase", inBase);
            command.Parameters.AddWithValue("inArchive", inArchive);
            command.Parameters.AddWithValue("photo", photo);

            command.ExecuteNonQuery();
            connection.Close();
        }
        public void AddPartner(int minAge, int maxAge, int minHeight, int maxHeight, int minWeight, int maxWeight)
        { //для збереження загальних вимог до партнера
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [Partner]([minAge],[maxAge],[minHeight],[maxHeight],[minWeight],[maxWeight])" +
                $"VALUES (minAge,maxAge,minHeight,maxHeight,minWeight,maxWeight)", connection);
            command.Parameters.AddWithValue("minAge", minAge);
            command.Parameters.AddWithValue("maxAge", maxAge);
            command.Parameters.AddWithValue("minHeight", minHeight);
            command.Parameters.AddWithValue("maxHeight", maxHeight);
            command.Parameters.AddWithValue("minWeight", minWeight);
            command.Parameters.AddWithValue("maxWeight", maxWeight);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void AddSmokingPartner(Smoking smoking)
        { //для збереження бажаного ставлення до куріння партнера
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [SmokingPartner]([komp],[neyt],[pozit],[neg])" +
                $"VALUES (komp,neyt,pozit,neg)", connection);
            command.Parameters.AddWithValue("komp", smoking.Komp);
            command.Parameters.AddWithValue("neyt", smoking.Neyt);
            command.Parameters.AddWithValue("pozit", smoking.Pozit);
            command.Parameters.AddWithValue("neg", smoking.Neg);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void AddAlcoholPartner(Alcohol alcohol)
        { //для збереження бажаного ставлення до алкоголю партнера
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [AlcoholPartner]([komp],[neyt],[pozit],[neg])" +
                $"VALUES (komp,neyt,pozit,neg)", connection);
            command.Parameters.AddWithValue("komp", alcohol.Komp);
            command.Parameters.AddWithValue("neyt", alcohol.Neyt);
            command.Parameters.AddWithValue("pozit", alcohol.Pozit);
            command.Parameters.AddWithValue("neg", alcohol.Neg);
            command.ExecuteNonQuery();
            connection.Close();

        }

        public void AddSexPartner(Sex sex)
        {
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [SexPartner]([man],[woman],[other])" +
                $"VALUES (man,woman,other)", connection);
            command.Parameters.AddWithValue("man", sex.Man);
            command.Parameters.AddWithValue("woman", sex.Woman);
            command.Parameters.AddWithValue("other", sex.Other);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddReligiounPartner(Religioun religioun)
        { //для збереження бажаної статі партнера
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [ReligiounPartner]([iud],[prav],[katol],[prot],[islam]," +
                $"[budd],[konf],[past],[ate])" +
                $"VALUES (iud,prav,katol,prot,islam,budd,konf,past,ate)", connection);
            command.Parameters.AddWithValue("iud", religioun.Iud);
            command.Parameters.AddWithValue("prav", religioun.Prav);
            command.Parameters.AddWithValue("katol", religioun.Katol);
            command.Parameters.AddWithValue("prot", religioun.Prot);
            command.Parameters.AddWithValue("islam", religioun.Islam);
            command.Parameters.AddWithValue("budd", religioun.Budd);
            command.Parameters.AddWithValue("konf", religioun.Konf);
            command.Parameters.AddWithValue("past", religioun.Past);
            command.Parameters.AddWithValue("ate", religioun.Ate);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddPoliticalPartner (Political political)
        { //для збереження бажаного політичного світогляду партнера
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [PoliticalPartner]([kom],[sots],[pom],[lib]," +
                $"[cons],[mon],[ultra])" +
                $"VALUES (kom,sots,pom,lib,cons,mon,ultra)", connection);
            command.Parameters.AddWithValue("kom", political.Kom);
            command.Parameters.AddWithValue("sots", political.Sots);
            command.Parameters.AddWithValue("pom", political.Pom);
            command.Parameters.AddWithValue("lib", political.Lib);
            command.Parameters.AddWithValue("cons", political.Cons);
            command.Parameters.AddWithValue("mon", political.Mon);
            command.Parameters.AddWithValue("ultra", political.Ultra);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddHairPartner (Hair hair)
        { //для збереження бажаного кольору волосся партнера
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [HairPartner]([black],[white],[brown],[lightBrown]," +
                $"[darkBrown],[colour],[other])" +
                $"VALUES (black,white,brown,lightBrown,darkBrown,colour,other)", connection);
            command.Parameters.AddWithValue("black", hair.Black);
            command.Parameters.AddWithValue("white", hair.White);
            command.Parameters.AddWithValue("brown", hair.Brown);
            command.Parameters.AddWithValue("lightBrown", hair.LightBrown);
            command.Parameters.AddWithValue("darkBrown", hair.DarkBrown);
            command.Parameters.AddWithValue("colour", hair.Colour);
            command.Parameters.AddWithValue("other", hair.Other);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddEyesPartner (Eyes eyes)
        { //для збереження бажаного кольору очей партнера
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [EyesPartner]([brown],[blue],[gray],[green])" +
                $"VALUES (brown,blue,gray,green)", connection);
            command.Parameters.AddWithValue("brown", eyes.Brown);
            command.Parameters.AddWithValue("blue", eyes.Blue);
            command.Parameters.AddWithValue("gray", eyes.Gray);
            command.Parameters.AddWithValue("green", eyes.Green);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddEducationPartner(Education education)
        { //для збереження бажаної освіти партнера
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [EducationPartner]([nSecondary],[secondary]," +
                $"[prof],[nHigh],[high])" +
                $"VALUES (nSecondary,secondary,prof,nHigh,high)", connection);
            command.Parameters.AddWithValue("nSecondary", education.NSecondary);
            command.Parameters.AddWithValue("secondary", education.Secondary);
            command.Parameters.AddWithValue("prof", education.Prof);
            command.Parameters.AddWithValue("nHigh", education.NHigh);
            command.Parameters.AddWithValue("high", education.High);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void CorrectLogin (string login, out bool corect)
        { //для перевірки унікальності введеного при реєстрації логіну
            connection.Open();
            dataAdapter = new OleDbDataAdapter();
            command = new OleDbCommand("SELECT * FROM [User] WHERE [login] = @login", connection);
            command.Parameters.Add("@login", OleDbType.VarChar).Value = login;
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            if (bufferTable.Rows.Count > 0)
            {
                MessageBox.Show("Користувач з таким ніком уже зареєстрований!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                corect = false;
            }
            else
                corect = true;
            bufferTable.Clear();
            connection.Close();
            
        }

        public bool CorrectPassword (string password, int id)
        { //для перевірки коректності введеного паролю
            connection.Open();
            command = new OleDbCommand("SELECT password FROM [User] WHERE [id]=" + id, connection);
            string temp = Convert.ToString(command.ExecuteScalar());
            connection.Close();
            return temp == password;

        }
        public bool CorrectProfile()
        { //для перевірки відповідності кількості записів у таблицях «Human» та «User»
            connection.Open();
            dataAdapter = new OleDbDataAdapter();
            command = new OleDbCommand("SELECT * FROM [User]", connection);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            int idUser = bufferTable.Rows.Count;
            bufferTable.Clear();
            dataAdapter = new OleDbDataAdapter();
            command = new OleDbCommand("SELECT * FROM [Human]", connection);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            int idHuman = bufferTable.Rows.Count;
            bufferTable.Clear();
            connection.Close();
            return (idUser != idHuman);
        }

        public int GetId(string login)
        { //для отримання індексу користувача, який зараз авторизувався
            connection.Open();
            int index = 0;
            command = new OleDbCommand("SELECT id FROM [User] WHERE [login] = @login", connection);
            command.Parameters.Add("@login", OleDbType.VarChar).Value = login;
            index = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
            return index;
        }

        public void StartProgram(int index, string table = "Temp")
        { //для внесення індексу авторизованого користувача у темпову таблицю для коректної роботи програми
            connection.Open();
            command = new OleDbCommand($"INSERT INTO ["+table+"]([idUser]) VALUES (index)", connection);
            command.Parameters.AddWithValue("index", index);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void CloseProgram(string table = "Temp")
        { //для видалення індексу користувача із таблиці для коректної роботи програми
            connection.Open();
            command = new OleDbCommand("DELETE idUser FROM ["+table+"]", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public bool CorrectEnter(User user)
        { //для перевірки правильності вводу логіну та пароля і авторизації користувача
            connection.Open();
            dataAdapter = new OleDbDataAdapter();
            command = new OleDbCommand("SELECT * FROM [User] WHERE [login] = @login AND [password] = @password", connection);
            command.Parameters.Add("@login", OleDbType.VarChar).Value = user.Login;
            command.Parameters.Add("@password", OleDbType.VarChar).Value = user.Password;
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            int temp = bufferTable.Rows.Count;
            bufferTable.Clear();
            connection.Close();
            return temp > 0;
        }
        public bool InArchive(int id)
        { //для перевірки наявності користувача в архіві
            connection.Open();
            command = new OleDbCommand("SELECT inArchive FROM [Human] WHERE [id] = " + id, connection);
            bool result = Convert.ToBoolean(command.ExecuteScalar());
            connection.Close();
            return result;

        }

        public int GetUser(string table = "Temp")
        { //для отримання індексу користувача, який зараз знаходиться в системі
            connection.Open();
            dataAdapter = new OleDbDataAdapter();
            command = new OleDbCommand("SELECT * FROM ["+table+"]", connection);
            int index =Convert.ToInt32(command.ExecuteScalar());
            connection.Close();

            return index;
        }
        public void Remove()
        { //для видалення сторінки з бази
            int id = GetUser();
            connection.Open();
            string[] temp = new string[] {"[User]", "[Human]", "[Partner]", "[SmokingPartner]", "[AlcoholPartner]",
            "[SexPartner]","[ReligiounPartner]","[PoliticalPartner]","[HairPartner]","[EyesPartner]","[EducationPartner]"};
            for (int i = 0; i < temp.Length; i++)
            {
                string query = "DELETE FROM " + temp[i] + " WHERE id=" + id;
                command = new OleDbCommand(query, connection);
                command.ExecuteNonQuery();
            }
            
            connection.Close();
        }      
        public int CountUser(string table = "Human")
        { //для підрахунку кількості користувачів
            connection.Open();
            command = new OleDbCommand("SELECT * FROM [" + table + "]", connection);
            dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            int result =bufferTable.Rows.Count;
            bufferTable.Clear();
            connection.Close();
            return result;
        }

        public int CountActive(bool inBase)
        { //для підрахунку кількості користувачів не в архіві
            connection.Open();
            command = new OleDbCommand($"SELECT * FROM [Human] WHERE [inBase]={inBase}", connection);
            dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            int result = bufferTable.Rows.Count;
            bufferTable.Clear();
            connection.Close();
            return result;
        }

        public string CreateArray(string table, int i, int id)
        { //для створення масиву користувачів
            connection.Open();
            dataAdapter = new OleDbDataAdapter();
            command = new OleDbCommand("SELECT * FROM [" + table + "]", connection);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            string result = bufferTable.Rows[id][i].ToString();
            bufferTable.Clear();
            connection.Close();
            return result;
        }

        public HashSet<int> ChoosePartner(Human human)
        { //для вибору партнерів за загальними характеристиками
            connection.Open();
            dataAdapter = new OleDbDataAdapter();

            DateTime minBDay = new DateTime(DateTime.Today.Year - human.BestPartner.MinAge, DateTime.Today.Month, DateTime.Today.Day);
            DateTime maxBDay = new DateTime(DateTime.Today.Year - human.BestPartner.MaxAge, DateTime.Today.Month, DateTime.Today.Day);
            string maxBDayStr = maxBDay.ToString("#M/d/yyyy#").Replace(".","/");
            string minBDayStr = minBDay.ToString("#M/d/yyyy#").Replace(".","/");
            command = new OleDbCommand("SELECT id FROM [Human] WHERE [weight] BETWEEN "+(human.BestPartner.MinWeight-1)+" AND "+
               (human.BestPartner.MaxWeight+1)+" AND [height] BETWEEN "+(human.BestPartner.MinHeight-1)+" AND "+(human.BestPartner.MaxHeight+1)+
              " AND [birthday] >="+maxBDayStr+ " AND [birthday]<="+ minBDayStr + " AND [inBase]=true", connection);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < bufferTable.Rows.Count; i++)
            {
                result.Add(Convert.ToInt32(bufferTable.Rows[i][0]));
            }
            bufferTable.Clear();
            connection.Close();
            return result;
        }

        public HashSet<int> ChoosePartnerBy(string column, string item, string table)
        { //для вибору партнерів за конкретними характеристиками
            connection.Open();
            dataAdapter = new OleDbDataAdapter();
            command = new OleDbCommand("SELECT id FROM [" + table + "] WHERE [" + column + "]=" + item, connection);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < bufferTable.Rows.Count; i++)
            {
                result.Add(Convert.ToInt32(bufferTable.Rows[i][0]));
            }
            bufferTable.Clear();
            command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        public string ChooseById(string column, int index, string table = "Human", string param = "id")
        { //вибір користувача за індексом
            connection.Open();
            command = new OleDbCommand("SELECT [" + column + "] FROM [" + table + "] WHERE [" + param + "]=" + index, connection);
            string result = command.ExecuteScalar().ToString();
            connection.Close();
            return result;
        }

        public HashSet<int> MyParametrs(Human human)
        { //для вибору партнерів, яким підходить користувач
            connection.Open();
            dataAdapter = new OleDbDataAdapter();
            command = new OleDbCommand("SELECT id FROM [Partner] WHERE [minAge]<=" + human.Age + " AND " +
                "[maxAge]>=" + human.Age + " AND [minHeight]<=" + human.Height + " AND [maxHeight]>=" + human.Height +
                " AND [minWeight]<=" + human.Weight + " AND [maxWeight]>=" + human.Weight, connection);
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            HashSet<int> result = new HashSet<int>();
            for (int i = 0; i < bufferTable.Rows.Count; i++)
            {
                result.Add(Convert.ToInt32(bufferTable.Rows[i][0]));
            }
            bufferTable.Clear();
            connection.Close();
            return result;
        }

        public void AddInvitation(Invitation invitation)
        { //для запису в таблицю даних про запрошення
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [Invitation]([from],[to]," +
                $"[place],[date_])" +
                $"VALUES (from,to,place,date_)", connection);
            command.Parameters.AddWithValue("from", invitation.From.Id);
            command.Parameters.AddWithValue("to", invitation.To.Id);
            command.Parameters.AddWithValue("place", invitation.Place);
            command.Parameters.AddWithValue("date_", invitation.Date);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Invitation[] GetInvitation(int index)
        { //для отримання усіх запрошень із бази
            connection.Open();
            command = new OleDbCommand("SELECT * FROM [Invitation] WHERE [from]=" + index + " OR [to]=" + index, connection);
            dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            Invitation[] invitations = new Invitation[bufferTable.Rows.Count];
            for (int i = 0; i < bufferTable.Rows.Count; i++)
            {
                Invitation invitation = new Invitation();
                invitation.From.Id = Convert.ToInt32(bufferTable.Rows[i][1]);
                invitation.To.Id = Convert.ToInt32(bufferTable.Rows[i][2]);
                invitation.Place = Convert.ToString(bufferTable.Rows[i][3]);
                invitation.Date = Convert.ToDateTime(bufferTable.Rows[i][4]);
                invitations[i] = invitation;
            }
            bufferTable.Clear();
            connection.Close();
            return invitations;
        }

        public void RemoveInvitation(bool archive, int id)
        { //для видалення запрошення з архіву
            connection.Open();
            string query;
            if (archive)
            {
                DateTime date = DateTime.Now;
                string dateStr = date.ToString("#M/d/yyyy HH:MM:ss#").Replace(".", "/");
                query = "DELETE FROM [Invitation] WHERE ([from]=" + id + " OR [to]=" + id + ") " +
                    "AND [date_]>=" + dateStr;                
            }
            else
            {
                query = "DELETE FROM [Invitation] WHERE [from]=" + id + " OR [to]=" + id;
            }
            command = new OleDbCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChangeHuman(Human human)
        { //для зміни інформації про користувача
            connection.Open();
            command = new OleDbCommand("UPDATE [Human] SET [name_] = '" + human.Name + "'," +
                "[lastname] = '" + human.Lastname + "', [post] = '" + human.Post + "', [phone] = '" + human.Phone + "'," +
                "[birthday] = '" + human.Birthday + "', [sex] = '" + human.Sex + "', [education] = '" + human.Education + "'," +
                "[height] = '" + human.Height + "', [weight] = '" + human.Weight + "', [place] = '" + human.Place + "'," +
                "[hair] = '" + human.Hair + "', [eyes] = '" + human.Eyes + "', [religioun] = '" + human.Religioun + "'," +
                "[hobby] = '" + human.Hobby + "', [politic] = '" + human.Politic + "', [impInLife] = '" + human.ImportantInLife + "'," +
                "[impInHuman] = '" + human.ImportantInHuman + "', [smoking] = '" + human.Smoking + "', [alcohol] = '" + human.Alcohol + "'," +
                "[inspiration] = '" + human.Inspiration + "', [photo] = '" + human.Photo + "' WHERE id = " + human.Id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChageUser(User user, int index)
        { //для зміни логіну та пароля
            connection.Open();
            command = new OleDbCommand("UPDATE [User] SET [login] = '" + user.Login + "', [password] = '" + user.Password + "'" +
                "WHERE [id] = " + index, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChangePartner(Partner partner, int id)
        { //для зміни загальних вимог до партнера
            connection.Open();
            command = new OleDbCommand("UPDATE [Partner] SET [minAge] = '" + partner.MinAge + "', [maxAge] = '" + partner.MaxAge + "'," +
                "[minHeight] = '" + partner.MinHeight + "', [maxHeight] = '" + partner.MaxHeight + "', [minWeight] = '" + partner.MinWeight + "'," +
                "[maxWeight] = '" + partner.MaxWeight + "' WHERE id = " + id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChangeEducation(Education e, int id)
        { //для зміни бажаної освіти партнера
            connection.Open();
            command = new OleDbCommand("UPDATE [EducationPartner] SET [nSecondary] = " + e.NSecondary + ", [secondary] = " + e.Secondary + "," +
                "[prof] = " + e.Prof + ", [nHigh] = " + e.NHigh + ", [high] = " + e.High + " WHERE [id] = " + id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChangeSex(Sex s, int id)
        { //для зміни бажаної статі партнера
            connection.Open();
            command = new OleDbCommand("UPDATE [SexPartner] SET [man] =  " + s.Man + ", [woman] =  " + s.Woman + "," +
                "[other] =  " + s.Other + " WHERE [id] = " + id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChangeReligioun(Religioun r, int id)
        { //для зміни бажаного релігійного світогляду партнера
            connection.Open();
            command = new OleDbCommand("UPDATE [ReligiounPartner] SET [iud] =  " + r.Iud + ", [prav] =  " + r.Prav + "," +
                "[katol] =  " + r.Katol + ", [prot] =  " + r.Prot + ", [islam] =  " + r.Islam + ", [budd] =  " + r.Budd + "," +
                "[konf] =  " + r.Konf + ", [past] =  " + r.Past + ", [ate] =  " + r.Ate + " WHERE [id] = " + id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChangePolitical(Political p, int id)
        { //для зміни бажаного політичного світогляду партнера
            connection.Open();
            command = new OleDbCommand("UPDATE [PoliticalPartner] SET [kom] =  " + p.Kom + ", [sots] =  " + p.Sots + "," +
                "[pom] =  " + p.Pom + ", [lib] =  " + p.Lib + ", [cons] =  " + p.Cons + ", [mon] =  " + p.Mon + ", " +
                "[ultra] =  " + p.Ultra + " WHERE [id] = " + id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChangeHair(Hair h, int id)
        { //для зміни бажаного кольору волосся партнера
            connection.Open();
            command = new OleDbCommand("UPDATE [HairPartner] SET [black] =  " + h.Black + ", [white] =  " + h.White + "," +
                "[brown] =  " + h.Brown + ", [lightBrown] =  " + h.LightBrown + ", [darkBrown] =  " + h.DarkBrown + "," +
                "[colour] =  " + h.Colour + ", [other] =  " + h.Other + " WHERE [id] = " + id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChangeEyes(Eyes e, int id)
        { //для зміни бажаного кольору очей партнера
            connection.Open();
            command = new OleDbCommand("UPDATE [EyesPartner] SET [blue] =  " + e.Blue + ", [brown] =  " + e.Brown + "," +
                "[green] =  " + e.Green + ", [gray] =  " + e.Gray + " WHERE [id] = " + id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ChangeAlcohol(Alcohol bh, int id)
        { //» для зміни бажаного ставлення до алкоголю партнера
            connection.Open();
            command = new OleDbCommand("UPDATE [AlcoholPartner] SET [komp] =  " + bh.Komp + ", [neyt] =  " + bh.Neyt + "," +
                "[neg] =  " + bh.Neg + ", [pozit] =  " + bh.Pozit + " WHERE [id] = " + id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void ChangeSmoking(Smoking bh, int id)
        { //для зміни бажаного ставлення до куріння партнера
            connection.Open();
            command = new OleDbCommand("UPDATE [SmokingPartner] SET [komp] =  " + bh.Komp + ", [neyt] =  " + bh.Neyt + "," +
                "[neg] =  " + bh.Neg + ", [pozit] =  " + bh.Pozit + " WHERE [id] = " + id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void ToArchive(int id)
        { //для перенесення користувача в архів
            connection.Open();
            command = new OleDbCommand("UPDATE [Human] SET [inBase] = false, [inArchive] = true " +
                "WHERE [id] = " + id, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddArchive(Couple couple)
        { //для заповнення інформації про пару в архіві
            connection.Open();
            command = new OleDbCommand($"INSERT INTO [Archive]([first],[second],[dateArchive]) VALUES (first,secind,dateArchive)", connection);
            command.Parameters.AddWithValue("first", couple.First.Id);
            command.Parameters.AddWithValue("second", couple.Second.Id);
            command.Parameters.AddWithValue("dateArchive", couple.DateArchive);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public Couple[] ArrayArchive()
        { //для створення масиву пар користувачів в архіві
            connection.Open();
            command = new OleDbCommand("SELECT * FROM [Archive] ", connection);
            dataAdapter = new OleDbDataAdapter();
            dataAdapter.SelectCommand = command;
            dataAdapter.Fill(bufferTable);
            Couple[] couples = new Couple[bufferTable.Rows.Count];
            for (int i = 0; i < bufferTable.Rows.Count; i++)
            {
                couples[i] = new Couple();
                couples[i].First.Id = Convert.ToInt32(bufferTable.Rows[i][1]);
                couples[i].Second.Id = Convert.ToInt32(bufferTable.Rows[i][2]);
                couples[i].DateArchive = Convert.ToDateTime(bufferTable.Rows[i][3]);
            }
            bufferTable.Clear();
            connection.Close();
            return couples;
        }
    }
}
