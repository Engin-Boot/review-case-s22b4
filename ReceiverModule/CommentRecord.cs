using System;
using System.Text;


namespace ReceiverModule
{
    public class CommentRecord
    {
        public string Date;
        public string Time;
        public string Comment;
        

        public CommentRecord(string date, string time, string comment)
        {
            this.Date = date;
            this.Time = time;
            this.Comment = comment;
        }
        public CommentRecord()
        {
            this.Date = "";
            this.Time = "";
            this.Comment ="";
        }
    }
}