using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Requisito : MonoBehaviour
{
    public int Requisito_Enemigo = 3;
    public int conteo = 0;

    private void Update()
    {
        if(Requisito_Enemigo == conteo)
        {
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
