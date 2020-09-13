using System;
using System.Collections.Generic;
using System.Text;

namespace ReceiverModule
{
    public class WordCount
    {
        Dictionary<string, int> WordWithItsCount= new Dictionary<string, int>();
        public Dictionary<string, int> CountWordsInTheList(List<CommentRecord> _commentrecord)
        {
            foreach (var comment in _commentrecord)
            {
                string[] word = comment.Comment.Split(new char[] {' '});
                
                for (int i = 0; i < word.Length; i++)
                {
                       word[i]= word[i].ToLower();
                      if (WordWithItsCount.ContainsKey(word[i]))
                          WordWithItsCount[word[i]] = ++WordWithItsCount[word[i]];
                      else
                          WordWithItsCount.Add(word[i], 1); 
                    
                }
            }
            return WordWithItsCount;
        }
    }
}
