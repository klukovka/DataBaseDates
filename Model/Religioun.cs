using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Religioun
    {
        private bool iud; //іудаїздм
        private bool prav; //православ"я
        private bool katol; //католицизм
        private bool prot; //протестантизм
        private bool islam; //іслам
        private bool budd; //буддизм
        private bool konf; //конфуціанство
        private bool past; //пастафаріанство
        private bool ate; //атеїзм
        public Religioun()
        {
            iud = false;
            prav = false;
            katol = false;
            prot = false;
            islam = false;
            budd = false;
            konf = false;
            past = false;
            ate = false;
        }
        public Religioun(bool iud, bool prav, bool katol, bool prot, bool islam,
            bool budd, bool konf, bool past, bool ate)
        {
            this.iud = iud;
            this.prav = prav;
            this.katol = katol;
            this.prot = prot;
            this.islam = islam;
            this.budd = budd;
            this.konf = konf;
            this.past = past;
            this.ate = ate;          
        }
        //безпечний доступ до полів

        public bool Iud
        {
            get { return iud; }
            set { iud = value; }
        }
        public bool Prav
        {
            get { return prav; }
            set { prav = value; }
        }
        public bool Katol
        {
            get { return katol; }
            set { katol = value; }
        }
        public bool Prot
        {
            get { return prot; }
            set { prot = value; }
        }
        public bool Islam
        {
            get { return islam; }
            set { islam = value; }
        }
        public bool Budd
        {
            get { return budd; }
            set { budd = value; }
        }
        public bool Konf
        {
            get { return konf; }
            set { konf = value; }
        }
        public bool Past
        {
            get { return past; }
            set { past = value; }
        }
        public bool Ate
        {
            get { return ate; }
            set { ate = value; }
        }

        public void Check()
        { //перевірка введення
            if (iud == false &&
            prav == false &&
            katol == false &&
            prot == false &&
            islam == false &&
            budd == false &&
            konf == false &&
            past == false &&
            ate == false)
            {
                iud = true;
                prav = true;
                katol = true;
                prot = true;
                islam = true;
                budd = true;
                konf = true;
                past = true;
                ate = true;
            }
        }

        public string GetReligioun()
        { //для виведення інформації в полі
            string result = "";
            if (iud)
                result += "Іудаїзм, ";
            if (prav)
                result += "Православ*я, ";
            if (katol)
                result += "Католицизм, ";
            if (prot)
                result += "Протестантизм, ";
            if (islam)
                result += "Іслам, ";
            if (budd)
                result += "Буддизм, ";
            if (konf)
                result += "Конфуціанство, ";
            if (past)
                result += "Пастафаріанство, ";
            if (ate)
                result += "Атеїзм, ";
            result = result.Substring(0, result.Length - 2);

            return result;
        }
    }
}
