using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class StringReader 
{
    public static string GetAllFile(string filePath)
    {
        TextAsset fileText = Resources.Load<TextAsset>(filePath);
        return fileText.text;
    }

    public static int GetStringCount(string filePath)
    {
        TextAsset fileText = Resources.Load<TextAsset>(filePath);
        var word = fileText.text.Split("\n");
        return word.Length;
    }

    public static string GetString(int stringIndex, string filePath)
    {
        TextAsset fileText = Resources.Load<TextAsset>(filePath);
        var word = fileText.text.Split("\n")[stringIndex];
        word = word.Remove(word.Length - 1);
        return word;
    }
    
}
