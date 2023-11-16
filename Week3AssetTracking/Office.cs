using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3AssetTracking
{
    internal class Office
    {
        public Office(OfficeCountry country)
        {
            Country = country;

            if(country == OfficeCountry.Sweden) {
                this.Currency = "SEK";
            }
            else if (country == OfficeCountry.Greece)
            {
                this.Currency = "EUR";
            }
            else
            {
            this.Currency = "USD";
            }
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
