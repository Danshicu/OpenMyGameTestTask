using System;
using System.Collections.Generic;
using App.Scripts.Libs.Factory;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using App.Scripts.Tools;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel
{
    public class FactoryLevelModel : IFactory<LevelModel, LevelInfo, int>
    {
        public LevelModel Create(LevelInfo value, int levelNumber)
        {
            var model = new LevelModel();

            model.LevelNumber = levelNumber;

            model.Words = value.words;
            model.InputChars = BuildListChars(value.words);

            return model;
        }

        private List<char> BuildListChars(List<string> words)
        {
            Dictionary<char, int> maxCharCount = new Dictionary<char, int>();
            foreach (string word in words)
            {
                Dictionary<char, int> currentCharCount = GetWordDictionary(word);
                foreach (var incomePair in currentCharCount)
                {
                   char currentChar = incomePair.Key;
                   int currentInt = incomePair.Value;
                   if (maxCharCount.ContainsKey(currentChar))
                   {
                       if (maxCharCount[currentChar] < currentInt)
                       {
                           maxCharCount[currentChar] = currentInt;
                       }
                   }
                   else
                   {
                       maxCharCount.Add(currentChar, currentInt);
                   }
                }
            }

            return CharListFromDictionary(maxCharCount).Shuffle();
        }

        private Dictionary<char, int> GetWordDictionary(string word)
        {
            Dictionary<char, int> targetDictionary = new Dictionary<char, int>();
            for (int index = 0; index < word.Length; index++)
            {
                char currentChar = word[index];
                if (targetDictionary.ContainsKey(currentChar))
                {
                    targetDictionary[currentChar]++;
                }
                else
                {
                    targetDictionary.Add(currentChar, 1);
                }
            }

            return targetDictionary;
        }

        private List<char> CharListFromDictionary(Dictionary<char, int> charDictionary)
        {
            List<char> targetList = new List<char>();
            foreach (var pair in charDictionary)
            {
                for (int index = 0; index < pair.Value; index++)
                {
                    targetList.Add(pair.Key);
                }
            }

            return targetList;
        }
        
    }
}