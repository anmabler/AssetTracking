﻿using Week3AssetTracking;

// ! instantiating offices. Perhaps use dict instead ??
Office swe = new(Office.OfficeCountry.Sweden);
Office usa = new(Office.OfficeCountry.USA);
Office greece = new(Office.OfficeCountry.Greece);



List<Asset> assetList = new List<Asset> {
    new Computer("ASUS ROG", "B550-F", new DateTime(2020, 11, 24), 2438, swe),
    new Computer("HP", "14S-FQ1010NO", new DateTime(2022, 01, 30), 6790, usa),
    new Phone("Samsung", "S20 Plus", new DateTime(2020, 09, 12), 15000, swe),
    new Phone("Sony Xperia", "10 III", new DateTime(2020, 03, 06), 8000,usa),
    new Phone("Iphone", "10", new DateTime(2018, 11, 25), 9512, greece),
    new Computer("HP", "Elitebook", new DateTime(2021, 08, 30), 22340, greece),
    new Computer("HP", "Elitebook", new DateTime(2020, 07, 30), 22340, swe)
};
//Asset.addMultiple(assetList);

Computer computer = new Computer("ASUS ROG", "B550-F", new DateTime(2020, 11, 24), 2438, greece);
Console.WriteLine("Currency: " + computer.Office.Currency);
displayList();



void displayList()
{
    
    Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(15) + "Price");
    Console.WriteLine("----------------------------------------------------------------------------------------------------");
    // order by office - then class - then purchase date ascending
    assetList = assetList.OrderBy(asset => asset.Office.Country).ThenBy(asset => asset.GetType().Name).ThenBy(asset => asset.PurchaseDate).ToList();
    foreach (Asset asset in assetList)
    {
        TimeSpan timeSpan = DateTime.Now - asset.EndOfLife;
        

        // IF end of life is more than 180 days - red
        // ELSE IF end of life is between 0 - 90 days - yellow
        if (timeSpan.Days >= 180)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(asset.GetType().Name.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.Country.ToString().PadRight(15) + asset.PurchaseDate.ToShortDateString().PadRight(15) + asset.Price.ToString().PadRight(15));
            Console.ResetColor();
        }
        else if (timeSpan.Days > 0 && timeSpan.Days >= 90)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(asset.GetType().Name.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.Country.ToString().PadRight(15) + asset.PurchaseDate.ToShortDateString().PadRight(15) + asset.Price.ToString().PadRight(15));
            Console.ResetColor();
        }
        
        else
        { 
            Console.WriteLine(asset.GetType().Name.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.Country.ToString().PadRight(15) + asset.PurchaseDate.ToShortDateString().PadRight(15) + asset.Price.ToString().PadRight(15));
        }

    }
}