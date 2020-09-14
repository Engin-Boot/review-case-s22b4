using System;
using System.Collections.Generic;



namespace ReceiverModule
{
    public interface IReader
    {
        public void ReadProcessedData(string outputFile);
    }
    
    public class ConsoleReader : IReader
    {
        public void ReadProcessedData(string outputFilePath)
        {
            var rawCommentRecords = new List<string>();
            string commentRecord;
            while ((commentRecord = Convert.ToString(Console.In.ReadLine())) != "$")
            {
                rawCommentRecords.Add(commentRecord);
            }
            var splitter = new FieldSplitter();
            splitter.SplitFields(rawCommentRecords,outputFilePath);
        }
    }
}