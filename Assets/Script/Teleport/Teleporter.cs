using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleporter : ClickablePortal
{
    [SerializeField] private Transform destination;
    public GameObject PlayerPosition;
    
    public Transform GetDestination()
    {
        return destination;
    }

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlayerPosition.GetComponent<PlayerTeleport>().transferStart = true;
        }
    }

    //private void OnMouseDown() 
    //{
    //    PlayerPosition.GetComponent<PlayerTeleport>().transferStart = true;
    //}
}
