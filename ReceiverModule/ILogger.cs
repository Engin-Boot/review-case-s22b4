
using System.Collections.Generic;
using System.IO;
using System;

namespace ReceiverModule
{
    public interface ILogger
    {
        public bool LogAnalysis(Dictionary<string, int> dictionary, string filepath);
    }
    public class FileLogger : ILogger
    {
        public bool LogAnalysis(Dictionary<string, int> dictionary,string filepath)
        {
            var extension = filepath.Substring(filepath.LastIndexOf('.') + 1).ToLower();
            if (extension == "csv")
            {
                var file = new StreamWriter(filepath, false);
                foreach (KeyValuePair<string,int> keyValue in dictionary)
                {
                    file.WriteLine(keyValue.Key + "," + keyValue.Value);
                    Console.WriteLine(keyValue.Key + " " + keyValue.Value);
                }
                file.Close();
            }
            return ValidateFilePath(filepath);
        }

        private bool ValidateFilePath(string filepath)
        {
            if (File.Exists(filepath))
            {
                return true;
            }
            return false;
        }
    }
}