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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            DataTable userdata = UserFacade.LoginUser(nameTxt.Text);
            if(userdata != null && userdata.Rows.Count > 0)
            {
                UserDetails.AuthorizeUser(passTxt.Text, userdata, this, new admin_dashbord());
            }
            else
            {
                MessageBox.Show("password or Username are wrong!", "Warning!");
            }

            //admin_dashbord ad=new admin_dashbord();
            //this.Hide();
            //ad.ShowDialog();
            //this.Close();
        }

        private void passTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
