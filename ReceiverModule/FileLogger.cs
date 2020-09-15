
using System.Collections.Generic;
using System.IO;

namespace ReceiverModule
{
    public class FileLogger
    {
        public bool AddCommentCountInACsvFile(Dictionary<string, int> dictionary,string filepath)
        {
            var extension = filepath.Substring(filepath.LastIndexOf('.') + 1).ToLower();
            if (extension == "csv")
            {
                var file = new StreamWriter(filepath, false);
                foreach (KeyValuePair<string,int> keyValue in dictionary)
                {
                    file.WriteLine(keyValue.Key + "," + keyValue.Value);
                }
                file.Close();
            }
            var fileChecker = new FileChecker();
            return fileChecker.CheckWhetherFileExists(filepath);
        }
    }
}