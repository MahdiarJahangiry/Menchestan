using Menchestan.Menu.Motion;
using UnityEngine;
/// <summary>
/// A base menu class that implements parameterless Show and Hide methods
/// </summary>
/// 
namespace Menchestan
{
    namespace Menu
    {
        public abstract class SimpleMenu<T> : Menu<T> where T : SimpleMenu<T>
        {
            public override void Init()
            {
                motion = GetComponent<MenuMotion>();
            }
            public static void Show()
            {
                if (!Open())
                    Show();
            }

            public static void Hide()
            {
                Close(false);
            }
            public static void ForceHide()
            {
                Close(true);
            }
        }
    }
}