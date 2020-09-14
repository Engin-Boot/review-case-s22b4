using System;
using System.Collections.Generic;
using System.Text;
namespace ReceiverModule
{
    class Program
    {
        static void Main(string[] args)
        {
           /* ConsoleReader reader = new ConsoleReader();
            reader.ReadProcessedData("WordCount.csv");*/

            var wordCount = new WordFrequencyGenerator();
            var record1 = new CommentRecord(new StringBuilder("1/1/2020 12:30"), new StringBuilder("Code should be decoupled"));
            var record2 = new CommentRecord(new StringBuilder("20/2/2020 13:10"), new StringBuilder("No additional Comments"));
            var record3 = new CommentRecord(new StringBuilder("10/3/2020 19:09"), new StringBuilder("No additional Comments"));
            var commentRecord = new List<CommentRecord> { record1, record2, record3 };
            var frequencyList1 = new Dictionary<string, int> { ["code"] = 1, ["should"] = 1, ["be"] = 1, ["decoupled"] = 1, ["no"] = 2, ["additional"] = 2, ["comments"] = 2 };
            var frequencyList2 = new  Dictionary<string, int> { ["code"] = 1, ["decoupled"] = 1, ["additional"] = 2, ["comments"] = 2 };
            Dictionary<string, int> d =wordCount.GenerateFrequencyList(commentRecord, "path2.csv");
            foreach (KeyValuePair<string, int> kv in d)
                Console.WriteLine(kv.Key + " " + kv.Value);
        }
    }
}
