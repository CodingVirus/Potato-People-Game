using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirCuitOn : MonoBehaviour
{
    public GameObject CirCuit;
    public GameObject machinedoor;

    private void OnMouseDown()
    {
        CirCuit.SetActive(true);
        machinedoor.SetActive(false);
        Time.timeScale = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
