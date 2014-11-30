using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FamilyFinancial.Domain.AggregateRoot
{
    public class Account:IAggregateRoot<int>
    {
        private Account(){}
        public Account(string loginName,string password)
        {
            if(string.IsNullOrEmpty(loginName))
                throw  new Exception("loginName can't be null or empty");

            this.LoginName = loginName;
            this.ChangPassword(password);
        }

        public int Id { get; set; }
        public string LoginName { get; private set; }
        public string Password { get; private set; }
        public string RegisterEmail { get; set; }

        public void ChangPassword(string newPassword)
        {
            if (string.IsNullOrEmpty(newPassword))
                throw new Exception("password can't be null or empty");

            if(newPassword.Length > 8 || newPassword.Length < 6)
                throw new Exception("password length should between 6 and 8");

            this.Password = newPassword;
        }
    }
}
