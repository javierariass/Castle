using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Botones : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool activo;


    public void OnPointerDown(PointerEventData eventData)
    {
        activo = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        activo = false;
    }
}
