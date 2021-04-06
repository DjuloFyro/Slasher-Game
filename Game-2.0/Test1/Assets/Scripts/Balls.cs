using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public GameObject groundCheckBall;
    private bool is_grounded;
    private Rigidbody2D rb;
    [SerializeField] private float radiusCircleBall;

    [SerializeField]
    private LayerMask layerBall;



    void Start()
    {
        is_grounded = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnGroundFreeze()
    {
        is_grounded = Physics2D.OverlapCircle(groundCheckBall.transform.position, radiusCircleBall, layerBall);

        if(is_grounded)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }

    void Update()
    {
        OnGroundFreeze();
    }
}
