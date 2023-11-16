using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3AssetTracking
{
    internal class Office
    {
        public Office(OfficeCountry country, string currency)
        {
            Country = country;
            Currency = currency;
        }

        public enum OfficeCountry
        {
            USA,
            Sweden,
            Greece
        }
        public OfficeCountry Country { get; set; }
        public string Currency { get; set; }

    }
}
