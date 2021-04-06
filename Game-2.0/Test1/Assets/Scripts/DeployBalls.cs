using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployBalls : MonoBehaviour
{

    public GameObject ballsPrefab;
    public float respawnTime = 5.0f;
    private Vector2 screenBounds;
   
    
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(depBalls());
       
    }

    private void spawnBalls()
    {

        GameObject ball = Instantiate(ballsPrefab) as GameObject;
        ball.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y -3);
        
    }
    
    
    IEnumerator depBalls()
    {
        while(true)
        {
            
            yield return new WaitForSeconds(respawnTime);
            spawnBalls();
        }
    }
}
