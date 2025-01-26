using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start_Game : MonoBehaviour, IPointerDownHandler
{
    public Sprite boton_press;
    public  AudioClip clicked;
    private AudioSource audio_act;
    public GameManager manager;

    private void Start()
    {
        audio_act = GetComponent<AudioSource>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        int Escena_indice = SceneManager.GetActiveScene().buildIndex;
        int sgt_Escena = Escena_indice++;
        audio_act.clip = clicked;
        audio_act.Play();
        gameObject.GetComponent<Image>().sprite = boton_press;
        manager.Scene_CArga.SetTrigger("Start");
        manager.logo_Carga.SetTrigger("Start");
        manager.Ui.raycastTarget = true;
        StartCoroutine(Load());
        
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
       
    }
}