using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VidaBoss : MonoBehaviour
{
    public float life = 200;

    public Image barra_vida, barra;
    public GameObject Win;

    public void DamageTake()
    {
        if(life > 0)
        {
            life -= 10;
            barra_vida.transform.localScale = new Vector2(barra_vida.transform.localScale.x - 0.05f, barra_vida.transform.localScale.y);
            

        }
       
        if(life <= 0)
        {           
            GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>().SetTrigger("death");
        }
        
    }
    public void destruye()
    {
        Win.SetActive(true);
        Destroy(gameObject);    
    }
}
