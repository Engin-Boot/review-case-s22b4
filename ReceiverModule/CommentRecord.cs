using System.Text;


namespace ReceiverModule
{
    public class CommentRecord
    {
        public StringBuilder DateTime;
        public StringBuilder Comment;

        public CommentRecord(StringBuilder dateTime, StringBuilder comment)
        {
            this.DateTime = dateTime;
            this.Comment = comment;
        }
        public CommentRecord()
        {
            this.DateTime = new StringBuilder("");
            this.Comment = new StringBuilder("");
        }
    }
}