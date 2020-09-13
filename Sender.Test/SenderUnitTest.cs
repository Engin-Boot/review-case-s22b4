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
            var streamReader = new StreamReader(@"C:\Users\Chalasani\Source\Repos\review-case-s22b4\LogFile.txt");
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
            Assert.Throws<DirectoryNotFoundException>(()=> injector.Reader.ReadCommentDataFromFile(csvPath));
            
        }

        [Fact]
        public void WritesEmptyStringWhenCsvFileIsEmpty()
        {
            var injector = new DependencyInjection();
            var csvPath = @"C:\Users\Chalasani\source\repos\review-case-s22b4\sample-review\Empty-file.csv";
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents.Equals(""));
        }
        [Fact]
        public void RemovesRecordWhenNoCommentIsPresentForTheTimestamp()
        {
            var injector = new DependencyInjection();
            var csvPath = @"C:\Users\Chalasani\source\repos\review-case-s22b4\sample-review\File-having-few-empty-comment-records.csv";
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "4/28/2020 21:26 Is this required as the we are already assigning currentLocationPermissionResult under postCurrentBleStatus() API call.");
        }

        [Fact]
        public void WritesEmptyStringWhenCsvFilesHasJustTimestampsAndNoComments()
        {
            var injector = new DependencyInjection();
            var csvPath = @"C:\Users\Chalasani\Source\Repos\review-case-s22b4\sample-review\Just-empty-comments.csv";
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents.Equals(""));
        }

        [Fact]
        public void WritesEmptyStringWhenCsvFilesHasJustCommas()
        {
            var injector = new DependencyInjection();
            var csvPath = @"C:\Users\Chalasani\Source\Repos\review-case-s22b4\sample-review\File-with-just-commas.csv";
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents.Equals(""));
        }

        [Fact]
        public void RemovesBlankLinesFromFile()
        {
            var injector = new DependencyInjection();
            var csvPath = @"C:\Users\Chalasani\Source\Repos\review-case-s22b4\sample-review\File-having-blank-lines.csv";
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "8/27/2019 11:22 No Additional Comments\r\n8/22/2019 18:39 No Additional Comments");
        }

        [Fact]
        public void RemovesLineWhenItHasNoTimestampOrComment()
        {
            var injector = new DependencyInjection();
            var csvPath = @"C:\Users\Chalasani\Source\Repos\review-case-s22b4\sample-review\File-has-records-with-no-timestamp-or-comment.csv";
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "4/27/2020 9:14 what does this help with?");
        }

	    [Fact]
        public void CombinesCommentsWhichSpanOverMultipleLines()
        {
            var injector = new DependencyInjection();
            var csvPath = @"C:\Users\Chalasani\Source\Repos\review-case-s22b4\sample-review\File-having-one-comment-spanning-multiple-lines.csv";
            injector.Reader.ReadCommentDataFromFile(csvPath);
            var reader = new OutputFileReader();
            Assert.True(reader.FileContents == "5/21/2020 19:57 No review comments. All looks fine.");
        }

        [Fact]
        public void TestMethod()
        {
            Assert.False(true, "Expected path " + Directory.GetCurrentDirectory());
        }
    }
}
