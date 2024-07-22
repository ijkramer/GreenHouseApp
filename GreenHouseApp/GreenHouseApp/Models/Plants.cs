using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenHouseApp.Models
{
    public class Plants
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int WaterDays { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public bool Notify { get; set; }
    }

}
}
