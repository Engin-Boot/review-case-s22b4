using System.Collections.Generic;



namespace ReceiverModule
{
    public class WordFrequencyGenerator
    {
        readonly Dictionary<string, int> _frequencyList = new Dictionary<string, int>();
        public Dictionary<string, int> GenerateFrequencyList(List<CommentRecord> commentRecord)
        {
            foreach (var comment in commentRecord)
            {
                var words = comment.Comment.ToString().ToLower().Split(' ');
                var wordList = new List<string>();
                foreach (var item in words)
                {
                    wordList.Add(item.TrimEnd('.'));
                }
                var remover = new StopWords();
                var processedList = remover.RemoveStopWords(wordList);

                foreach (var processedWord in processedList)
                {
                    if (_frequencyList.ContainsKey(processedWord))
                    {
                        _frequencyList[processedWord] = ++_frequencyList[processedWord];
                    }
                    else
                    {
                        _frequencyList.Add(processedWord, 1);
                    }
                }
            }
          
            return _frequencyList;
        }
    }
}