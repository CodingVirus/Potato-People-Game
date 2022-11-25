using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTeleport : MonoBehaviour
{
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
        gameObject.SetActive(false);
        Invoke("monSetActive", 1f);
    }

    private void monSetActive()
    {
        gameObject.SetActive(true);
    }
}
