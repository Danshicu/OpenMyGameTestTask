using System;
using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class ChessGridNavigator : IChessGridNavigator
    {
        public List<Vector2Int> FindPath(ChessUnitType unit, Vector2Int from, Vector2Int to, ChessGrid grid)
        {
            Queue<PathNode> nodesQueue = new Queue<PathNode>();
            List<PathNode> visitedNodes = new List<PathNode>();
            Vector2Int gridSize = grid.Size;
            
            List<List<PathNode>> nodes = CreateNodesList(gridSize);

            PathNode startNode = nodes[from.x][from.y];
            PathNode endNode = nodes[to.x][to.y];
            PathNode currentNode;
            
            nodesQueue.Enqueue(startNode);
            visitedNodes.Add(startNode);

            while (nodesQueue.Count > 0)
            {
                currentNode = nodesQueue.Dequeue();
                if (currentNode == endNode)
                {
                    return GetPath(startNode, currentNode);
                }

                List<PathNode> neighbourNodes = new List<PathNode>();
                AddNeighboursNodes(currentNode, ref neighbourNodes, unit, ref grid, ref nodes, ref visitedNodes);
                foreach (var neigbhour in neighbourNodes)
                {
                    if (visitedNodes.Contains(neigbhour))
                    {
                        continue;
                    }
                    visitedNodes.Add(neigbhour);
                    neigbhour.ParentNode = currentNode;
                    nodesQueue.Enqueue(neigbhour);
                }
                
            }

            return null;
        }

        private List<List<PathNode>> CreateNodesList(Vector2Int size)
        {
            List<List<PathNode>> nodes = new List<List<PathNode>>();
            for (int firstIndex = 0; firstIndex < size.y; firstIndex++)
            {
                nodes.Add(new List<PathNode>());
                for (int secondIndex = 0; secondIndex < size.x; secondIndex++)
                {
                    nodes[firstIndex].Add(new PathNode(firstIndex, secondIndex));
                }
            }

            return nodes;
        }

        private List<Vector2Int> GetPath(PathNode startNode, PathNode endNode)
        {
            PathNode currentNode = endNode;
            List<Vector2Int> path = new List<Vector2Int>();
            path.Add(currentNode.Position);

            while (currentNode.ParentNode != startNode)
            {
                currentNode = currentNode.ParentNode;
                path.Add(currentNode.Position);
            }
            
            path.Reverse();

            return path;
        }

        private static bool CanMove(ref ChessGrid grid, Vector2Int position)
        {
            Vector2Int gridSize = grid.Size;
            return position.x < gridSize.x && position.x >= 0 && position.y < gridSize.y && position.y >= 0 &&
                   grid.Get(position.y, position.x) == null;
        }

        private void AddNeighboursNodes(PathNode currentNode, ref List<PathNode> neighbors, ChessUnitType unit, ref ChessGrid grid, ref List<List<PathNode>> nodes, ref List<PathNode> visitedNodes)
        {
            var moves = unit.GetPossibleMoves();
            int maxDistance = 1;
            if (moves.Item2)
            {
                if (grid.Size.x > grid.Size.y)
                {
                    maxDistance = grid.Size.x;
                }
                else
                {
                    maxDistance = grid.Size.y;
                }
            }
            
            foreach (var direction in moves.Item1)
            {
                for (int moveRound = 1; moveRound <= maxDistance; moveRound++)
                {
                    Vector2Int newPosition = currentNode.Position + (direction * moveRound);
                    if (CanMove(ref grid, newPosition) &&
                        !visitedNodes.Contains(nodes[newPosition.x][newPosition.y]))
                    {
                        neighbors.Add(nodes[newPosition.x][newPosition.y]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            
            
        }
    }
}