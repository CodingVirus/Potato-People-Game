using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirCuitOn : MonoBehaviour
{
    public GameObject CirCuit;
    public GameObject machinedoor;
    public GameObject ply;

    private void OnMouseDown()
    {
        this.GetComponent<UItriggerOff>().TriggerOff();
        ply.GetComponent<PlayerMouseControll>().StopMove();
        CirCuit.SetActive(true);
        
        //Time.timeScale = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
