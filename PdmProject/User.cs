using System;
using SQLite;


namespace PdmProject
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }

        public User()
        {

        }

        public User(string Username, string Password, string Nume, string Prenume, string Email)
        {
            this.Username = Username;
            this.Password = Password;
            this.Nume = Nume;
            this.Prenume = Prenume;
            this.Email = Email;
        }
    }
}
