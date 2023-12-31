﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3AssetTracking
{
    internal abstract class Asset
    {
        public string Brand {  get; set; }
        public string Model {  get; set; }
        public Office Office { get; set; }
        public DateTime PurchaseDate {  get; set; }
        public int Price { get; set; }
        public DateTime EndOfLife ;
    }
}
