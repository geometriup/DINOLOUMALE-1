using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creamos un tipo enumerado para definir la dirección
public enum Direccion { Horizontal, Vertical }

public class Proyectil : MonoBehaviour
{
    //Variables públicas
   public Direccion DireccionArma = Direccion.Horizontal;
   public float Velocidad = 50.0F;
 
   //Variables privadas
   private Rigidbody2D thisRigidbody;
 
   void Start ()
   {
      thisRigidbody = GetComponent<Rigidbody2D>();
   }
 
   void Update ()
   {
      //Establecemos su velocidad y su dirección
      if (DireccionArma == Direccion.Horizontal)
      {
         //Movemos el arma en horizontal
         thisRigidbody.transform.Translate(new Vector3(Velocidad, 0, 0) * Time.deltaTime);
      }
      else
      {
         //Movemos el arma en vertical
         thisRigidbody.transform.Translate(new Vector3(0, Velocidad, 0) * Time.deltaTime);
      }
   }
 
   void OnTriggerEnter(Collider other)
   {
      if (other.tag == "Enemigo")
      {
         //Si el ataque colisiona contra un objeto con el tag 'Enemigo', se decrementan las vidas de dicho enemigo
        // other.gameObject.GetComponent<ComportamientoEnemigo>().Vidas--;
 
         //Destruimos el objeto cuando colisione contra un enemigo
          Destroy(gameObject);
      }
      //Destroy(gameObject);
      //Debug.Log("destruccion");
      
   }

   private void OnCollisionEnter2D(Collision2D other)
   {
       Destroy(gameObject);
      Debug.Log("destruccion");
   }

}
