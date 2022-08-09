using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movehand : MonoBehaviour {
    //------------My color 1=yellow
    //------------My color 2=Red
    //------------My color 3=Blue
    //------------My color 4=Green
    public int Mycolor;

    public GameObject Output;
    public GameObject Pipe;
    public GameObject Mymanage;
    private Manage Manage;
    public LayerMask layerMask;

    private Target target;
    private Rigidbody2D Rb;

    public bool A;
    public GameObject coll2;
    private int Once;
    // Start is called before the first frame update
    void Start() {
        Rb = GetComponent<Rigidbody2D>();
        target = Mymanage.GetComponent<Target>();
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        Manage.Movehand = true;

        Manage.Hands[Mycolor] = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mospos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        Vector3 obj = Camera.main.ScreenToWorldPoint(mospos);
       
       transform.position=Vector3.Lerp(transform.position, obj , Time.deltaTime * 10);
        // transform.position = obj;
      
    }

    void FixedUpdate() {
      
    


      
    }
    void OnMouseDrag()
    {
      
    }
    void OnTriggerStay2D(Collider2D coll)
    {
      

    
        if (coll.gameObject.tag == "Home")
        {
            coll2 = coll.gameObject;
      
            if (coll2.GetComponent<Home>().Mypipe != null)
            {

                if (coll2.GetComponent<Home>().Mypipe.GetComponent<Pipe>().Color == Mycolor)
                {
                    coll2.GetComponent<Home>().Dest = true;
                    if (Manage.Sound == 0)
                    {
                        GameObject.Find("Cutmp3").GetComponent<AudioSource>().Play();
                    }
                }
                else if (coll2.GetComponent<Home>().Mypipe.GetComponent<Pipe>().Color != Mycolor)
                {
                    coll2.transform.GetComponent<Home>().Changecolor();
                   
                }
            }
            if (coll2.GetComponent<Home>().Mypipe == null)
            {

                if (target.Myparts[0] == null || target.Myparts[1] == null || target.Myparts[2] == null || target.Myparts[3] == null
        || target.Myparts[4] == null || target.Myparts[5] == null || target.Myparts[6] == null || target.Myparts[7] == null
        || target.Myparts[8] == null || target.Myparts[9] == null || target.Myparts[10] == null || target.Myparts[11] == null || target.Myparts[12] == null || target.Myparts[13] == null || target.Myparts[14] == null || target.Myparts[15] == null)
                {
                   

                    if (target.Myparts[0] == null)
                {
                    Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                        Once = 0;
                        target.Myhome[0] = coll2.gameObject;
                    target.Myparts[0] = Output;
                }
                else if (target.Myparts[0] != null && target.Myparts[1] == null)
                {
                    if ((coll2.transform.position.y == target.Myhome[0].transform.position.y) || (coll2.transform.position.x == target.Myhome[0].transform.position.x))
                    {
                        if ((target.Myhome[0].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[0].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                ((target.Myhome[0].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[0].transform.position.y <= coll2.transform.position.y + 2f)))
                        {
                            Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[1] = coll2.gameObject;
                            if (coll2.transform.position.x > target.Myparts[0].transform.position.x + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            if (coll2.transform.position.y > target.Myparts[0].transform.position.y + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 90);
                            }
                            if (coll2.transform.position.y < target.Myparts[0].transform.position.y - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 270);
                            }
                            if (coll2.transform.position.x < target.Myparts[0].transform.position.x - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 180);
                            }
                            target.Myparts[1] = Output;
                        }
                     
                    }

                }

                else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] == null)
                {

                    if ((coll2.transform.position.y == target.Myhome[1].transform.position.y) || (coll2.transform.position.x == target.Myhome[1].transform.position.x))
                    {
                        if ((target.Myhome[1].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[1].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                 ((target.Myhome[1].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[1].transform.position.y <= coll2.transform.position.y + 2f)))
                        {
                            Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[2] = coll2.gameObject;
                            if (coll2.transform.position.x > target.Myparts[1].transform.position.x + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x - 1f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            if (coll2.transform.position.y > target.Myparts[1].transform.position.y + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 90);
                            }
                            if (coll2.transform.position.y < target.Myparts[1].transform.position.y - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 270);
                            }
                            if (coll2.transform.position.x < target.Myparts[1].transform.position.x - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 180);
                            }
                            target.Myparts[2] = Output;
                        }
                     
                    }


                }
                else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] == null)
                {

                    if ((coll2.transform.position.y == target.Myhome[2].transform.position.y) || (coll2.transform.position.x == target.Myhome[2].transform.position.x))
                    {
                        if ((target.Myhome[2].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[2].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                 ((target.Myhome[2].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[2].transform.position.y <= coll2.transform.position.y + 2f)))
                        {
                            Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[3] = coll2.gameObject;
                            if (coll2.transform.position.x > target.Myparts[2].transform.position.x + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            if (coll2.transform.position.y > target.Myparts[2].transform.position.y + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 90);
                            }
                            if (coll2.transform.position.y < target.Myparts[2].transform.position.y - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 270);
                            }
                            if (coll2.transform.position.x < target.Myparts[2].transform.position.x - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 180);
                            }
                            target.Myparts[3] = Output;
                        }
                      
                    }


                }
                else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null && target.Myparts[4] == null)
                {

                    if ((coll2.transform.position.y == target.Myhome[3].transform.position.y) || (coll2.transform.position.x == target.Myhome[3].transform.position.x))
                    {
                        if ((target.Myhome[3].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[3].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                 ((target.Myhome[3].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[3].transform.position.y <= coll2.transform.position.y + 2f)))
                        {
                            Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[4] = coll2.gameObject;
                            if (coll2.transform.position.x > target.Myparts[3].transform.position.x + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            if (coll2.transform.position.y < target.Myparts[3].transform.position.y - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 270);
                            }
                            if (coll2.transform.position.y > target.Myparts[3].transform.position.y + 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 90);
                            }
                            if (coll2.transform.position.x < target.Myparts[3].transform.position.x - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 180);
                            }
                            target.Myparts[4] = Output;
                        }
                      
                    }
                }
                else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null && target.Myparts[4] != null && target.Myparts[5] == null)
                {
                    if ((coll2.transform.position.y == target.Myhome[4].transform.position.y) || (coll2.transform.position.x == target.Myhome[4].transform.position.x))
                    {
                        if ((target.Myhome[4].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[4].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                ((target.Myhome[4].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[4].transform.position.y <= coll2.transform.position.y + 2f)))
                        {
                            Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[5] = coll2.gameObject;
                            if (coll2.transform.position.x > target.Myparts[4].transform.position.x + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            if (coll2.transform.position.y < target.Myparts[4].transform.position.y - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 270);
                            }
                            if (coll2.transform.position.y > target.Myparts[4].transform.position.y + 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 90);
                            }
                            if (coll2.transform.position.x < target.Myparts[4].transform.position.x - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 180);

                            }
                            target.Myparts[5] = Output;
                        }
                      
                    }
                }
                else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null
                    && target.Myparts[4] != null && target.Myparts[5] != null && target.Myparts[6] == null)
                {
                    if ((coll2.transform.position.y == target.Myhome[5].transform.position.y) || (coll2.transform.position.x == target.Myhome[5].transform.position.x))
                    {
                        if ((target.Myhome[5].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[5].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                ((target.Myhome[5].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[5].transform.position.y <= coll2.transform.position.y + 2f)))
                        {
                            Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[6] = coll2.gameObject;
                            if (coll2.transform.position.x > target.Myparts[5].transform.position.x + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            if (coll2.transform.position.y < target.Myparts[5].transform.position.y - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 270);
                            }
                            if (coll2.transform.position.y > target.Myparts[5].transform.position.y + 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 90);
                            }
                            if (coll2.transform.position.x < target.Myparts[5].transform.position.x - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 180);

                            }
                            target.Myparts[6] = Output;
                        }
                      
                    }
                }
                else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null
                  && target.Myparts[4] != null && target.Myparts[5] != null && target.Myparts[6] != null && target.Myparts[7] == null)
                {
                    if ((coll2.transform.position.y == target.Myhome[6].transform.position.y) || (coll2.transform.position.x == target.Myhome[6].transform.position.x))
                    {
                        if ((target.Myhome[6].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[6].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                ((target.Myhome[6].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[6].transform.position.y <= coll2.transform.position.y + 2f)))
                        {
                            Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[7] = coll2.gameObject;
                            if (coll2.transform.position.x > target.Myparts[6].transform.position.x + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            if (coll2.transform.position.y < target.Myparts[6].transform.position.y - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 270);
                            }
                            if (coll2.transform.position.y > target.Myparts[6].transform.position.y + 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 90);
                            }
                            if (coll2.transform.position.x < target.Myparts[6].transform.position.x - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 180);

                            }
                            target.Myparts[7] = Output;
                        }
                       
                    }
                }
                else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null
                 && target.Myparts[4] != null && target.Myparts[5] != null && target.Myparts[6] != null && target.Myparts[7] != null && target.Myparts[8] == null)
                {
                    if ((coll2.transform.position.y == target.Myhome[7].transform.position.y) || (coll2.transform.position.x == target.Myhome[7].transform.position.x))
                    {
                        if ((target.Myhome[7].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[7].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                ((target.Myhome[7].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[7].transform.position.y <= coll2.transform.position.y + 2f)))
                        {
                            Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[8] = coll2.gameObject;
                            if (coll2.transform.position.x > target.Myparts[7].transform.position.x + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            if (coll2.transform.position.y < target.Myparts[7].transform.position.y - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 270);
                            }
                            if (coll2.transform.position.y > target.Myparts[7].transform.position.y + 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 90);
                            }
                            if (coll2.transform.position.x < target.Myparts[7].transform.position.x - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 180);

                            }
                            target.Myparts[8] = Output;
                        }
                     
                    }
                }
                else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null
                && target.Myparts[4] != null && target.Myparts[5] != null && target.Myparts[6] != null && target.Myparts[7] != null
                && target.Myparts[8] != null && target.Myparts[9] == null)
                {
                    if ((coll2.transform.position.y == target.Myhome[8].transform.position.y) || (coll2.transform.position.x == target.Myhome[8].transform.position.x))
                    {
                        if ((target.Myhome[8].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[8].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                ((target.Myhome[8].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[8].transform.position.y <= coll2.transform.position.y + 2f)))
                        {
                            Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[9] = coll2.gameObject;
                            if (coll2.transform.position.x > target.Myparts[8].transform.position.x + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            if (coll2.transform.position.y < target.Myparts[8].transform.position.y - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 270);
                            }
                            if (coll2.transform.position.y > target.Myparts[8].transform.position.y + 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 90);
                            }
                            if (coll2.transform.position.x < target.Myparts[8].transform.position.x - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 180);

                            }
                            target.Myparts[9] = Output;
                        }
                         
                    }
                }
                else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null
         && target.Myparts[4] != null && target.Myparts[5] != null && target.Myparts[6] != null && target.Myparts[7] != null
         && target.Myparts[8] != null && target.Myparts[9] != null && target.Myparts[10] == null)
                {
                    if ((coll2.transform.position.y == target.Myhome[9].transform.position.y) || (coll2.transform.position.x == target.Myhome[9].transform.position.x))
                    {
                        if ((target.Myhome[9].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[9].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                ((target.Myhome[9].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[9].transform.position.y <= coll2.transform.position.y + 2f)))

                        {
                            Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[10] = coll2.gameObject;
                            if (coll2.transform.position.x > target.Myparts[9].transform.position.x + 1f)
                            {

                                Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 0);
                            }
                            if (coll2.transform.position.y < target.Myparts[9].transform.position.y - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 270);
                            }
                            if (coll2.transform.position.y > target.Myparts[9].transform.position.y + 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 90);
                            }
                            if (coll2.transform.position.x < target.Myparts[9].transform.position.x - 1f)
                            {
                                Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                Output.transform.eulerAngles = new Vector3(0, 0, 180);

                            }
                            target.Myparts[10] = Output;
                        }
                         
                    }
                }


                    else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null
        && target.Myparts[4] != null && target.Myparts[5] != null && target.Myparts[6] != null && target.Myparts[7] != null
        && target.Myparts[8] != null && target.Myparts[9] != null && target.Myparts[10] != null && target.Myparts[11] == null)
                    {
                        if ((coll2.transform.position.y == target.Myhome[10].transform.position.y) || (coll2.transform.position.x == target.Myhome[10].transform.position.x))
                        {
                            if ((target.Myhome[10].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[10].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                    ((target.Myhome[10].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[10].transform.position.y <= coll2.transform.position.y + 2f)))

                            {
                                Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[11] = coll2.gameObject;
                                if (coll2.transform.position.x > target.Myparts[10].transform.position.x + 1f)
                                {

                                    Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                                if (coll2.transform.position.y < target.Myparts[10].transform.position.y - 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 270);
                                }
                                if (coll2.transform.position.y > target.Myparts[10].transform.position.y + 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 90);
                                }
                                if (coll2.transform.position.x < target.Myparts[10].transform.position.x - 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 180);

                                }
                                target.Myparts[11] = Output;
                            }

                        }
                    }
                    else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null
