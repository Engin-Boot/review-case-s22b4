using System;

namespace ReceiverModule
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleReader reader = new ConsoleReader();
            reader.ReadProcessedData("WordCount.csv");
        }
    }
}
