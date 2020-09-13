

using System.Collections.Generic;
using System.Text;


namespace SenderModule
{
    internal class CommentRecordCreator
    {
        private readonly List<CommentRecord> _commentRecords = new List<CommentRecord>();
        private CommentRecord _currentRecord = new CommentRecord();

        readonly ILogger _logger;

        public CommentRecordCreator(ILogger target)
        {
            this._logger = target;
        }

        /*public void SetLogger(ILogger target)
        {
            this._logger = target;
        }*/

        public void LogData(List<CommentRecord> commentRecords)
        {
            this._logger.LogData(commentRecords);
        }
        public void SplitFields(List<string> rawCommentRecords)
        {

            foreach (var record in rawCommentRecords)
            {
                var fields = record.Split(',' );
                if (fields.Length == 2)
                {
                    AddRecord(fields);
                    ValidateCommentRecord(fields);
                }
                else
                {
                    AppendToComment(fields);
                }
            }
            _commentRecords.Add(_currentRecord);
            this.LogData(_commentRecords);
        }

        public void ValidateCommentRecord(string[] fields)
        {
            if (!string.IsNullOrWhiteSpace(fields[1]))
            {
                _currentRecord = new CommentRecord(new StringBuilder(fields[0]), new StringBuilder(fields[1]));
            }
        }

        public void AddRecord(string[] fields)
        {
            if (!string.IsNullOrWhiteSpace(fields[1]))
            {
                _commentRecords.Add(_currentRecord);
            }
        }

        public void AppendToComment(string[] fields)
        {
            if (!string.IsNullOrWhiteSpace(fields[0]))
            {
                _currentRecord.Comment = _currentRecord.Comment.Append(" " + fields[0]);
            }
        }


    }
}