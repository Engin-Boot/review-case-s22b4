using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using ReceiverModule;

namespace Receiver.Test

{
    public class ReceiverUnitTest
    {

        
        [Fact]
        public void WhenAListOfStringIsPassedThenWeGetListOfTypeCommandRecord()
        {
            FieldSplitter splitfield = new FieldSplitter();
            List<string> datePlusReview = new List<string> { "1/1/2020 12:30 Code should be decoupled" };
            List<CommentRecord> dateTimeAndCommentsSplitted = splitfield.SplitFields(datePlusReview);
            foreach (var record in dateTimeAndCommentsSplitted)
            {
                record.Date.Equals("1/1/2020");
                record.Time.Equals("12:30");
                record.Comment.Equals("Code should be decoupled");
            }
        }
        [Fact]
        public void WhenWePassListOfRecordsAndReturnTheCommentsWithCountInDictionary()
        {
            WordCount wordCount = new WordCount();
            CommentRecord commentInfo1 = new CommentRecord("1/1/2020", "12:30", "Code should be decoupled");
            CommentRecord commentInfo2 = new CommentRecord("20/2/2020", "13:10", "No additional Comments");
            CommentRecord commentInfo3 = new CommentRecord("10/3/2020", "19:09", "No additional Comments");
            List<CommentRecord> commentrecord = new List<CommentRecord> { commentInfo1, commentInfo2, commentInfo3 };
            Dictionary<string, int> wordCountInDictionary = new Dictionary<string, int> { ["code"] = 1, ["should"] = 1, ["be"] = 1, ["decoupled"] = 1, ["no"] = 2, ["additional"] = 2, ["comments"] = 2 };
            Assert.True(wordCount.CountWordsInTheList(commentrecord).SequenceEqual(wordCountInDictionary));

        }
        
        [Fact]
        public void CheckForACorrectFilePathWhenAddingWordCountToCsv()
        {
            WordCountToCsvAdder wordCountToCsvAdder = new WordCountToCsvAdder();
            Dictionary<string, int> wordCount = new Dictionary<string, int> { ["Comments"] = 1, ["Additional"] = 2, ["No"] = 3, ["Fault"] = 1 };
            Assert.True(wordCountToCsvAdder.AddCommentCountInACsvFile(wordCount, "CommentsCount.csv"));
            Assert.False(wordCountToCsvAdder.AddCommentCountInACsvFile(wordCount, "a "));
            Assert.False(wordCountToCsvAdder.AddCommentCountInACsvFile(wordCount, " "));
        }

        [Fact]
        public void CheckIfCorrectValueIsUploadedInCsvFile()
        {
            WordCountToCsvAdder wordCountToCsvAdder = new WordCountToCsvAdder();
            Dictionary<string, int> wordCount = new Dictionary<string, int> { ["Comments"] = 1, ["Additional"] = 2, ["No"] = 3, ["Fault"] = 1 };
            Assert.True(wordCountToCsvAdder.AddCommentCountInACsvFile(wordCount, "CommentsCountTest.csv"));
            Dictionary<string, int> word = wordCountToCsvAdder.AddToDic("CommentsCountTest.csv");
            Assert.True(wordCount.SequenceEqual(word));
        }

    }
}
