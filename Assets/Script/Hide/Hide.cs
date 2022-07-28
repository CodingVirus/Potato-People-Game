using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : ClickableHide
{
    public GameObject player;

    private void OnMouseDown() 
    {
        player.GetComponent<PlayerHide>().hideStart = true;
        Debug.Log("MouseDown : true");
    }

}
