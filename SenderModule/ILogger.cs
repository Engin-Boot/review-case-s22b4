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
            Console.WriteLine("Enter the filter");
            string filter = Console.ReadLine();
            ColumnFilter.ChooseFilter(filter, commentRecords);
        }
    } 
}