using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 2;
    public float jumpSpeed;
    public GameObject Arma, izquierda, derecha, atacar, saltar, interact;
    public bool Inmune, death,sound_walk,Plataforma_moviles = false;
    public bool Wait = true;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public float counterTime = 0.25f;
    private Sonidos_Player player_sound;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player_sound = GetComponent<Sonidos_Player>();
        izquierda = GameObject.FindGameObjectWithTag("Boton_izquierda");
        derecha = GameObject.FindGameObjectWithTag("Boton_derecha");
        atacar = GameObject.FindGameObjectWithTag("Boton_ataque");
        saltar = GameObject.FindGameObjectWithTag("Boton_salto");
        interact = GameObject.FindGameObjectWithTag("Boton_interactuar");
    }

    // Update is called once per frame
    void FixedUpdate()
    {       
        if (!death)
        {

            RUNING();
            JUMPING();
            FLIP();
            Attack_On();
            
                                 
        }
        if(death)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("RUN", false);
        }
    }

    //Acciones De Ataque
    private void Attack_On()
    {
        if (Input.GetKey(KeyCode.A) || atacar.GetComponent<Botones>().activo)
        {
            animator.SetBool("ATTACK", true);
        }
    }

    public void Attack_Impact()
    {
        Arma.GetComponent<BoxCollider2D>().enabled = true;
        player_sound.Activar_Sonido(player_sound.au_atk);
    }

    public void Attack_Impact_OFF()
    {
        Arma.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void Attack_Of()
    {
        animator.SetBool("ATTACK", false);
        Arma.GetComponent<BoxCollider2D>().enabled = false;
    }   


    //Movimiento jugador
    private void RUNING()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !animator.GetBool("ATTACK") || derecha.GetComponent<Botones>().activo && !animator.GetBool("ATTACK"))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            animator.SetBool("RUN", true);
           
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && !animator.GetBool("ATTACK") || izquierda.GetComponent<Botones>().activo && !animator.GetBool("ATTACK"))
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            animator.SetBool("RUN", true);          
        }

        else
        {
            if (!Plataforma_moviles && Wait)
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                
            }
            animator.SetBool("RUN", false);
            
        }
    }

    private void JUMPING()
    {
        if (Input.GetKey(KeyCode.Space) && PlayerJump.Suelo || saltar.GetComponent<Botones>().activo && PlayerJump.Suelo)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            animator.SetTrigger("Jump");
        }
    }
    private void FLIP()
    {
        if (Input.GetKey(KeyCode.RightArrow) || derecha.GetComponent<Botones>().activo)
        {
            spriteRenderer.flipX = false;
            Arma.transform.localScale = new Vector2(1, Arma.transform.localScale.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || izquierda.GetComponent<Botones>().activo)
        {
            spriteRenderer.flipX = true;
            Arma.transform.localScale = new Vector2(-1, Arma.transform.localScale.y); ;
        }
    }

    //Hurt
    public void HurtOFF()
    {
        animator.SetBool("Hurt", false);
    }
    //Death

    
    
}
