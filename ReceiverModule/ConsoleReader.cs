using System;
using System.Collections.Generic;



namespace ReceiverModule
{
    public class ConsoleReader
    {
        public List<string> ReadFromConsole()
        {
            var rawCommentRecords = new List<string>();
            Console.WriteLine("Enter string");
            string commentRecord;
            while ((commentRecord = Convert.ToString(Console.In.ReadLine())) != null)
            {
                rawCommentRecords.Add(commentRecord);
            }
            return rawCommentRecords;
        }
    }
}