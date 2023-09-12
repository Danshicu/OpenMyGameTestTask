using System;
using System.Collections.Generic;
using System.IO;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using UnityEngine;

namespace App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel
{
    public class ProviderFillwordLevel : IProviderFillwordLevel
    {
        
        
        public GridFillWords LoadModel(int index)
        {
            string level = StringReader.GetStringFromFile(index-1, "Assets/App/Resources/Fillwords/pack_0.txt");
            string[] allWordsStrings = level.Split(' ');
            List<char> finalCharsList = new List<char>();
            for (int wordIndex = 0; wordIndex < allWordsStrings.Length / 2; wordIndex++)
            {
                int indexInArray = wordIndex * 2;
                finalCharsList.AddRange(GetWordBySymbols(int.Parse(allWordsStrings[indexInArray]), allWordsStrings[indexInArray+1].Split(";")));
            }
            
            Debug.Log(level);
            
            return new GridFillWords(new Vector2Int(3,3));
        }

        private List<char> GetWordBySymbols(int index, string[] charsQueue)
        {
            List<char> charsList = new List<char>();
            string word = StringReader.GetStringFromFile(index, "Assets/App/Resources/Fillwords/words_list.txt");
            for (int charIndex = 0; charIndex < charsQueue.Length; charIndex++)
            {
                charsList.Add(word[int.Parse(charsQueue[charIndex])]);
            }

            return charsList;
        }

        
    }
}