using System;
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
            using StreamReader reader = new StreamReader("Assets\\App\\Resources\\Fillwords\\pack_0.txt");
            int lineCounter = 0;
            while (lineCounter != index-1)
            {
                reader.ReadLine();
                lineCounter++;
            }

            string level = reader.ReadLine();
            Debug.Log(level);
            
            return new GridFillWords(new Vector2Int(3,3));
        }
    }
}