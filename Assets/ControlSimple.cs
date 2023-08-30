using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// LIBRERIAS

public class ControlSimple : MonoBehaviour { 

	public float maximaVelocidad = 5.5f;
	public float speed = 2f;
	public bool grounded = false;
	public float jumpPower = 4.5f;

	private Rigidbody2D rb2d;
	private Animator anim;
	private bool jump;
	public static ControlSimple sharedInstance; //Definimos al Script como Singleton
	
	 
	// Use this for initialization
	
	private void Awake()
    {
        sharedInstance = this; //activamos el singleton
    }

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		//anim = GetComponent<Animator>();
		//anim.SetBool("isAlive", true);
		//grounded = false;
        //anim.SetBool("Grounded", true); esto sirve para que el personaje este tocando el suelo y la aninmacion de Iddle se active
	}
	
	// Update is called once per frame
	void Update () 
	{
		//anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
		//anim.SetBool("Grounded", grounded); //tener en cuenta la variable publica creada al comienzo, esto activa la variable y la animación
		
		if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
		{
			jump = true;
			Debug.Log("Salte!");
		}
	}

	void FixedUpdate()
	{

		float h = Input.GetAxis("Horizontal");

		rb2d.AddForce(Vector2.right * speed * h);

		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maximaVelocidad, maximaVelocidad);
		//rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y); // este codigo es el original de movimiento libre
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
		//Debug.Log(rb2d.velocity.x); Muestra la velocidad en consola
	}

	public void Kill()    //aca creamos el metodo de muerte del jugador
    {
        //GameManager.sharedInstance.GameOver();
        //this.anim.SetBool("isAlive", false);
		//gameObject.SetActive(false); //Este comando desactiva al Objeto directamente
		this.enabled = false; //al morir el pesonaje desactivamos este mismo Script para que el jugador no pueda seguirse moviendo...porque esta muerto :V
        //float currentMaxScore = PlayerPrefs.GetFloat("Puntuación Maxima", 0); //inicializamos en 0 el maxscore
        /* if(currentMaxScore < this.GetDistance())
        {
            PlayerPrefs.SetFloat("Puntuación Maxima", this.GetDistance()); //asignamos el nuevo record
        }
		*/
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
		if(collider.gameObject.tag == "DIE")
		{
			Kill();
			Debug.Log("Me cai al POZO");
			Debug.Log("Me pincho un Cactus");
		}
	}

}
