using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos_Player : MonoBehaviour
{
    public AudioSource audioActivo;
    public  AudioClip au_atk,au_move,au_Hit;

    // Start is called before the first frame update
    void Start()
    {
        audioActivo = GetComponent<AudioSource>();
    }

    public void Activar_Sonido(AudioClip sound)
    {
        audioActivo.clip = sound;
        audioActivo.Play();
    }
}
