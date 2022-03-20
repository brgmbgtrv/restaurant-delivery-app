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
    public partial class formCreateOrder : Form
    {
        private DBClient _dBClient;
        private List<MenuItem> _menu = new List<MenuItem>();
        private List<MenuItem> _currentOrderList = new List<MenuItem>();
        private List<Ingredient> _ingredients = new List<Ingredient>();
        private List<Ingredient> _selectedIngredients = new List<Ingredient>();
        private List<MenuItem> _dishConstructors = new List<MenuItem>();
        private int dishId = new int();

        public formCreateOrder()
        {
            InitializeComponent();
            _dBClient = new DBClient();
            GetMenuForCreateOrder();
            dgvMenu.DataSource = _menu;
            try
            {
                DBClient.sqlConnection.Open();
                SqlCommand command = new SqlCommand("SELECT name FROM Discounts", DBClient.sqlConnection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        comboBoxDiscounts.Items.Add(reader.GetString(0));
                    }
                }
            }
            catch (SqlException e)
            {

            }
            finally
            {
                DBClient.sqlConnection.Close();
            }
        }

        private void GetMenuForCreateOrder()
        {
            List<MenuItem> data = _dBClient.GetMenu();
            _menu = data;
        }

        private void formCreateOrder_Load(object sender, EventArgs e)
        {

        }

        private void dgvMenu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int? curPrice = new int();
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var curId = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
                var curDishCategory = (int)dgv.Rows[e.RowIndex].Cells[1].Value;
                var curName = (string)dgv.Rows[e.RowIndex].Cells[2].Value;
                if (curDishCategory == 8)
                {
                    var _d = new MenuItem
                    {
                        Id = curId,
                        DishCategory = curDishCategory,
                        Name = curName
                    };
                    _dishConstructors.Add(_d);
                    dishId = curId;
                    _selectedIngredients = new List<Ingredient>();
                    dgvIngredients.DataSource = null;
                    dgvSelectedIngredients.DataSource = null;
                    _ingredients = _dBClient.GetIngredients(curId);
                    dgvIngredients.DataSource = _ingredients;
                    panelDishConstructor.Visible = true;
                }
                else
                {
                    curPrice = (int)dgv.Rows[e.RowIndex].Cells[3].Value;
                    if (_currentOrderList.Exists(x => x.Id == curId))
                    {
                        _currentOrderList.Find(x => x.Id == curId).Quantity += 1;
                        _currentOrderList.Find(x => x.Id == curId).Price += curPrice;
                    }
                    else
                    {
                        var item = new MenuItem
                        {
                            Id = curId,
                            DishCategory = curDishCategory,
                            Name = curName,
                            Quantity = 1,
                            Price = curPrice
                        };
                        _currentOrderList.Add(item);
                    }
                }

                dgvCurrentOrder.DataSource = null;
                dgvCurrentOrder.DataSource = _currentOrderList;
            }
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text != "" && txtContact.Text != "")
            {
                var price = dgvCurrentOrder.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToInt32(t.Cells[4].Value));

                var procent = _dBClient.GetDiscountByName(comboBoxDiscounts.SelectedItem.ToString());
                price = price - (price / 100 * procent);

                DBClient.CreateOrder(txtAddress.Text, txtContact.Text, price, comboBoxDiscounts.Items.IndexOf(comboBoxDiscounts.Text) + 1);
                DBClient.InsertOrderToDish(_currentOrderList);

                if (_currentOrderList.Exists(x => x.DishCategory == 8))
                {
                    List<MenuItem> _list = _currentOrderList.FindAll(x => x.DishCategory == 8);
                    foreach (MenuItem elem in _list)
                    {
                        DBClient.InsertOrderToDishConstructor(elem.Id, elem.Ingredients);
                    }
                }

                MessageBox.Show("Order is created", "Success");
                this.Hide();
                var f = new formManager();
                f.Closed += (s, args) => this.Close();
                f.Show();
            }
            else
            {
                MessageBox.Show("All fields must be filled before order is created", "Failure");
            }
        }

        private void btnBackToOrders_Click(object sender, EventArgs e)
        {
            this.Hide();
            var f = new formManager();
            f.Closed += (s, args) => this.Close();
            f.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                var selectedId = (int)dgv.Rows[e.RowIndex].Cells[1].Value;
                var selectedCategoryId = (int)dgv.Rows[e.RowIndex].Cells[5].Value;
                var selectedName = (string)dgv.Rows[e.RowIndex].Cells[2].Value;
                var selectedPrice = (int)dgv.Rows[e.RowIndex].Cells[4].Value;
                if (_selectedIngredients.Exists(x => x.Id == selectedId))
                {
                    _selectedIngredients.Find(x => x.Id == selectedId).Quantity += 1;
                    _selectedIngredients.Find(x => x.Id == selectedId).Price += selectedPrice;
                }
                else
                {
                    var ingredient = new Ingredient
                    {
                        Id = selectedId,
                        IngredientCategory = selectedCategoryId,
                        Name = selectedName,
                        Quantity = 1,
                        Price = selectedPrice
                    };
                    _selectedIngredients.Add(ingredient);
                }
            }
            dgvSelectedIngredients.DataSource = null;
            dgvSelectedIngredients.DataSource = _selectedIngredients;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            _dishConstructors.Find(x => x.Id == dishId).Ingredients = _selectedIngredients;
            _dishConstructors.Find(x => x.Id == dishId).Price = _dishConstructors.Find(x => x.Id == dishId).Ingredients.Sum(Ingredient => Ingredient.Price);
            if (_currentOrderList.Exists(x => x.Id == dishId))
            {
                _currentOrderList.Find(x => x.Id == dishId).Quantity += 1;
                _currentOrderList.Find(x => x.Id == dishId).Price += _dishConstructors.Find(x => x.Id == dishId).Price;
            }
            else
            {
                _dishConstructors.Find(x => x.Id == dishId).Quantity = 1;
                _currentOrderList.Add(_dishConstructors.Find(x => x.Id == dishId));
            }
            dgvCurrentOrder.DataSource = null;
            dgvCurrentOrder.DataSource = _currentOrderList;
            panelDishConstructor.Visible = false;
            dishId = new int();
        }

        private void btnHideDishConstructor_Click(object sender, EventArgs e)
        {
            panelDishConstructor.Visible = false;
        }
    }
}
