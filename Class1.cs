using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wave_Priject
{
    class LoginManage
    {
        private readonly string _Username = "admin";

        private readonly string _Password = "0000";



        public bool UsernameValidation(string username)
        {
            return (_Username == username);
        }

        public bool PasswordValidation(string password)
        {
            return (_Password == password);
        }
    }
}
