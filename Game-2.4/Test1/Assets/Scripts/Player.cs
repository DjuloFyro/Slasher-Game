using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;






public class Player : PlayerStats
{

    public event Action MonEvent;

    public bool PlayerIsDead { get { return PV <= 0f; } }
    
    void Start()
    {
        if(MonEvent != null &&  PlayerIsDead)
        {
            MonEvent();
        }
    }

   
    void Update()
    {
        
    }

   

    
   
}
