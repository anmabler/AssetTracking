using Week3AssetTracking;

List<Asset> assetList = new List<Asset> {
    new Computer("ASUS ROG", "B550-F", new DateTime(2020, 11, 24), 2438),
    new Computer("HP", "14S-FQ1010NO", new DateTime(2022, 01, 30), 6790),
    new Phone("Samsung", "S20 Plus", new DateTime(2020, 09, 12), 15000),
    new Phone("Sony Xperia", "10 III", new DateTime(2020, 03, 06), 8000)
};

foreach (var asset in assetList)
{
    Console.WriteLine(asset.EndOfLife);
}