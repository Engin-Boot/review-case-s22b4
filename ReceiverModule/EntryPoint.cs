using System;
using System.IO;

namespace ReceiverModule
{
    public class EntryPoint
    {
       public static void Main()
        {
            Console.WriteLine("Reading data from the sender.....");

            IReader reader = new ConsoleReader();
            var listOfString=reader.ReadProcessedData();
            if (listOfString.Count != 0)
            {
                var splitter = new FieldSplitter();
                var listOfCommentRecords = splitter.SplitFields(listOfString);

                var frequencyGenerator = new WordFrequencyGenerator();
                var frequencyList = frequencyGenerator.GenerateFrequencyList(listOfCommentRecords);

                ILogger logger = new FileLogger();
                logger.LogAnalysis(frequencyList, "output.csv");
            }
            else
            {
                Console.WriteLine("Log file is empty");
                var writer = new StreamWriter("output.csv");
                writer.WriteLine("Data not found");
                writer.Close();
            }

        }
    }
}
