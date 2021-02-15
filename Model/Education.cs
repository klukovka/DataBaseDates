using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Education
    {
        private bool nSecondary; //неповна середня
        private bool secondary; //середня
        private bool prof; // середня професійна
        private bool nHigh; //неповна вища
        private bool high; //вища
        public Education()
        {
            nSecondary = false;
            secondary = false;
            prof = false;
            nHigh = false;
            high = false;
        }
        public Education(bool nSecondary, bool secondary, bool prof, bool nHigh, bool high)
        {
            this.nSecondary = nSecondary;
            this.secondary = secondary;
            this.prof = prof;
            this.nHigh = nHigh;
            this.high = high;
        }
        //безпечний доступ до полів

        public bool NSecondary
        {
            get { return nSecondary; }
            set { nSecondary = value; }
        }
        public bool Secondary
        {
            get { return secondary; }
            set { secondary = value; }
        }
        public bool Prof
        {
            get { return prof; }
            set { prof = value; }
        }
        public bool NHigh
        {
            get { return nHigh; }
            set { nHigh = value; }
        }
        public bool High
        {
            get { return high; }
            set { high = value; }
        }

        public void Check()
        { //перевірка введення
            if (nSecondary == false &&
            secondary == false &&
            prof == false &&
            nHigh == false &&
            high == false)
            {
                nSecondary = true;
                secondary = true;
                prof = true;
                nHigh = true;
                high = true;
            }
        }

        public string GetEducation()
        { //для виведення інформації в полі
            string result = "";
            if (nSecondary)
                result += "Неповна середня, ";
            if (secondary)
                result += "Закінчена середня, ";
            if (prof)
                result += "Середня професійна, ";
            if (nHigh)
                result += "Неповна вища, ";
            if (high)
                result += "Вища, ";
            result = result.Substring(0, result.Length - 2);

            return result;
        }
    }
}
