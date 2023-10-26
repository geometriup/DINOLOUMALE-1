using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movi : MonoBehaviour
{
    public GameObject victoryArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == victoryArea)
        {
            // El personaje ha entrado en el área de victoria
            Debug.Log("¡Has ganado el juego!");
            // Aquí puedes agregar cualquier lógica adicional de victoria, como mostrar un mensaje de victoria o cargar una escena de fin de juego.
        }
    }
}
