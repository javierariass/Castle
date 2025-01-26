using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool Inmune;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !Inmune)
        {
            collision.gameObject.GetComponentInParent<Vida>().Restar_Vida(Status.Attack,gameObject.transform.position);
            collision.gameObject.GetComponentInParent<Vida>().Retroceso();
            StartCoroutine(Inmunidad());
        }

        if(collision.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<VidaBoss>().DamageTake();
        }
        if (collision.CompareTag("Destructible"))
        {
            collision.gameObject.GetComponentInParent<BoxDestroyer>().RestarVida();
        }
    }


    IEnumerator Inmunidad()
    {
        Inmune = true;
        yield return new WaitForSeconds(0.5f);
        Inmune = false;
    }
}
