using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Shared
{
    public class Enums
    {
        public enum FieldEventStatus
        {
            New = 1,
            InProgress = 2,
            Completed = 3,
            Cancelled = 4
        }

        public enum EmployeeCategory
        {
            Dispatcher = 1,
            FieldWorker = 2,
            Manager = 3
        }
    }
}
