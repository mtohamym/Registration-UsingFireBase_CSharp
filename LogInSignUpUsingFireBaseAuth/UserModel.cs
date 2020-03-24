using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogInSignUpUsingFireBaseAuth
{
    class UserModel
    {
        public string FirstName;
        public string SecondName;
        public string Password;
        public string Email;


        public UserModel(string firstName, string secondName, string password, string email)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
            this.Password = password;
            this.Email = email;
        }
        public UserModel(string password, string firstName)
        {

            this.Password = password;
            this.FirstName = firstName;
        }
        public UserModel()
        {
           
        }



       
    }
}
