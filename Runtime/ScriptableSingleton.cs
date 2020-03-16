using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace BSS.Singleton {
    /// <summary>
    /// Scriptable Object Singleton
    /// </summary>
    public class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject {
        private static T _instance;
        public static T instance {
            get {
                if (_instance == null) {
                    _instance = Resources.Load(typeof(T).Name) as T;
                    if(_instance==null) {
                        _instance = Resources.LoadAll<T>("").FirstOrDefault();
                    }
                } 
                return _instance;
            }
        }
    }
}