using System;
using System.Collections.Generic;
using System.IO;
using SQLite;

namespace PdmProject
{
    public class UserDb
    {

        private SQLiteConnection db;
        private string dbPath;

        public UserDb()
        {
            string connString = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "pdm.db");
            db = new SQLiteConnection(connString);
            db.CreateTable<User>();
        }

        public int insert(User user)
        {
            return db.Insert(user);
        }

        public User getUser(string Username, string Password)
        {
            List<User> userList = db.Query<User>("SELECT * FROM [Users] WHERE [Username]=? AND [Password]=?", Username, Password);
            if (userList.Count > 0)
            {
                return userList[0];
            }
            return null;
        }

        public bool checkCredentials(string Username, string Password)
        {
            if (getUser(Username, Password) != null)
            {
                return true;
            }
            return false;
        }
    }
    
}

