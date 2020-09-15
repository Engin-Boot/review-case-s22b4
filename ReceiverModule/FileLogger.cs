using System;
using System.Collections.Generic;
using System.IO;

namespace ReceiverModule
{
    public class FileLogger
    {
        private bool CheckWhetherFileExists(string filepath)
        {
            if (File.Exists(filepath))
            {
                return true;
            }
            return false;
        }
        public bool AddCommentCountInACsvFile(Dictionary<string, int> dictionary,string filepath)
        {
            var Extension = filepath.Substring(filepath.LastIndexOf('.') + 1).ToLower();
            if (Extension == "csv")
            {
                var file = new StreamWriter(filepath, false);
                foreach (var keyValue in dictionary)
                {
                    file.WriteLine(keyValue.Key + "," + keyValue.Value);
                }
                file.Close();
            }
           return CheckWhetherFileExists(filepath);
        }
    }
}