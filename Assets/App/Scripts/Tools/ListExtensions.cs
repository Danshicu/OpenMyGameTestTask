using System;
using System.Collections.Generic;

namespace App.Scripts.Tools
{
    public static class ListExtensions
    {
        public static List<T> Shuffle<T>(this List<T> list)  
        {  
            Random rand = new Random();  
            int n = list.Count;  
            while (n > 1) {  
                n--;  
                int k = rand.Next(n + 1);  
                (list[k], list[n]) = (list[n], list[k]);
            }

            return list;
        }
    }
}