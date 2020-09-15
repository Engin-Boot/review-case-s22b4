
using System.Collections.Generic;
using System;

namespace ReceiverModule
{
    interface IReader
    {
        public List<string> ReadProcessedData();
    }

    public class ConsoleReader : IReader
    {
        public List<string> ReadProcessedData()
        {
            var rawCommentRecords = new List<string>();
            string commentRecord;
            while ((commentRecord = Convert.ToString(Console.In.ReadLine())) != "End of log file")
            {
                rawCommentRecords.Add(commentRecord);
            }
            return (rawCommentRecords);
        }
    }
}
