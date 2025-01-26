using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroyer : MonoBehaviour
{
    int vida = 3;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
    }

   public void RestarVida()
    { 
        {
            vida -= 1;
            animator.enabled = true;

            if (vida == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void desactivate()
    {
        animator.enabled = false;
    }
}
