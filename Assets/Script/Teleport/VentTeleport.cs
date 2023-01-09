using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentTeleport : MonoBehaviour
{
    public GameObject ply;
    private void OnMouseDown()
    {
        ply.GetComponent<PlayerTeleport>().DoorEnter();
        //this.gameObject.SetActive(false);
        Invoke("test", 0.2f);
    }

    private void OnMouseEnter()
    {
        ply.GetComponent<PlayerMouseControll>().StopMove();
        ply.GetComponent<PlayerMouseControll>().MaintainPosition();
    }

    private void OnMouseExit()
    {
        ply.GetComponent<PlayerMouseControll>().StartMove();
    }

    private void test()
    {
        this.gameObject.SetActive(false);
    }
}
