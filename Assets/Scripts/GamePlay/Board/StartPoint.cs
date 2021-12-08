using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Menchestan
{
    namespace GamePlay
    {
        namespace Board
        {
            public class StartPoint : WayPoint
            {
                public Image icon;
                public Image iconBack;
                public Image ring;
                public RTLTMPro.RTLTextMeshPro playerName;
                public List<Toggle> gemLife;
                public EndPoint endPoint;
                public List<PiecePoint> piecePoints = new List<PiecePoint>();
                public Color piecePointColor;
                public Color endSafePointColor;
                public Color startPointColor;
                public Color timeBarColor;
                public BoardColor.ColorPalette colorPalette;
                public void Register<T>(T safePoint)
                {
                    if (typeof(T) == typeof(EndSafePoint))
                    {
                        EndSafePoint tmp = (EndSafePoint)(object)safePoint;
                        endPoint?.endSafePoints.Add(tmp);
                        tmp.holeCol.color = endSafePointColor;
                    }
                    else if (typeof(T) == typeof(PiecePoint))
                    {
                        PiecePoint tmp = (PiecePoint)(object)safePoint;
                        piecePoints.Add((PiecePoint)(object)safePoint);
                        tmp.holeCol.color = piecePointColor;
                    }
                }
                public override void OnBoardInit()
                {
                    type = PointType.StartPoint;
                    endPoint.startPoint = this;
                }
            }
        }
    }
}