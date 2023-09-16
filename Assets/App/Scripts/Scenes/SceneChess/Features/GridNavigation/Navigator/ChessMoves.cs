using System;
using System.Collections.Generic;
using System.Numerics;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public static class ChessMoves
    {
        private static (List<Vector2Int>, bool) _pawnMoves = (new List<Vector2Int>{Vector2Int.up, Vector2Int.down}, false);
        private static (List<Vector2Int>, bool) _bishopMoves = (new List<Vector2Int>{Vector2Int.one, new Vector2Int(1, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 1)}, true);
        private static (List<Vector2Int>, bool) _knightMoves = (new List<Vector2Int>{new Vector2Int(1,2), new Vector2Int(2,1), new Vector2Int(2,-1), new Vector2Int(1, -2), new Vector2Int(-1, -2), new Vector2Int(-2, -1), new Vector2Int(-2,1), new Vector2Int(-1, 2)}, false);
        private static (List<Vector2Int>, bool) _rookMoves = (new List<Vector2Int>{Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left}, true);
        private static (List<Vector2Int>, bool) _queenMoves = (new List<Vector2Int>{Vector2Int.up, Vector2Int.one, Vector2Int.right, new Vector2Int(1, -1), Vector2Int.down, new Vector2Int(-1, -1), Vector2Int.left, new Vector2Int(-1, 1)}, true);
        private static (List<Vector2Int>, bool) _kingMoves = (new List<Vector2Int>{Vector2Int.up, Vector2Int.one, Vector2Int.right, new Vector2Int(1, -1), Vector2Int.down, new Vector2Int(-1, -1), Vector2Int.left, new Vector2Int(-1, 1)}, false);

        public static (List<Vector2Int>, bool) GetPossibleMoves(this ChessUnitType type)
        {
            return type switch
            {
                ChessUnitType.Pawn => _pawnMoves,
                ChessUnitType.Bishop => _bishopMoves,
                ChessUnitType.Knight => _knightMoves,
                ChessUnitType.Rook => _rookMoves,
                ChessUnitType.Queen => _queenMoves,
                ChessUnitType.King => _kingMoves,
                _ => throw new Exception("Invalid chess type")
            };
        }
    }
}