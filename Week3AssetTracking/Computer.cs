﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3AssetTracking
{
    internal class Computer : Asset
    {
        public Computer(string brand, string model, DateTime purchaseDate, int price)
        {
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
            EndOfLife = PurchaseDate.AddYears(3);
        }

    }
}
