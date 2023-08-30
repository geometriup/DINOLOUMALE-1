using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empuje : MonoBehaviour
{
    Rigidbody2D rb;
    public int vel = 10;
    public SpriteRenderer spr;
    private bool jump;
    public bool grounded = false;
	public float jumpPower = 4.5f;
    public AudioSource Saltito;
    public AudioSource Muere;

    public bool muerte;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        Saltito = GetComponent<AudioSource>();
        Muere.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
		{
			jump = true;
			Debug.Log("Salte!");
		}
    }

    void FixedUpdate()
    {
        //float h = Input.GetAxis("Horizontal");
        float h = SimpleInput.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * vel * h); // Asi es movimiento libre
        //rb.AddForce(Vector2.right * vel); // Asi es un RUNNER
        if(h >0)
        {
            spr.flipX = false;
        }
        if(h <0)
        {
            spr.flipX = true;
        }

        if (jump)
		{
			/*rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);  //Codigo viejo del salto q en el boton hacia salto infinito 
            if(Saltito)
            {
                Saltito.enabled = true;
			}*/
            Jump();
            jump = false;
		}
    }

    public void Jump()
    {
        //jump = true;
		Debug.Log("Salte!");
        if (grounded)           // solucion al salto infinito del boton
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            if(Saltito)
            {
                Saltito.enabled = true;
			}
            jump = false;
        }
    }

    public void Kill()    //aca creamos el metodo de muerte del jugador
    {
        
		this.enabled = false; //al morir el pesonaje desactivamos este mismo Script para que el jugador no pueda seguirse moviendo...porque esta muerto :V
        Muere.enabled = true;
        muerte = true;
    }

    private void OnCollisionEnter2D(Collision2D other) // OJO CON COMO SE ESCRIBE COLLISION y COLLISION2D
	{
		if(other.gameObject.tag == "Tierra")
		{
			grounded = true;
			Debug.Log("Estoy tocando tierra");
            Saltito.enabled = false;
		}
	}

	private void OnCollisionExit2D(Collision2D other) // para cuando salimos del contacto con el piso!
	{
		if(other.gameObject.tag == "Tierra")
		{
			grounded = false;
			Debug.Log("Estoy en el aire!");
		}
	}

	private void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "DIE")
		{
			Kill();
			Debug.Log("Me cai al POZO");
			Debug.Log("Me pincho un Cactus");
		}
	}
}
