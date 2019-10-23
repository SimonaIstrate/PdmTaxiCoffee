using System;
using SQLite;

namespace PdmProject
{
    [Table("Coffees")]
    public class Coffee
    {
        
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Coffee()
        {
        }   


        public Coffee(string Name, string Description, double price)
        {
            this.Name = Name;
            this.Description = Description;
            this.Price = price;
        }
    }      
}
