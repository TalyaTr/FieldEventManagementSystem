using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataObjects
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber{ get; set; }
        public int EmployeeCategoryId{ get; set; }
        public string Email { get; set; }
    }
}
