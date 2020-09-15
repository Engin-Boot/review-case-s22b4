using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace ReceiverModule
{
    public class FieldSplitter
    {
        readonly List<CommentRecord> _commentRecords = new List<CommentRecord>();
        CommentRecord _currentRecord;
       
        public List<CommentRecord> SplitFields(List<string> rawCommentRecords)
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
                       var checker = new FieldClassifier();
                       checker.CheckIfFieldIsCommentOrDate(_currentRecord,fields[0]);
                    }
                    _commentRecords.Add(_currentRecord);
                }
            
                return _commentRecords;
        }

        private void ValidateAndAddRecord(string[] fields)
        {
            _currentRecord = new CommentRecord(new StringBuilder(fields[0]), new StringBuilder(fields[1]));
        }

    }
}