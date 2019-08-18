﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse_Control.Forms;
using Warehouse_Control.Models;
using Warehouse_Control.Properties;

namespace Warehouse_Control.Connection
{
    public class ConnectionDB : DbContext
    {
        public ConnectionDB() : base(Settings.Default.Connection)
        {
        }

        public virtual DbSet<Departure> Departures { get; set; }
        public virtual DbSet<DepartureDet> DepartureDet { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<EntryDet> EntryDet { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<District> Districts { get; set; }

    }
}
