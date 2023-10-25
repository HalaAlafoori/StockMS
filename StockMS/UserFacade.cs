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
                return returned == "1" ? true : false;
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

        public static DataTable GetItem(String name)
        {
            try
            {
                User.TYPE = "item";
                return User.Find(name,"name");
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

        public static bool AddTransaction(int itemId,int stockId,String Details,int Quantitiy,int Type,String date )
        {
            Transaction newtrans = new Transaction();
            try
            {
                newtrans.Details = Details;
                newtrans.Type = Type;
                newtrans.Quantitiy = Quantitiy;
                newtrans.Date = date;
                newtrans.ItemID = itemId;
                newtrans.StockId = 1;


                //newUser.PhoneNumber = Int32.Parse(phoneNumber);
                string returned = newtrans.Save();
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

        public static DataTable AllStocks()
        {
            try
            {
                User.TYPE = "stock";
                return User.All();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new DataTable();
            }
        }
        public static bool AddStock(string name, string location)
        {
            Stock newStock = new Stock();
            try
            {
                newStock.Name = name;
                newStock.Location = location;
                //newUser.PhoneNumber = Int32.Parse(phoneNumber);
                string returned = newStock.Save();
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
        public static void DeleteStock(string ID)
        {
            try
            {
                Item.TYPE = "stock";
                Item.Remove(ID, "id");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void UpdateStock(int ID, string name, string location)
        {
            Stock updStock = new Stock();
            try
            {
                updStock.Id = ID;
                updStock.Name = name;
                updStock.Location = location;
                //upditem.Price = Int32.Parse(salary);
                updStock.Update();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            //FOR TESTING
            //MessageBox.Show(updteacher.Update());
        }


        public static DataTable AllTrans()
        {
            try
            {
                User.TYPE = "transaction";
                return User.All();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new DataTable();
            }
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


