using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    public GameObject [] Myhome;

    private Manage Manage;
    public int Targetnum;
    public GameObject Output;
    public GameObject Hand;
    public GameObject[] Myparts;
    public int Num;

    public GameObject Mytarget2;
    private Target Cleantarget;
    public bool Dest;
    void Start()
    {
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        Cleantarget = Mytarget2.GetComponent<Target>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Dest == true)
        {
            Destroy(Myparts[0]);
            Destroy(Myparts[1]);
            Destroy(Myparts[2]);
            Destroy(Myparts[3]);
            Destroy(Myparts[4]);
            Destroy(Myparts[5]);
            Destroy(Myparts[6]);
            Destroy(Myparts[7]);
            Destroy(Myparts[8]);
            Destroy(Myparts[9]);
            Destroy(Myparts[10]);
            Destroy(Myparts[11]);
            Destroy(Myparts[12]);
            Destroy(Myparts[13]);
            Destroy(Myparts[14]);
            Destroy(Myparts[15]);
            Dest = false;
        }
        if (Myparts[0] != null)
        {
           Myparts[0].GetComponent<Pipe>().Num = 0;
        }
        if (Myparts[1] != null)
        {
            Myparts[1].GetComponent<Pipe>().Num = 1;
        }
        if (Myparts[2] != null)
        {
            Myparts[2].GetComponent<Pipe>().Num = 2;
        }
        if (Myparts[3] != null)
        {
            Myparts[3].GetComponent<Pipe>().Num = 3;
        }
        if (Myparts[4] != null)
        {
            Myparts[4].GetComponent<Pipe>().Num = 4;
        }
        if (Myparts[5] != null)
        {
            Myparts[5].GetComponent<Pipe>().Num = 5;
        }
        if (Myparts[6] != null)
        {
            Myparts[6].GetComponent<Pipe>().Num = 6;
        }
        if (Myparts[7] != null)
        {
            Myparts[7].GetComponent<Pipe>().Num = 7;
        }
        if (Myparts[8] != null)
        {
            Myparts[8].GetComponent<Pipe>().Num = 8;
        }
        if (Myparts[9] != null)
        {
            Myparts[9].GetComponent<Pipe>().Num = 9;
        }
        if (Myparts[10] != null)
        {
            Myparts[10].GetComponent<Pipe>().Num = 10;
        }
        if (Myparts[11] != null)
        {
            Myparts[11].GetComponent<Pipe>().Num = 11;
        }
        if (Myparts[12] != null)
        {
            Myparts[12].GetComponent<Pipe>().Num = 12;
        }
        if (Myparts[13] != null)
        {
            Myparts[13].GetComponent<Pipe>().Num = 13;
        }
        if (Myparts[14] != null)
        {
            Myparts[14].GetComponent<Pipe>().Num = 14;
        }
        if (Myparts[15] != null)
        {
            Myparts[15].GetComponent<Pipe>().Num = 15;
        }

    }
    void OnMouseDown()
    {
        if (Manage.Win == false)
        {
            Output = Instantiate(Hand, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            Output.transform.parent = transform;
            Output.GetComponent<Movehand>().Mymanage = gameObject;
            Cleantarget.Dest = true;
        }
    }
    void OnMouseUp() {
        if (Manage.Win == false)
        {
            if (Output != null)
            {
                Manage.Movehand = false;
                Manage.Check();
                Destroy(Output);
            }
        }
    }
}
