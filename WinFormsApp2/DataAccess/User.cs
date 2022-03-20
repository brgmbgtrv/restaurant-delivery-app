using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2.DataAccess
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public Role UserRole { get; set; }
    }
}
