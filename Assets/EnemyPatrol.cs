using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    
    Rigidbody2D rb;
    public Transform pos;
    public bool mustTurn;
    
    public float walkspeed;

    public bool mustPatrol;

    public LayerMask ground;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
        //pos.transform = new Vector3(5, 0, 0);


    }

    void FixedUpdate ()
    {
        if(mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(pos.position, 0.1f, ground);
            
        }
    }

    void Patrol ()
    {
        if(mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkspeed * Time.fixedDeltaTime, rb.velocity.x );

    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkspeed *= -1;
        mustPatrol = true;
    }
}
