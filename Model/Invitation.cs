using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Invitation
    { 
        private Human from; //зберігається інформація про користувача, від якого було надіслано запрошення
        private Human to; //зберігається інформація про користувача, кому було надіслано запрошення
        private string place; //інформація про місце зустрічі
        private DateTime date; //зберігається дата та час зустрічі;

        public Invitation()
        {
            from = new Human();
            to = new Human();
        }
        public Invitation(int f, int t)
        {
            from = new Human();
            to = new Human();
            from.Id = f;
            to.Id = t;            
        }
        //Властивості для безпечного управління даними полів
        public Human From
        {
            get { return from; }
            set { from = value; }
        }
        public Human To
        {
            get { return to; }
            set { to = value; }
        }
        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
    }
}
