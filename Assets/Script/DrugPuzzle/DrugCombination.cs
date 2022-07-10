using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrugCombination : MonoBehaviour
{
    public GameObject three, four, five, notice;
    public GameObject threeSprite, fourSprite, fiveSprite;

    public Sprite[] spritesFour = new Sprite[2];
    public Sprite[] spritesThree = new Sprite[4];
    public Sprite[] spritesFive = new Sprite[6];

    private int threeCurrentState = 0;
    private int fiveCurrentState = 0;
    private int pow = 0;
    private int result = 0;

    private void Update()
    {
        ChangeThreeSprite();
        ChageFiveSprite();
    }
    public void ChangeThreeSprite()
    {
        if (threeCurrentState == 0)
        {
            threeSprite.GetComponent<Image>().sprite = spritesThree[0];
        }

        else if (threeCurrentState == 1)
        {
            threeSprite.GetComponent<Image>().sprite = spritesThree[1];
        }

        else if (threeCurrentState == 2)
        {
            threeSprite.GetComponent<Image>().sprite = spritesThree[2];
        }

        else if (threeCurrentState == 3)
        {
            threeSprite.GetComponent<Image>().sprite = spritesThree[3];
        }
    }

    public void ChageFiveSprite()
    {
        if (fiveCurrentState == 0)
        {
            fiveSprite.GetComponent<Image>().sprite = spritesFive[0];
        }

        else if (fiveCurrentState == 1)
        {
            fiveSprite.GetComponent<Image>().sprite = spritesFive[1];
        }

        else if (fiveCurrentState == 2)
        {
            fiveSprite.GetComponent<Image>().sprite = spritesFive[2];
        }

        else if (fiveCurrentState == 3)
        {
            fiveSprite.GetComponent<Image>().sprite = spritesFive[3];
        }

        else if (fiveCurrentState == 4)
        {
            fiveSprite.GetComponent<Image>().sprite = spritesFive[4];
        }

        else if (fiveCurrentState == 5)
        {
            fiveSprite.GetComponent<Image>().sprite = spritesFive[5];
        }
    }
    public void NoticeInitialization()
    {
        notice.GetComponent<Text>().text = "";
    }
    public void ThreeButton()
    {
        if (fiveCurrentState >= 5)
        {
            //Debug.Log("Pull!!!");
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
            fourSprite.GetComponent<Image>().sprite = spritesFour[1];
            four.GetComponent<Text>().text = result + "L";
            threeCurrentState = 0;
            fiveCurrentState = 0;
            five.GetComponent<Text>().text = fiveCurrentState + "L";
            three.GetComponent<Text>().text = threeCurrentState + "L";
        }

        else
        {
            //Debug.Log("Error!!!");
            notice.GetComponent<Text>().text = "Error!!!";
            Invoke("NoticeInitialization", 1.0f);
        }
    }

    public void FiveButton()
    {
        if (threeCurrentState >= 3)
        {
           // Debug.Log("Pull!!!");
            notice.GetComponent<Text>().text = "Pull!!!";
            Invoke("NoticeInitialization", 1.0f);
        }

        threeCurrentState = fiveCurrentState + threeCurrentState;
        pow = threeCurrentState - 3;

        if (threeCurrentState >= 8)
        {
            //Debug.Log("Pull!!!");
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
            fourSprite.GetComponent<Image>().sprite = spritesFour[0];
            result = 0;
            four.GetComponent<Text>().text = result + "L";

            //Debug.Log("추출 성공!!");
            notice.GetComponent<Text>().text = "추출 성공!!!";
            Invoke("NoticeInitialization", 1.0f);
        }

        else
        {
            //Debug.Log("추출 불가!!");
            notice.GetComponent<Text>().text = "추출 불가!!!";
            Invoke("NoticeInitialization", 1.0f);
        }
    }
}
