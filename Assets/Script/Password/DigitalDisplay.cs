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

    private string codeTextValue;
    public CanvasGroup passwordgroup;

    public void Click()
    {
        passwordgroup.alpha = 1;
    }

    private void Start() 
    {
        pw = () => {Click();};
        codeTextValue = "";
        passwordgroup.alpha = 0;
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
            passwordgroup.alpha = 0;
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
        passwordgroup.alpha = 0;
    }
    
}
