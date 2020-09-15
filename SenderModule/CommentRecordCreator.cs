

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

        private void LogData(List<CommentRecord> commentRecords, string columnFilter)
        {
            this._logger.LogData(commentRecords, columnFilter);
        }
        public void SplitFields(List<string> rawCommentRecords, string columnFilter)
        {

            foreach (var record in rawCommentRecords)
            {
                var fields = record.Split(',');
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
            _commentRecords.RemoveAt(0);
            this.LogData(_commentRecords, columnFilter);
        }

        private void ValidateCommentRecord(string[] fields)
        {
            if (!IsWhitespaceOrEmptyOrNull(fields[1]))
            {
                _currentRecord = new CommentRecord(new StringBuilder(fields[0]), new StringBuilder(fields[1]));
            }
        }

        private void AddRecord(string[] fields)
        {
            if (!IsWhitespaceOrEmptyOrNull(fields[1]))
            {
                _commentRecords.Add(_currentRecord);
            }
        }

        private void AppendToComment(string[] fields)
        {
            if (!IsWhitespaceOrEmptyOrNull(fields[0]))
            {
                _currentRecord.Comment = _currentRecord.Comment.Append(" " + fields[0]);
            }
        }

        private bool IsWhitespaceOrEmptyOrNull(string field)
        {
            bool condition1 = string.IsNullOrEmpty(field);
            bool condition2 = string.IsNullOrWhiteSpace(field) && condition1;

            return condition2;
        }
    }
}