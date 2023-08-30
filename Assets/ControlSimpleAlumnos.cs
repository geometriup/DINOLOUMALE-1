using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSimpleAlumnos : MonoBehaviour
{
    public float maxSpeed = 5f;
	public float speed = 2f;
	public bool grounded = false;
	public float jumpPower = 4.5f;

	private Rigidbody2D rb2d;
	private Animator anim;
	private bool jump;
	public static ControlSimpleAlumnos sharedInstance; //Definimos al Script como Singleton
	
	 
	// Use this for initialization
	
	private void Awake()
    {
        sharedInstance = this; //activamos el singleton
    }

	void Start () 
    {
		rb2d = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

	void FixedUpdate(){

		float h = Input.GetAxis("Horizontal");

		rb2d.AddForce(Vector2.right * speed * h);

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);

		rb2d.velocity = new Vector3(speed, rb2d.velocity.y,limitedSpeed); // con este codigo es un Runner

		if (h > 0.1f) {
			transform.localScale = new Vector3(4f, 4f, 4f); //Aca la escala depende de como configuramos el modelo
		} 

		if (h < -0.1f){
			transform.localScale = new Vector3(-4f, 4f, 4f); // idem arriba
		}

		if (jump)
		{
			rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
			jump = false;
		}
		
	}

	public void Kill()    //aca creamos el metodo de muerte del jugador
    {
        
    }

	private void OnCollisionEnter2D(Collision2D other) // OJO CON COMO SE ESCRIBE COLLISION y COLLISION2D
	{
		if(other.gameObject.tag == "Tierra")
		{
			grounded = true;
			Debug.Log("Estoy tocando tierra");
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
		
	}

}
