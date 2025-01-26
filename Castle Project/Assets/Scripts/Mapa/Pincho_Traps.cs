using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pincho_Traps : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Life_Player>().Death();
        }
    }
}
