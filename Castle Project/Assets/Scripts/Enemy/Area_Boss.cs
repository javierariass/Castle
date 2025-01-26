using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area_Boss : MonoBehaviour
{
    
    public GameObject Camera1,Camera2, boss,bosscanva;
    public AudioSource Sound;
    private void Start()
    {
        Camera1 = GameObject.FindGameObjectWithTag("MainCamera");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Sound.enabled = true;
            Camera1.SetActive(false);
            Camera2.SetActive(true);
            bosscanva.SetActive(true);
            boss.GetComponent<Boss>().enabled = true;
        }
    }
}
