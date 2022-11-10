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

    private void Update() 
    {
        // PlayerPosition.GetComponent<PlayerTeleport>().transferStart = true;
        // Debug.Log("MouseDown : true");

        // mousePos = Input.mousePosition;
        // transPos = Camera.main.ScreenToWorldPoint(mousePos);
        // target = new Vector3(transPos.x, target.y, 0);

        // RaycastHit2D raycast = Physics2D.Raycast(PlayerPosition, target, 1, LayerMask.GetMask("Door"));
        // if(Physics2D.Raycast(PlayerPosition, target, 1, LayerMask.GetMask("Door")))
        // {
        //     Debug.Log(raycast.collider.gameobject.name);
        // }
        // //Debug.Log(Rayhit.collider.gameobject.name);
    }
   
}
