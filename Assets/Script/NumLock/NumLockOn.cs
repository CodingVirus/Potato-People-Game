using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumLockOn : MonoBehaviour
{
    public GameObject NumLock;
    public GameObject ObservationAdoor;
    private void OnMouseDown()
    {
        NumLock.SetActive(true);
        ObservationAdoor.SetActive(false);
        Time.timeScale = 0;
    }

    public void Exit()
    {
        NumLock.SetActive(false);
        ObservationAdoor.SetActive(true);
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