&& target.Myparts[4] != null && target.Myparts[5] != null && target.Myparts[6] != null && target.Myparts[7] != null
&& target.Myparts[8] != null && target.Myparts[9] != null && target.Myparts[10] != null && target.Myparts[11] != null && target.Myparts[12] == null)
                    {
                        if ((coll2.transform.position.y == target.Myhome[11].transform.position.y) || (coll2.transform.position.x == target.Myhome[11].transform.position.x))
                        {
                            if ((target.Myhome[11].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[11].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                    ((target.Myhome[11].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[11].transform.position.y <= coll2.transform.position.y + 2f)))

                            {
                                Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[12] = coll2.gameObject;
                                if (coll2.transform.position.x > target.Myparts[11].transform.position.x + 1f)
                                {

                                    Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                                if (coll2.transform.position.y < target.Myparts[11].transform.position.y - 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 270);
                                }
                                if (coll2.transform.position.y > target.Myparts[11].transform.position.y + 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 90);
                                }
                                if (coll2.transform.position.x < target.Myparts[11].transform.position.x - 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 180);

                                }
                                target.Myparts[12] = Output;
                            }

                        }
                    }
                    else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null
&& target.Myparts[4] != null && target.Myparts[5] != null && target.Myparts[6] != null && target.Myparts[7] != null
&& target.Myparts[8] != null && target.Myparts[9] != null && target.Myparts[10] != null && target.Myparts[11] != null && target.Myparts[12] != null && target.Myparts[13] == null)
                    {
                        if ((coll2.transform.position.y == target.Myhome[12].transform.position.y) || (coll2.transform.position.x == target.Myhome[12].transform.position.x))
                        {
                            if ((target.Myhome[12].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[12].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                    ((target.Myhome[12].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[12].transform.position.y <= coll2.transform.position.y + 2f)))

                            {
                                Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[13] = coll2.gameObject;
                                if (coll2.transform.position.x > target.Myparts[12].transform.position.x + 1f)
                                {

                                    Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                                if (coll2.transform.position.y < target.Myparts[12].transform.position.y - 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 270);
                                }
                                if (coll2.transform.position.y > target.Myparts[12].transform.position.y + 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 90);
                                }
                                if (coll2.transform.position.x < target.Myparts[12].transform.position.x - 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 180);

                                }
                                target.Myparts[13] = Output;
                            }

                        }
                    }

                    else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null
