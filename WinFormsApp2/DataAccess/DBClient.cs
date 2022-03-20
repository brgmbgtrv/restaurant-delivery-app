using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace WinFormsApp2.DataAccess
{
	public class DBClient
	{
		public static SqlConnection sqlConnection;
		public DBClient()
		{
			sqlConnection = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=task5;Integrated Security=SSPI");
		}

		public User Login(string login, string password)
		{
			User _result = null;
			var _queryString = $" SELECT u.Id, u.[login], r. Id, r.[name] " +
							  $" FROM Users u " +
							  $" JOIN UserRoles r on r.Id = u.roleId " +
							  $" WHERE u.[login] = @login AND u.[password] = @password ";

			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(_queryString, sqlConnection);
				command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;
				using (SHA256 sha256Hash = SHA256.Create())
				{
					command.Parameters.Add("@password", SqlDbType.NVarChar).Value = Cryptography.Encrypt(sha256Hash, password, Cryptography.salt);
				}
				// command.Parameters.Add("@password", SqlDbType.NVarChar).Value = password;
				using (SqlDataReader reader = command.ExecuteReader())
				{
					if (reader.HasRows)
					{
						_result = new User();

						while (reader.Read())
						{
							_result.Id = reader.GetInt32(0);
							_result.Login = reader.GetString(1);
							_result.UserRole = new Role
							{
								Id = reader.GetInt32(2),
								Name = reader.GetString(3)
							};
						}
					}
					else
					{
						
					}
				}
			}
			catch (SqlException e)
			{
				var f = new DbFailure();
				f.Show();
			}
			finally
			{
				sqlConnection.Close();
			}
			return _result;
		}

		public User Register(string login, string password, string role)
		{
			User _result = null;
			var _insertString = $" INSERT INTO Users VALUES (@login, @password, @roleId)";

			try
			{
				sqlConnection.Open();
				int _roleId = new int();
				switch (role)
				{
					case "manager":
						_roleId = 1;
						break;
					case "kitchen-worker":
						_roleId = 2;
						break;
					case "courier":
						_roleId = 3;
						break;
					default:
						break;
				}

				using (SqlCommand command = new SqlCommand(_insertString, sqlConnection))
				{
					command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;
					using (SHA256 sha256Hash = SHA256.Create())
					{
						command.Parameters.Add("@password", SqlDbType.NVarChar).Value = Cryptography.Encrypt(sha256Hash, password, Cryptography.salt);
					}
					command.Parameters.Add("@roleId", SqlDbType.Int).Value = _roleId;
					var _rowsAffected = command.ExecuteNonQuery();
				}
			}
			catch (SqlException e)
			{
				var f = new DbFailure();
				f.Show();
			}
			finally
			{
				sqlConnection.Close();
			}
			return _result;
		}

		public List<Order> GetOrdersByStatus(OrderStatus status)
		{
			List<Order> result = null;
			var queryString = $"SELECT o.Id, o.[address], o.[contact], o.statusId, o.price, o.discountId " +
							  $" FROM Orders o" +
							  $" WHERE o.statusId = @status";
			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(queryString, sqlConnection);
				int statusId = (int)status;
				command.Parameters.Add("@status", SqlDbType.NVarChar).Value = statusId;
				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					result = new List<Order>();
					while (reader.Read())
					{
						var o = new Order
						{
							Id = reader.GetInt32(0),
							Dish = new List<MenuItem>(),
							Address = reader.GetString(1),
							ClientContact = reader.GetString(2),
							Status = (OrderStatus)reader.GetInt32(3),
							Price = reader.GetInt32(4),
							DiscountId = reader.GetInt32(5)
						};
						result.Add(o);
					}
				}
				else
				{
					//
				}
				sqlConnection.Close();
			}
			catch (SqlException e)
			{
				var f = new DbFailure();
				f.Show();
			}
			finally
			{
				sqlConnection.Close();
			}
			return result;
		}

		public bool ChangeOrderStatus(int Id, OrderStatus newStatus)
		{
			var queryString = $"UPDATE [orders]" +
							  $" set statusId = @newStatus" +
							  $" WHERE [Id] = @Id";
			var result = false;
			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(queryString, sqlConnection);
				command.Parameters.Add("@newStatus", SqlDbType.Int).Value = (int)newStatus;
				command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
				var rowsAffected = command.ExecuteNonQuery();
				result = true;
			}
			catch (SqlException e)
			{
				var f = new DbFailure();
				f.Show();
			}
			finally
			{
				sqlConnection.Close();
			}
			return result;
		}

		public List<MenuItem> GetMenu()
		{
			List<MenuItem> result = null;
			var queryString = $"SELECT o.Id, o.dishCategory, o.name, o.price " +
							  $" FROM Menu o";
			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(queryString, sqlConnection);								
				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					result = new List<MenuItem>();
					while (reader.Read())
					{
						var o = new MenuItem
						{
							Id = reader.GetInt32(0),
							DishCategory = reader.GetInt32(1),
							Name = reader.GetString(2),
							Price = reader.GetInt32(3)
						};
						result.Add(o);
					}
				}
				else
				{
					//
				}
				sqlConnection.Close();
			}
			catch (SqlException e)
			{
				var f = new DbFailure();
				f.Show();
			}
			finally
			{
				sqlConnection.Close();
			}
			return result;
		}

		public List<Ingredient> GetIngredients(int orderId, int dishId)
		{
			List<Ingredient> result = new List<Ingredient>();
			bool _isDishConstrctor = false;
			string _queryString = "";
			if (dishId >= 35)
            {
				_queryString = $"SELECT otcd.ingredientId, i.ingredient, ic.price, i.ingredientCategory, otcd.quantity" +
								$" FROM OrderToConstructorDish otcd" +
								$" JOIN Ingredient i ON i.id = otcd.ingredientId" +
								$" JOIN IngredientCategory ic ON ic.Id = otcd.ingredientId" +
								$" WHERE otcd.orderId = @orderId AND otcd.dishId = @dishId";
				_isDishConstrctor = true;
			} else
            {
				_queryString = $"select i.id, i.ingredient" +
								$" from Ingredient i" +
								$" JOIN DishToIngredient dti ON dti.ingredientId = i.Id" +
								$" WHERE dti.dishId = @dishId";
            }
				
			try
			{
				DBClient.sqlConnection.Open();
				SqlCommand command = new SqlCommand(_queryString, DBClient.sqlConnection);
				command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
				command.Parameters.Add("@dishId", SqlDbType.TinyInt).Value = dishId;
				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						if (_isDishConstrctor)
                        {
							var i = new Ingredient
							{
								Id = reader.GetInt32(0),
								Name = reader.GetString(1),
								IngredientCategory = reader.GetInt32(2),
								Price = reader.GetInt32(3),
								Quantity = reader.GetInt32(4)
							};
							result.Add(i);
						}
						else
                        {
							var i = new Ingredient
							{
								Id = reader.GetInt32(0),
								Name = reader.GetString(1)
							};
							result.Add(i);
						}					
					}
				}
			}
			catch (SqlException e)
			{
				var f = new DbFailure();
				f.Show();
			}
			finally
			{
				DBClient.sqlConnection.Close();
			}
			return result;
		}

		public List<Ingredient> GetIngredients(int dishId)
        {
			List<Ingredient> result = new List<Ingredient>();
			bool _isDishConstrctor = false;
			string _queryString = "";
			if (dishId >= 35)
			{
				_queryString = $"SELECT DISTINCT i.Id, i.ingredient, ic.Id, ic.price" +
								$" FROM Ingredient i" +
								$" JOIN Templates t ON t.categoryId = i.ingredientCategory" +
								$" JOIN IngredientCategory ic ON ic.Id = i.ingredientCategory" +
								$" WHERE t.dishId = @dishId";
				_isDishConstrctor = true;
			}
			else
			{
				_queryString = $"select i.id, i.ingredient" +
					$" from Ingredient i" +
					$" JOIN DishToIngredient dti ON dti.ingredientId = i.Id" +
					$" WHERE dti.dishId = @dishId";
			}

			try
			{
				DBClient.sqlConnection.Open();
				SqlCommand command = new SqlCommand(_queryString, DBClient.sqlConnection);
				command.Parameters.Add("@dishId", SqlDbType.TinyInt).Value = dishId;
				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						if (_isDishConstrctor)
						{
							var i = new Ingredient
							{
								Id = reader.GetInt32(0),
								Name = reader.GetString(1),
								IngredientCategory = reader.GetInt32(2),
								Price = reader.GetInt32(3),
							};
							result.Add(i);
						}
						else
						{
							var i = new Ingredient
							{
								Id = reader.GetInt32(0),
								Name = reader.GetString(1)
							};
							result.Add(i);
						}
					}
				}
			}
			catch (SqlException e)
			{
				var f = new DbFailure();
				f.Show();
			}
			finally
			{
				DBClient.sqlConnection.Close();
			}
			return result;

		}

		public static void CreateOrder( string address, string contact, int price, int discountId)
        {
			var _insertString = $"INSERT INTO Orders" +
									$" VALUES" +
									$" (@status, @address, @contact, @price, @discountId)";

			try
            {
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(_insertString, sqlConnection);
				command.Parameters.Add("@status", SqlDbType.Int).Value = (int)OrderStatus.Created;
				command.Parameters.Add("@contact", SqlDbType.NVarChar).Value = contact;
				command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
				command.Parameters.Add("@price", SqlDbType.Int).Value = price;
				command.Parameters.Add("@discountId", SqlDbType.Int).Value = discountId;
				var _rowsAffected = command.ExecuteNonQuery();
            }
			catch (SqlException e)
            {
				var f = new DbFailure();
				f.Show();
			}
            finally
            {
				sqlConnection.Close();
            }
		}

		public static int GetLastOrderId()
        {
			int _result = new int();
			try
            {
				sqlConnection.Open();
				SqlCommand command = new SqlCommand("SELECT TOP 1 Id FROM Orders ORDER BY Id DESC", sqlConnection);
				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
                {
					while (reader.Read())
                    {
						_result = reader.GetInt32(0);
                    }
                }
				else
                {
					throw new ArgumentException();
                }
			}
			catch (SqlException e)
            {
				var f = new DbFailure();
				f.Show();
			}
			finally
            {
				sqlConnection.Close();
            }
			return _result;
		}

		public static void InsertOrderToDish (List<MenuItem> list)
        {
			var _insertString = $"INSERT INTO OrderToDish VALUES (@orderId, @dishId, @price, @quantity)";
			int _orderId = GetLastOrderId();
			try
            {
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(_insertString, sqlConnection);
				foreach (MenuItem elem in list)
                {
					command.Parameters.Clear();
					command.Parameters.Add("@orderId", SqlDbType.Int).Value = _orderId;
					command.Parameters.Add("@dishId", SqlDbType.Int).Value = elem.Id;
					command.Parameters.Add("@quantity", SqlDbType.Int).Value = elem.Quantity;
					command.Parameters.Add("@price", SqlDbType.Int).Value = elem.Price;
					var _rowsAffected = command.ExecuteNonQuery();
				}	
            }
			catch (SqlException e)
            {
				var f = new DbFailure();
				f.Show();
			}
			finally
            {
				sqlConnection.Close();
            }
        }

		public static void InsertOrderToDishConstructor (int _dishId, List<Ingredient> list)
        {
			var _insertString = $"INSERT INTO OrderToConstructorDish VALUES (@orderId, @dishId, @ingredientId, @quantity)";
			var _orderId = GetLastOrderId();
			try
			{
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(_insertString, sqlConnection);
				foreach (Ingredient elem in list)
				{
					command.Parameters.Clear();
					command.Parameters.Add("@orderId", SqlDbType.Int).Value = _orderId;
					command.Parameters.Add("@dishId", SqlDbType.Int).Value = _dishId;
					command.Parameters.Add("@ingredientId", SqlDbType.Int).Value = elem.Id;
					command.Parameters.Add("@quantity", SqlDbType.Int).Value = elem.Quantity;
					var _rowsAffected = command.ExecuteNonQuery();
				}
			}
			catch (SqlException e)
			{
				var f = new DbFailure();
				f.Show();
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		public int GetDiscountByName(string name)
		{
			int result = 0;
			var queryString = $"SELECT d.Id, d.[name], d.[percent]" +
							  $" FROM Discounts d" +
							  $" WHERE d.name = @name";
			try
			{

				DBClient.sqlConnection.Open();
				SqlCommand command = new SqlCommand(queryString, DBClient.sqlConnection);
				command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						result = reader.GetInt32(2);
					}
				}
				else
				{
					//
				}
				sqlConnection.Close();
			}
			catch (SqlException e)
			{
				var f = new DbFailure();
				f.Show();
			}
			finally
			{
				sqlConnection.Close();
			}
			return result;
		}

		public List<MenuItem> RetrieveOrderToDish (int Id)
        {
			var _queryString = $"SELECT otd.dishId, m.[Name], otd.quantity" +
								$" FROM OrderToDish otd JOIN Menu m ON m.Id = otd.dishId" +
								$" WHERE otd.orderId = @Id";
			List<MenuItem> _result = new List<MenuItem>();
			try
            {
				sqlConnection.Open();
				SqlCommand command = new SqlCommand(_queryString, sqlConnection);
				command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
				SqlDataReader reader = command.ExecuteReader();
				if (reader.HasRows)
                {
					while (reader.Read())
                    {
						var _dish = new MenuItem
						{
							Id = reader.GetInt32(0),
							Name = reader.GetString(1),
							Quantity = reader.GetInt32(2)
						};
						_result.Add(_dish);
                    }
                }
				return _result;
            }
			catch (SqlException e)
            {
				_result = new List<MenuItem>();
				return _result;
				var f = new DbFailure();
				f.Show();
			}
			finally
            {
				sqlConnection.Close();
            }
        }

		public void CancelOrder(int id)
		{
			ChangeOrderStatus(id, OrderStatus.Cancelled);
		}

		public void DeleteOrder(int id)
		{
			var queryString = "DELETE FROM [OrderToConstructorDish]\n" +
									"WHERE orderId = @Id\n" +
								"DELETE FROM[OrderToDish]\n" +
									"WHERE orderId = @Id\n" +
								"DELETE FROM [Orders]\n" +
									"WHERE Id = @Id\n";
			try
			{
				sqlConnection.Open();

				SqlCommand command = new SqlCommand(queryString, sqlConnection);
				command.Parameters.Add("@Id", SqlDbType.Int);
				command.Parameters["@Id"].Value = id;

				var rowsAffected = command.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				var f = new DbFailure();
				f.Show();
			}
			finally
			{
				sqlConnection.Close();
			}
		}
	}
}
