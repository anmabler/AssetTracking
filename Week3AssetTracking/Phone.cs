using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3AssetTracking
{
    internal class Phone : Asset
    {
        public Phone(string brand, string model, DateTime purchaseDate, int price)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
            EndOfLife = PurchaseDate.AddYears(3);

        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public DateTime EndOfLife;
    }
}
