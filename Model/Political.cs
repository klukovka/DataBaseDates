using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Political
    {
        private bool kom; //комуністичні
        private bool sots; //соціалістичні
        private bool pom; //помірні
        private bool lib; //ліберальні
        private bool cons; //конституційні
        private bool mon; //монархічні
        private bool ultra; //ультраконсервативні
        public Political()
        {
            kom = false;
            sots = false;
            pom = false;
            lib = false;
            cons = false;
            mon = false;
            ultra = false;
        }
        public Political(bool kom, bool sots, bool pom, bool lib, bool cons, bool mon, bool ultra)
        {
            this.kom = kom;
            this.pom = pom;
            this.lib = lib;
            this.cons = cons;
            this.sots = sots;
            this.mon = mon;
            this.ultra = ultra;
        }
        //безпечний доступ до полів

        public bool Kom
        {
            get { return kom; }
            set { kom = value; }
        }
        public bool Sots
        {
            get { return sots; }
            set { sots = value; }
        }
        public bool Pom
        {
            get { return pom; }
            set { pom = value; }
        }
        public bool Lib
        {
            get { return lib; }
            set { lib = value; }
        }
        public bool Cons
        {
            get { return cons; }
            set { cons = value; }
        }
        public bool Mon
        {
            get { return mon; }
            set { mon = value; }
        }
        public bool Ultra
        {
            get { return ultra; }
            set { ultra = value; }
        }

        public void Check()
        { //перевірка введення
            if (kom == false &&
            sots == false &&
            pom == false &&
            lib == false &&
            cons == false &&
            mon == false &&
            ultra == false)
            {
                kom = true;
                sots = true;
                pom = true;
                lib = true;
                cons = true;
                mon = true;
                ultra = true;
            }
        }
        public string GetPolitical()
        { //для виведення інформації в полі
            string result = "";
            if (kom)
                result += "Комуністичні, ";
            if (sots)
                result += "Соціалістичні, ";
            if (pom)
                result += "Помірні, ";
            if (lib)
                result += "Ліберальні, ";
            if (cons)
                result += "Консервативні, ";
            if (mon)
                result += "Монархічні, ";
            if (ultra)
                result += "Ультраконсервативні, ";

            result = result.Substring(0, result.Length - 2);
            return result;
        }
    }
}
