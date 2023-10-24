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
    public partial class Manage_stocks : Form
    {
        int id;
        string name;
        string location;
        string SelectedStockID;
        bool passFlag;

        private void refresh()
        {

            DataGridView_stock.DataSource = UserFacade.AllStocks();
            toggleBtnDisabled();
            DataGridView_stock.ClearSelection();
        }

        public Manage_stocks()
        {
            InitializeComponent();
        }
        private void toggleBtnEnabled()
        {
            //btn_active.Enabled = true;
            //btn_active.BackColor = active ? Color.Orange : Color.Blue;
            deleteBtn.Enabled = true;
            deleteBtn.BackColor = Color.Red;
            updateBtn.Enabled = true;
            updateBtn.BackColor = Color.Green;
        }
        private void toggleBtnDisabled()
        {
            //btn_active.Enabled = false;
           // btn_active.BackColor = Color.Gray;
            deleteBtn.Enabled = false;
            deleteBtn.BackColor = Color.Gray;
            updateBtn.Enabled = false;
            updateBtn.BackColor = Color.Gray;
        }
        private void Manage_users_Load(object sender, EventArgs e)
        {
            //DataGridView_users.DataSource = UserFacade.AllAdmins();
            //toggleBtnDisabled();
            //DataGridView_users.ClearSelection();
            refresh();
        }
        
        private void DataGridView_users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                name = DataGridView_stock.Rows[e.RowIndex].Cells["name"].Value.ToString();
                nameTxt.Text = name;
               // txt_mobile.Text = DataGridView_users.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
                locationTxt.Text = DataGridView_stock.Rows[e.RowIndex].Cells["location"].Value.ToString();
                //txt_email.Text = DataGridView_users.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                id = Int32.Parse(DataGridView_stock.Rows[e.RowIndex].Cells["id"].Value.ToString());
                SelectedStockID = DataGridView_stock.Rows[e.RowIndex].Cells["id"].Value.ToString();

                toggleBtnEnabled();
                passFlag = false;
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            UserFacade.UpdateStock(
               id,
               nameTxt.Text,
               locationTxt.Text
           );
            refresh();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            UserFacade.DeleteStock(SelectedStockID);
            refresh();
        }

        private void btn_active_Click(object sender, EventArgs e)
        {
          
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            passFlag = true;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            UserFacade.AddStock(
            nameTxt.Text,
            locationTxt.Text

            );
            refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DataGridView_users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    C.Text = "";

                }
            }
        }
    }
}
