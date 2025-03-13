using DGVPrinterHelper;
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
    public partial class UC_PlaceOrder : UserControl
    {
        function fn = new function();
        String query;

        public UC_PlaceOrder()
        {
            InitializeComponent();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            String category = comboCategory.Text;
            query = "select name from Item2 where category= '" + category + "'";
            showItemlist(query);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

           
            String category = comboCategory.Text;
            query = "select name from Item2 where category= '" + category + "' and name like '" + txtSearch.Text + "%'";
            showItemlist(query);
        }
        private void showItemlist(string query)
        {
           listBox1.Items.Clear();

            DataSet ds = fn.getData(query);
            int i;
            for (i = 0; i<ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
}

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtQuantity.ResetText();
            TxtTotal.Clear();
            string text = listBox1.GetItemText(listBox1.SelectedItem);
            TxtItemName.Text = text;
            query = "select price from Item2 where name = '" + text + "'";
            DataSet ds = fn.getData(query);

            try
            {
                TxtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }

        }

        private void TxtQuantity_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(TxtQuantity.Value.ToString());
            Int64 price = Int64.Parse(TxtPrice.Text);
            TxtTotal.Text = (quan * price).ToString();
        }

        protected int n, total = 0;

        int amount; 
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            catch
            {

            }
        }

        

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView1.Rows.RemoveAt(this.guna2DataGridView1.SelectedRows[0].Index);
            }
            catch { }
            total -= amount;
            LabelTotalAmount.Text = "Rs. " + total;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer Bill";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total Payble Amount : " + LabelTotalAmount.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView1);

            total = 0;
            guna2DataGridView1.Rows.Clear();
            LabelTotalAmount.Text = "Rs. " + total;



        }
        
        private void btnAddtoCart_Click(object sender, EventArgs e)
        {
            if (TxtTotal.Text != "0" && TxtTotal.Text != "")
            {


                n = guna2DataGridView1.Rows.Add();
                guna2DataGridView1.Rows[n].Cells[0].Value = TxtItemName.Text;
                guna2DataGridView1.Rows[n].Cells[1].Value = TxtPrice.Text;
                guna2DataGridView1.Rows[n].Cells[2].Value = TxtQuantity.Value;
                guna2DataGridView1.Rows[n].Cells[3].Value = TxtTotal.Text;

                total = total + int.Parse(TxtTotal.Text);
                LabelTotalAmount.Text = "Rs. " + total;
            }
            else
            {
                MessageBox.Show("Minimum Quantity need to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
