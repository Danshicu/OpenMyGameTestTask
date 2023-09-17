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
                if (index < StringReader.GetStringCount(Path.Combine("Fillwords", "pack_0")))
                {
                    fillWords = TryParseLevel(index + 1);
                    if (fillWords == null)
                    {
                        throw new Exception($"Levels {index}, {index+1} invalid data");
                    }
                }
            }

            return fillWords;
        }

        private GridFillWords TryParseLevel(int index)
        {
            string level = StringReader.GetString(index-1, Path.Combine("Fillwords", "pack_0"));
            
            string[] allWordsStrings = level.Split(' ');
            Dictionary<int, char> indexesWithChars = new Dictionary<int, char>();
            
            for (int wordIndex = 0; wordIndex < allWordsStrings.Length; wordIndex+=2)
            {
                if (!TryParseWord(allWordsStrings[wordIndex], allWordsStrings[wordIndex+1].Split(";"),
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
            string word = StringReader.GetString(int.Parse(index), Path.Combine("Fillwords", "words_list"));
            
            //Indexes doesn't match
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

            return -1; //Level can't be loaded as squate table
        }
        
        
    }
}