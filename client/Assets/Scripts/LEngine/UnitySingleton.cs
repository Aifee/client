using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEngine
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class SingleShow : Attribute
    {
        public bool DontDestroy { get; private set; }
        public SingleShow(bool dont)
        {
            DontDestroy = dont;
        }
    }

    public abstract class UnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T instance = default(T);
        protected static readonly object _lock = new object();

        public static T Instance {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if(instance == null || instance == default(T))
                        {
                            T[] array = FindObjectsOfType<T>();
                            if(array.Length > 1)
                            {
                                Debug.LogWarning("[Singleton] Something went really warning " + "- there should never be more than 1 singleton!" + "Reopening the scene might fix it.");
                                return instance;
                            }
                            if(array.Length != 1)
                            {
                                GameObject singleton = new GameObject();
                                instance = singleton.AddComponent<T>();
                                singleton.name = "(singleton) " + typeof(T).ToString();
                                SingleShow classAtt = (SingleShow)Attribute.GetCustomAttribute(typeof(T), typeof(SingleShow));
                                if(classAtt == null)
                                {
                                    singleton.hideFlags = HideFlags.HideAndDontSave;
                                }
                                else
                                {
                                    if (classAtt.DontDestroy)
                                    {
                                        DontDestroyOnLoad(singleton);
                                    }
                                }
                            }
                            else
                            {
                                instance = array[0];
                            }
                        }
                    }
                }
                return instance;
            }
        }

    }
}