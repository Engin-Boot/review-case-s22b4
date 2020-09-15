using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ReceiverModule
{
    public class FieldSplitter
    {
        readonly List<CommentRecord> _commentRecords = new List<CommentRecord>();
        CommentRecord _currentRecord;
        private void CheckIfFieldIsCommentOrDate(string field)
        {
            if (char.IsLetter(field[0]))
            {
                _currentRecord.Comment = _currentRecord.Comment.Append(field);
            }
            else
            {
                _currentRecord.Timestamp = _currentRecord.Timestamp.Append(field);
            }
        }
        public List<CommentRecord> SplitFields(List<string> rawCommentRecords)
        {

            if (rawCommentRecords.Count != 0)
            {
                foreach (string record in rawCommentRecords)
                {
                    _currentRecord = new CommentRecord();
                    var fields = record.Split(',');
                    if (fields.Length == 2)
                    {
                        ValidateAndAddRecord(fields);
                    }
                    else
                    {
                        CheckIfFieldIsCommentOrDate(fields[0]);
                    }
                    _commentRecords.Add(_currentRecord);
                }
                var frequencyGenerator = new WordFrequencyGenerator();
                frequencyGenerator.GenerateFrequencyList(_commentRecords);
            }
            else
            {
                var writer = new StreamWriter("output.csv");
                writer.WriteLine("Data not found");
                writer.Close();
            }
            return _commentRecords;
        }

        private void ValidateAndAddRecord(string[] fields)
        {
            _currentRecord = new CommentRecord(new StringBuilder(fields[0]), new StringBuilder(fields[1]));
        }

    }
}