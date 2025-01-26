using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : MonoBehaviour
{
    private Animator animator;
    public bool esta = false;
    private AudioSource audioSource;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    
    IEnumerator Ejecucion()
    {
        
        yield return new WaitForSeconds(0.6f);
        animator.enabled = true;
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void Apagar()
    {
        animator.enabled = false;
        StartCoroutine(Ejecucion());
    }

    
}
