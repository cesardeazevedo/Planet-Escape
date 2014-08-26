using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance;

    public static T Instance {
        get {
            if(_instance == null) { 
                _instance = (T) FindObjectOfType(typeof(T));

                if(_instance == null) {
                        
                    GameObject singleton = new GameObject("_(Added)"+typeof(T).ToString());
                    _instance = singleton.AddComponent<T>();
                    DontDestroyOnLoad(singleton);

                } 

            }

            return _instance;

        }

        set { _instance = value; }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

}
