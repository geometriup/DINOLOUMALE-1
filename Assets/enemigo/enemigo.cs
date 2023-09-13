using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo : MonoBehaviour
{
    public GameObject personaje;

    private void Update()
    {
        Vector2 direction = personaje.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector2(1.0f, 1.0f);
        else transform.localScale = new Vector2(-1.0f, 1.0f);
    }
}