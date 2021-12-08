namespace Menchestan
{
    namespace GamePlay
    {
        namespace Board
        {
            public class WayPoint : MPoint
            {
                public override void OnBoardInit()
                {
                    type = PointType.WayPoint;
                }
                public override int Distance(WayPoint point, StartPoint onStartPoint)
                {
                    int distance = 0;

                    WayPoint tmpPoint = this;
                    while (tmpPoint != null)
                    {
                        if (tmpPoint == point)
                            return distance;
                        tmpPoint = tmpPoint.GetNextWayPoint(onStartPoint);
                        distance++;
                    }
                    return 1000000;
                }

                public WayPoint GetNextWayPoint(StartPoint onStartPoint)
                {
                    if (type == PointType.EndPoint)
                    {
                        EndPoint endPoint = (EndPoint)this;
                        if (endPoint.startPoint == onStartPoint)
                        {
                            return endPoint.endSafePoint;
                        }
                        else
                        {
                            return nextPoint;
                        }
                    }
                    else
                    {
                        return nextPoint;
                    }
                }
                public WayPoint GetNthPoint(StartPoint onStartPoint, int step)
                {
                    WayPoint point = this;
                    while (step != 0 && point!=null)
                    {
                        point = point.GetNextWayPoint(onStartPoint);
                        step--;
                    }
                    return point;
                }
            }
        }
    }
}