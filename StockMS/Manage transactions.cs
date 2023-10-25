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
            foreach (DataRow row in stocksTable.Rows)
            {
                int count = 0;

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
            foreach (DataRow row in itemTable.Rows)
            {
                int count = 0;
                
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

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

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
            int item_id=-1;
            int selectedItem = Convert.ToInt32(itemCmbox.SelectedIndex);
            if (selectedItem > 0)
            {
                var row=itemTable.Rows[selectedItem];
                item_id=Convert.ToInt32( row["id"]);

            }
            int stock_id=-1;
            int selectedStock = Convert.ToInt32(stockCmbox.SelectedIndex);
            if (selectedItem > 0)
            {
                var row = stocksTable.Rows[selectedStock];
                stock_id = Convert.ToInt32(row["id"]);

            }



            UserFacade.AddTransaction(
           item_id,
           stock_id,
           detalisTxt.Text,
           Convert.ToInt16(quantityNum.Value),
           typeCmbox.SelectedIndex,
           "date"


           );
            refresh();
        }
    }
}
