using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FactoryLayer;
using InterfaceLayer;
using ServiceUI;
namespace WinformCustomer
{
    public partial class Form1 : Form
    {
        
        ServiceCustomer srv = new ServiceCustomer(1);
       
        ICustomer icust = null;
        public Form1()
        {
            InitializeComponent();
            
            LoadGrid();
        }
        private void LoadGrid()
        {
            dataGridView1.DataSource = srv.Get();
            
        }
        private void btnValidate_Click(object sender, EventArgs e)
        {
            try
            {
                icust.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            icust.CustomerName = txtCustomerName.Text;

        }

        private void cmbCustomerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            icust = srv.Create(cmbCustomerType.SelectedIndex);
            icust.CustomerType = cmbCustomerType.SelectedIndex.ToString();
        }

        private void txtCustomerCode_TextChanged(object sender, EventArgs e)
        {
            icust.CustomerCode = txtCustomerCode.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            srv.Add(icust);
            LoadGrid();
            txtCustomerCode.Text = "";
            txtCustomerName.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void LoadCustomer(ICustomer i)
        {
            txtCustomerName.Text = i.CustomerName;
            txtCustomerCode.Text = i.CustomerCode;
            cmbCustomerType.SelectedIndex = Convert.ToInt16(i.CustomerType);
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            icust = srv.Select(e.RowIndex);
            LoadCustomer(icust);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            icust = srv.Revert();
            LoadCustomer(icust);
        }
    }
}
