using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiverModule
{
    class EntryPoint
    {
        static void Main()
        {
            var reader = new ConsoleReader();
            reader.ReadProcessedData("outputFile.csv");
        }
    }
}
