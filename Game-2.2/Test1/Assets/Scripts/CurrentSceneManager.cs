using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{

    public bool isPlayerPresentByDefault = false;


    public static CurrentSceneManager instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("trop d'instance CurrentSceneManager samer");
            return;
        }
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
