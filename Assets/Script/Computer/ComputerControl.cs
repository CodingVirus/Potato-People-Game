using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerControl : MonoBehaviour
{
    public GameObject ply;
    public GameObject gameData;
    public GameObject computer;

    private void OnMouseDown()
    {
        ply.GetComponent<PlayerMouseControll>().StopMove();
        computer.SetActive(true);
        this.GetComponent<UItriggerOff>().TriggerOff();
        gameData.GetComponent<GameDataControl>().MainCameraGetItemOff();
        gameData.GetComponent<GameDataControl>().MainCameraUIcontrolOff();
    }

    public void TriggerOn()
    {
        gameData.GetComponent<GameDataControl>().MainCameraGetItemOn();
        gameData.GetComponent<GameDataControl>().MainCameraUIcontrolOn();
        ply.GetComponent<PlayerMouseControll>().MaintainPosition();
        ply.GetComponent<PlayerMouseControll>().StartMove();

    }
}