&& target.Myparts[4] != null && target.Myparts[5] != null && target.Myparts[6] != null && target.Myparts[7] != null
&& target.Myparts[8] != null && target.Myparts[9] != null && target.Myparts[10] != null && target.Myparts[11] != null && target.Myparts[12] != null && target.Myparts[13] != null && target.Myparts[14] == null)
                    {
                        if ((coll2.transform.position.y == target.Myhome[13].transform.position.y) || (coll2.transform.position.x == target.Myhome[13].transform.position.x))
                        {
                            if ((target.Myhome[13].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[13].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                    ((target.Myhome[13].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[13].transform.position.y <= coll2.transform.position.y + 2f)))

                            {
                                Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[14] = coll2.gameObject;
                                if (coll2.transform.position.x > target.Myparts[13].transform.position.x + 1f)
                                {

                                    Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                                if (coll2.transform.position.y < target.Myparts[13].transform.position.y - 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 270);
                                }
                                if (coll2.transform.position.y > target.Myparts[13].transform.position.y + 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 90);
                                }
                                if (coll2.transform.position.x < target.Myparts[13].transform.position.x - 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 180);

                                }
                                target.Myparts[14] = Output;
                            }

                        }
                    }
                    else if (target.Myparts[0] != null && target.Myparts[1] != null && target.Myparts[2] != null && target.Myparts[3] != null
&& target.Myparts[4] != null && target.Myparts[5] != null && target.Myparts[6] != null && target.Myparts[7] != null
&& target.Myparts[8] != null && target.Myparts[9] != null && target.Myparts[10] != null && target.Myparts[11] != null && target.Myparts[12] != null && target.Myparts[13] != null
&& target.Myparts[14] != null&& target.Myparts[15] == null)
                    {
                        if ((coll2.transform.position.y == target.Myhome[14].transform.position.y) || (coll2.transform.position.x == target.Myhome[14].transform.position.x))
                        {
                            if ((target.Myhome[14].transform.position.x == coll2.transform.position.x - 1.9f) || (target.Myhome[14].transform.position.x == coll2.transform.position.x + 1.9f) ||
                                    ((target.Myhome[14].transform.position.y >= coll2.transform.position.y - 2f) && (target.Myhome[14].transform.position.y <= coll2.transform.position.y + 2f)))

                            {
                                Output = Instantiate(Pipe, new Vector3(coll2.transform.position.x, coll2.transform.position.y, coll2.transform.position.z), Quaternion.identity);
                                Once = 0;
                                target.Myhome[15] = coll2.gameObject;
                                if (coll2.transform.position.x > target.Myparts[14].transform.position.x + 1f)
                                {

                                    Output.transform.position = new Vector3(coll2.transform.position.x - 0.9f, coll2.transform.position.y, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 0);
                                }
                                if (coll2.transform.position.y < target.Myparts[14].transform.position.y - 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y + 0.9f, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 270);
                                }
                                if (coll2.transform.position.y > target.Myparts[14].transform.position.y + 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x, coll2.transform.position.y - 0.9f, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 90);
                                }
                                if (coll2.transform.position.x < target.Myparts[14].transform.position.x - 1f)
                                {
                                    Output.transform.position = new Vector3(coll2.transform.position.x + 0.9f, coll2.transform.position.y, -1);
                                    Output.transform.eulerAngles = new Vector3(0, 0, 180);

                                }
                                target.Myparts[15] = Output;
                            }

                        }
                    }
                    if (Output != null)
                {
                        if (Once == 0) { 
                    Output.GetComponent<Pipe>().Myhome = coll2.gameObject;
                    Output.transform.parent = Mymanage.transform;
                    Output.GetComponent<Pipe>().Mymanage = Mymanage;
                    Output.GetComponent<Pipe>().Color = Mycolor;

                    coll2.GetComponent<Home>().Mypipe = Output;
                            Once += 1;
                    }
                    }

                }


        }
        }
    }
}
