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
    public partial class admin_dashbord : Form
    {
        public admin_dashbord()
        {
            InitializeComponent();
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userBtn.Visible = false;
            if (UserDetails.role == "admin")
            {
                userBtn.Visible = true;
            }

            label_name.Text = UserDetails.username;
            label_role.Text = UserDetails.role;
        }

        private void selectedButton(Button btn) {
            btn.BackColor = Color.Turquoise;
        }
        private void unselectedButton()
        {
            userBtn.BackColor = Color.LightSeaGreen;
            itemBtn.BackColor = Color.LightSeaGreen;
            stockBtn.BackColor = Color.LightSeaGreen;
            transBtn.BackColor = Color.LightSeaGreen;
            logoutBtn.BackColor = Color.LightSeaGreen;
        }



        private void showmenu(Panel menu)
        {
            if (menu.Visible == false)
            {
             
                menu.Visible = true;
            }
            else
                menu.Visible = false;
        }

        private void btn_users_Click(object sender, EventArgs e)
        {
           
        }

        #region usersmenu
        private void btn_newuser_Click(object sender, EventArgs e)
        {
            //openChildForm(new New_user());
        }

        private void btn_manageusers_Click(object sender, EventArgs e)
        {
            //openChildForm(new Manage_users());
         
        }
        #endregion 

        private void btn_teachers_Click(object sender, EventArgs e)
        {
        }

        #region teachersmenu
        private void btn_newteacher_Click(object sender, EventArgs e)
        {
           // openChildForm(new New_teacher());
         
        }

        private void btn_manageteachers_Click(object sender, EventArgs e)
        {
            //openChildForm(new Manage_teachers());
           
        }
        #endregion 

        private void btn_students_Click(object sender, EventArgs e)
        {
           
        }

        #region studentsmenu
        private void btn_newstudent_Click(object sender, EventArgs e)
        {
           // openChildForm(new Newstudent());
           
        }

        private void btn_managestudents_Click(object sender, EventArgs e)
        {
            //openChildForm(new Manage_students());
            
        }
        #endregion 

        private void btn_marks_Click(object sender, EventArgs e)
        {
         
        }

        #region marksmenu
        private void btn_addmark_Click(object sender, EventArgs e)
        {
             //openChildForm(new Add_marks());
        
        }

        private void btn_managemarks_Click(object sender, EventArgs e)
        {
          // openChildForm(new Manage_marks());
            
        }

        #endregion

        private void openChildForm(Form childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_main.Controls.Add(childForm);
            panel_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void userBtn_Click(object sender, EventArgs e)
        {
            unselectedButton();
            selectedButton(this.userBtn);


            openChildForm(new Manage_users());
        }

        private void itemBtn_Click(object sender, EventArgs e)
        {
            unselectedButton();
            selectedButton(this.itemBtn);
            openChildForm(new Manage_items());
        }

        private void stockBtn_Click(object sender, EventArgs e)
        {
            unselectedButton();
            selectedButton(this.stockBtn);
            openChildForm(new Manage_stocks());

        }

        private void transBtn_Click(object sender, EventArgs e) 
        {
            unselectedButton();
            selectedButton(this.transBtn);
            openChildForm(new Manage_transactions());
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            unselectedButton();
            selectedButton(this.logoutBtn);
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    
}
