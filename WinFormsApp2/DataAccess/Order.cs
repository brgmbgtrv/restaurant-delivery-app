using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.DataAccess
{
    public class Order
    {
        public int Id { get; set; }

        public List<MenuItem> Dish { get; set; }

        public string Address { get; set; }

        public string ClientContact { get; set; }

        public OrderStatus Status { get; set; }

        public int Price { get; set; }

        public int DiscountId { get; set; }


    }
}