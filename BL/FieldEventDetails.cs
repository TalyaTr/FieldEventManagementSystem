using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class FieldEventDetails
    {
        public long Id { get; set; }    
        public string Title { get; set; }
        public string Description { get; set; }
        public int SourceId { get; set; }
        public string SourceName { get; set; }
        public int SourceCategoryId { get; set; }
        public string Address { get; set; }
        public int UserId { get; set; }
        
    }

    public class FieldEventFullDetails: FieldEventDetails
    {
        public DateTime StartDate { get; set; }
        public int Status { get; set; }
    }


}
