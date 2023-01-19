using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    public GameObject click;
    public GameObject click1;
    public GameObject click2;
    public GameObject rotate;
    public GameObject rotate1;
    public GameObject sound;
    [SerializeField]
    List<GameObject> List = new List<GameObject>();
    public static int listnum;
    private AudioSource RopeAudio;
    [SerializeField] private AudioClip[] clip;
    public void ListAdd()
    {
        List.Add(click);
        List.Add(click1);
        List.Add(click2);
        List.Add(rotate);
        List.Add(rotate1);
       
     }
    void OnMouseDown()
    {
        List[listnum].SetActive(false);
       
        if (listnum >= 0 && listnum <= 4)
        {
            listnum++;
            List[listnum].SetActive(true);
            RopeAudio.clip = clip[0];
            RopeAudio.Play();
        }
        if (listnum >= 4)
        {
            SceneManager.LoadScene("BuwonScene");//여기에 세이브 데이터 연동 하면 됨.
        }
    }
    void Start()
    {
       
        ListAdd();
        RopeAudio = sound.GetComponent<AudioSource>();
    }

    
    void Update()
    {
        
    }
}
