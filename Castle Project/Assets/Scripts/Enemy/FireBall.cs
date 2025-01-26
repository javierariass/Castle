using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.gameObject.GetComponent<PlayerMove>().Inmune)
        {
            collision.GetComponent<Life_Player>().Restar_Vida(gameObject.transform.position);
            collision.GetComponent<Animator>().SetBool("Hurt", true);
            collision.GetComponent<Life_Player>().Retroceso();
            collision.GetComponent<Sonidos_Player>().Activar_Sonido(collision.gameObject.GetComponent<Sonidos_Player>().au_Hit);
            Destroy(gameObject);
        }
    }
}
