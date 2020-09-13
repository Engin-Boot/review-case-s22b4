namespace ReceiverModule
{
    public class CommentRecord
    {
        public readonly string Timestamp;
        public readonly string Comment;
        

        public CommentRecord(string timestamp, string comment)
        {
            this.Timestamp = timestamp;
            this.Comment = comment;
        }

        public CommentRecord()
        {
            this.Timestamp = "";
            this.Comment = "";
        }
    }
}