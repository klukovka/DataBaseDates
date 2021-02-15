using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Eyes
    {
        private bool brown; //карі
        private bool blue; //блакитні
        private bool gray; //сірі
        private bool green; //зелені
        public Eyes()
        {
            brown = false;
            blue = false;
            gray = false;
            green = false;
        }
        public Eyes(bool brown, bool blue, bool gray, bool green)
        {
            this.brown = brown;
            this.blue = blue;
            this.gray = gray;
            this.green = green;
        }
        //безпечний доступ до полів

        public bool Brown
        {
            get { return brown; }
            set { brown = value; }
        }
        public bool Blue
        {
            get { return blue; }
            set { blue = value; }
        }
        public bool Gray
        {
            get { return gray; }
            set { gray = value; }
        }
        public bool Green
        {
            get { return green; }
            set { green = value; }
        }

        public void Check()
        { //перевірка введення
            if (brown == false &&
            blue == false &&
            gray == false &&
            green == false)
            {

                brown = true;
                blue = true;
                gray = true;
                green = true;
            }
        }
        public string GetEyes()
        { //для виведення інформації в полі
            string result = "";
            if (brown)
                result += "Карі, ";
            if (blue)
                result += "Блакитні, ";
            if (gray)
                result += "Сірі, ";
            if (green)
                result += "Зелені, ";
            result = result.Substring(0, result.Length - 2);
            return result;
        }
    }
}
