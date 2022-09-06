using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockPick : MonoBehaviour
{
    public GameObject lockPick;
    public GameObject lockPick_1;
    public GameObject lockPick_2;
    public GameObject lockPick_3;
    public GameObject lockPick_4;
    public GameObject lockPick_5;
    public GameObject lockPick_6;
    public GameObject lockPick_7;
    private AudioSource UnLockAudio;
    [SerializeField] private AudioClip[] clip;
    public static int i ;
    int Randomnum;

    [SerializeField]
    List<GameObject> LockPickList = new List<GameObject>();
    public void LockPickAdd()
    {
        
        LockPickList.Add(lockPick_1);
        LockPickList.Add(lockPick_2);
        LockPickList.Add(lockPick_3);
        LockPickList.Add(lockPick_4);
        LockPickList.Add(lockPick_5);
        LockPickList.Add(lockPick_6);
        LockPickList.Add(lockPick_7);
        LockPickList.Add(lockPick);
    }
    public void LockPickActive()
    {
        
        {
            LockPickList[i].SetActive(true);
            if (i >= 1)
            {
                LockPickList[i - 1].SetActive(false);
            }
            if (i == 0)
            {
                LockPickList[7].SetActive(false);
            }
            }
    }
    public void LockPickChange()
    {
        {
            LockPickActive();
            i++;

            if (i >= 8)
            {

                i = 0;

            }
        }
    }
    public void UnLockCheck()
    {

        if(i == Randomnum)
        {
            Debug.Log("UnLock");
            UnLockAudio.clip = clip[0]; 
            UnLockAudio.Play();
        }
        else
        {
            Debug.Log("Lock");
            UnLockAudio.clip = clip[1];
            UnLockAudio.Play();
        }
       
       
        
    }
 
  

    public void Start()
    {
        LockPickAdd();
        Randomnum = Random.Range(0, 8);
        Debug.Log(Randomnum);
        UnLockAudio = GetComponent<AudioSource>();

    }

  
    void Update()
    {


    }

    // https://flowersayo.tistory.com/18 오디오소스
}