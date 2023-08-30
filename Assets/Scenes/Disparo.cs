using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Disparo : MonoBehaviour
{
    public GameObject FireballPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FireballPrefab != null && Input.GetButtonDown("Fire1"))
      {
         //Accedemos al script 'ArmaArrojadiza.cs' del prefab
         Proyectil scriptFireball = FireballPrefab.GetComponent<Proyectil>();
 
         if (Input.GetAxis("Vertical") > 0)
         {
            //Ataque hacia arriba
            scriptFireball.DireccionArma = Direccion.Vertical;
            scriptFireball.Velocidad = Math.Abs(scriptFireball.Velocidad);
         }
         else if (Input.GetAxis("Vertical") < 0)
         {
            //Ataque hacia abajo
            scriptFireball.DireccionArma = Direccion.Vertical;
            scriptFireball.Velocidad = -Math.Abs(scriptFireball.Velocidad);
         }
         else if (Input.GetAxis("Horizontal") > 0)
         {
            //Ataque hacia la derecha
            scriptFireball.DireccionArma = Direccion.Horizontal;
            scriptFireball.Velocidad = Math.Abs(scriptFireball.Velocidad);
         }
         else if (Input.GetAxis("Horizontal") < 0)
         {
            //Ataque hacia la izquierda
            scriptFireball.DireccionArma = Direccion.Horizontal;
            scriptFireball.Velocidad = -Math.Abs(scriptFireball.Velocidad);
         }
 
         //Creamos una instancia del prefab en nuestra escena, concretamente en la posición de nuestro personaje
         Instantiate(FireballPrefab, transform.position, Quaternion.identity);
      }
   
    }
}
