
using Xunit;
using SenderModule;
using ReceiverModule;
using System.IO;
using System;

namespace Integration.Test
{
    class OutputFileReader
    {
        public readonly string FileContents;
        public OutputFileReader(string filePath)
        {
            var streamReader = new StreamReader(filePath);
            this.FileContents = streamReader.ReadToEnd();
            streamReader.Close();
            this.FileContents = this.FileContents.Trim();
        }
    }
    public class IntegrationUnitTest
    {
        [Fact]
        public void WhenSenderIsInvokedItOutputsAStreamOfRawData()
        {
            
            CsvReader.Main();
            var reader = new OutputFileReader(@"D:\a\review-case-s22b4\review-case-s22b4\Sender.Test\bin\Debug\netcoreapp3.1\sample-review\LogFile.txt");
            var receiverInputContents = reader.FileContents;
            var inputString = new StringReader(receiverInputContents);
            Console.SetIn(inputString);
            ConsoleReader.Main();
            reader = new OutputFileReader(@"D:\a\review-case-s22b4\review-case-s22b4\output.csv");
            var outputContents = reader.FileContents;
            Assert.True(outputContents == "review,1\r\ncomments.,1\r\nlooks,1\r\nfine.,1");
        }
    }
}
