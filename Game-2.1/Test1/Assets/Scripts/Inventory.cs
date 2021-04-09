using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int scoreCount;
    public Text scoreCountText;

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("too much instance");
            return;
        }

        instance = this;
    }

    public void AddScore(int count)
    {
        scoreCount += count;
        scoreCountText.text = scoreCount.ToString();
    }
}
