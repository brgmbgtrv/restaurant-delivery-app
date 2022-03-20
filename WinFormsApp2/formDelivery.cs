using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp2.DataAccess;

namespace WinFormsApp2
{
    public partial class formDelivery : Form
    {

        private DBClient _dBClient;
        private List<Order> _orders;

        public formDelivery()
        {
            InitializeComponent();
            _dBClient = new DBClient();
            GetOrdresForDelivery();
            dgvOrders.DataSource = _orders;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            GetOrdresForDelivery();
            dgvOrders.DataSource = _orders;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var orderId = (int)dgv.Rows[e.RowIndex].Cells["Id"].Value;
                var order = _orders.FirstOrDefault(x => x.Id == orderId);
                var currentStatus = order.Status;

                var newStatus = currentStatus + 1;
                var success = _dBClient.ChangeOrderStatus(order.Id, newStatus);
                if (success)
                {
                    if (order.Status == OrderStatus.Completed)
                    {
                        _dBClient.DeleteOrder(order.Id);
                    }
                    GetOrdresForDelivery();
                    dgvOrders.DataSource = _orders;
                }
            }
        }

        private void GetOrdresForDelivery()
        {
            List<Order> data = new List<Order>();

            var cooked = _dBClient.GetOrdersByStatus(OrderStatus.Cooked);
            var delivery = _dBClient.GetOrdersByStatus(OrderStatus.Delivery);

            if (cooked != null)
            {
                if (data != null)
                {
                    data.AddRange(cooked);
                }
                else
                {
                    data = cooked;
                }
            }
            if (delivery != null)
            {
                if (data != null)
                {
                    data.AddRange(delivery);
                }
                else
                {
                    data = delivery;
                }
            }
            _orders = data;
        }

        private void formDelivery_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new formLogin();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }
    }
}