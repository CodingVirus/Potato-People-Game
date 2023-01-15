using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject test;
    public GameObject gameData;

    private void OnMouseDown()
    {
        test.GetComponent<PlayerMouseControll>().StopMove();
        this.transform.GetChild(0).gameObject.SetActive(true);
        this.GetComponent<UItriggerOff>().TriggerOff();
        gameData.GetComponent<GameDataControl>().MainCameraGetItemOff();
        gameData.GetComponent<GameDataControl>().MainCameraUIcontrolOff();
    }
}
