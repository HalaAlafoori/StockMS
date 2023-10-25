using StockMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StockMS
{

    public partial class Manage_transactions : Form
    {

        int chosenItem;
        int chosenStock;
        DataTable stocksTable;
        DataTable itemTable;
        private void refresh()
        {

            DataGridView_trans.DataSource = UserFacade.AllTrans();
            toggleBtnDisabled();
            DataGridView_trans.ClearSelection();
        }
        private void setStocks(int chosenId = 0) {

            stockCmbox.Items.Clear();
             stocksTable = UserFacade.AllStocks();
            int selected = -1;
            int count = 0;
            foreach (DataRow row in stocksTable.Rows)
            {

                if (Convert.ToInt32(row["id"]) == chosenId) selected = count;
                string stockName = row["Name"].ToString(); // Replace "StockName" with the column name in your DataTable that contains the stock names
                stockCmbox.Items.Add(stockName);
                count++;
            }
            if (selected != -1)
                stockCmbox.SelectedIndex = selected;
        }
        private void setItems(int chosenId=0)
        {
            itemCmbox.Items.Clear();
            itemTable = UserFacade.AllItems();
            int selected=-1;
             int count = 0;
            foreach (DataRow row in itemTable.Rows)
            {
                
                if(Convert.ToInt32( row["id"])==chosenId)  selected =count;
                string itemName = row["Name"].ToString(); // Replace "StockName" with the column name in your DataTable that contains the stock names
                itemCmbox.Items.Add(itemName);
                 count++;
            }
            if(selected != -1)
            itemCmbox.SelectedIndex = selected;
        }

        public Manage_transactions()
        {
            InitializeComponent();
            //stockDropdown();
            //itemDropdown();
        }
        private void toggleBtnEnabled()
        {
            // btn_active.Enabled = true;
            //btn_active.BackColor = active ? Color.Orange : Color.Blue;
            deleteBtn.Enabled = true;
            deleteBtn.BackColor = Color.Red;
            updateBtn.Enabled = true;
            updateBtn.BackColor = Color.Green;
        }
        private void toggleBtnDisabled()
        {
            //btn_active.Enabled = false;
            //btn_active.BackColor = Color.Gray;
            deleteBtn.Enabled = false;
            deleteBtn.BackColor = Color.Gray;
            updateBtn.Enabled = false;
            updateBtn.BackColor = Color.Gray;
        }
        private void Manage_users_Load(object sender, EventArgs e)
        {
            refresh();
            setStocks();
            setItems();

            stockDropdown();
            itemDropdown();
            



        }
        int id;
        int item;
        int stock;
        string date;
        int quantity;
        int type;
        string details;
        bool passFlag;
        bool active;
        private void DataGridView_trans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id = Int32.Parse(DataGridView_trans.Rows[e.RowIndex].Cells["id"].Value.ToString());

                details = DataGridView_trans.Rows[e.RowIndex].Cells["Details"].Value.ToString();

                quantity = Convert.ToInt32(DataGridView_trans.Rows[e.RowIndex].Cells["Quantity"].Value);
                type = Convert.ToInt32(DataGridView_trans.Rows[e.RowIndex].Cells["Type"].Value);
                chosenItem =  Convert.ToInt32( DataGridView_trans.Rows[e.RowIndex].Cells["item_id"].Value);
                chosenStock = Convert.ToInt32(DataGridView_trans.Rows[e.RowIndex].Cells["stock_id"].Value);


                quantityNum.Value = quantity;
                typeCmbox.SelectedIndex = type;
                detalisTxt.Text = details;

                setItems(chosenItem);
                setStocks(chosenStock);



                toggleBtnEnabled();
                passFlag = false;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            //
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            UserFacade.DeleteTransaction(id.ToString());
            refresh();
        }

        private void btn_active_Click(object sender, EventArgs e)
        {

        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            passFlag = true;
        }

        private void transCmbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addBtn_Click(object sender, EventArgs e)
        {

        }

        private void addBtn_Click_1(object sender, EventArgs e)
        {
            int item_id = -1;
            int selectedItem = Convert.ToInt32(itemCmbox.SelectedIndex);
            if (selectedItem >= 0)
            {//three is a value
                var row = itemTable.Rows[selectedItem];
                item_id = Convert.ToInt32(row["id"]);

            }
            int stock_id = -1;
            int selectedStock = Convert.ToInt32(stockCmbox.SelectedIndex);
            if (selectedStock >= 0)
            {
                var row = stocksTable.Rows[selectedStock];
                stock_id = Convert.ToInt32(row["id"]);

            }

            string dateString = Transaction.dateToString(DataDtp.Value);

            UserFacade.AddTransaction(
           item_id,
           stock_id,
           detalisTxt.Text,
           Convert.ToInt16(quantityNum.Value),
           typeCmbox.SelectedIndex,
           dateString

           );
            refresh();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            chosenItem = -1;
            chosenStock = -1;
            type = -1;
            quantityNum.Value = 0;
            detalisTxt.Text = "";

            // Clear the selected values in the ComboBox controls
            itemCmbox.SelectedIndex = -1;
            stockCmbox.SelectedIndex = -1;
            typeCmbox.SelectedIndex = -1;
        }

        private void ItemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void stockComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void itemDropdown()
        {
            //DataTable items = UserFacade.AllItems();

            // Create a list to store the item names
            List<string> itemFilter = new List<string>();

            itemFilter.Add("");
            // Iterate through the items and add their names to the list
            foreach (DataRow row in itemTable.Rows)
            {
                string itemName = row["name"].ToString();
                itemFilter.Add(itemName);
            }

            // Set the list as the data source for the dropdown list
            ItemComboBox.DataSource = itemFilter;
        }

        private void stockDropdown()
        {
            //DataTable stocks = UserFacade.AllStocks();

            // Create a list to store the item names
            List<string> stockFilter = new List<string>();

            stockFilter.Add("");
            // Iterate through the items and add their names to the list
            foreach (DataRow row in stocksTable.Rows)
            {
                string stockName = row["name"].ToString();
                stockFilter.Add(stockName);
            }

            // Set the list as the data source for the dropdown list
            stockComboBox.DataSource = stockFilter;
        }

        private void fromPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void toPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ApplyFilters()
        {
            // Get the selected values from the filters
            string selectedItem = (string)ItemComboBox.SelectedItem;
            string selectedStock = (string)stockComboBox.SelectedItem;

            int itemId = getId(selectedItem, "item");
            int stockId = getId(selectedStock, "stock");

            MessageBox.Show(selectedItem + itemId.ToString());

            //if (selectedPrice > 0 || (selectedName != null && selectedName != ""))
            //{

            //    // Call the AllItems method with the selected filters to retrieve the filtered items
            //    DataTable filteredItems = UserFacade.FilterItems(selectedName, selectedPrice);

            //    // Set the filtered items as the data source for the DataGridView
            //    DataGridView_items.DataSource = filteredItems;

            //    // Reset the selection and toggle buttons
            //    DataGridView_items.ClearSelection();
            //    toggleBtnDisabled();
            //}
            //else
            //{
            //    refresh();
            //}
        }

        private int getId(string name, string table)
        {
            if (table == "stock" || table == "s")
            {
                // Iterate through the items and add their names to the list
                foreach (DataRow row in stocksTable.Rows)
                {
                    if(row["name"].ToString() == name)
                    {
                        return (int)row["id"];
                    } 
                    return 0;
                }
            }
            else if (table == "item" || table == "i")
            {
                // Iterate through the items and add their names to the list
                foreach (DataRow row in itemTable.Rows)
                {
                    if (row["name"].ToString() == name)
                    {
                        return (int)row["id"];
                    }
                    return 0;
                }
            }
            
            return 0;
        }
    }
}
