using System;
using System.Collections.Generic;
using App.Scripts.Scenes.SceneChess.Features.ChessField.GridMatrix;
using App.Scripts.Scenes.SceneChess.Features.ChessField.Types;
using UnityEngine;

namespace App.Scripts.Scenes.SceneChess.Features.GridNavigation.Navigator
{
    public class ChessGridNavigator : IChessGridNavigator
    {
        /*
         Pawn - пешка
         Bishop - слон (по диагонали)
         Knight - конь
         Rook - Ладья (по сторонам)
         Queen - королева
         King - король
         */
        public List<Vector2Int> FindPath(ChessUnitType unit, Vector2Int from, Vector2Int to, ChessGrid grid)
        {
            //напиши реализацию не меняя сигнатуру функции
            //ChessUnitType type = ChessUnitType.King;
            //type.GetPossibleMoves();
            throw new NotImplementedException();
        }
    }
}