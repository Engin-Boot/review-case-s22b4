﻿using System.Collections.Generic;



namespace ReceiverModule
{
    public class WordFrequencyGenerator
    {
         readonly Dictionary<string, int> _frequencyList = new Dictionary<string, int>();
         public Dictionary<string, int> CountWordsInTheList(List<CommentRecord> commentRecord)
            {
                foreach (var comment in commentRecord)
                {
                    var word = comment.Comment.ToLower().Split(' ' );
                    var wordList = new List<string>();
                    foreach (var item in word)
                    {
                        wordList.Add(item);
                    }
                    var processedList  = StopWords.RemoveStopWords(wordList);

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