using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Hair
    {
        private bool black; //брюнет
        private bool white; //блондин
        private bool brown; //русявий
        private bool lightBrown; //світло-русявий
        private bool darkBrown; //темно-русявий
        private bool colour; //кольоровий
        private bool other; //рудий
        public Hair()
        {
            black = false;
            white = false;
            brown = false;
            lightBrown = false;
            darkBrown = false;
            colour = false;
            other = false;
        }
        public Hair(bool black, bool white, bool brown, bool lightBrown, bool darkBrown, bool colour, bool other)
        {
            this.black = black;
            this.brown = brown;
            this.lightBrown = lightBrown;
            this.darkBrown = darkBrown;
            this.white = white;
            this.colour = colour;
            this.other = other;
        }
        //безпечний доступ до полів

        public bool Black
        {
            get { return black; }
            set { black = value; }
        }
        public bool White
        {
            get { return white; }
            set { white = value; }
        }
        public bool Brown
        {
            get { return brown; }
            set { brown = value; }
        }
        public bool LightBrown
        {
            get { return lightBrown; }
            set { lightBrown = value; }
        }
        public bool DarkBrown
        {
            get { return darkBrown; }
            set { darkBrown = value; }
        }
        public bool Colour
        {
            get { return colour; }
            set { colour = value; }
        }
        public bool Other
        {
            get { return other; }
            set { other = value; }
        }

        public void Check()
        { //перевірка введення
            if (black == false &&
            white == false &&
            brown == false &&
            lightBrown == false &&
            darkBrown == false &&
            colour == false &&
            other == false)
            {
                black = true;
                white = true;
                brown = true;
                lightBrown = true;
                darkBrown = true;
                colour = true;
                other = true;
            }
        }
        public string GetHair()
        { //для виведення інформації в полі
            string result = "";
            if (black)
                result += "Брюнет(ка), ";
            if (white)
                result += "Блондинка(ка), ";
            if (brown)
                result += "Шатен(ка), ";
            if (lightBrown)
                result += "Світло-русяве, ";
            if (darkBrown)
                result += "Темно-русяве, ";
            if (colour)
                result += "Кольорове, ";
            if (other)
                result += "Руде, ";
            result = result.Substring(0, result.Length - 2);
            return result;
        }
    }
}
