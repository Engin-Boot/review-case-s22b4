
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
            var writer = new StreamWriter("C:\\Users\\Chalasani\\Source\\Repos\\review-case-s22b4\\LogFile.txt");
            foreach (var record in commentRecords)
            {
                writer.WriteLine(record.Timestamp+ " " +record.Comment);
               //Console.WriteLine(record.Timestamp + " " + record.Comment);
            }
            writer.Close();
        }
    } 
}