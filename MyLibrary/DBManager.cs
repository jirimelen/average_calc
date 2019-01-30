using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite;

namespace MyLibrary
{
    public class DBManager
    {

        static MyDatabase database;

        public static MyDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new MyDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite1.db3"));
                }
                return database;
            }
        }
    }
}
