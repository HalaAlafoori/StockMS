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
            }
            catch (Exception e)
            {
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
            LogProxy logProxy = new LogProxy();
            try
            {
                User.TYPE = "user";
                User.Activate(id);

                // user log
                UserLogModel ulm = new UserLogModel();
                ulm.UserId = UserDetails.ID;
                ulm.RowId = id;
                ulm.Type = "update";
                ulm.TableName = "user";
                logProxy.Log(ulm);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static bool AddUser(string username, string password, string phone, int userType)
        {
            User newUser = new User();
            LogProxy logProxy = new LogProxy();

            try
            {
                newUser.Name = username;
                newUser.Password = password;
                newUser.Phone = phone;
                newUser.IsAdmin = userType;
                string returned = newUser.Save();

                if (!returned.StartsWith("ERR"))
                {
                    // user log
                    UserLogModel ulm = new UserLogModel();
                    ulm.UserId = UserDetails.ID;
                    ulm.RowId = int.Parse(returned);
                    ulm.Type = "insert";
                    ulm.TableName = "user";
                    logProxy.Log(ulm);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        public static void UpdateUser(int ID, string name, string password, string phone, int userType)
        {
            LogProxy logProxy = new LogProxy();

            User updUser = new User();
            try
            {
                updUser.Id = ID;
                updUser.Name = name;
                updUser.Password = password;
                updUser.Phone = phone;
                updUser.IsAdmin = userType;
                string returned = updUser.Update();
                if (!returned.StartsWith("ERR"))
                {
                    // user log
                    UserLogModel ulm = new UserLogModel();
                    ulm.UserId = UserDetails.ID;
                    ulm.RowId = ID;
                    ulm.Type = "update";
                    ulm.TableName = "user";
                    logProxy.Log(ulm);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public static void DeleteUser(int ID)
        {
            LogProxy logProxy = new LogProxy();

            try
            {
                string returned = User.Remove(ID.ToString(), "id");
                if (!returned.StartsWith("ERR"))
                {
                    // user log
                    UserLogModel ulm = new UserLogModel();
                    ulm.UserId = UserDetails.ID;
                    ulm.RowId = ID;
                    ulm.Type = "delete";
                    ulm.TableName = "user";
                    logProxy.Log(ulm);
                }
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

        public static DataTable GetItem(String name)
        {
            try
            {
                User.TYPE = "item";
                return User.Find(name, "name");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return new DataTable();
            }
        }

        public static bool AddItem(string name, double price)
        {
            LogProxy logProxy = new LogProxy();

            Item newitem = new Item();
            try
            {
                newitem.Name = name;
                newitem.Price = price;
                string returned = newitem.Save();

                if (!returned.StartsWith("ERR"))
                {
                    // item log
                    UserLogModel ulm = new UserLogModel();
                    ulm.UserId = UserDetails.ID;
                    ulm.RowId = int.Parse(returned);
                    ulm.Type = "insert";
                    ulm.TableName = "item";
                    logProxy.Log(ulm);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }
        public static void DeleteItem(string ID)
        {
            LogProxy logProxy = new LogProxy();

            try
            {
                Item.TYPE = "item";
                string returned = Item.Remove(ID, "id");
                if (!returned.StartsWith("ERR"))
                {
                    // Item log
                    UserLogModel ulm = new UserLogModel();
                    ulm.UserId = UserDetails.ID;
                    ulm.RowId = int.Parse(ID);
                    ulm.Type = "delete";
                    ulm.TableName = "item";
                    logProxy.Log(ulm);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public static void UpdateItem(int ID, string name, string price)
        {
            LogProxy logProxy = new LogProxy();

            Item upditem = new Item();
            try
            {
                upditem.Id = ID;
                upditem.Name = name;
                upditem.Price = double.Parse(price);
                string returned = upditem.Update();
                if (!returned.StartsWith("ERR"))
                {
                    // item log
                    UserLogModel ulm = new UserLogModel();
                    ulm.UserId = UserDetails.ID;
                    ulm.RowId = ID;
                    ulm.Type = "update";
                    ulm.TableName = "item";
                    logProxy.Log(ulm);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        // transaction operations
        public static bool AddTransaction(int itemId, int stockId, String Details, int Quantitiy, int Type, String date)
        {
            LogProxy logProxy = new LogProxy();

            Transaction newtrans = new Transaction();
            try
            {
                newtrans.Details = Details;
                newtrans.Type = Type;
                newtrans.Quantitiy = Quantitiy;
                newtrans.Date = date;
                newtrans.ItemID = itemId;
                newtrans.StockId = stockId;

                string returned = newtrans.Save();
                if (!returned.StartsWith("ERR"))
                {
                    // transaction log
                    UserLogModel ulm = new UserLogModel();
                    ulm.UserId = UserDetails.ID;
                    ulm.RowId = int.Parse(returned);
                    ulm.Type = "insert";
                    ulm.TableName = "transaction";
                    logProxy.Log(ulm);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

            //FOR TESTING
            //MessageBox.Show(newUser.Save());
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

        public static void DeleteTransaction(string ID)
        {
            try
            {
                Item.TYPE = "transaction";
                Item.Remove(ID, "id");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Item stock
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
            LogProxy logProxy = new LogProxy();

            Stock newStock = new Stock();
            try
            {
                newStock.Name = name;
                newStock.Location = location;
                string returned = newStock.Save();
                if (!returned.StartsWith("ERR"))
                {
                    // stock log
                    UserLogModel ulm = new UserLogModel();
                    ulm.UserId = UserDetails.ID;
                    ulm.RowId = int.Parse(returned);
                    ulm.Type = "insert";
                    ulm.TableName = "stock";
                    logProxy.Log(ulm);
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }
        public static void DeleteStock(string ID)
        {
            LogProxy logProxy = new LogProxy();

            try
            {
                Item.TYPE = "stock";
                string returned = Item.Remove(ID, "id");
                if (!returned.StartsWith("ERR"))
                {
                    // stock log
                    UserLogModel ulm = new UserLogModel();
                    ulm.UserId = UserDetails.ID;
                    ulm.RowId = int.Parse(ID);
                    ulm.Type = "delete";
                    ulm.TableName = "stock";
                    logProxy.Log(ulm);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void UpdateStock(int ID, string name, string location)
        {
            LogProxy logProxy = new LogProxy();

            Stock updStock = new Stock();
            try
            {
                updStock.Id = ID;
                updStock.Name = name;
                updStock.Location = location;
                string returned = updStock.Update();
                if (!returned.StartsWith("ERR"))
                {
                    // stock log
                    UserLogModel ulm = new UserLogModel();
                    ulm.UserId = UserDetails.ID;
                    ulm.RowId = ID;
                    ulm.Type = "update";
                    ulm.TableName = "stock";
                    logProxy.Log(ulm);
                }
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
            try
            {
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


