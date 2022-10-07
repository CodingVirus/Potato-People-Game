using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTest : MonoBehaviour
{
    public GameObject player;
    private void OnMouseDown()
    {
        player.GetComponent<PlayerMouseControll>().StopMove();
    }
}
