using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject Reiniciar;
    public GameObject otroDia;

    public Empuje emp;

    // Start is called before the first frame update
    void Start()
    {
        Reiniciar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (emp.muerte == true)
        {
            Reiniciar.SetActive(true);
        }
    }


    public void reiniciarNivel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Troll()
    {
        otroDia.SetActive(true);
    }
}
