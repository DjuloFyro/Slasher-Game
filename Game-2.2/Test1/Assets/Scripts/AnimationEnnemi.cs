using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public enum StateAnimEnnemi
{
    Idle,
    Run
}


public class AnimationEnnemi : MonoBehaviour
{

    private Animator anim;
    private Ennemi ennemi;
    private StateAnimEnnemi state;



    void Start()
    {
        anim = GetComponent<Animator>();
        ennemi = GetComponent<Ennemi>();

    }


    void Update()
    {
        bool run = ennemi.Running;

       
        if (run && ennemi.Grounded)
        {
            
            state = StateAnimEnnemi.Run;
        }
        else if (!run && ennemi.Grounded)
        {
            
            state = StateAnimEnnemi.Idle;
        }

        /* else if (!ennemi.Grounded)
         {
             state = StateAnim.Jump;

         }*/


       

        Animation();
        

    }


    private void Animation()
    {
        switch (state)
        {
            case StateAnimEnnemi.Idle:
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
                break;

            case StateAnimEnnemi.Run:
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
                break;

        }
    }
}
