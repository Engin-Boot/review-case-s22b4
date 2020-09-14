using System.Text;


namespace ReceiverModule
{
    public class CommentRecord
    {
        public StringBuilder Timestamp;
        public StringBuilder Comment;

        public CommentRecord(StringBuilder timestamp, StringBuilder comment)
        {
            this.Timestamp = timestamp;
            this.Comment = comment;
        }
        public CommentRecord()
        {
            this.Timestamp = new StringBuilder("");
            this.Comment = new StringBuilder("");
        }
    }
}