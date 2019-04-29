using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour
{
    public static Singleton<T> Instance { get; protected set; }
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
