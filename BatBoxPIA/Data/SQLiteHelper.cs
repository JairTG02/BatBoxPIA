using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using BatBoxPIA.Models;

namespace BatBoxPIA.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<EstadisticaBateoModel>().Wait();
            db.CreateTableAsync<EstadisticaPitcheoModel>().Wait();
        }
    }
}
