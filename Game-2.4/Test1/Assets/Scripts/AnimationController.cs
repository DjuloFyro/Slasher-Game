using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public enum StateAnim
{
    Idle,
    Run,
    Jump
}

public class AnimationController : MonoBehaviour
{

    public Animator anim;
    private PlayerController player;
    private PlayerMovement playerMovement;
    private StateAnim state;

    public static AnimationController instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("trop d'instance animation samer");
            return;
        }
        instance = this;
    }


    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        playerMovement = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        bool run = player.X == 1 || player.X == -1;

        if (run && playerMovement.Grounded)
        {
            state = StateAnim.Run;
        }
        else if (!run && playerMovement.Grounded)
        {
            state = StateAnim.Idle;
        }
        else if (!playerMovement.Grounded)
        {
            state = StateAnim.Jump;

        }

        Animation();
        
        
    }
    

    private void Animation()
    {
        switch(state)
        {
            case StateAnim.Idle:
                anim.SetBool("Idle", true);
                anim.SetBool("Run", false);
                anim.SetBool("Ground", true);
                break;

            case StateAnim.Run:
                anim.SetBool("Run", true);
                anim.SetBool("Idle", false);
                anim.SetBool("Ground", true);
                break;
            case StateAnim.Jump:
                anim.SetBool("Ground", false);
                anim.SetBool("Run", false);
                anim.SetBool("Idle", false);
                break;
        }
        

    }
}
