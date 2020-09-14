using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ReceiverModule
{
   public class FieldSplitter
    {
        readonly List<CommentRecord> _commentRecords = new List<CommentRecord>();
        CommentRecord _currentRecord;
        public void CheckIfFieldIsCommentOrDate(string field)
        { 
           if(char.IsLetter(field[0]))
          _currentRecord.Comment = _currentRecord.Comment.Append(field);
           else
          _currentRecord.Timestamp = _currentRecord.Timestamp.Append(field);
        }
        public List<CommentRecord> SplitFields(List<string> rawCommentRecords)
        {

            foreach (string record in rawCommentRecords)
            {
                _currentRecord = new CommentRecord();
                var fields = record.Split(new char[] { ',' });
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

               return _commentRecords;
        }

        public void ValidateAndAddRecord(string[] fields)
        {
                _currentRecord = new CommentRecord(new StringBuilder(fields[0]), new StringBuilder(fields[1]));
        }

    }
}