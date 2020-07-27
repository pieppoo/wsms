using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSMS_MASTER.Models
{
    public class SalePriceColumns
    {
        public int priceid { get; set; }
        public int prodid { get; set; }
        public double price_1 { get; set; }
        public double price_2 { get; set; }
        public double price_3 { get; set; }
        public double price_4 { get; set; }
        public double price_5 { get; set; }
        public string created_date { get; set; }
        public string created_by { get; set; }
        public string updated_date { get; set; }
        public string updated_by { get; set; }
    }
}
