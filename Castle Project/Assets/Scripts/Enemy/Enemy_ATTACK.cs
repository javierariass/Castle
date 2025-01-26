using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_ATTACK : MonoBehaviour
{
    public int Atk = 1;
    private GameObject Player;
    private bool StayPlayer;
    public AudioClip clipAttack;
    private AudioSource audioSource;
    public GameObject proyectil;
    public Transform spawn;
    public float speedShoot;
    public bool shoot = true;


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !collision.gameObject.GetComponent<PlayerMove>().Inmune && !collision.gameObject.GetComponent<PlayerMove>().death)

        {      
            Player = collision.gameObject;
            StayPlayer = true;
            Ataca(collision);            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StayPlayer=false;
        }
    }
    public void Ataca(Collider2D collision)
    {
        damage();
        
        Player = collision.gameObject;
        if(Atk != 3)
        {
            if (clipAttack != null)
            {
                audioSource.clip = clipAttack;
                audioSource.Play();
            }
        }
       
        if(Atk == 2)
        {
            gameObject.GetComponent<Animator>().SetBool("Attack", true);           
        }       

        if (Atk == 3)
        {
            if(shoot)
            {
                GameObject fire;
                fire = Instantiate(proyectil, spawn.position, spawn.rotation);
                fire.GetComponent<Rigidbody2D>().velocity = new Vector2(speedShoot, 0);
                audioSource.clip = clipAttack;
                audioSource.Play();
                StartCoroutine(Enemy_Shoot());
                Destroy(fire, 2);
            }          
        }
        
        if (gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Enemy_Move());
        }
    }

    IEnumerator Enemy_Move()
    {
        gameObject.GetComponent<Rutinas>().Is_posbile_move = false;
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<Rutinas>().Is_posbile_move = true;
    }

    IEnumerator Enemy_Shoot()
    {
        shoot = false;
        yield return new WaitForSeconds(2.5f);
        shoot = true;
    }
    public void Atacar_OFF()
    {
        gameObject.GetComponent<Animator>().SetBool("Attack", false);
    }
    
    public void damage()
    {
        if(StayPlayer)
        {
            Player.GetComponent<Life_Player>().Restar_Vida(gameObject.transform.position);          
            Player.GetComponent<Animator>().SetBool("Hurt", true);
            Player.GetComponent<Life_Player>().Retroceso();
            Player.GetComponent<Sonidos_Player>().Activar_Sonido(Player.gameObject.GetComponent<Sonidos_Player>().au_Hit);
        }
        
    }
}
