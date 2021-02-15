using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class Partner
    {
        private int minAge; //мінімальний вік 
        private int maxAge; //максимальний вік 
        private int minHeight; //мінімальний зріст 
        private int minWeight;  //мінімальна вага
        private int maxHeight; //максимальний зріст 
        private int maxWeight; //максимальна вага
        private Smoking smoking; //всі можливі ставлення до куріння ідеального партнера
        private Alcohol alcohol; //всі можливі ставлення до алкоголю ідеального партнера
        private Political political; //всі можливі ставлення до політики ідеального партнера
        private Religioun religioun; //всі можливі ставлення до релігії ідеального партнера
        private Sex sex; //всі можливі статі ідеального партнера
        private Eyes eyes; //всі можливі кольори очей ідеального партнера
        private Education education; //всі можливі освіти ідеального партнера
        private Hair hair; //всі можливі кольори волосся ідеального партнера
        public Partner()
        {
            minAge = 0;
            maxAge = 0;
            minHeight = 0;
            maxHeight = 0;
            minWeight = 0;
            maxWeight = 0;
            smoking = new Smoking();
            alcohol = new Alcohol();
            political = new Political();
            religioun = new Religioun();
            sex = new Sex();
            eyes = new Eyes();
            education = new Education();
            hair = new Hair();
        }
        public Partner(int minAge, int maxAge, int minHeight, int maxHeight, int minWeight, int maxWeight)
        {
            this.minAge = minAge;
            this.maxAge = maxAge;
            this.minHeight = minHeight;
            this.maxHeight = maxHeight;
            this.minWeight = minWeight;
            this.maxWeight = maxWeight;
            smoking = new Smoking();
            alcohol = new Alcohol();
            political = new Political();
            religioun = new Religioun();
            sex = new Sex();
            eyes = new Eyes();
            education = new Education();
            hair = new Hair();
        }
        //властивості для безпечного управління даними полів
        public int MinAge
        {
            get { return minAge; }
            set { minAge = value; }
        }
        public int MaxAge
        {
            get { return maxAge; }
            set { maxAge = value; }
        }
        public int MinHeight
        {
            get { return minHeight; }
            set { minHeight = value; }
        }
        public int MaxHeight
        {
            get { return maxHeight; }
            set { maxHeight = value; }
        }
        public int MinWeight
        {
            get { return minWeight; }
            set { minWeight = value; }
        }
        public int MaxWeight
        {
            get { return maxWeight; }
            set { maxWeight = value; }
        }
        public Smoking Smoking
        {
            get { return smoking; }
            set { smoking = value; }
        }
        public Alcohol Alcohol
        {
            get { return alcohol; }
            set { alcohol = value; }
        }
        public Political Political
        {
            get { return political; }
            set { political = value; }
        }

        public Religioun Religioun
        {
            get { return religioun; }
            set { religioun = value; }
        }
        public Sex Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public Eyes Eyes
        {
            get { return eyes; }
            set { eyes = value; }
        }

        public Education Education
        {
            get { return education; }
            set { education = value; }
        }
        public Hair Hair
        {
            get { return hair; }
            set { hair = value; }
        }

        private void Swap(ref int a, ref int b)
        { //для зміни місцями мінімального та максимального едементів
            int temp;
            if (a>b)
            {
                temp = a;
                a = b;
                b = temp;
            }
        }

        public void Correct()
        {//для перевірки правильності введення мінімальних та максимальних параметрів
            Swap(ref minAge, ref maxAge);
            Swap(ref minHeight, ref maxHeight);
            Swap(ref minWeight, ref maxWeight);
        }
    }
}
