using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ReceiverModule

{
    public class FieldSplitter
    {
        List<CommentRecord> _commentRecords = new List<CommentRecord>();
        CommentRecord _currentRecord;
        public List<CommentRecord> SplitFields (List<string> rawCommentRecords)
        {

            foreach (string record in rawCommentRecords)
            {   
                var fields = record.Split(new char[] { ' ' });
                if (fields.Length == 3 || fields.Length > 3)
                {
                    ValidateAndAddRecord(fields);
                    _commentRecords.Add(_currentRecord);
                }
            }
            return _commentRecords;
        }
        
        public void ValidateAndAddRecord(string[] fields)
        {
            if (fields.Length == 3)
                _currentRecord = new CommentRecord(fields[0], fields[1], fields[2]);
     
                for (int i = 3; i < fields.Length; i++)
                    fields[2] = fields[2] + " " + fields[i];
            _currentRecord = new CommentRecord(fields[0], fields[1], fields[2]);
  
        }

    }
}