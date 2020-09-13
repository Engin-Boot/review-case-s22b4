using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace ReceiverModule
{
    public class WordCount
    {
        Dictionary<string, int> WordWithItsCount = new Dictionary<string, int>();
         public Dictionary<string, int> CountWordsInTheList(List<CommentRecord> _commentrecord)
            {
                foreach (var comment in _commentrecord)
                {
                    string[] word = comment.Comment.ToLower().ToString().Split(new char[] { ' ' });
                    List<string> ListOfWords = new List<string>();
                    foreach (string item in word)
                    {
                        ListOfWords.Add(item);
                    }
         List<string> ListAfterRemovingStopWords  = StopWords.RemoveStopWords(ListOfWords);

                    for (int i = 0; i < ListAfterRemovingStopWords.Count; i++)
                    {
                        if (WordWithItsCount.ContainsKey(ListAfterRemovingStopWords[i]))
                            WordWithItsCount[ListAfterRemovingStopWords[i]] = ++WordWithItsCount[ListAfterRemovingStopWords[i]];
                        else
                            WordWithItsCount.Add(ListAfterRemovingStopWords[i], 1);

                    }
                }
                return WordWithItsCount;
            }
        }
    }
