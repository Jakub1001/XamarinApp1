using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalApp1.Models
{
    public class Routine
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public TimeSpan From { get; set; } 
        public TimeSpan To { get; set; }
        public string RoutineText { get; set; }
     
    }
}
