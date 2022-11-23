using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public GameObject W;
    public GameObject A;
    public GameObject D;
    public GameObject rope;
    public GameObject LeftRight;
    public int w;
    public int a;
    public int d;
    public int leftRight;
  



    


    public void Press_W()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (w <= 5)
            {
                w++;
                
            }
        }
        if (w >= 5)
        {
            W.SetActive(false);
            A.SetActive(true);
            
        }
    }
    public void Press_A()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (a <= 5)
            {
                a++;
               
            }

        }
        if (a >= 5)
        {
            A.SetActive(false);
            D.SetActive(true);
        }
    }
    public void Press_D()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (d <= 5)
            {
                d++;
                
            }

        }
        if (d >= 5)
        {
            D.SetActive(false);
            LeftRight.SetActive(true);

        }
    }
    public void Press_LR()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (leftRight <= 5)
            {
                leftRight++;

            }

        }
        if (leftRight >= 5)
        {
            LeftRight.SetActive(false);
            rope.SetActive(false);

        }
    }



    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        Press_W();
        
        Press_A();
        Press_D();
        Press_LR();
       
    

    }
}
