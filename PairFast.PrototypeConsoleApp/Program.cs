namespace PairFast.PrototypeConsoleApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Extensions.CollectItems()
            .PairItems()
            .CompareItems()
            .InterpretResults()
            .ViewResults();
    }
}
