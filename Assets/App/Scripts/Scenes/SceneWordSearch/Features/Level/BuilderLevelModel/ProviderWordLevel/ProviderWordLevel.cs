using System;
using System.Collections.Generic;
using System.IO;
using App.Scripts.Scenes.SceneWordSearch.Features.Level.Models.Level;
using UnityEngine;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.BuilderLevelModel.ProviderWordLevel
{
    public class ProviderWordLevel : IProviderWordLevel
    {
        public LevelInfo LoadLevelData(int levelIndex)
        {
            using StreamReader reader = new StreamReader($"Assets/App/Resources/WordSearch/Levels/{levelIndex}.json");
            var json = reader.ReadToEnd();
            var words = JsonUtility.FromJson<LevelInfo>(json);
            return words;
        }
    }
}