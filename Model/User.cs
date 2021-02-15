using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDates.Model
{
    class User
    {
        string login; //в ньому зберігається логін користувача
        string password; //в ньому зберігається пароль користувача

        public User()
        {
            login = "";
            password = "";
        }
        public User(string login, string password)
        { 
            this.login = login;
            this.password = password;               
        }
        public string Login
        { //для безпечного управління даними поля «login»
            get { return login; }
            set { login = value; }
        }
        public string Password
        { //для безпечного управління даними поля «password»
            get { return password; }
            set { password = value; }
        }

        public bool Correct()
        { //для валідації введених даних
            return (login.Length > 5 && password.Length > 5 && login.IndexOf(" ") <0 && password.IndexOf(" ")<0);
        }
    }
}
