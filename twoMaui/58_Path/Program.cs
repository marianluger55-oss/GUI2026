// See https://aka.ms/new-console-template for more information
using System.Security;

Console.WriteLine("Hello, World!");

DateTime now = DateTime.Now;
string basisPath = @"C:\temp"; 
string path = Path.Combine(basisPath, "log.txt", $"out{now.Year}_{now.Month}_{now.Day}");
Console.WriteLine(path);

if(File.Exists(path))
{
    Console.WriteLine($"Datei {path} existiert bereits");
}
else
{
 Console.WriteLine("Datei existiert nicht");
}

string? dir = Path.GetDirectoryName(path);  
Console.WriteLine(dir);