using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleTouchArea : MonoBehaviour, IPointerDownHandler,IPointerUpHandler
{
    private bool pressed;

    void Awake()
    {      
        pressed = false;
    }

    public void OnPointerDown(PointerEventData Data)
    {
        if (!pressed)
        {
            pressed = true;
        }
    }
   
    public void OnPointerUp(PointerEventData Data)
    {
            //reset everything
            pressed = false;
    }
    public bool Pressed()
    {
        return pressed;
    }
}

