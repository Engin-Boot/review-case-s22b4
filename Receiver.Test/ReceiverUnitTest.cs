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
            var fields = new FieldSplitter();
            var commentRecords = new List<string> { "1/1/2020 12:30 Code should be decoupled" };
            var records = fields.SplitFields(commentRecords);
            var condition = true;
            foreach (var record in records)
            {
                var condition1 = record.Date.Equals("1/1/2020");
                var condition2 = record.Time.Equals("12:30");
                var condition3 = record.Comment.Equals("Code should be decoupled");
                condition = condition && condition1 && condition2 && condition3;
            }
            Assert.True(condition);
        }
        [Fact]
        public void WhenWePassListOfRecordsAndReturnTheCommentsWithCountInDictionary()
        {
            var wordCount = new WordFrequencyGenerator();
            var record1 = new CommentRecord("1/1/2020", "12:30", "Code should be decoupled");
            var record2 = new CommentRecord("20/2/2020", "13:10", "No additional Comments");
            var record3 = new CommentRecord("10/3/2020", "19:09", "No additional Comments");
            var commentRecord = new List<CommentRecord> { record1, record2, record3 };
            var frequencyList1 = new Dictionary<string, int> { ["code"] = 1, ["should"] = 1, ["be"] = 1, ["decoupled"] = 1, ["no"] = 2, ["additional"] = 2, ["comments"] = 2 };
            var frequencyList2 = new Dictionary<string, int> { ["code"] = 1, ["decoupled"] = 1, ["additional"] = 2, ["comments"] = 2 };
            Assert.True(wordCount.CountWordsInTheList(commentRecord).SequenceEqual(frequencyList2));
            Assert.False(wordCount.CountWordsInTheList(commentRecord).SequenceEqual(frequencyList1));

        }
        
        [Fact]
        public void CheckForACorrectFilePathWhenAddingWordCountToCsv()
        {
            var logger = new FileLogger();
            var wordCount = new Dictionary<string, int> { ["Comments"] = 1, ["Additional"] = 2, ["No"] = 3, ["Fault"] = 1 };
            Assert.True(logger.AddCommentCountInACsvFile(wordCount, "CommentsCount.csv"));
            Assert.False(logger.AddCommentCountInACsvFile(wordCount, "a "));
            Assert.False(logger.AddCommentCountInACsvFile(wordCount, " "));
        }

        [Fact]
        public void CheckIfCorrectValueIsUploadedInCsvFile()
        {
            var logger = new FileLogger();
            var wordCount = new Dictionary<string, int> { ["Comments"] = 1, ["Additional"] = 2, ["No"] = 3, ["Fault"] = 1 };
            Assert.True(logger.AddCommentCountInACsvFile(wordCount, "CommentsCountTest.csv"));
            var word = logger.AddToDic("CommentsCountTest.csv");
            Assert.True(wordCount.SequenceEqual(word));
        }

    }
}
