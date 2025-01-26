using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aparicion_Boss : MonoBehaviour
{
    public float time,speed = 4;
    private GameObject Player;
    private bool emp = false;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(emp)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(gameObject,0.4f);
        }
    }

    public void Empieza()
    {
        emp = true; 
        Destroy(gameObject, time);
        
    }
}
