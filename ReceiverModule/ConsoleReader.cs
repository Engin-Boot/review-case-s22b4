using System;
using System.Collections.Generic;



namespace ReceiverModule
{
    public class ConsoleReader
    {
        public List<string> ReadFromConsole()
        {
            List<string> _rawCommentRecords = new List<string>();
            Console.WriteLine("Enter string");
            while (true)
            {   
                string rawCommentRecord = Convert.ToString(Console.In.ReadLine());
                _rawCommentRecords.Add(rawCommentRecord);
                if (rawCommentRecord == "$")
                {
                    break;
                }
            }
            return _rawCommentRecords;
        }
    }
}