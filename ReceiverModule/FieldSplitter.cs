using System.Collections.Generic;


namespace ReceiverModule

{
    public class FieldSplitter
    {
        readonly List<CommentRecord> _commentRecords = new List<CommentRecord>();
        CommentRecord _currentRecord;
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
        }
        
        private void ValidateAndAddRecord(string[] fields)
        {
            if (fields.Length == 3)
            {
                _currentRecord = new CommentRecord(fields[0], fields[1], fields[2]);
            }
            else
            {
                foreach(var field in fields)
                {
                    fields[2] = fields[2] + " " + field;
                }
                _currentRecord = new CommentRecord(fields[0], fields[1], fields[2]);
            }
        }
    }
}