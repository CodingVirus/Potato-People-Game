using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject test;

    private void OnMouseDown()
    {
        test.GetComponent<PlayerMouseControll>().StopMove();
        this.transform.GetChild(0).gameObject.SetActive(true);
    }
}
