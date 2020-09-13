using System;
using System.Collections.Generic;
using System.IO;

namespace SenderModule
{
    public interface ILogger
    {
        public void LogData(List<CommentRecord> commentRecords);
    }
    public class ConsoleLogger : ILogger
    {
        public void LogData(List<CommentRecord> commentRecords)
        {
            var writer = new StreamWriter(@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\LogFile.txt");
            foreach (var record in commentRecords)
            {
                string commentRecord = record.Timestamp + " " + record.Comment;
                writer.WriteLine(commentRecord);
                Console.WriteLine(commentRecord);
            }
            writer.Close();
        }
    } 
}