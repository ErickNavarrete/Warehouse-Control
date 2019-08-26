using System;

namespace Warehouse_Control.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string serie { get; set; }
        public int folio { get; set; }
        public DateTime date { get; set; }
        public string observation { get; set; }
        public int id_user { get; set; }
        public int id_warehouse { get; set; }
    }
}
