namespace Menchestan
{
    namespace GamePlay
    {
        namespace Board
        {
            public class SafePoint : WayPoint
            {
                public StartPoint startPoint;

                public override void OnBoardInit()
                {
                    type = PointType.SafePoint;
                    startPoint?.Register(this);
                }
            }
        }
    }
}