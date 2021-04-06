using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMovement))]


public class PlayerController : MonoBehaviour
{

    private static PlayerController instance;

    public static PlayerController Instance { get { return instance; } }
    private float x;

    public float X { get { return x; } }

    private PlayerMovement motor;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

  
    void Start()
    {
        motor = GetComponent<PlayerMovement>();
    }

    
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");

        if(x == 1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(x == -1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        float _y = Input.GetAxisRaw("Jump");

        Vector2 _velocity = new Vector2(x, _y);

        motor.RunAndJump(_velocity);
    }
}
