using System;
using System.Collections.Generic;
using System.IO;

namespace ReceiverModule
{
    public class FileLogger
    {
        /*private bool CheckWhetherFileExists(string filepath)
        {
            if (File.Exists(filepath))
            {
                return true;
            }
            return false;
        }*/
        public void AddCommentCountInACsvFile(Dictionary<string, int> dictionary)
        {
            var file = new StreamWriter("output.csv");
            foreach (var keyValue in dictionary)
            {
                file.WriteLine(keyValue.Key + "," + keyValue.Value);
            }
            file.Close();
        }
    }
}