using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinerButton : MonoBehaviour
{
    public GameObject combinerUI;
    public GameObject ply;
    public GameObject gameData;
    private void OnMouseDown()
    {
        //ply.GetComponent<PlayerMouseControll>().StopMove();
        //this.gameObject.SetActive(false);
        gameData.GetComponent<GameDataControl>().PlayerMouseControllOff();
        Invoke("DelayActive", 0.2f);
        if (gameData.GetComponent<GameDataControl>().clueyQuestActive == true)
        {
            combinerUI.SetActive(true);
            this.gameObject.SetActive(false);
            transform.parent.GetComponent<UItriggerOff>().TriggerOff();
            ply.GetComponent<PlayerMouseControll>().StopMove();
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
}
