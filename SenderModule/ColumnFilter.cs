using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SenderModule
{
   public class ColumnFilter
    {
        public static void ChooseFilter(string filter, List<CommentRecord> commentRecords)
        {
            StreamWriter writer = new StreamWriter("C:\\Users\\Anji\\Source\\Repos\\review-case-s22b4\\LogFile.txt");
            if (filter == "DateTime")
            {
                foreach (CommentRecord record in commentRecords)
                {
                    writer.WriteLine(record.Timestamp + "\n");
                    Console.Out.WriteLine(record.Timestamp + "\n");
                }
            }
            else if(filter == "Comment")
            {
                foreach (CommentRecord record in commentRecords)
                {
                    writer.WriteLine(record.Comment + "\n");
                    Console.Out.WriteLine(record.Comment + "\n");
                }
            }
            else
            {
                foreach (CommentRecord record in commentRecords)
                {
                    writer.WriteLine(record.Timestamp + "," + record.Comment + "\n");
                    Console.Out.WriteLine(record.Timestamp +","  + record.Comment + "\n");
                }
            }
            writer.Close();
        }
    }
}
