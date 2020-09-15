
using System.IO;
using Xunit;
using SenderModule;


namespace Sender.Test
{
    class DependencyInjection
    {
        private static readonly ILogger Logger = new ConsoleLogger();
        public readonly IReader Reader = new CsvReader(Logger);
    }
    class OutputFileReader
    {
        public readonly string FileContents;
        public OutputFileReader()
        {
            var streamReader = new StreamReader(@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\LogFile.txt");
            this.FileContents = streamReader.ReadToEnd();
            streamReader.Close();
            this.FileContents = this.FileContents.Trim();
        }
    }
    public class SenderUnitTest
    {
        [Fact]
        public void ThrowsExceptionWhenCsvFileNotFound()
        {
            var injector = new DependencyInjection();
            var csvPath = @"C: \Users\Chalasani\source\repos\sample-review\review-report.csv";
            Assert.Throws<DirectoryNotFoundException>(() => injector.Reader.ReadCommentDataFromFile(csvPath));
        }

        [Fact]
        public void WritesEmptyStringWhenCsvFileIsEmpty()
        {
            var injector = new DependencyInjection();
            var csvPath = (@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\Empty-file.csv");
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents.Equals("End of log file"));
        }
        [Fact]
        public void RemovesRecordWhenNoCommentIsPresentForTheTimestamp()
        {
            var injector = new DependencyInjection();
            var csvPath = (@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\File-having-few-empty-comment-records.csv");
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "4/28/2020 21:26,Is this required as the we are already assigning currentLocationPermissionResult under postCurrentBleStatus() API call.\r\nEnd of log file");
        }

        [Fact]
        public void WritesEmptyStringWhenCsvFilesHasJustTimestampsAndNoComments()
        {
            var injector = new DependencyInjection();
            var csvPath = (@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\Just-empty-comments.csv");
            injector.Reader.ReadCommentDataFromFile(csvPath, "comment");
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents.Equals("End of log file"));
        }

        [Fact]
        public void WritesEmptyStringWhenCsvFilesHasJustCommas()
        {
            var injector = new DependencyInjection();
            var csvPath = (@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\File-with-just-commas.csv");
            injector.Reader.ReadCommentDataFromFile(csvPath, "timestamp");
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents.Equals("End of log file"));
        }

        [Fact]
        public void RemovesBlankLinesFromFile()
        {
            var injector = new DependencyInjection();
            var csvPath = (@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\File-having-blank-lines.csv");
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "8/27/2019 11:22,No Additional Comments\r\n8/22/2019 18:39,No Additional Comments\r\nEnd of log file");
        }

        [Fact]
        public void RemovesLineWhenItHasNoTimestampOrComment()
        {
            var injector = new DependencyInjection();
            var csvPath = (@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\File-has-records-with-no-timestamp-or-comment.csv");
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "4/27/2020 9:14,what does this help with?\r\nEnd of log file");
        }

        [Fact]
        public void CombinesCommentsWhichSpanOverMultipleLines()
        {
            var injector = new DependencyInjection();
            var csvPath = (@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\File-having-one-comment-spanning-multiple-lines.csv");
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "5/21/2020 19:57,No review comments. All looks fine.\r\nEnd of log file");
        }

        [Fact]
        public void OutputsTimestampsAloneWhenTimestampFilterIsUsed()
        {
            var injector = new DependencyInjection();
            var csvPath = (@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\File-having-one-comment-spanning-multiple-lines.csv");
            injector.Reader.ReadCommentDataFromFile(csvPath, "timestamp");
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "5/21/2020 19:57\r\nEnd of log file");
        }

        [Fact]
        public void OutputsCommentsAloneWhenCommentFilterIsUsed()
        {
            var injector = new DependencyInjection();
            var csvPath = (@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\File-having-one-comment-spanning-multiple-lines.csv");
            injector.Reader.ReadCommentDataFromFile(csvPath, "comment");
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "No review comments. All looks fine.\r\nEnd of log file");
        }

        [Fact]
        public void WhenMainIsInvokedItStartsSender()
        {
            CsvReader.Main();
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "5/8/2020 13:17,This line does not have any impact as the. return value was not used. Check if we can remove this.\r\n5/8/2020 13:32,Remove this line. This line does not have any impact on solutionJsonString as it was not assigned back after replacing.\r\n5/14/2020 10:54,[Design] In BaseFullScreenDialogFragment expose OnDismissListener Now thats available to all the troubleshoot fragments Attach dismiss listener from searching fragment right after creating troubleShoot dialogs and call tryAgain() from the dismiss listener.\r\n5/14/2020 10:58,[Readability] Move troubleshoot to devicesetup package\r\nEnd of log file");
        }

    }
}
