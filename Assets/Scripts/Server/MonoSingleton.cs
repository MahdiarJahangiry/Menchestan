using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Menchestan
{
    namespace Server
    {
        public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
        {
            private static T _instance;

            private static object _lock = new object();

            public static T Instance
            {
                get
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = (T)FindObjectOfType(typeof(T));

                            if (FindObjectsOfType(typeof(T)).Length > 1)
                            {
                                Debug.LogError("[Singleton] Something went really wrong " +
                                    " - there should never be more than 1 singleton!" +
                                    " Reopening the scene might fix it.");
                                return _instance;
                            }

                            if (_instance == null)
                            {
                                Debug.unityLogger.Log("[Singleton] An instance of " + typeof(T) +
                                    " is needed in the scene, none was provided. Single Ton create a game object");
                                _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                            }
                            else
                            {
                                Debug.unityLogger.Log("[Singleton] Using instance already created: " +
                                    _instance.gameObject.name);
                            }
                        }

                        return _instance;
                    }
                }
            }
        }
    }
}
