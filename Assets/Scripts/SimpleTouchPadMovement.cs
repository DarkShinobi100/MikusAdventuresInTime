using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SimpleTouchPadMovement : MonoBehaviour, IPointerDownHandler,IDragHandler, IPointerUpHandler{
    private Vector2 origin;
    private Vector2 Direction;
    public float Smoothing;
    private Vector2 SmoothDirection;
    private bool Pressed;
    private int PointerID;

    void Awake()
    {
        Direction = Vector2.zero;
        Pressed = false;
    }

    public void OnPointerDown(PointerEventData Data)
    {if (!Pressed)
        {
            Pressed = true;
            PointerID = Data.pointerId;
            //set our start point
            origin = Data.position;
        }
    }
    public void OnDrag(PointerEventData Data)
    {
        if (Data.pointerId == PointerID)
        {
            //compare the difference between our start point and our current position
            Vector2 CurrentPosition = Data.position;
            Vector2 DirectionRaw = CurrentPosition - origin;
            Direction = DirectionRaw.normalized;
        }
    }
    public void OnPointerUp(PointerEventData Data)
    { if (Data.pointerId == PointerID)
        {
            //reset everything
            Direction = Vector2.zero;
            Pressed = false;
        }
    }
    public Vector2 GetDirection()
    {
        SmoothDirection = Vector2.MoveTowards(SmoothDirection,Direction,Smoothing);
        return SmoothDirection;
    }
}
