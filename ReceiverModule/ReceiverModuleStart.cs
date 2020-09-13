using System;
using System.Text;
using System.Collections.Generic;
namespace ReceiverModule
{
    class ReceiverModuleStart
    {
       /* static void Main(string[] args)
        {
            ConsoleReader consoleReader = new ConsoleReader();
            List<string> comments = consoleReader.ReadFromConsole();


            FieldSplitter fieldSplitter = new FieldSplitter();
            List<CommentRecord> c=fieldSplitter.SplitFields(comments);

            foreach (CommentRecord record in c)
            {
                Console.WriteLine("records:");
                Console.WriteLine(record.Date + " " + record.Time + "     " + record.Comment + "\n");
            }
            WordCount wordCount = new WordCount();
            Dictionary<string, int> dictionary= wordCount.CountWordsInTheList(c);
            WordCountToCsvAdder.AddCommentCount(dictionary, "CommentRecord.csv");


        }*/
    }
}
