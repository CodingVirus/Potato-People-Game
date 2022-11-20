using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{
    public GameObject ply;
    private void OnMouseDown()
    {
        ply.GetComponent<PlayerTeleport>().DoorEnter();
        gameObject.transform.parent.GetComponent<Teleporter>().GetDesObj().GetComponent<BoxCollider2D>().enabled = false;
        Invoke("test2", 3.0f);
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

    public void test2()
    {
        gameObject.transform.parent.GetComponent<Teleporter>().GetDesObj().GetComponent<BoxCollider2D>().enabled = true;
    }
}
