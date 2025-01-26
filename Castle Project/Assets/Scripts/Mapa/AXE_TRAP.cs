using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AXE_TRAP : MonoBehaviour
{
    

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Life_Player>().Restar_Vida(gameObject.transform.position);
        }
    }

}
