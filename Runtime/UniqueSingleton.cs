using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace BSS.Singleton {
    /// <summary>
    /// Don't destory when scene changed. 
    /// If not exists, it is created.
    /// </summary>
    public class UniqueSingleton<T> : MonoBehaviour where T : MonoBehaviour {
        private static T _instance;
        public static T instance {
            get {
                if (_instance == null) {
                    var instances = FindObjectsOfType<T>();
                    if (instances.Length>1) {
                        throw new Exception($"[{typeof(T).Name}] is Not Single");
                    } else if (instances.Length ==0) {
                        var obj = new GameObject(typeof(T).Name);
                        _instance = obj.AddComponent<T>();
                    } else {
                        _instance = instances[0];
                    }
                }
                return _instance;
            }
        }

        protected virtual void Awake() {
            if (instance != this) {
                Destroy(this);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}
