using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public int Life;
    private Vector2 retro;
    public GameObject zona,door;

    public void Restar_Vida(int atk,Vector2 position_Enemy)
    {
        retro = position_Enemy;
        Life -= atk;
        gameObject.GetComponent<Animator>().SetBool("Hurt", true);
        if (Life <= 0)
        {
            Destroy(gameObject,0.25f);
            if(zona != null)
            {
                door.GetComponent<Requisito>().conteo += 1;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Life_Player>().Sumar_Vida();
                Destroy(zona,0.25f);
            }
        }
    }

    public void Retroceso()
    {
        if (gameObject.transform.position.x < retro.x)

        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-800, 0), ForceMode2D.Force);
        }

        else

        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(800, 0), ForceMode2D.Force);
        }
    }

    public void HurtOFF()
    {
        gameObject.GetComponent<Animator>().SetBool("Hurt", false);
    }
}
