using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject spawnPoint, player;
    public Image Ui;
    public Animator Scene_CArga, logo_Carga;
    public int inicio = 1;
    // Start is called before the first frame update
    void Start()
    {
        if(inicio == 1)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("Spawn");
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = spawnPoint.transform.position;
        }
        
        Ui.raycastTarget = true;
        StartCoroutine(Pantalla_Carga());
    }

    IEnumerator Pantalla_Carga()
    {
        yield return new WaitForSeconds(3);
        logo_Carga.SetTrigger("Stop");
        Scene_CArga.SetTrigger("Stop");
        Ui.raycastTarget = false;
    }


}

