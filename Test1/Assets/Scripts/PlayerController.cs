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

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
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
