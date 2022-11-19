using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    public GameObject ply;

    private void OnMouseDown()
    {
        ply.GetComponent<PlayerHide>().HideEnter();
    }

    public void HideTest()
    {
        ply.GetComponent<PlayerHide>().HideEnter();
    }
}
