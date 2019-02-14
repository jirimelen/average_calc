using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyLibrary.types
{
    public class Mark : ATable
    {
        public double Value { get; set; }
        public int Impact { get; set; }
        public int SubjectID { get; set; }
    }
}
