using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public static bool Suelo = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Suelo"))
        {
            Suelo = true;       
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            Suelo = false;
        }
    }
}
