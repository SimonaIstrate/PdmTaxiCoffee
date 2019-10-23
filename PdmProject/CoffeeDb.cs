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

        public int insertAll(List<Coffee> coffeesList)
        {
            return db.InsertAll(coffeesList);
        }

        public int deleteAll()
        {
            return db.DeleteAll<Coffee>();
        }

        public int delete(Coffee coffee)
        { 
            return db.Delete(coffee);
        }

        public List<Coffee> getcoffeesList()
        {
            return db.Query<Coffee>("SELECT * FROM [Coffees]");
        }

        public List<Coffee> getFavouritecoffeesList(List<int> ids)
        {
            List<Coffee> list = new List<Coffee>();

            foreach (int id in ids)
            {
                List<Coffee> tempList = db.Query<Coffee>("SELECT * FROM [coffees] WHERE id=?", id);
                if (tempList.Count > 0)
                {
                    list.Add(tempList[0]);
                }
            }
            return list;
        }

        public List<Coffee> searchCoffee(string name)
        {
            return db.Query<Coffee>("SELECT * FROM [coffees] WHERE Name LIKE '%" + name + "%'");
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
