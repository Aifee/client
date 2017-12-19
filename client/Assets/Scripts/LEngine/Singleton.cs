using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LEngine
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        protected static readonly object syncObj = new object();
        private static T instance = null;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncObj)
                    {
                        if (instance == null)
                        {
                            instance = new T();
                        }
                    }
                }
                return instance;
            }
        }
    }
}