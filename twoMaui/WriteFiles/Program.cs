// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string text = "Hallo, das ist ein Test!";
File.WriteAllText(@"C:\temp\First.txt", text);

text = "Hallo, das ist ein Test! \nDas ist die zweite Zeile.";
File.WriteAllText("gedicht.txt", text);

string [] lines = new string[] { "Hallo, das ist ein Test!", "Das ist die zweite Zeile.", "Das ist die dritte Zeile." };
File.WriteAllLines("gedicht2.txt", lines);

string name = "Nick"; 
for(int i = 0; i < 100; i++)
{
    File.AppendAllText(@"C:\temp\name.txt", name);
    
}
