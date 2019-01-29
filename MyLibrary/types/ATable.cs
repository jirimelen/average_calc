using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MyLibrary.types
{
    public abstract class ATable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
