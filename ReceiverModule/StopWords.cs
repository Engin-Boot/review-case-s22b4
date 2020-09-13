using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiverModule
{
    class StopWords
    {
        public static bool IsStopWord(string word)
        {
            List<string> StopWords = new List<string> { "a", "able", "about", "across", "after", "all", "almost", "also", "am", "among", "an", "and", "any", "are","as", "at", "be", "because", "been", "but", "by", "can", "cannot", "could", "dear", "did","do","does","either","else","ever","every","for", "from", "get", "got", "had", "has", "have", "he", "her", "hers",
                "him", "his", "how", "however", "i","if","in","into","is","it","its","just","least"
                ,"let","like","likely","may","me","might","most","must","my","neither","no","nor","not"
                ,"of","off","often","on","only","or","other","our","own","rather","said","say","says","she","should",
                "since","so","some","than","that","the","their","them","then","there","these","they","this","to","too",
                "was","us","wants","we","were","what","when","where","which","who","whom","why","will","with","would","yet","you","your" };
            for (int i = 0; i < StopWords.Count; i++)
            {
                if (word == StopWords[i])
                    return true;
            }
            return false;
        }
        public static List<string> RemoveStopWords(List<string> words)
        {
            words.RemoveAll(IsStopWord);
            return words;
        }
    }
}
