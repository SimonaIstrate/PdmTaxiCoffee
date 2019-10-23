using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace PdmProject
{
    public class CoffeeDb
    { 
        private SQLiteConnection db;

        public CoffeeDb()
        {
            string connString = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "pdm.db");
            db = new SQLiteConnection(connString);
            db.CreateTable<Coffee>();
        }

        public int insert(Coffee coffee)
        {
            return db.Insert(coffee);
        }

        public Coffee getCoffee(string Name)
        {
            List<Coffee> coffeeList = db.Query<Coffee>("SELECT * FROM [Coffees] WHERE [Name]=?", Name);
            if (coffeeList.Count > 0)
            {
                return coffeeList[0];
            }
            return null;
        }

    }
    
}
