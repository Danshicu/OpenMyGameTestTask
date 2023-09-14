using System;
using System.Collections.Generic;
using System.IO;
using App.Scripts.Scenes.SceneFillwords.Features.FillwordModels;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using App.Scripts.Tools;
using UnityEngine;

namespace App.Scripts.Scenes.SceneFillwords.Features.ProviderLevel
{
    public class ProviderFillwordLevel : IProviderFillwordLevel
    {
        
        public GridFillWords LoadModel(int index)
        {
            var fillWords = TryParseLevel(index);
            if (fillWords == null)
            {
                if (index < StringReader.GetStringCount("Assets/App/Resources/Fillwords/pack_0.txt"))
                {
                    fillWords = TryParseLevel(index + 1);
                    if (fillWords == null)
                    {
                        throw new Exception($"Level {index} invalid data");
                    }
                }
            }

            return fillWords;
        }

        private GridFillWords TryParseLevel(int index)
        {
            string level = StringReader.GetStringFromFile(index-1, "Assets/App/Resources/Fillwords/pack_0.txt");
            string[] allWordsStrings = level.Split(' ');
            Dictionary<int, char> indexesWithChars = new Dictionary<int, char>();
            
            for (int wordIndex = 0; wordIndex < allWordsStrings.Length / 2; wordIndex++)
            {
                int indexInArray = wordIndex * 2;
                if (!TryParseWord(allWordsStrings[indexInArray], allWordsStrings[indexInArray + 1].Split(";"),
                        indexesWithChars))
                {
                    return null;
                }
            }

            int size = GetGridSide(indexesWithChars);
            if(size < 1 || !indexesWithChars.HasCorrectSelfIndexes())
            {
                return null;
            }

            var fillWordsGrid = new GridFillWords(new Vector2Int(size, size));
            for (int totalIndex = 0; totalIndex < indexesWithChars.Count; totalIndex++)
            {
                fillWordsGrid.Set(totalIndex/size, totalIndex%size, new CharGridModel(indexesWithChars[totalIndex]));
            }
            
            return fillWordsGrid;
        }

        private bool TryParseWord(string index, string[] charsQueue, Dictionary<int, char> charsPlaces)
        {
            string word = StringReader.GetStringFromFile(int.Parse(index), "Assets/App/Resources/Fillwords/words_list.txt");
            
            //Слово из словаря по индексу не совпадает по длине с индексами из уровня
            if (word.Length != charsQueue.Length) 
            {
                return false;
            }
            
            return charsPlaces.TryAddCharacters(ref word, charsQueue);
        }

        private int GetGridSide(Dictionary<int, char> dictionary)
        {
            int round = 1;
            while (round*round <= dictionary.Count)
            {
                if (round*round == dictionary.Count)
                {
                    return round;
                }

                round++;
            }

            return -1; //Уровень невозможно уложить в квадратную сетку
        }
        
        
    }
}