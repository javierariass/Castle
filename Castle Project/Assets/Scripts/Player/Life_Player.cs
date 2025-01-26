using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life_Player : MonoBehaviour
{
    public GameObject Texto_Lose,boton;
    public Image[] images = new Image[3];
    public float ForceX, ForceY;
    public Sprite[] hearts;
    int corazon = 0;
    int estado = 0;
    private bool vida_restada = false;
    private Vector2 retro;
    
    // Start is called before the first frame update

    private void Start()
    {
        images[0] = GameObject.FindGameObjectWithTag("life1").GetComponent<Image>();
        images[1] = GameObject.FindGameObjectWithTag("life2").GetComponent<Image>();
        images[2] = GameObject.FindGameObjectWithTag("life3").GetComponent<Image>();
    }

    public void Restar_Vida(Vector2 position_enemy)
    {
        retro = position_enemy;
        StartCoroutine(Inmunidad());
        StartCoroutine(TImeWait());
        
        switch (corazon)
        {
            case 0:
                if (estado == 0 && !vida_restada)
                {
                    images[0].sprite = hearts[1];
                    estado = 1;
                    vida_restada = true;
                }

                if (estado == 1 && !vida_restada)
                {
                    images[0].sprite = hearts[2];
                    estado = 0;
                    corazon = 1;
                    vida_restada = true;
                }
                break;

            case 1:
                if (estado == 0 && !vida_restada)
                {
                    images[1].sprite = hearts[1];
                    estado = 1;
                    vida_restada = true;
                }

                if (estado == 1 && !vida_restada)
                {
                    images[1].sprite = hearts[2];
                    estado = 0;
                    corazon = 2;
                    vida_restada = true;
                }
                break;

            case 2:
                if (estado == 0 && !vida_restada)
                {
                    images[2].sprite = hearts[1];
                    estado = 1;
                    vida_restada = true;
                }

                if (estado == 1 && !vida_restada)
                {
                    images[2].sprite = hearts[2];
                    estado = 0;
                    corazon = 3;
                    vida_restada = true;
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().death = true;
                    Texto_Lose.SetActive(true);
                    boton.SetActive(true);
                }
                break;

            default:
                break;
        }
        vida_restada = false;
    }


    IEnumerator Inmunidad()
    {
        gameObject.GetComponent<PlayerMove>().Inmune = true;
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<PlayerMove>().Inmune = false;
    }

    IEnumerator TImeWait()
    {
        gameObject.GetComponent<PlayerMove>().Wait = false;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<PlayerMove>().Wait = true;
    }
    public void Retroceso()
    {
        if (gameObject.transform.position.x < retro.x)

        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-ForceX, ForceY), ForceMode2D.Force);
        }

        else

        {
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(ForceX, ForceY), ForceMode2D.Force);
            
        }
    }

    public void Sumar_Vida()
    {
        switch (corazon)
        {
            case 0:
                
                if (estado == 1)
                {
                    images[0].sprite = hearts[0];
                    estado = 0;                    
                }
                break;

            case 1:
                if (estado == 0)
                {
                    images[0].sprite = hearts[0];
                    estado = 0;
                    corazon = 0;
                }

                if (estado == 1)
                {
                    images[1].sprite = hearts[0];
                    images[0].sprite = hearts[1];
                    estado = 1;
                    corazon = 0;                    
                }
                break;

            case 2:
                if (estado == 0)
                {
                    images[1].sprite = hearts[0];
                    estado = 0;
                    corazon = 1;
                }
                    if (estado == 1)
                {
                    images[2].sprite = hearts[0];
                    images[1].sprite = hearts[1];
                    estado = 1;
                    corazon = 1;                   
                }
                break;

            default:
                break;
        }
    }

    public void Regen()
    {
        images[0].sprite = hearts[0];
        images[1].sprite = hearts[0];
        images[2].sprite = hearts[0];
        corazon = 0;
        estado = 0;
    }

    public void Death()
    {
        images[0].sprite = hearts[2];
        images[1].sprite = hearts[2];
        images[2].sprite = hearts[2];
        corazon = 2;
        estado = 2;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().death = true;
        Texto_Lose.SetActive(true);
        boton.SetActive(true);
    }
}
