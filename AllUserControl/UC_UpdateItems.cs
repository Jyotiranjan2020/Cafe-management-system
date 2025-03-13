using System;
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
    public partial class UC_UpdateItems : UserControl
    {
        function fn = new function();
        String query;
        public UC_UpdateItems()
        {
            InitializeComponent();
        }

        private void UC_UpdateItems_Load(object sender, EventArgs e)
        {
            
            loadData();
        }

        private void loadData()
        {
            query = "select * from Item2";
            DataSet ds = fn.getData(query);
            guna2DataGridView.DataSource = ds.Tables[0];
        }

        private void TxtSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "select * from Item2 where name like '" + TxtSearchItem.Text + "%'";
            DataSet ds = fn.getData(query);
            guna2DataGridView.DataSource = ds.Tables[0];
        }

        int id;
        private void guna2DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          id = int.Parse(guna2DataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
           
            String category = guna2DataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            String name = guna2DataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
           int price = int.Parse(guna2DataGridView.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtCategory.Text = category;
            TxtItemName.Text = name;
            TxtPrice.Text = price.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "update Item2 set name ='" + TxtItemName.Text + "', category ='" + txtCategory.Text + "', price =" + TxtPrice.Text + " where iid = " +id+ "";
            fn.setData(query);
            loadData();
        }
    }
}
