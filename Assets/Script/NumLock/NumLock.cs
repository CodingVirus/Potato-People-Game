using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumLock : MonoBehaviour
{
    public GameObject Num1;
    public GameObject Num2;
    public GameObject Num3;
    public GameObject Num4;
    public GameObject Num5;
    public GameObject Num6;
    public GameObject Num7;
    public GameObject Num8;
    public GameObject Num9;
    public GameObject Num0;
   
    [SerializeField]
    List<GameObject> NumList = new List<GameObject>();
    public GameObject numLock;
    public GameObject observationAdoor;
    public static int Locknum1;
    public static int Locknum2;
    public static int Locknum3;
    public static int Locknum4;
    public static int SecretNum1 = 0;
    public static int SecretNum2 = 8;
    public static int SecretNum3 = 2;
    public static int SecretNum4 = 6;
    private AudioSource NumChange;
    [SerializeField] private AudioClip[] clip;
    
    


    public void NumAdd()
    {
        NumList.Add(Num0);
        NumList.Add(Num1);
        NumList.Add(Num2);
        NumList.Add(Num3);
        NumList.Add(Num4);
        NumList.Add(Num5);
        NumList.Add(Num6);
        NumList.Add(Num7);
        NumList.Add(Num8);
        NumList.Add(Num9);
    }
    public void LockNum1Active()
    {

        {
            NumList[Locknum1].SetActive(true);
            if (Locknum1 >= 1)
            {
                NumList[Locknum1 - 1].SetActive(false);
            }
            if (Locknum1 == 0)
            {
                NumList[9].SetActive(false);
            }
        }
    }
    public void LockNum1Change()
    {
        if (Locknum1 == SecretNum1)
        {
            NumChange.clip = clip[1];
            NumChange.Play();
        }
        else
        {
            NumChange.clip = clip[0];
            NumChange.Play();
        }
        LockNum1Active();
        Locknum1++;
        
        if (Locknum1 >= 10)
        {
            Locknum1 = 0;
        }
       
    }
    public void LockNum2Active()
    {

        {
            NumList[Locknum2].SetActive(true);
            if (Locknum2 >= 1)
            {
                NumList[Locknum2 - 1].SetActive(false);
            }
            if (Locknum2 == 0)
            {
                NumList[9].SetActive(false);
            }
        }
    }
    public void LockNum2Change()
    {
        if (Locknum2 == SecretNum2)
        {
            NumChange.clip = clip[1];
            NumChange.Play();
        }
        else
        {
            NumChange.clip = clip[0];
            NumChange.Play();
        }
        LockNum2Active();
        Locknum2++;
       
        if (Locknum2 >= 10)
        {
            Locknum2 = 0;
        }
        
    }
    public void LockNum3Active()
    {

        {
            NumList[Locknum3].SetActive(true);
            if (Locknum3 >= 1)
            {
                NumList[Locknum3 - 1].SetActive(false);
            }
            if (Locknum3 == 0)
            {
                NumList[9].SetActive(false);
            }
        }
    }
    public void LockNum3Change()
    {
        if (Locknum3 == SecretNum3)
        {
            NumChange.clip = clip[1];
            NumChange.Play();
        }
        else
        {
            NumChange.clip = clip[0];
            NumChange.Play();
        }
        LockNum3Active();
        Locknum3++;
     
        if (Locknum3 >= 10)
        {
            Locknum3 = 0;
        }
       
    }
    public void LockNum4Active()
    {

        {
            NumList[Locknum4].SetActive(true);
            if (Locknum4 >= 1)
            {
                NumList[Locknum4 - 1].SetActive(false);
            }
            if (Locknum4 == 0)
            {
                NumList[9].SetActive(false);
            }
        }
    }
    public void LockNum4Change()
    {
        if (Locknum4 == SecretNum4)
        {
            NumChange.clip = clip[1];
            NumChange.Play();
        }
        else
        {
            NumChange.clip = clip[0];
            NumChange.Play();
        }
        LockNum4Active();
        Locknum4++;
        
        if (Locknum4 >= 10)
        {
            Locknum4 = 0;
        }
        
    }
   
    public void LockExit()
    {
        numLock.SetActive(false);
        observationAdoor.SetActive(true);
        Time.timeScale = 1;
    }
    public void UnLock()
    {
        if (Locknum1 == 1 && Locknum2 == 9 && Locknum3 == 3 && Locknum4 == 7)
        {
            numLock.SetActive(false);
            observationAdoor.SetActive(true);
            Time.timeScale = 1;
        }
    }
   
  
    void Start()
    {
        NumAdd();
        NumChange = GetComponent<AudioSource>();
      

    }

    
    void Update()
    {
        
    }
}
