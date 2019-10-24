using System;
using SQLite;

namespace PdmProject
{
    [Table("CoffeShops")]
    public class CoffeShops
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Cod { get; set; }
        public string Nume { get; set; }
        public string Oras { get; set; }
        public string Adresa { get; set; }
        public string Program { get; set; }
    }
}
