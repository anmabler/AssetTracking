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
            // sets the currency depending on which country
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
            // set currency rate
            if(country == OfficeCountry.Sweden) {
                this.CurrencyRate = 10.574373f;
            }
            else if (country == OfficeCountry.Greece)
            {
                this.CurrencyRate = 0.921447f;
            }
            else
            {
                this.CurrencyRate = 1;
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
        public float CurrencyRate { get; set; }

    }
}
