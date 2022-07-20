using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class DigitalDisplay : MonoBehaviour
{
    //public static Action pw;

    [SerializeField]
    public Text codeText;
    public GameObject pad;
    public GameObject player;
    //public bool uiOn = false;

    private string codeTextValue;    

    private void Start() 
    {
        codeTextValue = "";
    }

    private void Update() 
    {
        CursorController.instance.Default();
    }

    public void Click()
    {
        pad.SetActive(true);
    }

    public void AddDigitToCodeTextValue(string digitEntered)
    {
            codeTextValue += digitEntered;
            codeText.text = codeTextValue;
            if(codeTextValue.Length > 4)
            {
                ResetDisplay();
            }
    }

    public void CheckResults()
    {
        if(codeTextValue == "0921")
        {
            Debug.Log("Correct!");
            pad.SetActive(false);
            //uiOn = false;
            Destroy(gameObject);
            Debug.Log("Destroy");
            Invoke("StartToMove", 0.5f);
        }
        else
        {
            Debug.Log("Wrong!");
            ResetDisplay();
        }
    }

    public void ResetDisplay()
    {
        codeTextValue = "";
        codeText.text = codeTextValue;
    }

    public void CloseDisplay()
    {
        ResetDisplay();
        pad.SetActive(false);
        //uiOn = false;
        Invoke("StartToMove", 0.3f);
    }

    private void StartToMove()
    {
        player.GetComponent<PlayerMouseControll>().target = player.transform.position;
        PlayerMouseControll.instance.StartMove();
    }
    
}
