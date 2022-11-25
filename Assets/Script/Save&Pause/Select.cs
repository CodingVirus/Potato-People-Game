using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System;

public class Select : MonoBehaviour
{
    public GameObject creat;
    public GameObject noData;
    public Text[] slotText;
    public string nowDate;
    public string nowTime;

    bool[] savefile = new bool[3];

    // Start is called before the first frame update
    void Start()
    {
        //슬롯별로 저장된 데이터가 존재하는지 판단
        for(int i = 0; i < 3; i++)
        {
            //슬롯 내용
            if(File.Exists(SLManager.instance.path + $"{i}"))
            {
                savefile[i] = true;
                SLManager.instance.nowSlot = i;
                SLManager.instance._load();
                slotText[i].text = "Data" + (i+1) + "\n" + SLManager.instance.nowPlayer.nowDate + " " + SLManager.instance.nowPlayer.nowTime;
            }
            else
            {
                slotText[i].text = "No Data";
            }
        }
        SLManager.instance.DataClear();
    }

    //슬롯이 3개인데 어떻게 알맞게 불러오느냐
    public void Slot(int num)
    {
        SLManager.instance.nowSlot = num;
        
        //슬롯 번호별로 데이터 불러오기
        if(savefile[num])
        {
            SLManager.instance._load(); //있을때
            creat.gameObject.SetActive(true);
        }
        else NoData(); //저장된 데이터가 없을때 처음부터 시작
    }

    //데이터가 없을때 처음부터 시작
    public void NoData()
    {
        //데이터가 없습니다 처음부터 시작할까요 ui
        noData.gameObject.SetActive(true);
        //게임 실행
    }

    //게임 실행
    public void GoGame()
    {
        Date();
        SLManager.instance._save();
        SceneManager.LoadScene(1);
    }

    public void Date()
    {
        SLManager.instance.nowPlayer.nowDate = DateTime.Now.ToString("yyyy-MM-dd");
        SLManager.instance.nowPlayer.nowTime = DateTime.Now.ToString("HH : mm : ss");
    }

    //NO 선택할 경우 창 닫기
    public void Exit()
    {
        if(creat.gameObject.activeSelf == true){
            creat.gameObject.SetActive(false);
        }
        else if(noData.gameObject.activeSelf == true){
            noData.gameObject.SetActive(false);
        }
    }

    public void SlotOpen()
    {
        this.gameObject.SetActive(true);
    }

    public void SlotClose()
    {
        this.gameObject.SetActive(false);
    }

}
