using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 5;
    public int numOfHearts = 5;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    


    private void Start()
    {
        
    }

    public void HealthAnim()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
    }

    public void TakeDamage(int damage)
    {

        health -= damage;
    }

    void Update()
    {
        Debug.Log("vie: " + health);
        HealthAnim();
    }

   
}
