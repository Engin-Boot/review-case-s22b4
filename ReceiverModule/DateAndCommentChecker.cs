using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiverModule
{
    class DateAndCommentChecker
    {
        public void CheckIfFieldIsCommentOrDate(CommentRecord _currentRecord,string field)
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
    }
}
