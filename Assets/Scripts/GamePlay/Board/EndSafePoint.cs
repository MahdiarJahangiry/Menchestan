namespace Menchestan
{
    namespace GamePlay
    {
        namespace Board
        {
            public class EndSafePoint : SafePoint
            {
                public override void OnBoardInit()
                {
                    type = PointType.EndSafePoint;
                    startPoint?.Register(this);
                }
            }
        }
    }
}
