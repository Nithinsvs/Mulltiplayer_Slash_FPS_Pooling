using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Movement : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static bool pressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("pressing");
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

}
