using System.Text;


namespace SenderModule
{
    public class CommentRecord
    {
        public readonly StringBuilder Timestamp;
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