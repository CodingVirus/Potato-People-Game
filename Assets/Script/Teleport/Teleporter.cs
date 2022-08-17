using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleporter : ClickablePortal
{
    [SerializeField] private Transform destination;
    public Transform PlayerPosition;

    //public float walkspeed = 5f;
    //public Vector3 target;
    //private Vector3 transPos;

    //private CameraFollow theCamera;
    [SerializeField]
    public float T_limitMinX, T_limitMaxX, T_limitMinY, T_limitMaxY;

    public Transform GetDestination()
    {
        return destination;
    }

    //private void Update() 
    //{
        //if(PlayerPosition.GetComponent<PlayerTeleport>().transferStart == true && Input.GetMouseButtonDown(0))
        //{
        //    Move();
        //}
    //}
    
    //void Move()
    //{
        //transPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //target = new Vector3(transPos.x, PlayerPosition.position.y, 0);
        //PlayerPosition.position = Vector2.MoveTowards(PlayerPosition.position, target, Time.smoothDeltaTime * walkspeed);
    //}
    
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
