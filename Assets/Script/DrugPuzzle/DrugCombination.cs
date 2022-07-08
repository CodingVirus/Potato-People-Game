using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugCombination : MonoBehaviour
{
    public GameObject three, four, five, notice;
    private int threeCurrentState = 0;
    private int fiveCurrentState = 0;
    private int pow = 0;
    private int result = 0;

    public void NoticeInitialization()
    {
        notice.GetComponent<Text>().text = "";
    }
    public void ThreeButton()
    {
        if (fiveCurrentState >= 5)
        {
            Debug.Log("Pull!!!");
            notice.GetComponent<Text>().text = "Pull!!!";
            Invoke("NoticeInitialization", 1.0f);
        }

        fiveCurrentState = threeCurrentState + fiveCurrentState;
        pow = fiveCurrentState - 5; 

        if (pow < 0)
        {
            threeCurrentState = 0;
        }

        else if (pow >= 0)
        {
            if (fiveCurrentState > 5)
            {
                fiveCurrentState = 5;
            }
            threeCurrentState = pow;
        }


        five.GetComponent<Text>().text = fiveCurrentState + "L";
        three.GetComponent<Text>().text = threeCurrentState + "L";

      
    }

    public void InputThree()
    {
        threeCurrentState = 3;
        three.GetComponent<Text>().text = threeCurrentState + "L";
    }
    public void DumpThree()
    {
        threeCurrentState = 0;
        three.GetComponent<Text>().text = threeCurrentState + "L";
    }

    public void FourButton()
    {
        result = fiveCurrentState + threeCurrentState;

        if (result == 4)
        {
            four.GetComponent<Text>().text = result + "L";
            threeCurrentState = 0;
            fiveCurrentState = 0;
            five.GetComponent<Text>().text = fiveCurrentState + "L";
            three.GetComponent<Text>().text = threeCurrentState + "L";
        }

        else
        {
            Debug.Log("Error!!!");
            notice.GetComponent<Text>().text = "Error!!!";
            Invoke("NoticeInitialization", 1.0f);
        }
    }

    public void FiveButton()
    {
        if (threeCurrentState >= 3)
        {
            Debug.Log("Pull!!!");
            notice.GetComponent<Text>().text = "Pull!!!";
            Invoke("NoticeInitialization", 1.0f);
        }

        threeCurrentState = fiveCurrentState + threeCurrentState;
        pow = threeCurrentState - 3;

        if (threeCurrentState >= 8)
        {
            Debug.Log("Pull!!!");
            notice.GetComponent<Text>().text = "Pull!!!";
            Invoke("NoticeInitialization", 1.0f);
        }

        if (pow < 0)
        {
            fiveCurrentState = 0;
        }

        else if (pow >= 0)
        {
            if (threeCurrentState > 3)
            {
                threeCurrentState = 3;
            }
            fiveCurrentState = pow;
        }

        five.GetComponent<Text>().text = fiveCurrentState + "L";
        three.GetComponent<Text>().text = threeCurrentState + "L";

    }
    public void InputFive()
    {
        fiveCurrentState = 5;
        five.GetComponent<Text>().text = fiveCurrentState + "L";
    }
    public void DumpFive()
    {
        fiveCurrentState = 0;
        five.GetComponent<Text>().text = fiveCurrentState + "L";
    }

    public void Extraction()
    {
        if (result == 4)
        {
            result = 0;
            four.GetComponent<Text>().text = result + "L";

            Debug.Log("추출 성공!!");
            notice.GetComponent<Text>().text = "추출 성공!!!";
            Invoke("NoticeInitialization", 1.0f);
        }

        else
        {
            Debug.Log("추출 불가!!");
            notice.GetComponent<Text>().text = "추출 불가!!!";
            Invoke("NoticeInitialization", 1.0f);
        }
    }
}
