using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMS
{
    internal class UserDetails
    {
        public static Int64 ID;
        public static string username;
        public static string role;
        public static string isAdmin;

        internal static void AuthorizeUser(string password, DataTable userdata, Form form, Form newWindow)
        {
            //if (userdata.Rows[0].Field<Int64>("Status") == 0) // error
            if (userdata.Rows[0].Field<string>("status") == "0")
            {
                MessageBox.Show("User is not active");
                return;
            }
            if (userdata.Rows[0].Field<string>("password") == password)
            {
                //UserDetails.ID = userdata.Rows[0].Field<Int64>("ID"); // ERROR
                // GPT solve
                string idValue = userdata.Rows[0].Field<string>("ID");
                if (Int64.TryParse(idValue, out long id))
                {
                    UserDetails.ID = id;
                }

                string isadminValue = userdata.Rows[0].Field<string>("is_admin");
                if (Int64.TryParse(isadminValue, out long isadmin))
                {
                    UserDetails.isAdmin = isadminValue;
                }
                //else
                //{ }
                UserDetails.username = userdata.Rows[0].Field<string>("name");
                if (UserDetails.isAdmin == "1")
                {
                    UserDetails.role = "admin";
                }
                else
                {
                    UserDetails.role = "user";
                }
                form.Hide();
                newWindow.ShowDialog();
                form.Close();
            }
            else
            {
                MessageBox.Show("Password or username are wrong!", "Warning!");
            }
        }

    }
}