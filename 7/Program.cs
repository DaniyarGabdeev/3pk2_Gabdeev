using _7;

internal class Program
{
    static void Main(string[] args)
    {
        Store store = new Store() { AllPurshares = "" };
        Client Ivan = new Client() { AllPurchases = 12000, Name = "Иван" };
        Client Vladimir = new Client() { AllPurchases = 3600, Name = "Владимир" };
        Client Alecsander = new Client() { AllPurchases = 90000, Name = "Александер" };

        Building_materials building_Materials = new Building_materials()
        {
            Name = "Строительные материалы",
            Gkm = "Кирпич",
            Rm = "Профнастил",
            Price = 30032
        };
        Building_mixes building_Mixes = new Building_mixes()
        {
            Name = "Строительные смеси",
            Drymixes = "Цемент",
            Bulkmaterials = "Гипс",
            Price = 100800
        };
        Finishing_materials finishing_Materials = new Finishing_materials()
        {
            Name = "Отделачные материалы",
            Doors = "Входные",
            Ceilings = "Подвестные",
            Price = 50880
        };

        store.SaveOrder(Ivan, new Product[1] { building_Mixes });

        store.SaveOrder(Vladimir, new Product[2] { building_Materials, finishing_Materials });

        store.SaveOrder(Alecsander, new Product[3] { building_Materials, finishing_Materials, building_Mixes });

        Console.WriteLine(store.AllPurshares);




    }
}