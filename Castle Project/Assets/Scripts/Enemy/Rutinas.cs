using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rutinas : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform tf;
    public int Patrulla_indice = 1;
    public float Distancia = 2;
    private int number_point = 0;
    public float SpeedX;
    public GameObject[] puntos;
    public string direct = "derecha";
    public static string pos = "derecha";
    public bool detectado_derecha, detectado_izquierda,llegada = false;
    public bool Is_posbile_move = true;
    private GameObject llegada_punto;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tf = GetComponent<Transform>();
        rb.drag = 50;
    }

    // Update is called once per frame
    void Update()
    {
        
      if (!detectado_derecha && !detectado_izquierda)
        {
            if(Patrulla_indice == 1)
            {
                Rutina_horizontal();
            }

            if(Patrulla_indice == 2)
            {
                Rutina_voladora();
            }

            if (Patrulla_indice == 3)
            {
                Rutina_Stay();
            }
        }
    Detected_Player();
        
    }

    public void Rutina_horizontal()
    {
        if(direct == "derecha")
        {
            transform.position = Vector2.MoveTowards(transform.position, puntos[0].transform.position, SpeedX * Time.deltaTime);
            if(llegada)
            {
                direct = "izquierda";
                llegada = false;
                Rotacion();
            }
        }

        if (direct == "izquierda")
        {
            transform.position = Vector2.MoveTowards(transform.position, puntos[1].transform.position, SpeedX * Time.deltaTime);
            if (llegada)
            {
                direct = "derecha";
                llegada=false;
                Rotacion();
            }
        }
       
    }

    public void Rutina_voladora()
    {
        if (llegada && puntos[number_point].GetComponent<Deteccion_Player>().Into_Range == true)
        {                      
            int i = Random.Range(0, puntos.Length);
            while (i == number_point)
            {
                i = Random.Range(0, puntos.Length);
                if (i != number_point)
                {
                    number_point = i;
                    break;
                }
            }

        }
        if(puntos[number_point].transform.position.x > transform.position.x)
        {
            direct = "derecha";
            tf.localScale = new Vector2(1, 1);
            
        }

        else
        {
            direct = "izquierda";
            tf.localScale = new Vector2(-1, 1);
        }
        
        if (Is_posbile_move)
        {
            transform.position = Vector2.MoveTowards(transform.position, puntos[number_point].transform.position, SpeedX * Time.deltaTime);
        }
    }

    private void Rotacion()
    {
        tf.localScale = new Vector2(tf.localScale.x * -1, tf.localScale.y);                                      
    }

    private void Detected_Player()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distancia = Vector2.Distance(transform.position, player.transform.position);

        if(distancia < Distancia)
        {            
            if(player.transform.position.x <= transform.position.x && detectado_izquierda == false)
            {
                if (direct != "izquierda")
                {
                    Rotacion();
                }
                direct = "izquierda";                   
                detectado_izquierda = true;
                detectado_derecha = false;          
            }

            if (player.transform.position.x >= transform.position.x && detectado_derecha == false)
            {
                if(direct != "derecha")
                {
                    Rotacion();
                }
                direct = "derecha";               
                detectado_izquierda = false;
                detectado_derecha = true;
                
            }
            if(Is_posbile_move)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, SpeedX * Time.deltaTime);
            }            
        }
        else
        {
            detectado_izquierda = false;
            detectado_derecha = false;
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("posiciones"))
        {
            collision.gameObject.GetComponent<Deteccion_Player>().Into_Range = true;
            llegada = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("posiciones"))
        {
            collision.gameObject.GetComponent<Deteccion_Player>().Into_Range = false;
        }
    }

    public void Rutina_Stay()
    {
        if (direct == "derecha")
        {
            
            if(Is_posbile_move)
            {
                gameObject.GetComponent<Animator>().SetBool("Run", true);
                transform.position = Vector2.MoveTowards(transform.position, puntos[0].transform.position, SpeedX * Time.deltaTime);
            }
            if (llegada)
            {
                direct = "izquierda";
                llegada = false;
                Rotacion();
                StartCoroutine(WaitTime());
            }
        }

        if (direct == "izquierda")
        {
            if(Is_posbile_move)
            {
                gameObject.GetComponent<Animator>().SetBool("Run", true);
                transform.position = Vector2.MoveTowards(transform.position, puntos[1].transform.position, SpeedX * Time.deltaTime);
            }
            if (llegada)
            {
                direct = "derecha";
                llegada = false;                
                Rotacion();
                StartCoroutine(WaitTime());
            }
        }
        
    }

    IEnumerator WaitTime()
    {
        Is_posbile_move = false;
        gameObject.GetComponent<Animator>().SetBool("Run", false);
        yield return new WaitForSeconds(2f);
        Is_posbile_move = true;
    }
}
