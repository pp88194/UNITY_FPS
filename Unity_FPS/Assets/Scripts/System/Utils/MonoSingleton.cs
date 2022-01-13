using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject container = new GameObject("SingletonObject");
                instance = container.AddComponent<T>();
            }
            return instance;
        }
    }
    static T instance;
}