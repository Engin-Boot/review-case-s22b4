
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
            reader = new OutputFileReader(@"output.csv");
            var outputContents = reader.FileContents;
            Assert.True(outputContents == "line,3\r\nimpact,2\r\nreturn,1\r\nvalue,1\r\nused,1\r\ncheck,1\r\nremove,2\r\nsolutionjsonstring,1\r\nassigned,1\r\nback,1\r\nreplacing,1\r\n[design],1\r\nbasefullscreendialogfragment,1\r\nexpose,1\r\nondismisslistener,1\r\nnow,1\r\nthats,1\r\navailable,1\r\ntroubleshoot,3\r\nfragments,1\r\nattach,1\r\ndismiss,2\r\nlistener,2\r\nsearching,1\r\nfragment,1\r\nright,1\r\ncreating,1\r\ndialogs,1\r\ncall,1\r\ntryagain(),1\r\n[readability],1\r\nmove,1\r\ndevicesetup,1\r\npackage,1");
        }
    }
}
