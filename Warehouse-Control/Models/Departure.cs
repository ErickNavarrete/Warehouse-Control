﻿using System;

namespace Warehouse_Control.Models
{
    public class Departure
    {
        public int id { set; get; }
        public string serie { get; set; }
        public int folio { get; set; }
        public DateTime date { get; set; }
        public string observation { get; set; }
        public int id_warehouse { get; set; }
        public int id_cellar { get; set; }
        public int id_user { get; set; }
    }
}
