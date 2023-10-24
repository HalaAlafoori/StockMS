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
    public partial class Manage_items : Form
    {
        int id;
        string name;
        bool price;

        string SelectedItemID;

        public Manage_items()
        {
            InitializeComponent();
        }
        private void toggleBtnEnabled()
        {
         
            deleteBtn.Enabled = true;
            deleteBtn.BackColor = Color.Red;
            updateBtn.Enabled = true;
            updateBtn.BackColor = Color.Green;
        }
        private void toggleBtnDisabled()
        {
            deleteBtn.Enabled = false;
            deleteBtn.BackColor = Color.Gray;
            updateBtn.Enabled = false;
            updateBtn.BackColor = Color.Gray;
        }
        private void Manage_users_Load(object sender, EventArgs e)
        {
            refresh();

            //DataGridView_users.DataSource = UserFacade.AllAdmins();
            //toggleBtnDisabled();
            //DataGridView_users.ClearSelection();
        }
       
        private void DataGridView_users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            UserFacade.UpdateItem(
                id,
                nameTxt.Text,
                priceTxt.Text
            );
            refresh();

        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            UserFacade.DeleteItem(SelectedItemID);
            refresh();
        }

        private void btn_active_Click(object sender, EventArgs e)
        {
          
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            //passFlag = true;
        }

       
        private void DataGridView_users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                name = DataGridView_items.Rows[e.RowIndex].Cells["name"].Value.ToString();
                nameTxt.Text = name;
                //  txt_mobile.Text = DataGridView_users.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
                priceTxt.Text = DataGridView_items.Rows[e.RowIndex].Cells["price"].Value.ToString();
                //txt_email.Text = DataGridView_users.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                id = Int32.Parse(DataGridView_items.Rows[e.RowIndex].Cells["id"].Value.ToString());
                // btn_active.Text = active ? "Unactivate" : "Activate";
                SelectedItemID = DataGridView_items.Rows[e.RowIndex].Cells["id"].Value.ToString();
                toggleBtnEnabled();
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if (double.TryParse(priceTxt.Text, out double price))
            {
                UserFacade.AddItem(nameTxt.Text, price);
                refresh();
            }
            else
            {
                MessageBox.Show("Invalid price value!", "Error");
            }
        }

        private void refresh()
        {

            DataGridView_items.DataSource = UserFacade.AllItems();
            toggleBtnDisabled();
            DataGridView_items.ClearSelection();
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
