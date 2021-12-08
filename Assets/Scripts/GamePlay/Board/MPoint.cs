using Menchestan.GamePlay.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Menchestan
{
    namespace GamePlay
    {
        namespace Board
        {
            public abstract class MPoint : MonoBehaviour
            {
                public PointType type;
                public Piece piece;
                public WayPoint nextPoint;
                public Image holeCol;
                public abstract void OnBoardInit();
                public void Init()
                {
                    if (holeCol == null)
                        holeCol = GetComponent<Image>();
                    OnBoardInit();
                }
                public abstract int Distance(WayPoint point, StartPoint onStartPoint);
                public int StepNum(WayPoint point, StartPoint onStartPoint)
                {
                    return (Distance(point, onStartPoint) / 6) + 1;
                }
            }
        }
    }
}