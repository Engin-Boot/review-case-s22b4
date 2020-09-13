using System;
using System.Collections.Generic;
using System.IO;

namespace Receiver
{
    public class WordCountToCsvAdder
    {
        public bool CheckWhetherFileExists(string filepath)
        {
            if (File.Exists(filepath))
                return true;
            return false;
        }
        public bool AddCommentCountInACsvFile(Dictionary<string, int> d, string filepath)
        {
            var Extension = filepath.Substring(filepath.LastIndexOf('.') + 1).ToLower();
            if (Extension == "csv")
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filepath, false))
                    {
                        foreach (KeyValuePair<string, int> keyValue in d)
                            file.WriteLine(keyValue.Key + "," + keyValue.Value);
                    }

                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Something is wrong", ex);
                }

            }
            // AddToDic(filepath);
            return CheckWhetherFileExists(filepath);
        }
        public Dictionary<string, int> AddToDic(string filepath)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            string line = "";
            using (StreamReader sr = new StreamReader(filepath))
            {
                while (sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    string[] splitted = line.Split(',');
                    try
                    {
                        dic.Add(splitted[0], Int32.Parse(splitted[1]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught", ex);
                    }

                }
            }
            return dic;

        }

    }
}
