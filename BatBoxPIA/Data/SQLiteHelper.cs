using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using BatBoxPIA.Models;
using System.Threading.Tasks;

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

        public Task <int> SavePitcheoAsync(EstadisticaPitcheoModel pitcheo)
        {
            if (pitcheo.IdJugador==0)
            {
                return db.InsertAsync(pitcheo);
            }
            else 
            {
                return null;
            }
        }

        public Task<int> SaveBateoAsync(EstadisticaBateoModel bateo)
        {
            if (bateo.IdJugador == 0)
            {
                return db.InsertAsync(bateo);
            }
            else
            {
                return null;
            }
        }
    }
}
