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
    public partial class formManager : Form
    {
        private DBClient _dBClient;
        private List<Order> _orders;
        public formManager()
        {
            InitializeComponent();
            _dBClient = new DBClient();
            GetOrdersForManager();
            dgvOrders.DataSource = _orders;
        }


        private void formManager_Load(object sender, EventArgs e)
        {

        }

        private void buttonCreateOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new formCreateOrder();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var orderId = (int)dgv.Rows[e.RowIndex].Cells["Id"].Value;
                var order = _orders.FirstOrDefault(x => x.Id == orderId);
                var newStatus = (OrderStatus)(((int)order.Status) + 1);
                var success = _dBClient.ChangeOrderStatus(orderId, newStatus);
                if (success)
                {
                    GetOrdersForManager();
                    dgvOrders.DataSource = _orders;
                }
                else
                {
                    MessageBox.Show("Failure");
                }
            }
        }

        private void GetOrdersForManager()
        {
            List<Order> data = new List<Order>();
            var created = _dBClient.GetOrdersByStatus(OrderStatus.Created);
            var cooking = _dBClient.GetOrdersByStatus(OrderStatus.Cooking);
            var cooked = _dBClient.GetOrdersByStatus(OrderStatus.Cooked);
            var delivery = _dBClient.GetOrdersByStatus(OrderStatus.Delivery);
                    
            if (created != null)
            {  
                if (data != null)
                {
                    data.AddRange(created);
                }
                else
                {
                    data = created;
                }
            }           
            if (cooking !=null)
            {
                if (data != null)
                {
                    data.AddRange(cooking);
                }
                else
                {
                    data = cooking;
                }
            }
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetOrdersForManager();
            dgvOrders.DataSource = _orders;
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