using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manage : MonoBehaviour
{
    public GameObject Winmenu;
    public GameObject[] Levels;
    public int Sound;
    public GameObject[] Particle;
    public GameObject[] Output;
    public GameObject[] Hands;
    public bool Movehand;
    public GameObject Ypipe;
    public GameObject Rpipe;
    public GameObject Gpipe;
    public GameObject Vpipe;
    public GameObject Bpipe;
    public bool Yellow;
    public bool Red;
    public bool Green;
    public bool Violet;
    public bool Blue;
    public int Level;
    public int Lock;
    public bool Win;
    private float Rpsize;

    public int Numberoftargets;
    // Start is called before the first frame update
    void Start()
    {
        Lock = PlayerPrefs.GetInt(" Lock", Lock);
        Sound = PlayerPrefs.GetInt(" Sound", Sound);
        DontDestroyOnLoad(gameObject);


       StartCoroutine(Logo());
    }


    public void Check()
    {
        if (Numberoftargets == 4 || Numberoftargets == 0) { 

        if (Yellow == true && Blue == true && Green == true && Red == true)
        {
            Win = true;
            if (Output[6] == null)
            {
                Output[6] = Instantiate(Winmenu, new Vector3(0, 0, -0.5f), Quaternion.identity) as GameObject;
                    Output[6].transform.parent = GameObject.Find("Canvas").transform;
                    Output[6].transform.localScale = Vector3.one;
                    Save();
            }
        }
    }
        if (Numberoftargets == 5)
        {

            if (Yellow == true && Blue == true && Green == true && Red == true && Violet == true)
            {
                Win = true;
                if (Output[6] == null)
                {
                    Output[6] = Instantiate(Winmenu, new Vector3(0, 0, -0.5f), Quaternion.identity) as GameObject;
                    Output[6].transform.parent = GameObject.Find("Canvas").transform;
                    Output[6].transform.localScale = Vector3.one;
                    Save();
                }
            }
        }
    }
    public void Part()
    {

        Output[0] = Instantiate(Particle[0], new Vector3(0.15f, 0.3f, transform.position.z), Quaternion.identity) as GameObject;
        Output[1] = Instantiate(Particle[1], new Vector3(0.15f, 0.3f, transform.position.z), Quaternion.identity) as GameObject;
        Output[2] = Instantiate(Particle[2], new Vector3(0.15f, 0.3f, transform.position.z), Quaternion.identity) as GameObject;
        Output[3] = Instantiate(Particle[3], new Vector3(0.15f, 0.3f, transform.position.z), Quaternion.identity) as GameObject;
        Output[4] = Instantiate(Particle[4], new Vector3(0.15f, 0.3f, transform.position.z), Quaternion.identity) as GameObject;
     
        Rpsize = Random.Range(0.7f, 1.3f);
        Output[0].transform.localScale = new Vector3(Rpsize, Rpsize, 1);
        Output[0].transform.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-2,2f), Random.Range(5, 10f));
        Rpsize = Random.Range(0.7f, 1.3f);
        Output[1].transform.localScale = new Vector3(Rpsize, Rpsize, 1);
        Output[1].transform.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-2, 2f), Random.Range(5,10f));
        Rpsize = Random.Range(0.7f, 1.3f);
        Output[2].transform.localScale = new Vector3(Rpsize, Rpsize, 1);
        Output[2].transform.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-2, 2f), Random.Range(5, 10f));
        Rpsize = Random.Range(0.7f, 1.3f);
        Output[3].transform.localScale = new Vector3(Rpsize, Rpsize, 1);
        Output[3].transform.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-2, 2f), Random.Range(5, 10f));
        Rpsize = Random.Range(0.7f, 1.3f);
        Output[4].transform.localScale = new Vector3(Rpsize, Rpsize, 1);
        Output[4].transform.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-2, 2f), Random.Range(5, 10f));
      
        StartCoroutine(Des());


    }
    // Update is called once per frame
    void Update()
    {
        if (Level >= 50)
        {
            Level = 50;
        }
        if (Ypipe == null)
        {
            Yellow = false;
        }
        if (Rpipe == null)
        {
            Red = false;
        }
        if (Gpipe == null)
        {
            Green = false;
        }
        if (Bpipe == null)
        {
            Blue = false;
        }
    }
    IEnumerator Des()
    {
        yield return new WaitForSeconds(5);
        Destroy(Output[0]);
        Destroy(Output[1]);
        Destroy(Output[2]);
        Destroy(Output[3]);
        Destroy(Output[4]);
    }

    //--for Start game.......(Pos.cs)
    public void Startnewgame()
    {
        Destroy(Output[5]);
        Destroy(Output[6]);
        Destroy(Output[0]);
        Destroy(Output[1]);
        Destroy(Output[2]);
        Destroy(Output[3]);
        Destroy(Output[4]);
        Win = false;
       Green = false;
      Violet = false;
       Red = false;
       Yellow = false;
       Blue = false;
        Output[5] = Instantiate(Levels[Level], new Vector3(0, 0, -0.5f), Quaternion.identity) as GameObject;
    }
    public void Save()
    {
        if (Lock <= Level)
        {
            Lock = Level + 1;
        }
        if (Lock >= 50)
            {
            Lock = 50;
            }
      PlayerPrefs.SetInt(" Lock", Lock);
    }
        IEnumerator Logo()
        {
            yield return new WaitForSeconds(3f);
      

        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    }
