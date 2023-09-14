using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class StringReader 
{
    public static string GetStringFromFile(int stringIndex, string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);
        while (stringIndex != 0)
        {
            reader.ReadLine();
            stringIndex--;
        }

        return reader.ReadLine();
    }

    public static string GetAllFile(string filePath)
    {
        using StreamReader reader = new StreamReader(filePath);
        return reader.ReadToEnd();
    }

    public static int GetStringCount(string filePath)
    {
        int lineCounter = 0;
        using StreamReader reader = new StreamReader(filePath);
        while(reader.ReadLine() != null)
        {
            lineCounter++;
        }
        return lineCounter;
    }
   
}
