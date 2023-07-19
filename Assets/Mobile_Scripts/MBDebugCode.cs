using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBDebugCode : MonoBehaviour
{
    delegate void DebugCode();
    DebugCode dg;
    public float TimeScale = 1.0f;
    public DialogueManager dialogueManager;
    public void print1()
    {
        Debug.Log("test!");
    }

    public void print2()
    {
        Debug.Log("test2");
    }

    public void print3() 
    {
        Debug.Log("test3");
    }
    // Update is called once per frame
    void Start()
    {
        dg = new DebugCode(print1);
        dg += new DebugCode(print2);
        dg += new DebugCode(print3);

        
        //Time.timeScale = 0f;
    }

    private void Update()
    {
        Time.timeScale = TimeScale;
    }
}
