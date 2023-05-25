Console.OutputEncoding = System.Text.Encoding.Default;
var menus = Directory.GetFiles(@"C:\Users\Kathi\Dokumente\c#-codes\POSE-Codes\059-schnitzelhunt\menucards");

PrintAllRestaurantThatHaveSchnitzel(menus);
Console.WriteLine();
PrintSpecifiedDish(menus, "Seitan Schnitzel", "THE CHEAPEST");
Console.WriteLine();
PrintSpecifiedDish(menus, "Seitan Schnitzel", "THE MOST EXPENSIVE");

void PrintAllRestaurantThatHaveSchnitzel(string[] menus)
{
    Console.WriteLine("WHERE TO GET SCHNITZEL?");
    Console.WriteLine("=======================");
    Console.WriteLine();

    for (int i = 0; i < menus.Length; i++)
    {
        string[] lines = File.ReadAllLines(menus[i]);
        bool firstOccurence = true;

        foreach (var line in lines)
            if (line.Contains("Schnitzel"))
            {
                if (firstOccurence)
                {
                    Console.WriteLine(Path.GetFileNameWithoutExtension(menus[i]));
                    firstOccurence = false;
                }
                int indexOfEnd = line.IndexOf(':');
                Console.WriteLine($"    {line.Substring(0, indexOfEnd)}");
            }
    }
}

void PrintSpecifiedDish(string[] menus, string searchedDish, string parameter)
{
    string welcome = $"WHERE TO GET {parameter} {searchedDish.ToUpper()}?";
    Console.WriteLine();
    Console.WriteLine(welcome);
    foreach (char ch in welcome)
    {
        Console.Write('=');
    }
    Console.WriteLine("\n");

    int count = 0, currentPrice = 0, endPrice = 0;
    string restaurant = "";
    bool condition = false;

    for (int i = 0; i < menus.Length; i++)
    {
        string[] lines = File.ReadAllLines(menus[i]);

        foreach (var line in lines)
        {
            if (line.Contains(searchedDish))
            {
                string price = "";
                for (int j = 0; j < line.Length; j++)
                {
                    if (Char.IsDigit(line[j]))
                    {
                        price += line[j];
                    }
                }

                if (count == 0)
                {
                    endPrice = int.Parse(price);
                }
                currentPrice = int.Parse(price);

                if (parameter == "THE CHEAPEST")
                {
                    condition = currentPrice < endPrice;
                }
                else if (parameter == "THE MOST EXPENSIVE")
                {
                    condition = currentPrice > endPrice;
                }
                
                if (condition)
                {
                    endPrice = currentPrice;
                    restaurant = Path.GetFileNameWithoutExtension(menus[i]);
                }
                count++;
            }
        }
    }
    if (parameter == "THE CHEAPEST") { Console.WriteLine($"{restaurant}, {endPrice}€"); }
    if (parameter == "THE MOST EXPENSIVE") { Console.WriteLine($"{restaurant}, {endPrice}"); }

}


