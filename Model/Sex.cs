using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Sex
    {
        private bool man; //чоловік
        private bool woman; //жінка
        private bool other; //інше
        public Sex()
        {
            man = false;
            woman = false;
            other = false;

        }
        public Sex(bool man, bool woman, bool other)
        {
            this.man = man;
            this.woman = woman;
            this.other = other;                
        }
        //безпечний доступ до полів

        public bool Man
        {
            get { return man; }
            set { man = value; }
        }
        public bool Woman
        {
            get { return woman; }
            set { woman = value; }
        }
        public bool Other
        {
            get { return other; }
            set { other = value; }
        }

        public void Check()
        { //перевірка введення
            if (man==false && woman==false && other == false)
            {
                man = true;
                woman = true;
                other = true;
            }
        }

        public string GetSex()
        { //для виведення інформації в полі
            string result = "";
            if (man)
                result += "Чоловік, ";
            if (woman)
                result += "Жінка, ";
            if (other)
                result += "Інше, ";
            result = result.Substring(0, result.Length - 2);
            return result;
        }
    }
}
