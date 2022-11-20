using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumLockOn : MonoBehaviour
{
    public GameObject ply;
    public GameObject NumLock;
    public GameObject ObservationAdoor;
    private void OnMouseDown()
    {
        NumLock.SetActive(true);
        ply.GetComponent<PlayerMouseControll>().MaintainPosition();
        ply.GetComponent<PlayerMouseControll>().StopMove();
        //ObservationAdoor.SetActive(false);
        Time.timeScale = 0;
        this.GetComponent<UItriggerOff>().TriggerOff();
    }

    public void Exit()
    {
        NumLock.SetActive(false);
        //ObservationAdoor.SetActive(true);
        Time.timeScale = 1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
