


using StatePattern;
using StatePattern.State;
using System.Text;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.OutputEncoding = Encoding.UTF8;
var doc = new NewDocument();

while (true)
{
    Console.WriteLine("\n================= BAD VERSION =================");
    Console.WriteLine($"Current State: {doc.StateName}");
    Console.WriteLine("Choose an action:");
    Console.WriteLine("1) Edit");
    Console.WriteLine("2) Submit");
    Console.WriteLine("3) Publish");
    Console.WriteLine("4) Reject (choose: final reject OR needs revision)");
    Console.WriteLine("5) Exired");
    Console.WriteLine("6) Reset to Draft");
    Console.WriteLine("0) Exit");
    Console.Write("> ");

    var choice = Console.ReadLine();
    if (choice == "0") break;

    switch (choice)
    {
        case "1": doc.Edit(); break;
        case "2": doc.Submit(); break;
        case "3": doc.Publish(); break;
        case "4": doc.Reject(); break;
        case "5": doc.Expire(); break;
        case "6": doc.ResetToDraft(); break;
        default: Console.WriteLine("⚠️ Invalid choice."); break;
    }
}
