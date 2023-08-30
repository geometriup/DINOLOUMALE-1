using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoT : MonoBehaviour
{
    
    //public Vector3 valorFinal = new Vector3(2,0,0);
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init();
        //transform.DOMove(valorFinal,2);
        
        //Aca movemos desde la ubicacion actual a X2 GLOBAl y despues de X2 a X18
        /*transform.DOMoveX(2,2);
        transform.DOMoveX(18,2).SetDelay(3);
        */
       //Con este vuela
       // transform.DOMove(new Vector3(2,2,0),2).SetDelay(2);

        //Aca probamos la secuencia
        Sequence patrulla1 = DOTween.Sequence();
        //patrulla1.Append(transform.DOMoveX(2,2)).SetDelay(2).Append(transform.DOMoveX(18,2).SetDelay(2)).SetLoops(3);
        patrulla1.Append(transform.DOMoveX(2,2)).SetDelay(2).Append(transform.DOMoveX(10,2)).SetDelay(2).Append(transform.DOMoveX(18,2).SetDelay(2)).SetLoops(3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
