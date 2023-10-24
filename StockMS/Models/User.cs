using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StockMS.Models
{
    public class User : Database
    {
        public int Id;

        private string name;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length <= 50 && namePattern.Match(value).ToString() == value)
                {
                    this.name = value;
                }
                else
                {
                    throw new Exception("Name should not be more than 50 characters");
                }
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value;
            }
        }
        private string phone;
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }
        private int status;
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                if (value == 0 || value == 1)
                {
                    this.status = value;
                }
                else
                {
                    throw new Exception("Status should be 1 or 0");
                }
            }
        }
        private int isAdmin;

        public int IsAdmin
        {
            get
            {
                return isAdmin;
            }
            set
            {
                if (value == 0 || value == 1)
                {
                    isAdmin = value;
                }
                else
                {
                    throw new Exception("User Type should be 1 or 0");
                }
            }
        }


        private readonly Regex namePattern = new Regex("[A-Za-z\\s]+$");

        protected override string[,] Fields()
        {
            return new string[,]
            {
                //{"id", Id.ToString() },
                {"name", Name.ToString() },
                {"password", Password.ToString() },
                {"phone", Phone.ToString() },
                {"status", Status.ToString() },
                {"isAdmin", IsAdmin.ToString() },
            };
        }

        public User()
        {
            TYPE = "user";
        }
    }
}
