using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleporter : ClickablePortal
{
    [SerializeField] private Transform destination;
    public Camera getCamera;
    public Transform PlayerPosition;

    [SerializeField]
    public float T_limitMinX, T_limitMaxX, T_limitMinY, T_limitMaxY;

    public Transform GetDestination()
    {
        return destination;
    }
    
    public void DoctorTalkMove()
    {
        //OnMouseDown();
    }   
}
