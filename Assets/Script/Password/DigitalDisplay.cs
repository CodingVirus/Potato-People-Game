using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class DigitalDisplay : MonoBehaviour
{
    public static Action pw;

    [SerializeField]
    public Text codeText;
    public GameObject pad;

    private string codeTextValue;

    private void Start() 
    {
        pw = () => {Click();};
        codeTextValue = "";
        pad.SetActive(false);
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
            Destroy(gameObject);
            Debug.Log("Destroy");
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
    }
    
}
