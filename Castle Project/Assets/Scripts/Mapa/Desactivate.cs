using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Desactivate : MonoBehaviour
{
    public GameObject Objeto;
    public Image Key_HUD;
    public Sprite Key_HUD_Sprite, Key_HUD_ORIGINAL_sprite;
    public bool condition, activate = false;
    public GameObject textoKey;
    private Animator _animator;
    public int type_item = 1;
    public int LVL;

    private void Start()
    {
        Key_HUD = GameObject.FindGameObjectWithTag("Key_HUD").GetComponent<Image>();
        textoKey = GameObject.FindGameObjectWithTag("KeyText");
    }
    public void Desactivate_State()
    {
        gameObject.GetComponent<Animator>().enabled = false;       
    }

    public void Activate_State()
    {
        _animator = gameObject.GetComponent<Animator>();
        if (condition)
        {
            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Interactua>().condition_Key)
            {
                _animator.enabled = true;
                activate = true;               
            }

            if (!GameObject.FindGameObjectWithTag("Player").GetComponent<Interactua>().condition_Key)
            {
                textoKey.transform.localScale = Vector2.one;
            }
        }
        else
        {
            _animator.enabled = true;
            activate = true;
        }
    }
    public void Destroy_Item()
    {
        Destroy(gameObject);
    }

    public void Activated_Item()
    {
        Objeto.SetActive(true);
        if(type_item == 1)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Interactua>().condition_Key = true;
            Key_HUD.sprite = Key_HUD_Sprite;
        }

        if(type_item == 2)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Life_Player>().Sumar_Vida();
        }
        
    }


    public void Open_Door()
    {
        Objeto.GetComponent<Animator>().enabled = true;
        Objeto.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void Sgt_lvl()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Interactua>().condition_Key = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Life_Player>().Regen();
        Key_HUD.sprite = Key_HUD_ORIGINAL_sprite;
        SceneManager.LoadScene(LVL);
    }

    

}
