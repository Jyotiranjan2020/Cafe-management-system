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
    public partial class UC_AddItems : UserControl
    {
        function fn = new function();
        String query;
        public UC_AddItems()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            query = "insert into Item2 (name, category, price) values ('" + TxtItemName.Text + "', '" + txtCategory.Text + "' , '"+ TxtPrice.Text + "')";
            fn.setData(query);
            clearAll();
       
        }

      
        public void clearAll()
        {
            txtCategory.SelectedIndex = -1;
            TxtItemName.Clear();
            TxtPrice.Clear();
            
        }

        private void UC_AddItems_Leave(object sender, EventArgs e)
        {
            clearAll();
        }
    }
}
