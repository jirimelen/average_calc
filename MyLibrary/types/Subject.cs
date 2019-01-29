using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;

namespace MyLibrary.types
{
    public class Subject : ATable
    {
        public string Name { get; set; }
    }
}
