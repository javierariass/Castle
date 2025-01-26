using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataformas_moviles : MonoBehaviour
{
    public float speedX,speedY = 1;
    public int Patrulla_Type;
    public string direct;
    private Rigidbody2D rb;
    public GameObject[] puntos;
    public static bool Player_Into = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Patrulla_Type == 1)
        {
            Patrulla_Vertical();
        }
        
        if(Patrulla_Type == 2)
        {
            Patrulla_Horizontal();
        }
        rb.velocity = new Vector2(speedX, speedY);

        if (Player_Into)
        {
           GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().velocity = new Vector2(speedX, speedY);
        }
    }

    private void Patrulla_Vertical()
    {

        if (gameObject.GetComponent<Transform>().position.x > puntos[0].GetComponent<Transform>().position.x && direct == "derecha")
        {
            speedX *= -1;
            speedY *= 0;
            direct = "izquierda";
        }

        if (gameObject.GetComponent<Transform>().position.x < puntos[1].GetComponent<Transform>().position.x && direct == "izquierda")
        {
            speedX *= -1;
            speedY *= 0;
            direct = "derecha";           
        }

    }



    private void Patrulla_Horizontal()
    {

        if (gameObject.GetComponent<Transform>().position.y > puntos[0].GetComponent<Transform>().position.y && direct == "arriba")
        {
            speedY *= -1;
            direct = "abajo";
            speedX *= 0;
        }

        if (gameObject.GetComponent<Transform>().position.y < puntos[1].GetComponent<Transform>().position.y && direct == "abajo")
        {
            speedY *= -1;
            speedX *= 0;
            direct = "arriba";
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Into = true;
            collision.gameObject.GetComponent<PlayerMove>().Plataforma_moviles = true;
            collision.gameObject.GetComponent<PlayerMove>().Wait = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Into = false;
            collision.gameObject.GetComponent<PlayerMove>().Wait = true;
            collision.gameObject.GetComponent<PlayerMove>().Plataforma_moviles = false;
        }
    }
}
