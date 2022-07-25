using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleporter : ClickablePortal
{
    [SerializeField] private Transform destination;
    public GameObject PlayerPosition;

    //private CameraFollow theCamera;
    [SerializeField]
    public float T_limitMinX, T_limitMaxX, T_limitMinY, T_limitMaxY;
 
    public Transform GetDestination()
    {
        return destination;
    }
    
    private void OnMouseDown() 
    {
        PlayerPosition.GetComponent<PlayerTeleport>().transferStart = true;
        Debug.Log("MouseDown : true");
    }

    //private void OnMouseEnter() 
    //{
    //    CursorController.instance.Portal_Click();

        //if(PlayerPosition.GetComponent<PlayerTeleport>().transferStart == true && PlayerPosition.GetComponent<PlayerTeleport>().currentTeleporter == null)
        //{
        //    PlayerPosition.GetComponent<PlayerTeleport>().transferStart = false;
        //    Debug.Log("MouseEnter : false");
        //}
    //}

    //private void OnMouseExit() 
    //{
    //    CursorController.instance.Default();

        //if(Input.GetMouseButtonDown(0))
        //{
        //    PlayerPosition.GetComponent<PlayerTeleport>().currentTeleporter = null;
        //    Debug.Log("MouseExit : null");
        //}

        //if(PlayerPosition.GetComponent<PlayerTeleport>().transferStart == true && PlayerPosition.GetComponent<PlayerTeleport>().currentTeleporter == null)
        //{
        //    PlayerPosition.GetComponent<PlayerTeleport>().transferStart = false;
        //    Debug.Log("MouseExit : fasle");
        //}
        //}
    //}
   
}
