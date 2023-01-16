using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerControl : MonoBehaviour
{
    public GameObject ply;
    public GameObject gameData;
    public GameObject computer;

    private void Start()
    {
        
    }
    private void OnMouseDown()
    {
        if (!enabled)
        {
            ply.GetComponent<PlayerMouseControll>().StopMove();
            Invoke("DelayActive", 0.2f);
        }

        else
        {
            ply.GetComponent<PlayerMouseControll>().StopMove();
            computer.SetActive(true);
            this.GetComponent<UItriggerOff>().TriggerOff();
            gameData.GetComponent<GameDataControl>().MainCameraGetItemOff();
            gameData.GetComponent<GameDataControl>().MainCameraUIcontrolOff();
        }
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

    private void DelayActive()
    {
        this.gameObject.SetActive(false);
    }

    public void TriggerOn()
    {
        gameData.GetComponent<GameDataControl>().MainCameraGetItemOn();
        gameData.GetComponent<GameDataControl>().MainCameraUIcontrolOn();
        ply.GetComponent<PlayerMouseControll>().MaintainPosition();
        ply.GetComponent<PlayerMouseControll>().StartMove();

    }
}
