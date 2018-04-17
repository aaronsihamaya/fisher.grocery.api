using System;

namespace Fisher.GroceryApi.Models
{
    public class Item
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Notes { get; set;}
    }
}