namespace Menchestan
{
    namespace Menu
    {
        namespace Motion
        {
            public class StopMotion : MenuMotion
            {
                protected override void Init()
                {
                }
                protected override void Revert()
                {
                }
                protected override void InitInAction()
                {
                }
                protected override void InAction()
                {
                    OnComplete?.Invoke();
                }
                protected override void OutAction()
                {
                    OnComplete?.Invoke();
                }
                protected override void InitOutAction()
                {
                }
            }
        }
    }
}