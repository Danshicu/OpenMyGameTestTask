using System.Collections.Generic;

namespace App.Scripts.Tools
{
    public static class DictionaryExtensions
    {
        public static bool HasCorrectSelfIndexes<T>(this Dictionary<int, T> dictionary)
        {
            foreach (var pair in dictionary)
            {
                if (pair.Key > dictionary.Count-1)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool TryAddCharacters(this Dictionary<int, char> charsPlaces,ref string word, string[] charsQueue)
        {
            for (int charIndex = 0; charIndex < charsQueue.Length; charIndex++)
            {
                int numberInGrid = int.Parse(charsQueue[charIndex]);
                if (!charsPlaces.TryAdd(numberInGrid, word[charIndex]))
                {
                    return false; //Необходимая клетка уже содержит символ
                }
            }

            return true;
        }
    }
}