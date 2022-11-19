using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3 : MonoBehaviour
{
    public GameObject ply;

    private void OnMouseDown()
    {
        ply.GetComponent<PlayerTeleport>().DoorEnter();
        this.gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        ply.GetComponent<PlayerMouseControll>().StopMove();
    }

    private void OnMouseExit()
    {
        ply.GetComponent<PlayerMouseControll>().StartMove();
    }
}
