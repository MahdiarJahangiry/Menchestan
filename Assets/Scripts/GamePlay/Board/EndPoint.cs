using System.Collections.Generic;
namespace Menchestan
{
    namespace GamePlay
    {
        namespace Board
        {
            public class EndPoint : WayPoint
            {
                public StartPoint startPoint;
                public EndSafePoint endSafePoint;
                public List<EndSafePoint> endSafePoints = new List<EndSafePoint>();
                public override void OnBoardInit()
                {
                    base.OnBoardInit();
                    type = PointType.EndPoint;
                }
            }
        }
    }
}