using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject MouseL;
    public GameObject MouseR;
    public GameObject MouseLR;
    public GameObject rope;
    public int mouseL;
    public int mouseR;
    public int mouseLR;
  
    public void Press_MouseL()
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            if (mouseL <= 5)
            {
                mouseL++;
                
            }
        }
        if (mouseL >= 5)
        {
            MouseL.SetActive(false);
            MouseR.SetActive(true);
            
        }
    }
    public void Press_MouseR()
    {
        if (Input.GetMouseButtonUp(1))
        {
            if (mouseR <= 5)
            {
                mouseR++;
               
            }

        }
        if (mouseR >= 5)
        {
            MouseR.SetActive(false);
            MouseLR.SetActive(true);
        }
    }
  
    public void Press_LR()
    {
        if (Input.GetMouseButtonUp(0) && Input.GetMouseButtonUp(1))
        {
            if (mouseLR <= 5)
            {
                mouseLR++;

            }

        }
        if (mouseLR >= 5)
        {
            MouseLR.SetActive(false);
            rope.SetActive(false);
            Time.timeScale = 1;

        }
    }



    void Start()
    {
        Time.timeScale = 0;

    }

    
    void Update()
    {
        Press_MouseL();
       
            Press_MouseR();
            
                Press_LR();
         

       
    

    }
}
