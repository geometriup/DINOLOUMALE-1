using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    float movimientoH;
    public Rigidbody2D rb;
    public float velocidad;
    public float velocidadSalto;
    public float horizontal;
    public float vertical; 
    bool enelaire = false;
    
	public GameObject disparo; 
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {                                                
        Movimiento1();
    }


    void Movimiento1 ()
    {
        movimientoH = Input.GetAxisRaw("Horizontal");
       rb.velocity = new Vector2(movimientoH * velocidad, rb.velocity.y);
        
       if (Input.GetKeyDown(KeyCode.W) && enelaire == false)
        {
            rb.AddForce(Vector2.up * velocidadSalto, ForceMode2D.Impulse);
            enelaire = true;
        }
        
    }

    void Movimiento2 ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * velocidad, ForceMode2D.Impulse);
            
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * velocidad, ForceMode2D.Impulse);
        }
        
        if (Input.GetKeyDown(KeyCode.W) && enelaire == false)
        {
            rb.AddForce(Vector2.up * velocidad, ForceMode2D.Impulse);
            enelaire = true;
        }
  
    }



    void Movimiento3 ()
    {
        horizontal = SimpleInput.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * velocidad * horizontal);

         if (Input.GetButton ("Jump") && enelaire == false)
        {
            rb.AddForce(Vector2.up * velocidad);
   
            enelaire = true;    

        }
 
    }
    
   private void OnCollisionEnter2D(Collision2D other)
{
    
    if (other.gameObject.CompareTag("Suelo"))
    {
        
        enelaire = false;
        
        rb.velocity = new Vector2(rb.velocity.x, 0);
    }
}
 
}
