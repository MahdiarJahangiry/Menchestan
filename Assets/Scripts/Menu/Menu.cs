using Menchestan.Menu.Motion;
using UnityEngine;

namespace Menchestan
{
    namespace Menu
    {
        public abstract class Menu<T> : Menu where T : Menu<T>
        {
            private static T instance;
            public static T Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = MenuManager.Instance.GetComponentInChildren<T>(true);
                        if (instance != null)
                        {
                            if (MenuManager.Instance.mainCamera != null)
                            {
                                instance.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
                                instance.GetComponent<Canvas>().worldCamera = MenuManager.Instance.mainCamera;
                            }
                            instance.Init();
                        }
                    }
                    return instance;
                }
            }
            protected virtual void Awake()
            {
                instance = (T)this;
            }

            protected virtual void OnDestroy()
            {
                instance = null;
            }

            protected static bool Open()
            {
                if (Instance == null)
                {
                    MenuManager.Instance.CreateInstance<T>();
                    if (MenuManager.Instance.mainCamera != null)
                    {
                        Instance.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceCamera;
                        Instance.GetComponent<Canvas>().worldCamera = MenuManager.Instance.mainCamera;
                    }
                    Instance.Init();
                    return false;
                }
                bool isPushed = MenuManager.Instance.OpenMenu(Instance);
                if (isPushed)
                {
                    Instance.gameObject.SetActive(true);
                    Instance.motion?.RunAction(null);
                }
                return true;
            }

            protected static void Close(bool force)
            {
                if (Instance == null)
                {
                    Debug.LogErrorFormat("Trying to close menu {0} but Instance is null", typeof(T));
                    return;
                }

                MenuManager.Instance.CloseMenu(Instance, force);
            }

            public override void OnBackPressed()
            {
                Close(false);
            }
        }

        public abstract class Menu : MonoBehaviour
        {
            [Tooltip("Destroy the Game Object when menu is closed (reduces memory usage)")]
            public bool DestroyWhenClosed = true;

            [Tooltip("Disable menus that are under this one in the stack")]
            public bool DisableMenusUnderneath = true;
            public MenuMotion motion;

            public bool isMain = false;
            public abstract void OnBackPressed();
            public abstract void Init();
        }
    }
}