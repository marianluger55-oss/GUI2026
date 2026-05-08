// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string all = File.ReadAllText(@"C:\temp\First.txt"); 
Console.WriteLine(all);

Console.WriteLine("------------------");
//relativer Pfad 

all = File.ReadAllText(@"C:\temp\Second.txt");
Console.WriteLine(all);

Console.WriteLine("------------------");



// Zeilenweise lesen
string[] lines = File.ReadAllLines(@"C:\temp\First.txt");
Console.WriteLine(lines[0]);
foreach (string line in lines)
{ 
    if(line.StartsWith("S"))
    {
        Console.WriteLine("S");
    }
    else    {
        Console.WriteLine(line);
    }
}
