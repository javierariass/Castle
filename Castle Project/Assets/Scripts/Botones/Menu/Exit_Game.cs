using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit_Game : MonoBehaviour, IPointerDownHandler
{
    public Sprite boton_press;
    public AudioClip clicked;
    private AudioSource audio_act;

    private void Start()
    {
        audio_act = GetComponent<AudioSource>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {    
        audio_act.Play();
        gameObject.GetComponent<Image>().sprite = boton_press;
        StartCoroutine(Load());

    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(2);
        Application.Quit();
    }

}

