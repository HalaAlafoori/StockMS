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
    public partial class Manage_users : Form
    {

        public Manage_users()
        {
            InitializeComponent();
        }
        private void toggleBtnEnabled()
        {
            btn_active.Enabled = true;
            btn_active.BackColor = active ? Color.Orange : Color.Blue;
            btn_delete.Enabled = true;
            btn_delete.BackColor = Color.Red;
            btn_update.Enabled = true;
            btn_update.BackColor = Color.Green;
        }
        private void toggleBtnDisabled()
        {
            btn_active.Enabled = false;
            btn_active.BackColor = Color.Gray;
            btn_delete.Enabled = false;
            btn_delete.BackColor = Color.Gray;
            btn_update.Enabled = false;
            btn_update.BackColor = Color.Gray;
        }
        private void Manage_users_Load(object sender, EventArgs e)
        {
            refresh();
        }
        int id;
        string username;
        bool passFlag;
        bool active;
        private void DataGridView_users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                username = DataGridView_users.Rows[e.RowIndex].Cells["name"].Value.ToString();
                txt_username.Text = username;
                txt_password.Text = DataGridView_users.Rows[e.RowIndex].Cells["password"].Value.ToString();
                id = Int32.Parse(DataGridView_users.Rows[e.RowIndex].Cells["id"].Value.ToString());
                active = DataGridView_users.Rows[e.RowIndex].Cells["status"].Value.ToString() == "1" ? true : false;
                btn_active.Text = active ? "Unactivate" : "Activate";
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
            UserFacade.ActivateUser(id);
            Manage_users_Load(sender, e);
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            passFlag = true;
        }

        private void btn_clesr_Click(object sender, EventArgs e)
        {
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    C.Text = "";

                }
            }
        }
        DataTable newUser = new DataTable();

        private void btn_add_Click(object sender, EventArgs e)
        {
            UserFacade.AddUser(
            txt_username.Text,
            txt_password.Text
            //txt_mobile.Text
            );
            refresh();
        }

        private void refresh()
        {
        
            DataGridView_users.DataSource = UserFacade.AllUsers();
            toggleBtnDisabled();
            DataGridView_users.ClearSelection();
        }
    }
}
