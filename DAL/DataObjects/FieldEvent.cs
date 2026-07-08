using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataObjects
{
    public class FieldEvent
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime StartDate { get; set; }
        public int UserId { get; set; }
        public int SourseId { get; set; }
        public int StatusId { get; set; }
        public int EmployeeId { get; set; }
    }
}
