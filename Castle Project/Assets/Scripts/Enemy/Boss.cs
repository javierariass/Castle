using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


public enum UndeadStatus
{
    Talking,
    IDLE,
    Attack1,
    Attack2,
    Aparicion,
    Dead
}

public class Boss : MonoBehaviour
{
    public UndeadStatus status;

    public GameObject Aparicion,pointAparicion, player;

    public GameObject[] puntosTele;

    public int countApar = 0;

    public Animator animator;

    private float statusCh = 2;

    public float speed = 2;

    private bool Acercarse = false;
  
    private void Start()
    {
        status = UndeadStatus.IDLE;
        animator = GetComponent<Animator>();
        StartCoroutine(UndeadStatuses());
        Acercarse = true;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {       

        if (Acercarse && Vector2.Distance(transform.position, player.transform.position) > 1f)
        {
            Flipx();
            gameObject.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void Flipx()
    {
        if (player.transform.position.x > transform.position.x)
        {
            gameObject.transform.localScale = new Vector2(3, 2.5f);
        }

        else
        {
            gameObject.transform.localScale = new Vector2(-3, 2.5f);
        }
    }

    public IEnumerator UndeadStatuses()
    {
        var randomAttack = Random.Range(1, 5);     
        yield return new WaitForSeconds(statusCh);

        switch(randomAttack)
        {
            case 1:
                status = UndeadStatus.IDLE;
                break;
            case 2:
                status = UndeadStatus.Attack1;
                break;
            case 3:
                status = UndeadStatus.Attack2;
                break;
            case 4:
                status = UndeadStatus.Aparicion;
                break;
            default:
                break;
        }

        StatusChanger();
    }
    public void Habilidad_Aparicion()
    {      
       GameObject.Instantiate(Aparicion, pointAparicion.transform.position, pointAparicion.transform.rotation);            
    }
   
    public void Skill()
    {
        animator.SetTrigger("Summon");      
    }

    private void Attack_1()
    {
        animator.SetTrigger("Atk1");
    }

    private void Attack_2()
    {
        animator.SetTrigger("Atk2");
    }

    public void StatusChanger()
    {
         switch (status)
        {
            case UndeadStatus.Talking:
                break;

            case UndeadStatus.IDLE:
                statusCh = 3;
                Acercarse = true;
                StartCoroutine(UndeadStatuses());              
                break;

            case UndeadStatus.Attack1:
                Acercarse = false;
                Attack_1();
                statusCh = 3f;
                status = UndeadStatus.IDLE;
                StatusChanger();
                break;

            case UndeadStatus.Attack2:
                Acercarse = false;
                Attack_2();
                statusCh = 3f; 
                status = UndeadStatus.IDLE;
                StatusChanger();
                break;

            case UndeadStatus.Aparicion:                
                Flipx();
                Acercarse = false;
                Skill();
                statusCh = 2f;
                StartCoroutine(UndeadStatuses());
                break;

            case UndeadStatus.Dead:
                break;
        }

    }

   




}
