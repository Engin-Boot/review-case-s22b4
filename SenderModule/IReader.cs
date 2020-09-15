using System.Collections.Generic;
using System.IO;

namespace SenderModule
{
    public interface IReader
    {
        public void ReadCommentDataFromFile(string sourceFilePath);

        public void ReadCommentDataFromFile(string sourceFilePath, string columnFilter);
    }
    public class CsvReader : IReader
    {
        private readonly List<string> _rawCommentRecords = new List<string>();
        readonly ILogger _logger;

        public static void Main()
        {
            ILogger logger = new ConsoleLogger();
            IReader reader = new CsvReader(logger);
            var csvPath = @"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\File-having-one-comment-spanning-multiple-lines.csv";
            reader.ReadCommentDataFromFile(csvPath);
        }
       
        public CsvReader(ILogger target)
        {
            this._logger = target;
        }

        public void ReadCommentDataFromFile(string sourceFilePath)
        {
            this.ReadCommentDataFromFile(sourceFilePath, null);
        }

        public void ReadCommentDataFromFile(string sourceFilePath, string columnFilter)
        {
            try
            {
                var reader = new StreamReader(sourceFilePath);
                while (reader.EndOfStream != true)
                {
                    var rawCommentRecord = reader.ReadLine();
                    _rawCommentRecords.Add(rawCommentRecord);
                }
                reader.Close();

                var splitter = new CommentRecordCreator(this._logger);
                splitter.SplitFields(_rawCommentRecords, columnFilter);
            }
            catch
            {
                throw new DirectoryNotFoundException();
            }
        }
    }
}