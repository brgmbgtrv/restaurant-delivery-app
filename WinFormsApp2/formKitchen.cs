using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using WinFormsApp2.DataAccess;

namespace WinFormsApp2
{
    public partial class formKitchen : Form
    {
        private DBClient _dBClient;
        private List<Order> _orders;
        private List<MenuItem> _dishes;
        private int _selectedOrderId = new int();
        public formKitchen()
        {
            InitializeComponent();
            _dBClient = new DBClient();
            dgvOrders.AutoGenerateColumns = false;
            dgvOrderDetails.AutoGenerateColumns = false;
            dgvIngredients.AutoGenerateColumns = false;
            GetOrders();
            dgvOrders.DataSource = _orders;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetOrders();
            dgvOrders.DataSource = _orders;
        }

        private void GetOrders()
        {
            var data = _dBClient.GetOrdersByStatus(OrderStatus.Created);
            var cooking = _dBClient.GetOrdersByStatus(OrderStatus.Cooking);
            if (data != null)
            {
                if (cooking != null)
                {
                    data.AddRange(cooking);
                }
                _orders = data;
            } else
            {
                if (cooking != null)
                {
                    data = cooking;
                    _orders = data;
                }
                else
                {
                    MessageBox.Show("No orders for now.", "Alert");
                }
            }         
            _orders = data;
        }

        private void formKitchen_Load(object sender, EventArgs e)
        {

        }

        private void dgvOrders_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {     
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && e.ColumnIndex== 3 && _orders != null)
            {
                var orderId = (int)dgv.Rows[e.RowIndex].Cells["Id"].Value;
                var order = _orders.FirstOrDefault(x => x.Id == orderId);
                var newStatus = (OrderStatus)(((int)order.Status) + 1);
                var success = _dBClient.ChangeOrderStatus(orderId, newStatus);
                if (success)
                {
                    GetOrders();
                    dgvOrders.DataSource = _orders;
                }
                else
                {
                    MessageBox.Show("Failure");
                }
            } else if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0&& e.ColumnIndex == 1&&_orders!=null)
            {
                try
                {
                    _selectedOrderId = (int)dgv.Rows[e.RowIndex].Cells["Id"].Value;
                    dgvOrderDetails.DataSource = null;
                    dgvOrderDetails.DataSource = _dBClient.RetrieveOrderToDish((int)dgv.Rows[e.RowIndex].Cells["Id"].Value);
                }
                 catch (Exception ex)
                {
                    MessageBox.Show("Failure");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dgvOrderDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0 && _orders!=null)
            {
                dgvIngredients.DataSource = null;
                int _dishId = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
                dgvIngredients.DataSource = _dBClient.GetIngredients(_selectedOrderId, _dishId);
                label3.Visible = true;
                dgvIngredients.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new formLogin();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}
