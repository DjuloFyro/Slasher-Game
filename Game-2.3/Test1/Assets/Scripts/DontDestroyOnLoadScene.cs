using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;


    public static DontDestroyOnLoadScene instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("trop d'instance DontDestroyOnLoad samer");
            return;
        }
        instance = this;

        foreach (var element in objects)
        {
           
            DontDestroyOnLoad(element);
        }
    }



    

    public void RemoveSpecificFromDontDestroyOnLoad(GameObject objects)
    {
        SceneManager.MoveGameObjectToScene(objects, SceneManager.GetActiveScene());
    }

    public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            
           
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
        /*if (GameOverManager.instance.playerIsDead)
        {
            foreach (var en in AutoSpawn.instance.enemies)
            {

                SceneManager.MoveGameObjectToScene(en, SceneManager.GetActiveScene());
            }
        }*/

    }
}
