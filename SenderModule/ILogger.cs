using System;
using System.Collections.Generic;
using System.IO;

namespace SenderModule
{
    public interface ILogger
    {
        public void LogData(List<CommentRecord> commentRecords, string columnFilter);
    }
    public class ConsoleLogger : ILogger
    {
        public void LogData(List<CommentRecord> commentRecords, string columnFilter)
        {

            if (!string.IsNullOrEmpty(columnFilter))
            {
                columnFilter = columnFilter.ToLower();
            }

            var writer = new StreamWriter(@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\LogFile.txt");
            ChooseFilter(commentRecords, columnFilter, writer);
            Console.WriteLine("End of log file");
            writer.WriteLine("End of log file");
            writer.Close();
        }

        private static void ChooseFilter(List<CommentRecord> commentRecords, string columnFilter, StreamWriter writer)
        {
            if (columnFilter == "timestamp")
            {
                foreach (CommentRecord record in commentRecords)
                {
                    writer.WriteLine(record.Timestamp);
                    Console.Out.WriteLine(record.Timestamp);
                }
            }
            else if (columnFilter == "comment")
            {
                foreach (CommentRecord record in commentRecords)
                {
                    writer.WriteLine(record.Comment);
                    Console.Out.WriteLine(record.Comment);
                }
            }
            else
            {
                foreach (CommentRecord record in commentRecords)
                {
                    writer.WriteLine(record.Timestamp + "," + record.Comment);
                    Console.Out.WriteLine(record.Timestamp + "," + record.Comment);
                }
            }
        }
    }
}