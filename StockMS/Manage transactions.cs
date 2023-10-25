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
        DataTable transTable;


        private void filterRefresh(string selectedItem, string selectedStock, DateTime fromDate,DateTime  toDate) {


            bool itemSearch = false;
            bool stockSearch = false;
            bool dateSearch = false;
            int itemId = -1;
            int stockId = -1;
            //string toDate="";
            //string fromDate;

            if (selectedItem != ""){
                 itemId = getId(selectedItem, "item");
                itemSearch = true;
            }
            if (selectedStock != "")
            {
                 stockId = getId(selectedStock, "stock");
                stockSearch = true;
            }
            if(fromDate!= new DateTime(2023, 10, 10) )
            {
                dateSearch = true;
            }
            if (toDate != DateTime.Today.Date)
            {
                dateSearch = true;
            }





            DataTable filterResult=new DataTable();
            foreach (DataColumn column in transTable.Columns)
{
    filterResult.Columns.Add(column.ColumnName, column.DataType);
}
            foreach (var row in transTable.Rows) {

                DataRow dataRow = (DataRow)row;
                if ((stockSearch && !itemSearch) && (stockId!=-1 &&Convert.ToInt32( dataRow["stock_id"] )== stockId))
                {
                    
                    DataRow newRow = filterResult.NewRow();
                    // Copy values individually from source row to destination row
                    for (int i = 0; i < filterResult.Columns.Count; i++)
                    {
                      //  MessageBox.Show("in");
                        string columnName = filterResult.Columns[i].ColumnName;
                        newRow[columnName] = dataRow[columnName];
                    }
                    filterResult.Rows.Add(newRow);
                    




                    // filterResult.Rows.Add(dataRow.i);
                }
                else if ((!stockSearch && itemSearch) && (itemId != -1 && Convert.ToInt32(dataRow["item_id"] )== itemId))
                {

                    DataRow newRow = filterResult.NewRow();
                    // Copy values individually from source row to destination row
                    for (int i = 0; i < filterResult.Columns.Count; i++)
                    {
                         // MessageBox.Show("in");
                        string columnName = filterResult.Columns[i].ColumnName;
                        newRow[columnName] = dataRow[columnName];
                    }
                    filterResult.Rows.Add(newRow);
                }
                else if (stockSearch && itemSearch && Convert.ToInt32(dataRow["stock_id"]) == stockId && Convert.ToInt32(dataRow["item_id"]) == itemId)
                {

                    DataRow newRow = filterResult.NewRow();
                    // Copy values individually from source row to destination row
                    for (int i = 0; i < filterResult.Columns.Count; i++)
                    {
                        //  MessageBox.Show("in");
                        string columnName = filterResult.Columns[i].ColumnName;
                        newRow[columnName] = dataRow[columnName];
                    }
                    filterResult.Rows.Add(newRow);
                }
                //refresh
                DataGridView_trans.DataSource = filterResult;
                toggleBtnDisabled();
                DataGridView_trans.ClearSelection();
                return;


                DataTable datefilterResult = new DataTable();
                foreach (DataColumn column in filterResult.Columns)
                {
                    datefilterResult.Columns.Add(column.ColumnName, column.DataType);

                }
                //check date
                if (dateSearch )
                {
                    

                        DataRow newRow = datefilterResult.NewRow();
                    for (int i = 0; i < datefilterResult.Columns.Count; i++)
                    {
                        DateTime rowDate =Convert.ToDateTime( dataRow["date"]);
                        MessageBox.Show(rowDate.ToString());
                        if(rowDate > fromDate && rowDate <= toDate)
                        {
                            MessageBox.Show("item added");
                            string columnName = datefilterResult.Columns[i].ColumnName;
                            newRow[columnName] = dataRow[columnName];
                              MessageBox.Show("in");

                        }


                    }
                    datefilterResult.Rows.Add(newRow);

                }
                //refresh
                DataGridView_trans.DataSource = datefilterResult;
                toggleBtnDisabled();
                DataGridView_trans.ClearSelection();
                return;







            }


            //MessageBox.Show(selectedItem + itemId.ToString());


        }
        private void refresh()
        {
            toPicker.Value = DateTime.Today.Date;

            fromPicker.Value = new DateTime(2023, 10, 10);
            transTable = UserFacade.AllTrans();

            DataGridView_trans.DataSource = transTable;
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
           // ApplyFilters();
        }

        private void stockComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           // ApplyFilters();
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
            //ApplyFilters();
        }

        private void toPicker_ValueChanged(object sender, EventArgs e)
        {
            //ApplyFilters();
        }

        private void ApplyFilters()
        {
            // Get the selected values from the filters
            string selectedItem = (string)ItemComboBox.SelectedItem;
            string selectedStock = (string)stockComboBox.SelectedItem;

            filterRefresh(selectedItem, selectedStock, fromPicker.Value, toPicker.Value);

           

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
                        return Convert.ToInt32(row["id"]);
                    } 
                    
                }
                return 0;
            }
            else if (table == "item" || table == "i")
            {
                // Iterate through the items and add their names to the list
                foreach (DataRow row in itemTable.Rows)
                {
                    if (row["name"].ToString() == name)
                    {
                        return Convert.ToInt32( row["id"]);
                    }

                }
                return 0;
            }
           

            return 0;
        }

        private void ItemComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ApplyFilters();
        }

        private void stockComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void fromPicker_TabIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }
    }
}
