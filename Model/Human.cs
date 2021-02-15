using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Human
    {
        private int id; //індекс користувача
        private string name; //ім‘я користувача
        private string lastname; //прізвище користувача
        private string post; //ошта користувача
        private string phone; //телефон користувача
        private DateTime birthday; //дата народження користувача
        private int sex; //стать користувача
        private int education; //освіта користувача
        private int height; //зріст користувача
        private int weight; //вага користувача
        private string place; //місце проживання користувача
        private int hair; //колір волосся користувача
        private int eyes; //колір очей користувача
        private int religioun; //релігійний світогляд користувача
        private string hobby; //хобі користувача
        private DateTime registration; //дата реєстрації користувача 
        private int politic; //політичний світогляд користувача
        private int importantInLife; //найважливіше в житті 
        private int importantInHuman; //найважливіше в людях для користувача
        private int smoking; //ставлення до куріння користувача
        private int alcohol; //ставлення до алкоголю користувача
        private string inspiration; //джерело натхнення користувача
        private string photo; //фото користувача
        private Partner bestPartner; //вимоги до партнера користувача
        private bool inBase;  //статус наявності в базі користувача
        private bool inArchive; //статус наявності в архіві користувача користувача


        public Human()
        {
            bestPartner = new Partner();
        }
        //властивості для безпечного доступу до полів класу
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
        public string Post
        {
            get { return post; }
            set { post = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public int Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public int Education
        {
            get { return education; }
            set { education = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        public int Hair
        {
            get { return hair; }
            set { hair = value; }
        }
        public int Eyes
        {
            get { return eyes; }
            set { eyes = value; }
        }
        public int Religioun
        {
            get { return religioun; }
            set { religioun = value; }
        }
        public string Hobby
        {
            get { return hobby; }
            set { hobby = value; }
        }
        public int Politic
        {
            get { return politic; }
            set { politic = value; }
        }
        public int ImportantInLife
        {
            get { return importantInLife; }
            set { importantInLife = value; }
        }

        public int ImportantInHuman
        {
            get { return importantInHuman; }
            set { importantInHuman = value; }
        }
        public int Smoking
        {
            get { return smoking; }
            set { smoking = value; }
        }
        public int Alcohol
        {
            get { return alcohol; }
            set { alcohol = value; }
        }
        public string Inspiration
        {
            get { return inspiration; }
            set { inspiration = value; }
        }
        public bool InBase
        {
            get { return inBase; }
            set { inBase = value; }
        }
        public bool InArchive
        {
            get { return inArchive; }
            set { inArchive = value; }
        }
        public DateTime Registration
        {
            get { return registration; }
            set { registration = value; }
        }
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        public Partner BestPartner
        {
            get { return bestPartner; }
            set { bestPartner = value; }
        }
        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public int Age //виведення віку користувача
        {
            get
            {
                int age = DateTime.Now.Year - birthday.Year;
                if (DateTime.Now.DayOfYear < birthday.DayOfYear) 
                    age--;
                return age;
            }
        }

        public string MyBirthday
        { //для коректного виведення дати народження
            get
            {
                string result = birthday.ToString();
                result = result.Substring(0, result.IndexOf(" "));
                return result;
            }
        }

        public string SexTable
        { //виведення ключа для пошуку по статі
            get
            {
                string result = "";
                switch (sex)
                {
                    case 1:
                        result = "man";
                        break;
                    case 2:
                        result = "woman";
                        break;
                    case 3:
                        result = "other";
                        break;
                    default:
                        break;

                }
                return result;
            }
        }
        public string ReligiounTable
        { //виведення ключа для пошуку по релігійному світогляду
            get
            {
                string result = "";
                switch (religioun)
                {
                    case 1:
                        result = "iud";
                        break;
                    case 2:
                        result = "prav";
                        break;
                    case 3:
                        result = "katol";
                        break;
                    case 4:
                        result = "prot";
                        break;
                    case 5:
                        result = "islam";
                        break;
                    case 6:
                        result = "budd";
                        break;
                    case 7:
                        result = "konf";
                        break;
                    case 8:
                        result = "past";
                        break;
                    case 9:
                        result = "ate";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }

        public string PoliticalTable
        { //виведення ключа для пошуку по політичним вподобанням
            get
            {
                string result = "";
                switch (politic)
                {
                    case 1:
                        result = "kom";
                        break;
                    case 2:
                        result = "sots";
                        break;
                    case 3:
                        result = "pom";
                        break;
                    case 4:
                        result = "lib";
                        break;
                    case 5:
                        result = "cons";
                        break;
                    case 6:
                        result = "mon";
                        break;
                    case 7:
                        result = "ultra";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }
        public string HairTable
        { //виведення ключа для пошуку по кольору волосся
            get
            {
                string result = "";
                switch (hair)
                {
                    case 1:
                        result = "black";
                        break;
                    case 2:
                        result = "white";
                        break;
                    case 3:
                        result = "brown";
                        break;
                    case 4:
                        result = "lightBrown";
                        break;
                    case 5:
                        result = "darkBrown";
                        break;
                    case 6:
                        result = "colour";
                        break;
                    case 7:
                        result = "other";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }
        public string EducationTable
        { //виведення ключа для пошуку по освіті
            get
            {
                string result = "";
                switch (education)
                {
                    case 1:
                        result = "nSecondary";
                        break;
                    case 2:
                        result = "secondary";
                        break;
                    case 3:
                        result = "prof";
                        break;
                    case 4:
                        result = "nHigh";
                        break;
                    case 5:
                        result = "high";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }
        public string EyesTable
        { //виведення ключа для пошуку по кольору очей;
            get
            {
                string result = "";
                switch (eyes)
                {
                    case 1:
                        result = "brown";
                        break;
                    case 2:
                        result = "blue";
                        break;
                    case 3:
                        result = "gray";
                        break;
                    case 4:
                        result = "green";
                        break;
                    default:
                        break;
                }
                return result;
            }
        }
        public string BadHabbitTable(int habbit)
        { //виведення ключа для пошуку по шкідливих звичках
            string result = "";
            switch (habbit)
            {
                case 1:
                    result = "komp";
                    break;
                case 2:
                    result = "neyt";
                    break;
                case 3:
                    result = "pozit";
                    break;
                case 4:
                    result = "neg";
                    break;
                default:
                    break;
            }
            return result;
        }

        public string MySex()
        { //для конвертації коду статі в текст
            string result="";
            switch (sex)
            {
                case 1:
                    result = "Чоловік";
                    break;
                case 2:
                    result = "Жінка";
                    break;
                case 3:
                    result = "Інше";
                    break;
                default:
                    break;
            }
            return result;
        }

        public string MyEducation()
        { //для конвертації коду освіти в текст
            string result = "";
            switch (education)
            {
                case 1:
                    result = "Неповна середня";
                    break;
                case 2:
                    result = "Закінчена середня";
                    break;
                case 3:
                    result = "Середня професійна";
                    break;
                case 4:
                    result = "Неповна вища";
                    break;
                case 5:
                    result = "Вища";
                    break;
                default:
                    break;
            }
            return result;
        }

        public string MyHair()
        { //для конвертації коду кольору волосся в текст
            string result = "";
            switch (hair)
            {
                case 1:
                    if (sex == 1)
                        result = "Брюнет";
                    else if (sex == 2)
                        result = "Брюнетка";
                    else
                        result = "Брюнет(ка)";
                    break;
                case 2:
                    if (sex == 1)
                        result = "Блондин";
                    else if (sex == 2)
                        result = "Блондинка";
                    else
                        result = "Блондин(ка)";
                    break;
                case 3:
                    if (sex == 1)
                        result = "Шатен";
                    else if (sex == 2)
                        result = "Шатенка";
                    else
                        result = "Шатен(ка)";
                    break;
                case 4:
                    result = "Світло-русяве";
                    break;
                case 5:
                    result = "Темно-русяве";
                    break;
                case 6:
                    result = "Кольорове";
                    break;
                case 7:
                    result = "Руде";
                    break;
                default:
                    break;
            }
            return result;
        }
        public string MyEyes()
        {  //для конвертації коду кольору очей в текст
            string result = "";
            switch (eyes)
            {
                case 1:
                    result = "Карі";
                    break;
                case 2:
                    result = "Блакитні";
                    break;
                case 3:
                    result = "Сірі";
                    break;
                case 4:
                    result = "Зелені";
                    break;
                default:
                    break;
            }
            return result;
        }
        public string MyReligioun()
        { //для конвертації коду релігійного світогляду в текст
            string result = "";
            switch (religioun)
            {
                case 1:
                    result = "Іудаїзм";
                    break;
                case 2:
                    result = "Православ*я";
                    break;
                case 3:
                    result = "Католицизм";
                    break;
                case 4:
                    result = "Протестантизм";
                    break;
                case 5:
                    result = "Іслам";
                    break;
                case 6:
                    result = "Буддизм";
                    break;
                case 7:
                    result = "Конфуціанство";
                    break;
                case 8:
                    result = "Пастафаріанство";
                    break;
                case 9:
                    result = "Атеїзм";
                    break;
                default:
                    break;
            }
            return result;
        }
        public string MyPolitition()
        { //для конвертації коду політичних вподобань в текст
            string result = "";
            switch (politic)
            {
                case 1:
                    result = "Комуністичні";
                    break;
                case 2:
                    result = "Соціалістичні";
                    break;
                case 3:
                    result = "Помірні";
                    break;
                case 4:
                    result = "Ліберальні";
                    break;
                case 5:
                    result = "Консервативні";
                    break;
                case 6:
                    result = "Монархічні";
                    break;
                case 7:
                    result = "Ультраконсервативні";
                    break;
                default:
                    break;
            }
            return result;
        }
        public string MyImportantInLife()
        { //для конвертації коду найважливішого в житті в текст
            string result = "";
            switch (importantInLife)
            {
                case 1:
                    result = "Сім*я та діти";
                    break;
                case 2:
                    result = "Кар*єра та гроші";
                    break;
                case 3:
                    result = "Розваги та відпочинок";
                    break;
                case 4:
                    result = "Розваги та відпочинок";
                    break;
                case 5:
                    result = "Удосконалення світу";
                    break;
                case 6:
                    result = "Саморозвиток";
                    break;
                case 7:
                    result = "Краса та мистецтво";
                    break;
                case 8:
                    result = "Слава та впливовість";
                    break;
                default:
                    break;
            }
            return result;
        }

        public string MyImportantInHuman()
        { //для конвертації коду найважливішого в людях в текст
            string result = "";
            switch (importantInHuman)
            {
                case 1:
                    result = "Ум та креативність";
                    break;
                case 2:
                    result = "Доброта і чесність";
                    break;
                case 3:
                    result = "Краса та здоров*я";
                    break;
                case 4:
                    result = "Влада та багатство";
                    break;
                case 5:
                    result = "Сміливість та завзяття";
                    break;
                case 6:
                    result = "Гумор та життєлюбство";
                    break;
                default:
                    break;
            }
            return result;
        }

        public string MyBadHabbit(int habbit)
        { //для конвертації коду шкідливої звички в текст
            string result = "";
            switch (habbit)
            {
                case 1:
                    result = "Компромісне";
                    break;
                case 2:
                    result = "Нейтральне";
                    break;
                case 3:
                    result = "Позитивне";
                    break;
                case 4:
                    result = "Негативне";
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
