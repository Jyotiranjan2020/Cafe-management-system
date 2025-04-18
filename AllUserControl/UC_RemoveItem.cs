﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafe_management_system.AllUserControl
{
    public partial class UC_RemoveItem : UserControl
    {
        function fn = new function();
        String query;
        public UC_RemoveItem()
        {
            InitializeComponent();
        }

        private void UC_RemoveItem_Load(object sender, EventArgs e)
        {
            Dellabel.Text = "How to DELETE?";
            Dellabel.ForeColor = Color.Blue;
            loadData(); 
        }

        public void loadData()
        {
            query = "select * from Item2";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            query = "select * from Item2 where name like '" + txtSearch.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBox.Show("Delete item?","Important Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                query = "delete from Item2 where iid = " + id + "";
                fn.setData(query);
                loadData();
            }
        }

        private void Dellabel_Click(object sender, EventArgs e)
        {
            Dellabel.ForeColor = Color.Red;
            Dellabel.Text = "*Click on Row to Delete the Item.";
        }
    }
}
