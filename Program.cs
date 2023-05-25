var menus = Directory.GetFiles(@"C:\Users\Kathi\Dokumente\c#-codes\POSE-Codes\059-schnitzelhunt\menucards");

PrintWelcomingMessage();

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

void PrintWelcomingMessage()
{
    Console.WriteLine("WHERE TO GET SCHNITZEL?");
    Console.WriteLine("=======================");
    Console.WriteLine();
}
