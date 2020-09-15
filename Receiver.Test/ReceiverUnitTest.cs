using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Xunit;
using ReceiverModule;
using System.IO;

namespace Receiver.Test

{
    class OutputFileReader
    {
        public readonly string FileContents;
        public OutputFileReader()
        {
            var streamReader = new StreamReader("output.csv");
            this.FileContents = streamReader.ReadToEnd();
            streamReader.Close();
            this.FileContents = this.FileContents.Trim();
        }
    }
    public class ReceiverUnitTest
    {
        [Fact]
        public void WhenBothTimestampAndCommentIsPassedThenStoreBothInAListOfCommentRecordType()
        {
            var fields = new FieldSplitter();
            var commentRecords = new List<string> { "1/1/2020 12:30,Code should be decoupled" };
            var records = fields.SplitFields(commentRecords);
            var condition = true;
            foreach (var record in records)
            {
                var condition1 = record.Timestamp.Equals("1/1/2020 12:30");
                var condition2 = record.Comment.Equals("Code should be decoupled");
                condition = condition && condition1 && condition2;
            }
            Assert.True(condition);
        }
        [Fact]
        public void WhenDateTimeIsPassedThenWeStoreOnlyDateInAListOfCommentRecordType()
        {
            var fields = new FieldSplitter();
            var commentRecords = new List<string> { "1/1/2020 12:30" };
            var records = fields.SplitFields(commentRecords);
            var condition = true;
            foreach (var record in records)
            {
                var condition1 = record.Timestamp.Equals("1/1/2020 12:30");
                var condition2 = record.Comment.Equals("");
                condition = condition && condition1 && condition2;
            }
            Assert.True(condition);
        }
        [Fact]
        public void WhenCommentPassedThenWeStoreOnlyCommentInAListOfCommentRecordType()
        {
            var fields = new FieldSplitter();
            var commentRecords = new List<string> { "No additional Comments" };
            var records = fields.SplitFields(commentRecords);
            var condition = true;
            foreach (var record in records)
            {
                var condition1 = record.Timestamp.Equals("");
                var condition2 = record.Comment.Equals("No additional Comments");

                condition = condition && condition1 && condition2;
            }
            Assert.True(condition);
        }
        [Fact]
        public void WhenWePassListOfRecordsThenReturnTheCommentsWithCountInDictionaryAfterRemovingStopWords()
        {
            var wordCount = new WordFrequencyGenerator();
            var record1 = new CommentRecord(new StringBuilder("1/1/2020 12:30"), new StringBuilder("Code should be decoupled"));
            var record2 = new CommentRecord(new StringBuilder("20/2/2020 13:10"), new StringBuilder("No additional Comments"));
            var record3 = new CommentRecord(new StringBuilder("10/3/2020 19:09"), new StringBuilder("No additional Comments"));
            var commentRecord = new List<CommentRecord> { record1, record2, record3 };
            var frequencyList1 = new Dictionary<string, int> { ["code"] = 1, ["should"] = 1, ["be"] = 1, ["decoupled"] = 1, ["no"] = 2, ["additional"] = 2, ["comments"] = 2 };
            var frequencyList2 = new Dictionary<string, int> { ["code"] = 1, ["decoupled"] = 1, ["additional"] = 2, ["comments"] = 2 };
            Assert.True(wordCount.GenerateFrequencyList(commentRecord).SequenceEqual(frequencyList2));
            Assert.False(wordCount.GenerateFrequencyList(commentRecord).SequenceEqual(frequencyList1));

        }

        [Fact]
        public void CheckForACorrectFilePathWhenAddingWordCountToCsv()
        {
            var logger = new FileLogger();
            var wordCount = new Dictionary<string, int> { ["Comments"] = 1, ["Additional"] = 2, ["No"] = 3, ["Fault"] = 1 };
            Assert.True(logger.LogAnalysis(wordCount, "CommentsCount.csv"));
            Assert.False(logger.LogAnalysis(wordCount, "a "));
            Assert.False(logger.LogAnalysis(wordCount, " "));
        }

        [Fact]
        public void WhenGivenEmptyFileThenWritesDataNotFoundToOutputFile()
        {
            var inputString = new StringReader("End of log file");
            Console.SetIn(inputString);
            EntryPoint.Main();
            var output = new OutputFileReader();
            Assert.True(output.FileContents == "Data not found");
        }


        [Fact]
        public void WhenWePassStringsThroughConsoleThenReceiverReadsItAndStoresInList()
        {
            var inputString = new StringReader("1/1/2020 12:30,Code should be decoupled" + "\n" +
                                               "2/4/2020 14:56,No additional Comments" + "\n" + "End of log file");
            Console.SetIn(inputString);
            ConsoleReader reader = new ConsoleReader();
            List<string> dataReadThroughConsole = new List<string> { "1/1/2020 12:30,Code should be decoupled", "2/4/2020 14:56,No additional Comments" };
            Assert.True(reader.ReadProcessedData().SequenceEqual(dataReadThroughConsole));

        }

        [Fact]
        public void WhenGivenValidLogDataThenWritesAnalysisToOutputFile()
        {
            var inputString = new StringReader("1/1/2020 12:30,Code should be decoupled\nEnd of log file");
            Console.SetIn(inputString);
            EntryPoint.Main();
            var output = new OutputFileReader();
            Assert.True(output.FileContents == "code,1\r\ndecoupled,1");
        }

    }
}