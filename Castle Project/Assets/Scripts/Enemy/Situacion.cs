using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Situacion : MonoBehaviour
{
    public Enemy_ATTACK enemy;
    private Collider2D col;


  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            col = collision;
            enemy.Ataca(col);

        }
    }
   
}
