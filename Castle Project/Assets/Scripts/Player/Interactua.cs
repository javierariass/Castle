using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Interactua : MonoBehaviour
{   
   
    public GameObject interact;
    private Desactivate activate;
    public bool condition_Key = false;

    private void Start()
    {
        interact = GameObject.FindGameObjectWithTag("Boton_interactuar");
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Objetos_usables"))
        {
            activate = collision.gameObject.GetComponent<Desactivate>();
            interact.transform.localScale = new Vector2(1, 1.3f);   
            if (Input.GetKey(KeyCode.E) && !activate.activate || interact.GetComponent<Botones>().activo && !activate.activate)
            {
                activate.Activate_State();
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Objetos_usables"))
        {
            interact.transform.localScale = new Vector2(0, 0);

            if (activate.condition)
            {
                if (!condition_Key)
                {
                    activate.textoKey.transform.localScale = new Vector2(0, 0);
                }
            }
        }
       
    }
}
