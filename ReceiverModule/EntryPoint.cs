using System;
using System.IO;

namespace ReceiverModule
{
    public class EntryPoint
    {
       public static void Main()
        {
            Console.WriteLine("Reading data from the sender");

            var reader = new ConsoleReader();
            var listOfString=reader.ReadProcessedData();
            if (listOfString.Count != 0)
            {
                Console.WriteLine("list is not empty");
                var splitter = new FieldSplitter();
                var listOfCommentRecords = splitter.SplitFields(listOfString);

                var frequencyGenerator = new WordFrequencyGenerator();
                var frequencyList = frequencyGenerator.GenerateFrequencyList(listOfCommentRecords);

                var fileLogger = new FileLogger();
                fileLogger.AddCommentCountInACsvFile(frequencyList, "output.csv");
            }
            else
            {
                var writer = new StreamWriter("output.csv");
                writer.WriteLine("Data not found");
                writer.Close();
            }

        }
    }
}
