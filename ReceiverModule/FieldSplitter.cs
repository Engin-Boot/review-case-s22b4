using System.Collections.Generic;



namespace ReceiverModule

{
    public class FieldSplitter
    {
        readonly List<CommentRecord> _commentRecords = new List<CommentRecord>();
        CommentRecord _currentRecord = new CommentRecord();
        public List<CommentRecord> SplitFields (List<string> rawCommentRecords)
        {

            foreach (string record in rawCommentRecords)
            {   
                var fields = record.Split( ' ');
                if (fields.Length == 3 || fields.Length > 3)
                {
                    ValidateAndAddRecord(fields);
                    _commentRecords.Add(_currentRecord);
                }
            }

            return _commentRecords;
            //var generator = new WordFrequencyGenerator();
            //generator.GenerateFrequencyList(_commentRecords, outputFilePath);
        }
        
        private void ValidateAndAddRecord(string[] fields)
        {
            if (fields.Length == 3)
            {
                _currentRecord = new CommentRecord(fields[0] + " " + fields[1], fields[2]);
            }
            else
            {
                for(int i = 3; i < fields.Length; i++)
                {
                    fields[2] = fields[2] + " " + fields[i];
                }
                _currentRecord = new CommentRecord(fields[0] + " " + fields[1], fields[2]);
            }
        }
    }
}