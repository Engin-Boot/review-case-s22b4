namespace ReceiverModule
{
    public class CommentRecord
    {
        public readonly string Date;
        public readonly string Time;
        public readonly string Comment;
        

        public CommentRecord(string date, string time, string comment)
        {
            this.Date = date;
            this.Time = time;
            this.Comment = comment;
        }

        /*public CommentRecord()
        {
            this.Date = "";
            this.Time = "";
            this.Comment = "";
        }*/
    }
}