using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class PathNode
    {
        public Vector2Int Position { get; }
        public PathNode ParentNode;

        public PathNode(int posX, int posY)
        {
            Position = new Vector2Int(posX, posY);
        }

    }
}