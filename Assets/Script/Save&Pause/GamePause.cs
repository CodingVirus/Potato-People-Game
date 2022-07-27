using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject PausePanel;
    bool activePausePanel = false;
    bool isPause;
   
    void Start()
    {
       
        PausePanel.SetActive(activePausePanel);
        isPause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            activePausePanel = !activePausePanel;
            PausePanel.SetActive(activePausePanel);
            Time.timeScale = 0;
            
           
           
        }
        if (activePausePanel == false)
        {
            Time.timeScale = 1;
        }
           
        

    }
}
