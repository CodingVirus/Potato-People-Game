using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    //------int=int-----Movehand.cs.My color=Pipe.cs.color 1=yellow
    //------------Movehand.cs.My color=Pipe.cs.color 2=Red
    //------------Movehand.cs.My color=Pipe.cs.color 3=Blue
    //------------Movehand.cs.My color=Pipe.cs.color 4=Green

    public int Color;
    public GameObject Myhome;
    private Collider2D Mycolider;
    private Manage manage;
   
    public GameObject Mymanage;
    private Target mymanage;
    public int Num;
    public Sprite[] Pic;
    private SpriteRenderer Mysprite;
    private SpriteRenderer Spr;
    public bool Dest;



    public const string LAYER_NAME = "Pipe";
    public int sortingOrder = 0;
    private SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        Mycolider = GetComponent<BoxCollider2D>();
        manage = GameObject.Find("Manage").GetComponent<Manage>();
        mymanage = Mymanage.GetComponent<Target>();
        Mysprite = GetComponent<SpriteRenderer>();


        if (sprite)
        {
          
            sprite.sortingLayerName = LAYER_NAME;
        }


    }


    void Update()
    {

        if (Num != 0)
        {
            if (mymanage.Myhome[Num].transform.position.y > mymanage.Myhome[Num - 1].transform.position.y + 2.2f ||
            mymanage.Myhome[Num].transform.position.x > mymanage.Myhome[Num - 1].transform.position.x + 2.2f ||
                mymanage.Myhome[Num].transform.position.x < mymanage.Myhome[Num - 1].transform.position.x - 2.2f ||
                mymanage.Myhome[Num].transform.position.y < mymanage.Myhome[Num - 1].transform.position.y - 2.2f)
            {
                Destroy(gameObject);
            }
        }



        if (sprite)
        {
            sprite.sortingOrder = 20 - Num;
        }
            if (Num == 0)
        {
            if (mymanage.Myparts[Num + 1] == null)
            {
                Mysprite.enabled = false;
            }
            if (mymanage.Myparts[Num + 1] != null)
            {
                Mysprite.enabled = true;
                transform.eulerAngles = new Vector3(0, 0, mymanage.Myparts[Num + 1].transform.eulerAngles.z);
           
            }
        }
        if (Num == 1)
        {
            if (mymanage.Myparts[Num - 1] != null)
            {
                mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[4];
            }

        }
        if (Num >= 2)
        {
            if (mymanage.Myparts[Num - 1] == null)
            {
                Destroy(gameObject);
            }

            if (mymanage.Myparts[Num - 1] != null)
            {
                if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 0 && transform.eulerAngles.z == 90)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[2];
                }
                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 0 && transform.eulerAngles.z == 0)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[1];
                }
                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 0 && transform.eulerAngles.z == 270)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[3];
                }


                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 90 && transform.eulerAngles.z == 0)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[3];
                }
                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 90 && transform.eulerAngles.z == 90)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[1];
                }
                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 90 && transform.eulerAngles.z == 180)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[2];
                }


                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 180 && transform.eulerAngles.z == 90)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[3];
                }
                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 180 && transform.eulerAngles.z == 180)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[1];
                }
                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 180 && transform.eulerAngles.z == 270)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[2];
                }


                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 270 && transform.eulerAngles.z == 0)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[2];
                }
                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 270 && transform.eulerAngles.z == 180)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[3];
                }
                else if (mymanage.Myparts[Num - 1].transform.eulerAngles.z == 270 && transform.eulerAngles.z == 270)
                {
                    mymanage.Myparts[Num - 1].GetComponent<SpriteRenderer>().sprite = Pic[1];
                }
            }
        }
    }
    public void Destroypipes()
    {

        if (Num < 14) { 
             if (mymanage.Myparts[Num + 1] != null)
            {
                Destroy(mymanage.Myparts[Num + 1]);
            }
        }
        if (Num != 0)
            {

                Mysprite.sprite = Pic[0];
            }
            if (Num == 0)
            {
                if (transform.position.x > mymanage.transform.position.x + 1.1f || transform.position.x < mymanage.transform.position.x - 1.1f
                    || transform.position.y > mymanage.transform.position.y + 1.1f || transform.position.y < mymanage.transform.position.y - 1.1f)
                {
                    Destroy(gameObject);
                }
                Mysprite.sprite = Pic[4];
            }
       
    }
   


    public void Layers()
    {
    
    }
    void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "Violet")
        {
            if (Color != 5)
            {
                Destroy(gameObject);
            }
            if (Color == 5)
            {
                if (mymanage.Targetnum == 1)
                {
                    if (coll.GetComponent<Target>().Targetnum == 2)
                    {

                        manage.Vpipe = gameObject;
                        manage.Violet = true;
                        if (manage.Sound == 0)
                        {
                            GameObject.Find("Watermp3").GetComponent<AudioSource>().Play();
                        }
                        Mycolider.enabled = false;
                        manage.Movehand = false;
                        manage.Check();
                        Destroy(mymanage.Output);

                    }
                }
                if (mymanage.Targetnum == 2)
                {
                    if (coll.GetComponent<Target>().Targetnum == 1)
                    {

                        manage.Vpipe = gameObject;
                        manage.Violet = true;
                        if (manage.Sound == 0)
                        {
                            GameObject.Find("Watermp3").GetComponent<AudioSource>().Play();
                        }
                        Mycolider.enabled = false;
                        manage.Movehand = false;
                        manage.Check();
                        Destroy(mymanage.Output);

                    }
                }
            }
        }

        if (coll.gameObject.tag == "Yellow")
        {
            if (Color != 1)
            {
                Destroy(gameObject);
            }
                if (Color == 1) { 
            if (mymanage.Targetnum == 1)
            {
                if (coll.GetComponent<Target>().Targetnum == 2)
                {
                  
                        manage.Ypipe = gameObject;
                        manage.Yellow = true;
                        if (manage.Sound == 0)
                        {
                            GameObject.Find("Watermp3").GetComponent<AudioSource>().Play();
                        }
                        Mycolider.enabled = false;
                        manage.Movehand = false;
                        manage.Check();
                        Destroy(mymanage.Output);

                    }
            }
            if (mymanage.Targetnum == 2)
            {
                if (coll.GetComponent<Target>().Targetnum == 1)
                {
                   
                        manage.Ypipe = gameObject;
                        manage.Yellow = true;
                        if (manage.Sound == 0)
                        {
                            GameObject.Find("Watermp3").GetComponent<AudioSource>().Play();
                        }
                        Mycolider.enabled = false;
                       manage.Movehand = false;
                        manage.Check();
                        Destroy(mymanage.Output);

                    }
            }
            }
        }


        if (coll.gameObject.tag == "Red")
        {
            if (Color != 2)
            {
                Destroy(gameObject);
            }
            if (Color == 2)
            {
                if (mymanage.Targetnum == 1)
                {
                    if (coll.GetComponent<Target>().Targetnum == 2)
                    {
                       
                        manage.Rpipe = gameObject;
                        manage.Red = true;
                        if (manage.Sound == 0)
                        {
                            GameObject.Find("Watermp3").GetComponent<AudioSource>().Play();
                        }
                        Mycolider.enabled = false;
                        manage.Movehand = false;
                        manage.Check();
                        Destroy(mymanage.Output);
                    }
                }
                if (mymanage.Targetnum == 2)
                {
                    if (coll.GetComponent<Target>().Targetnum == 1)
                    {
                       
                        manage.Rpipe = gameObject;
                        manage.Red = true;
                        if (manage.Sound == 0)
                        {
                            GameObject.Find("Watermp3").GetComponent<AudioSource>().Play();
                        }
                        Mycolider.enabled = false;
                        manage.Movehand = false;
                        manage.Check();
                        Destroy(mymanage.Output);

                    }
                }
            }
        }


        if (coll.gameObject.tag == "Blue")
        {
            if (Color != 3)
            {
                Destroy(gameObject);
            }
            if (Color == 3)
            {
                if (mymanage.Targetnum == 1)
                {
                    if (coll.GetComponent<Target>().Targetnum == 2)
                    {
                       
                        manage.Bpipe = gameObject;
                        manage.Blue = true;
                        if (manage.Sound == 0)
                        {
                            GameObject.Find("Watermp3").GetComponent<AudioSource>().Play();
                        }
                        Mycolider.enabled = false;
                        manage.Movehand = false;
                        manage.Check();
                        Destroy(mymanage.Output);
                    }
                }
                if (mymanage.Targetnum == 2)
                {
                    if (coll.GetComponent<Target>().Targetnum == 1)
                    {
                       
                        manage.Bpipe = gameObject;
                        manage.Blue = true;
                        if (manage.Sound == 0)
                        {
                            GameObject.Find("Watermp3").GetComponent<AudioSource>().Play();
                        }
                        Mycolider.enabled = false;
                        manage.Movehand = false;
                        manage.Check();
                        Destroy(mymanage.Output);

                    }
                }
            }
        }



        if (coll.gameObject.tag == "Green")
        {
            if (Color != 4)
            {
                Destroy(gameObject);
            }
            if (Color == 4)
            {
                if (mymanage.Targetnum == 1)
                {
                    if (coll.GetComponent<Target>().Targetnum == 2)
                    {
                        
                        manage.Gpipe = gameObject;
                        manage.Green = true;
                        if (manage.Sound == 0)
                        {
                            GameObject.Find("Watermp3").GetComponent<AudioSource>().Play();
                        }
                        Mycolider.enabled = false;
                        manage.Movehand = false;
                        manage.Check();
                        Destroy(mymanage.Output);
                    }
                }
                if (mymanage.Targetnum == 2)
                {
                    if (coll.GetComponent<Target>().Targetnum == 1)
                    {
                        
                        manage.Gpipe = gameObject;
                        manage.Green = true;
                        if (manage.Sound == 0)
                        {
                            GameObject.Find("Watermp3").GetComponent<AudioSource>().Play();
                        }
                        Mycolider.enabled = false;
                        manage.Movehand = false;
                        manage.Check();
                        Destroy(mymanage.Output);
                    }
                }
            }
        }
    }
}
