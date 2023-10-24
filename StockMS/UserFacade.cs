using StockMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockMS
{
    internal class UserFacade
    {

        // user operations
        public static DataTable LoginUser(string username)
        {
            User user = new User();
            try
            {
                user.Name = username;
                return User.Find(username);
                //return User.Find(user.Name);
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return new DataTable();
            }
        }

        public static DataTable AllUsers()
        {
            try
            {
                User.TYPE = "user";
                return User.All();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new DataTable();
            }
        }

        public static void ActivateUser(int id)
        {
            try
            {
                User.TYPE = "user";
                User.Activate(id);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static bool AddUser(string username, string password, string phone, int userType)
        {
            User newUser = new User();
            try
            {
                newUser.Name = username;
                newUser.Password = password;
                newUser.Phone = phone;
                newUser.IsAdmin = userType;
                string returned = newUser.Save();
                return returned == "1"? true:false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        public static void UpdateUser(int ID, string name, string password, string phone, int userType)
        {
            User updUser = new User();
            try
            {
                updUser.Id = ID;
                updUser.Name = name;
                updUser.Password = password;
                updUser.Phone = phone;
                updUser.IsAdmin = userType;
                updUser.Update();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public static void DeleteUser(int ID)
        {
            try
            {
                //User.TYPE = "user";
                User.Remove(ID.ToString(), "id");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        // Item operations

        public static DataTable AllItems()
        {
            try
            {
                User.TYPE = "item";
                return User.All();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new DataTable();
            }
        }

        public static bool AddItem(string name, double price)
        {
            Item newitem = new Item();
            try
            {
                newitem.Name = name;
                newitem.Price = price;
                //newUser.PhoneNumber = Int32.Parse(phoneNumber);
                string returned = newitem.Save();
                return returned == "1" ? true : false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            //FOR TESTING
            //MessageBox.Show(newUser.Save());
        }

        public static void DeleteItem(string ID)
        {
            try
            {
                Item.TYPE = "item";
                Item.Remove(ID, "id");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void UpdateItem(int ID, string name, string price)
        {
            Item upditem = new Item();
            try
            {
                upditem.Id = ID;
                upditem.Name = name;
                upditem.Price = double.Parse(price);
                //upditem.Price = Int32.Parse(salary);
                upditem.Update();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            //FOR TESTING
            //MessageBox.Show(updteacher.Update());
        }

        // user log operations

        public static bool AddUserLog(UserLogModel newLog)
        {
            //UserLogModel newLog = new UserLogModel();
            try
            {
                //newLog.UserId = userId;
                //newLog.RowId = rowId;
                //newLog.TableName = tableName;
                //newLog.Type = type;
                string returned = newLog.Save();
                return returned == "1" ? true : false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

    }

}
