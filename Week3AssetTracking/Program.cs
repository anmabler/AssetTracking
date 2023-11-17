﻿using Week3AssetTracking;

Office swe = new(Office.OfficeCountry.Sweden);
Office usa = new(Office.OfficeCountry.USA);
Office greece = new(Office.OfficeCountry.Greece);


List<Asset> assetList = new List<Asset> {
    new Computer("ASUS ROG", "B550-F", new DateTime(2020, 11, 24), 243, swe),
    new Computer("HP", "14S-FQ1010NO", new DateTime(2022, 01, 30), 679, usa),
    new Phone("Samsung", "S20 Plus", new DateTime(2020, 09, 12), 1500, swe),
    new Phone("Sony Xperia", "10 III", new DateTime(2020, 03, 06), 800,usa),
    new Phone("Iphone", "10", new DateTime(2018, 11, 25), 951, greece),
    new Computer("HP", "Elitebook", new DateTime(2021, 08, 30), 2234, greece),
    new Computer("HP", "Elitebook", new DateTime(2020, 07, 30), 2234, swe)
};


// show list of assets
displayList();
// then menu 
showMenu();


void showMenu()
{
    Console.WriteLine("------------------------------------");
    Console.WriteLine("Enter a number to make a selection");
    Console.WriteLine("1/ Add asset");
    Console.WriteLine("2/ Display assets");
    Console.WriteLine("3/ Quit");
    Console.WriteLine("------------------------------------");

    string menuSelection = Console.ReadLine();

    switch(menuSelection)
    {
        case "1":
            addProduct();
            showMenu();
            break;
        case "2":
            displayList();
            showMenu();
            break;
        case "3":
            break;
        default:
            Console.WriteLine("Invalid selection");
            break;
    }
}
void displayList()
{
    
    Console.WriteLine("Type".PadRight(15) + "Brand".PadRight(15) + "Model".PadRight(15) + "Office".PadRight(15) + "Purchase Date".PadRight(15) + "Price (USD)".PadRight(15) + "Local Price");
    Console.WriteLine("----------------------------------------------------------------------------------------------------");
    // order by office - then class - then purchase date ascending
    assetList = assetList.OrderBy(asset => asset.Office.Country).ThenBy(asset => asset.GetType().Name).ThenBy(asset => asset.PurchaseDate).ToList();
    foreach (Asset asset in assetList)
    {
        TimeSpan timeSpan = DateTime.Now - asset.EndOfLife;
        
        // Instructions unclear - this output will be colorized if the date of End of life has passed 
        // IF end of life is more than 180 days - red
        // ELSE IF end of life is between 0 - 90 days - yellow
        if (timeSpan.Days >= 180)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            writeProduct(asset);
            Console.ResetColor();
        }
        else if (timeSpan.Days > 0 && timeSpan.Days >= 90)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            writeProduct(asset);
            Console.ResetColor();
        }
        
        else
        {
            writeProduct(asset);
        }

    }
    Console.WriteLine("----------------------------------------------------------------------------------------------------");

}

void writeProduct(Asset asset)
{
    // Writes asset info to console
    // Type - Brand - Model - Country - Purchase Date - Price(USD) - Local Price(Math.Round(Price * Local currency rate))
    Console.WriteLine(asset.GetType().Name.PadRight(15) + asset.Brand.PadRight(15) + asset.Model.PadRight(15) + asset.Office.Country.ToString().PadRight(15) + asset.PurchaseDate.ToShortDateString().PadRight(15) + asset.Price.ToString().PadRight(15) + Math.Round(asset.Office.CurrencyRate * asset.Price));
}

void addProduct()
{
    Console.WriteLine("Add product");
    Console.WriteLine("1 / Add computer");
    Console.WriteLine("2 / Add Phone");
    string assetInput = Console.ReadLine();
    if (assetInput != "1" && assetInput != "2")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input");
        Console.ResetColor();
        // Start over from beginning
        addProduct();
    }

    Console.Write("Enter brand: ");
    string brandInput = Console.ReadLine();

    Console.Write("Enter model: ");
    string modelInput = Console.ReadLine();

    Console.Write("Enter price: ");
    string priceInput = Console.ReadLine();
    bool isInt = int.TryParse(priceInput, out int value);
    if (!isInt)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input");
        Console.ResetColor();
        addProduct();
    }

    Console.WriteLine("Enter office: ");
    Console.WriteLine("1/ Sweden");
    Console.WriteLine("2/ Greece");
    Console.WriteLine("3/ USA");
    string officeInput = Console.ReadLine();
    Office office;
    //!  USA will be default - even if input is incorrect, not ideal
    if (officeInput == "1")
    {
        office = swe;
    }
    else if (officeInput == "2")
    {
        office = greece;
    }
    else
    {
        office = usa;
    }

    Console.WriteLine(office.Country);

    if (assetInput == "1")
    {
        Computer computer = new Computer(brandInput, modelInput, DateTime.Now, value, office);
        assetList.Add(computer);
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("Added computer to list.");
        Console.ResetColor();
    }
    else if (assetInput == "2")
            {
        Phone phone = new Phone(brandInput, modelInput, DateTime.Now, value, office);
        assetList.Add(phone);
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("Added phone to list.");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine("Something went wrong. Try again.");
        addProduct();
    }
}