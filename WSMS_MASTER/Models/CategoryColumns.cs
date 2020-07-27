using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSMS_MASTER.Models
{
    public class CategoryColumns
    {
        public int catid { get; set; }
        public string name { get; set; }
        public string remark { get; set; }
        public string created_date { get; set; }
        public string created_by { get; set; }
        public string updated_date { get; set; }
        public string updated_by { get; set; }
    }
}
