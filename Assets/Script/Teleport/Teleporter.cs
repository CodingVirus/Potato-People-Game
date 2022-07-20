using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleporter : ClickablePortal
{
    [SerializeField] private Transform destination;
    public GameObject PlayerPosition;

    private CameraFollow theCamera;
    [SerializeField]
    public float T_limitMinX, T_limitMaxX, T_limitMinY, T_limitMaxY;

    private void Awake() 
    {
        theCamera = Camera.main.GetComponent<CameraFollow>();
    }
    
    public Transform GetDestination()
    {
        return destination;
    }
    
    private void Update() 
    {
        //if(PlayerPosition.GetComponent<PlayerTeleport>().T_camera == true)
        //{
            //theCamera.limitMinX = T_limitMinX;
            //theCamera.limitMaxX = T_limitMaxX;
            //theCamera.limitMinY = T_limitMinY;
            //theCamera.limitMaxY = T_limitMaxY;
            //PlayerPosition.GetComponent<PlayerTeleport>().T_camera = false;
        //}
    }
    
    private void OnMouseDown() 
    {
        //if(PlayerPosition.GetComponent<PlayerMouseControll>().target.x == )
        //{
        PlayerPosition.GetComponent<PlayerTeleport>().transferStart = true;
        //theCamera.clampX = PlayerPosition.transform.position.x;
        //theCamera.clampY = PlayerPosition.transform.position.y;
        theCamera.limitMinX = T_limitMinX;
        theCamera.limitMaxX = T_limitMaxX;
        theCamera.limitMinY = T_limitMinY;
        theCamera.limitMaxY = T_limitMaxY;

            //if(PlayerPosition.CompareTag("Player") && PlayerPosition.GetComponent<PlayerTeleport>().transferStart == true)
            //{
            //    PlayerPosition.GetComponent<PlayerTeleport>().currentTeleporter = this.gameObject;
            //    PlayerPosition.GetComponent<PlayerTeleport>().DoorEnter();
            //}
        //}
    }
   
}
