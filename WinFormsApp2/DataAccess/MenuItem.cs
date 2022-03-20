using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.DataAccess
{
    public class MenuItem
    {
        public int Id { get; set; }
        public int DishCategory { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public virtual int? Price { get; set; }
    }
}
