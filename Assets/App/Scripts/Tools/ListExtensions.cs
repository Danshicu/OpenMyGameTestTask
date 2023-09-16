using System;
using System.Collections.Generic;

namespace App.Scripts.Tools
{
    public static class ListExtensions
    {
        public static List<T> Shuffle<T>(this List<T> list)  
        {  
            Random rand = new Random();  
            int round = list.Count;  
            while (round > 1) {  
                round--;  
                int temp = rand.Next(round + 1);  
                (list[temp], list[round]) = (list[round], list[temp]);
            }

            return list;
        }
        
    }
}