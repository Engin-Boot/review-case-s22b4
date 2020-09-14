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
            
            ChooseFilter(commentRecords, columnFilter);
        }

        public static void ChooseFilter(List<CommentRecord> commentRecords, string columnFilter)
        {
            StreamWriter writer = new StreamWriter(@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\LogFile.txt");
            if (columnFilter == "timestamp")
            {
                foreach (CommentRecord record in commentRecords)
                {
                    writer.WriteLine(record.Timestamp + "\n");
                    Console.Out.WriteLine(record.Timestamp + "\n");
                }
            }
            else if (columnFilter == "comment")
            {
                foreach (CommentRecord record in commentRecords)
                {
                    writer.WriteLine(record.Comment + "\n");
                    Console.Out.WriteLine(record.Comment + "\n");
                }
            }
            else
            {
                LogCompleteRecord(commentRecords, writer);
            }
            writer.Close();
        }

        public static void LogCompleteRecord(List<CommentRecord> commentRecords, StreamWriter writer)
        {
            foreach (CommentRecord record in commentRecords)
            {
                if (record.Timestamp.ToString() != "")
                {
                    writer.WriteLine(record.Timestamp + "," + record.Comment + "\n");
                    Console.Out.WriteLine(record.Timestamp + "," + record.Comment + "\n");
                }
            }
        }
    }
}