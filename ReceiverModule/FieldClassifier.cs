
namespace ReceiverModule
{
    class FieldClassifier
    {
        public void CheckIfFieldIsCommentOrDate(CommentRecord currentRecord,string field)
        {
            if (char.IsLetter(field[0]))
            {
                currentRecord.Comment = currentRecord.Comment.Append(field);
            }
            else
            {
                currentRecord.Timestamp = currentRecord.Timestamp.Append(field);
            }
        }
    }
}
