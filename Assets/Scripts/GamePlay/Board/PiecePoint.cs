namespace Menchestan
{
    namespace GamePlay
    {
        namespace Board
        {
            public class PiecePoint : SafePoint
            {
                public override void OnBoardInit()
                {
                    type = PointType.PiecePoint;
                    startPoint?.Register(this);
                }
                public override int Distance(WayPoint point, StartPoint onStartPoint)
                {
                    return base.Distance(point, onStartPoint) + 6;
                }
            }
        }
    }
}