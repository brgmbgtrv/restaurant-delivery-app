using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.DataAccess
{
    public enum OrderStatus
    {
        Created = 1,
        Cooking = 2,
        Cooked = 3,
        Delivery = 4,
        Completed = 5,
        Cancelled = 6
    }
}
