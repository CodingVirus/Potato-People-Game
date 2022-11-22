using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject test;

    private void OnMouseDown()
    {
        test.GetComponent<GameDataControl>().PlayerMouseControllOff();
    }
}
