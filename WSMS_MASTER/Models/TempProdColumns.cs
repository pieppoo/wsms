using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSMS_MASTER.Models
{
    public class TempProdColumns
    {
        public int prodid { get; set; }
        public string prodcode { get; set; }
        public string name { get; set; }
        public int brandid { get; set; }
        public string brand_name { get; set; }
        public int prodcat { get; set; }
        public string prodcat_name { get; set; }
        public int produnit { get; set; }
        public string produnit_code{ get; set; }
        public double purchaseprice { get; set; }
        public string barcodeno { get; set; }
        public int stocks { get; set; }
        public string created_date { get; set; }
        public string created_by { get; set; }
        public string updated_date { get; set; }
        public string updated_by { get; set; }
    }
}
