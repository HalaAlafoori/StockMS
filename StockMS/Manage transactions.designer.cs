
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
    partial class Manage_transactions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toPicker = new System.Windows.Forms.DateTimePicker();
            this.fromPicker = new System.Windows.Forms.DateTimePicker();
            this.ItemComboBox = new System.Windows.Forms.ComboBox();
            this.stockComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addBtn = new System.Windows.Forms.Button();
            this.itemCmbox = new System.Windows.Forms.ComboBox();
            this.DataGridView_trans = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.stockCmbox = new System.Windows.Forms.ComboBox();
            this.quantityNum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.typeCmbox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DataDtp = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.detalisTxt = new System.Windows.Forms.TextBox();
            this.clearBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_trans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNum)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(427, 505);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "Quantity :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 500);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 23;
            this.label1.Text = "Item :";
            // 
            // updateBtn
            // 
            this.updateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateBtn.BackColor = System.Drawing.Color.SeaGreen;
            this.updateBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.updateBtn.ForeColor = System.Drawing.Color.White;
            this.updateBtn.Location = new System.Drawing.Point(850, 671);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(2);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(116, 34);
            this.updateBtn.TabIndex = 31;
            this.updateBtn.Text = "Update";
            this.updateBtn.UseVisualStyleBackColor = false;
            this.updateBtn.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBtn.BackColor = System.Drawing.Color.Salmon;
            this.deleteBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.deleteBtn.ForeColor = System.Drawing.Color.White;
            this.deleteBtn.Location = new System.Drawing.Point(711, 671);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(116, 34);
            this.deleteBtn.TabIndex = 30;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.toPicker);
            this.panel1.Controls.Add(this.fromPicker);
            this.panel1.Controls.Add(this.ItemComboBox);
            this.panel1.Controls.Add(this.stockComboBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 104);
            this.panel1.TabIndex = 34;
            // 
            // toPicker
            // 
            this.toPicker.Location = new System.Drawing.Point(692, 67);
            this.toPicker.Name = "toPicker";
            this.toPicker.Size = new System.Drawing.Size(273, 23);
            this.toPicker.TabIndex = 45;
            this.toPicker.ValueChanged += new System.EventHandler(this.toPicker_ValueChanged);
            // 
            // fromPicker
            // 
            this.fromPicker.Location = new System.Drawing.Point(400, 67);
            this.fromPicker.Name = "fromPicker";
            this.fromPicker.Size = new System.Drawing.Size(269, 23);
            this.fromPicker.TabIndex = 44;
            this.fromPicker.ValueChanged += new System.EventHandler(this.fromPicker_ValueChanged);
            this.fromPicker.TabIndexChanged += new System.EventHandler(this.fromPicker_TabIndexChanged);
            // 
            // ItemComboBox
            // 
            this.ItemComboBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ItemComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemComboBox.FormattingEnabled = true;
            this.ItemComboBox.Items.AddRange(new object[] {
            "Admin",
            "User"});
            this.ItemComboBox.Location = new System.Drawing.Point(140, 65);
            this.ItemComboBox.Name = "ItemComboBox";
            this.ItemComboBox.Size = new System.Drawing.Size(115, 25);
            this.ItemComboBox.TabIndex = 43;
            this.ItemComboBox.SelectedIndexChanged += new System.EventHandler(this.ItemComboBox_SelectedIndexChanged);
            this.ItemComboBox.SelectionChangeCommitted += new System.EventHandler(this.ItemComboBox_SelectionChangeCommitted);
            // 
            // stockComboBox
            // 
            this.stockComboBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.stockComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stockComboBox.FormattingEnabled = true;
            this.stockComboBox.Items.AddRange(new object[] {
            "Admin",
            "User"});
            this.stockComboBox.Location = new System.Drawing.Point(263, 65);
            this.stockComboBox.Name = "stockComboBox";
            this.stockComboBox.Size = new System.Drawing.Size(115, 25);
            this.stockComboBox.TabIndex = 42;
            this.stockComboBox.SelectedIndexChanged += new System.EventHandler(this.stockComboBox_SelectedIndexChanged);
            this.stockComboBox.SelectionChangeCommitted += new System.EventHandler(this.stockComboBox_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(665, 2);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(301, 31);
            this.label6.TabIndex = 20;
            this.label6.Text = "Manage Trasnactions";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cooper Black", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(11, 2);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(367, 31);
            this.label9.TabIndex = 19;
            this.label9.Text = "Stock Managment System";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel2.Location = new System.Drawing.Point(-7, 463);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(984, 18);
            this.panel2.TabIndex = 35;
            // 
            // addBtn
            // 
            this.addBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addBtn.BackColor = System.Drawing.Color.DarkOrchid;
            this.addBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.addBtn.ForeColor = System.Drawing.Color.White;
            this.addBtn.Location = new System.Drawing.Point(573, 671);
            this.addBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(116, 34);
            this.addBtn.TabIndex = 37;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click_1);
            // 
            // itemCmbox
            // 
            this.itemCmbox.FormattingEnabled = true;
            this.itemCmbox.Items.AddRange(new object[] {
            "Admin",
            "User"});
            this.itemCmbox.Location = new System.Drawing.Point(164, 499);
            this.itemCmbox.Name = "itemCmbox";
            this.itemCmbox.Size = new System.Drawing.Size(228, 25);
            this.itemCmbox.TabIndex = 38;
            // 
            // DataGridView_trans
            // 
            this.DataGridView_trans.AllowUserToAddRows = false;
            this.DataGridView_trans.AllowUserToDeleteRows = false;
            this.DataGridView_trans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_trans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DataGridView_trans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_trans.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DataGridView_trans.Location = new System.Drawing.Point(0, 103);
            this.DataGridView_trans.MultiSelect = false;
            this.DataGridView_trans.Name = "DataGridView_trans";
            this.DataGridView_trans.RowHeadersWidth = 51;
            this.DataGridView_trans.RowTemplate.Height = 29;
            this.DataGridView_trans.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_trans.Size = new System.Drawing.Size(977, 354);
            this.DataGridView_trans.TabIndex = 36;
            this.DataGridView_trans.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_trans_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(18, 552);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 19);
            this.label5.TabIndex = 23;
            this.label5.Text = "Stock :";
            // 
            // stockCmbox
            // 
            this.stockCmbox.FormattingEnabled = true;
            this.stockCmbox.Items.AddRange(new object[] {
            "Admin",
            "User"});
            this.stockCmbox.Location = new System.Drawing.Point(164, 551);
            this.stockCmbox.Name = "stockCmbox";
            this.stockCmbox.Size = new System.Drawing.Size(228, 25);
            this.stockCmbox.TabIndex = 38;
            // 
            // quantityNum
            // 
            this.quantityNum.Location = new System.Drawing.Point(583, 499);
            this.quantityNum.Name = "quantityNum";
            this.quantityNum.Size = new System.Drawing.Size(120, 23);
            this.quantityNum.TabIndex = 39;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(427, 606);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 19);
            this.label7.TabIndex = 23;
            this.label7.Text = "Transaction Type:";
            // 
            // typeCmbox
            // 
            this.typeCmbox.FormattingEnabled = true;
            this.typeCmbox.Items.AddRange(new object[] {
            "in",
            "out"});
            this.typeCmbox.Location = new System.Drawing.Point(583, 605);
            this.typeCmbox.Name = "typeCmbox";
            this.typeCmbox.Size = new System.Drawing.Size(228, 25);
            this.typeCmbox.TabIndex = 38;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(427, 548);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.TabIndex = 28;
            this.label2.Text = "Date :";
            // 
            // DataDtp
            // 
            this.DataDtp.Location = new System.Drawing.Point(583, 549);
            this.DataDtp.Name = "DataDtp";
            this.DataDtp.Size = new System.Drawing.Size(200, 23);
            this.DataDtp.TabIndex = 40;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(21, 618);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 19);
            this.label4.TabIndex = 28;
            this.label4.Text = "Details :";
            // 
            // detalisTxt
            // 
            this.detalisTxt.Location = new System.Drawing.Point(164, 607);
            this.detalisTxt.Multiline = true;
            this.detalisTxt.Name = "detalisTxt";
            this.detalisTxt.Size = new System.Drawing.Size(228, 97);
            this.detalisTxt.TabIndex = 41;
            // 
            // clearBtn
            // 
            this.clearBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearBtn.BackColor = System.Drawing.Color.Goldenrod;
            this.clearBtn.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold);
            this.clearBtn.ForeColor = System.Drawing.Color.White;
            this.clearBtn.Location = new System.Drawing.Point(443, 670);
            this.clearBtn.Margin = new System.Windows.Forms.Padding(2);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(116, 34);
            this.clearBtn.TabIndex = 42;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // Manage_transactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(977, 716);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.detalisTxt);
            this.Controls.Add(this.DataDtp);
            this.Controls.Add(this.quantityNum);
            this.Controls.Add(this.typeCmbox);
            this.Controls.Add(this.stockCmbox);
            this.Controls.Add(this.itemCmbox);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.DataGridView_trans);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Manage_transactions";
            this.Text = "Manage_users";
            this.Load += new System.EventHandler(this.Manage_users_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_trans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private Button addBtn;
        private ComboBox itemCmbox;
        private DataGridView DataGridView_trans;
        private Label label5;
        private ComboBox stockCmbox;
        private NumericUpDown quantityNum;
        private Label label7;
        private ComboBox typeCmbox;
        private Label label2;
        private DateTimePicker DataDtp;
        private Label label4;
        private TextBox detalisTxt;
        private Button clearBtn;
        private ComboBox ItemComboBox;
        private ComboBox stockComboBox;
        private DateTimePicker toPicker;
        private DateTimePicker fromPicker;
    }
}