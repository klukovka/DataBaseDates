using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Couple
    {
        private Human first; //інформація про першого користувача пари
        private Human second; //інформація про другого користувача пари
        private DateTime dateArchive; //дата архівування

        public Couple()
        {
            first = new Human();
            second = new Human();
            dateArchive = DateTime.Today;
        }

        public Couple(int idFirst, int idSecond)
        {
            first = new Human();
            second = new Human();
            first.Id = idFirst;
            second.Id = idSecond;
            dateArchive = DateTime.Today;
        }
        //Властивості для безпечного управління даними полів
        public Human First
        {
            get { return first; }
            set { first = value; }
        }

        public Human Second
        {
            get { return second; }
            set { second = value; }
        }

        public DateTime DateArchive
        {
            get { return dateArchive; }
            set { dateArchive = value; }
        }
    }
}
