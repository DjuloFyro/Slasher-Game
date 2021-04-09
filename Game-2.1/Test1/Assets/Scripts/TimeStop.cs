using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStop : MonoBehaviour
{
    private float speed;
    private bool RestoreTime;

    public ParticleSystem particules;


    void Start()
    {
        RestoreTime = false;
      
        
        
    }

    void Update()
    {
        if(RestoreTime)
        {
            if(Time.timeScale < 1f)
            {
                Time.timeScale += Time.deltaTime * speed;
            }
            else
            {
                Time.timeScale = 1f;
                RestoreTime = false;
            }
        }
    }

  
    public void StopTime(float ChangeTime, int RestoreSpeed, float Delay)
    {
        particules.Play();
        speed = RestoreSpeed;
      
        if (Delay > 0)
        {
            StopCoroutine(StartTimeAgain(Delay));
            StartCoroutine(StartTimeAgain(Delay));
        }
        else
        {
            RestoreTime = true;
        }

        Time.timeScale = ChangeTime;
    }

    IEnumerator StartTimeAgain(float amt)
    {
       
        RestoreTime = true;
        //particules.Stop();
        yield return new WaitForSecondsRealtime(amt);
        
    }
}
