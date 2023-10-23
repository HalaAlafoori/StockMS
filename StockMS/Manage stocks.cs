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
        }
        int id;
        string username;
        bool passFlag;
        bool active;
        private void DataGridView_users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                username = DataGridView_users.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                nameTxt.Text = username;
               // txt_mobile.Text = DataGridView_users.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
                locationTxt.Text = DataGridView_users.Rows[e.RowIndex].Cells["Password"].Value.ToString();
                //txt_email.Text = DataGridView_users.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                id = Int32.Parse(DataGridView_users.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                active = DataGridView_users.Rows[e.RowIndex].Cells["Status"].Value.ToString() == "1" ? true : false;
                //btn_active.Text = active ? "Unactivate" : "Activate";
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
    }
}
