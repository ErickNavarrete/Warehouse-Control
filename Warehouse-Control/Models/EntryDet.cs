using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse_Control.Models
{
    public class EntryDet
    {
        public int Id { get; set; }
        public int id_entry { get; set; }
        public int id_item { get; set; }
        public int quantity { get; set; }
    }
}
