using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Smoking
    {
        private bool komp; // компроміне
        private bool neyt; // нейтральне
        private bool pozit; // позитивне
        private bool neg; // негативне
        public Smoking()
        {
            komp = false;
            neyt = false;
            pozit = false;
            neg = false;
        }
        public Smoking(bool komp, bool neyt, bool pozit, bool neg)
        {
            this.komp = komp;
            this.neyt = neyt;
            this.pozit = pozit;
            this.neg = neg;
        }
        //безпечний доступ до полів
        public bool Komp
        {
            get { return komp; }
            set { komp = value; }
        }
        public bool Neyt
        {
            get { return neyt; }
            set { neyt = value; }
        }
        public bool Pozit
        {
            get { return pozit; }
            set { pozit = value; }
        }
        public bool Neg
        {
            get { return neg; }
            set { neg = value; }
        }

        public void Check()
        { //перевірка введення
            if (komp==false && neyt == false &&
                pozit==false && neg == false)
            {
                komp = true;
                neyt = true;
                pozit = true;
                neg = true;
            }
        }

        public string GetSmoking()
        { //для виведення інформації в полі
            string result = "";
            if (komp)
                result += "Компромісне, ";
            if (neyt)
                result += "Нейтральне, ";
            if (pozit)
                result += "Позитивне, ";
            if (neg)
                result += "Негативне, ";
            result = result.Substring(0, result.Length - 2);
            return result;
        }
    }
}
