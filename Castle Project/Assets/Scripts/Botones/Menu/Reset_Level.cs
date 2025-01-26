using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Reset_Level : MonoBehaviour

{
    
    public AudioClip clicked;
    private AudioSource audio_act;
    public GameObject lose,a,b,c;
    private void Start()
    {
        audio_act = GetComponent<AudioSource>();
    }
    public void Reset_Game()
    {
        audio_act.clip = clicked;
        audio_act.Play();
        var i = SceneManager.GetActiveScene().buildIndex;
        if(i == 1)
        {
            Destroy(c);
            Destroy(a);
            Destroy(b);
            Destroy(GameObject.FindGameObjectWithTag("Player"));
        }
        SceneManager.LoadScene(i);
        gameObject.SetActive(false);
        lose.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>().death = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Life_Player>().Regen();
    }
}


