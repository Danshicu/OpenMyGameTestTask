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
            var jsonString = StringReader.GetAllFile(Path.Combine("WordSearch", "Levels", $"{levelIndex}"));
            var words = JsonUtility.FromJson<LevelInfo>(jsonString);
            return words;
        }
        
    }
}