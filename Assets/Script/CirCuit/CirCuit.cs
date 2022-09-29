using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirCuit : MonoBehaviour
{
    public GameObject CrossWire;
    public GameObject ParallWire;
    public GameObject SlashDownWire;
    public GameObject SlashUpWire;
    public GameObject Circuit;
    public GameObject machineDoor;
    public static int a1;
    public static int a2;
    public static int a3;
    public static int b1;
    public static int b3;
    public static int c2;
    public static int c3;


    [SerializeField]
    List<GameObject> WireList = new List<GameObject>();

    public void WireAdd()
    {
        WireList.Add(CrossWire);
        WireList.Add(ParallWire);
        WireList.Add(SlashDownWire);
        WireList.Add(SlashUpWire);
    }
    public void WireActiveA1()
    {
        WireList[a1].SetActive(true);
        if (a1 >= 1)
        {
            WireList[a1 - 1].SetActive(false);
        }
        if (a1 == 0)
        {
            WireList[3].SetActive(false);
        }
     }
    public void WireChangeA1()
    {
        WireActiveA1();
        a1++;
        if(a1 >= 4)
        {
            a1 = 0;
           
        }
        
            
    }
    public void WireActiveA2()
    {
        WireList[a2].SetActive(true);
        if (a2 >= 1)
        {
            WireList[a2 - 1].SetActive(false);
        }
        if (a2 == 0)
        {
            WireList[3].SetActive(false);
        }
    }
    public void WireChangeA2()
    {
        WireActiveA2();
        a2++;
        if (a2 >= 4)
        {
            a2 = 0;

        }


    }
    public void WireActiveA3()
    {
        WireList[a3].SetActive(true);
        if (a3 >= 1)
        {
            WireList[a3 - 1].SetActive(false);
        }
        if (a3 == 0)
        {
            WireList[3].SetActive(false);
        }
    }
    public void WireChangeA3()
    {
        WireActiveA3();
        a3++;
        if (a3 >= 4)
        {
            a3 = 0;

        }


    }
    public void WireActiveB1()
    {
        WireList[b1].SetActive(true);
        if (b1 >= 1)
        {
            WireList[b1 - 1].SetActive(false);
        }
        if (b1 == 0)
        {
            WireList[3].SetActive(false);
        }
    }
    public void WireChangeB1()
    {
        WireActiveB1();
        b1++;
        if (b1 >= 4)
        {
            b1 = 0;

        }


    }
    public void WireActiveB3()
    {
        WireList[b3].SetActive(true);
        if (b3 >= 1)
        {
            WireList[b3 - 1].SetActive(false);
        }
        if (b3 == 0)
        {
            WireList[3].SetActive(false);
        }
    }
    public void WireChangeB3()
    {
        WireActiveB3();
        b3++;
        if (b3 >= 4)
        {
            b3 = 0;

        }


    }
    public void WireActiveC2()
    {
        WireList[c2].SetActive(true);
        if (c2 >= 1)
        {
            WireList[c2 - 1].SetActive(false);
        }
        if (c2 == 0)
        {
            WireList[3].SetActive(false);
        }
    }
    public void WireChangeC2()
    {
        WireActiveC2();
        c2++;
        if (c2 >= 4)
        {
            c2 = 0;

        }


    }
    public void WireActiveC3()
    {
        WireList[c3].SetActive(true);
        if (c3 >= 1)
        {
            WireList[c3 - 1].SetActive(false);
        }
        if (c3 == 0)
        {
            WireList[3].SetActive(false);
        }
    }
    public void WireChangeC3()
    {
        WireActiveC3();
        c3++;
        if (c3 >= 4)
        {
            c3 = 0;

        }


    }
    public void WireCheck()
    {
        if(a1 == 2 && a2 == 1 && a3 == 0 && b1 == 2 && b3 == 2 && c2 == 3 && c3 ==2)
        {
            Debug.Log("UnLock");
            Circuit.SetActive(false);
            machineDoor.SetActive(true);
            Time.timeScale = 1;
        }
    }
   
    void Start()
    {
        WireAdd();

    }

    
    void Update()
    {
      
    }
}
