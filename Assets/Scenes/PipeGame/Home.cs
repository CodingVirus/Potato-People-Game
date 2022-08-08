using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public Sprite[] Colorhomes;
    public GameObject Colorhome;
    private SpriteRenderer Sprcolor;
    public int Color;
    public GameObject Pipemanage;
    public GameObject Mypipe;
  
    public bool Dest;
    
    public GameObject []Sidehome;


    public GameObject Mymanage;
    private Target mymanage;
    public GameObject Output;
    public GameObject []Hand;

    private Manage Manage;
    private BoxCollider2D bc2D;

    public bool isMousePressed;

    void Start() {
       Sprcolor = Colorhome.GetComponent<SpriteRenderer>();
        Manage = GameObject.Find("Manage").GetComponent<Manage>();
        bc2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

 



        if ( Manage.Hands[Color] == null&&Mypipe!=null)
        {
            //------int=int-----Movehand.cs.My color=Pipe.cs.color 1=yellow
            //------------Movehand.cs.My color=Pipe.cs.color 2=Red
            //------------Movehand.cs.My color=Pipe.cs.color 3=Blue
            //------------Movehand.cs.My color=Pipe.cs.color 4=Green


            if (Mypipe.GetComponent<Pipe>().Num == 0 && Mypipe.GetComponent<Pipe>().Mymanage.GetComponent<Target>().Myparts[1] !=null) { 
               
           Color= Mypipe.GetComponent<Pipe>().Color;
            Sprcolor.enabled = true;
           Sprcolor.sprite = Colorhomes[Color];
            }
            if (Mypipe.GetComponent<Pipe>().Num >= 1 )
            {

                Color = Mypipe.GetComponent<Pipe>().Color;
                Sprcolor.enabled = true;
                Sprcolor.sprite = Colorhomes[Color];
            }

        }
        else if(Mypipe == null) { Sprcolor.enabled = false; }
        else if (Mypipe != null&& Manage.Movehand == true&&Manage.Hands[Color]!=null) {
            Color = Mypipe.GetComponent<Pipe>().Color;
            Sprcolor.sprite = Colorhomes[Color];
            Sprcolor.enabled = false; }



        if (Dest == true)
        {
            if (Mypipe != null)
            {
                Mypipe.GetComponent<Pipe>().Destroypipes();
            }
            Dest = false;
        }


    }
    void OnMouseDown()
    {
        if (Manage.Win == false) { 
        if (Mypipe != null) {

            Manage.Movehand = true;
            if (Mypipe.GetComponent<Pipe>().Color == 1)
            {
                Color = 0;
            }
            if (Mypipe.GetComponent<Pipe>().Color == 2)
            {
                Color = 1;
            }
            if (Mypipe.GetComponent<Pipe>().Color == 3)
            {
                Color = 2;
            }
            if (Mypipe.GetComponent<Pipe>().Color == 4)
            {
                Color = 3;
            }
                if (Mypipe.GetComponent<Pipe>().Color == 5)
                {
                    Color = 4;
                }

                Mymanage = Mypipe.GetComponent<Pipe>().Mymanage;
                mymanage = Mymanage.GetComponent<Target>();
                Output = Instantiate(Hand[Color], new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Output.transform.parent = transform;
                mymanage.Output = Output;
                Output.GetComponent<Movehand>().Mymanage = Mymanage;
         
          
        }
        }

    }
    public void Changecolor()
    {
        Mypipe.GetComponent<Pipe>().Destroypipes();
        Destroy(Mypipe);
    }
    void OnMouseUp()
    {
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
