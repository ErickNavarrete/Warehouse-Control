using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Control.Models
{
    public class DepartureDet
    {
        public int id { get; set; }
        public int id_departure { get; set; }
        public int id_item { get; set; }
        public int quantity { get; set; }
    }
}
