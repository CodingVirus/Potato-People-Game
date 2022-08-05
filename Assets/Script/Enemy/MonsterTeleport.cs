using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTeleport : MonoBehaviour
{
    //public GameObject startTeleport;
    public Transform playertel;

    private void Update() 
    {
        if(playertel.GetComponent<PlayerTeleport>().transferState == true && this.GetComponent<MonsterMove>().traceState == true)
        {
            Invoke("MonTeleport", 4f);
        }
    }

    private void MonTeleport()
    {
        transform.position = playertel.GetComponent<PlayerTeleport>().p_Teleport;
    }
    //private bool teleport;
    
    //private void OnTriggerEnter2D(Collider2D other)
    //{
        //Debug.Log("충돌");
        //teleport = (Random.value > 0.5f);
        //Debug.Log(teleport)/;
        //if(this.GetComponent<MonsterMove>().monteleport == true)
        //{
        //    if(other.CompareTag("Door"))
        //    {
        //        Debug.Log("monster이동");
                //startTeleport = other.gameObject;
        //        transform.position = startTeleport.GetComponent<Teleporter>().GetDestination().position;
        //        startTeleport = null;
        //    }
        //}
    //}

    //private void OnTriggerExit2D() 
    //{
    //    startTeleport = null;
        //Debug.Log("Exit : null");
    //}
}
