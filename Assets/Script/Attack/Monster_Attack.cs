using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Monster_Attack: MonoBehaviour 
{

    public GameObject playerData; //player 데이터 받아오기
    private int playerHP; 

    //public static Action M_HP, Mattack;
    public string monNam;
    public int monHP = 50;
    int M_attack = 0; //공격
    int M_damage = 0; //추가 데미지 1~20% 
    bool M_perChek; //확률 체크 (참,거짓) 

    //private void Awake() 
   //{
    //    Mattack = () => {HitPlayer();};
    //    M_HP = () => {Monster_HpChek();};
    //}

    private void OnMouseDown() 
    {
        Panel_Attack.panel();
    }

    public void HitPlayer ()
    {
        Debug.Log("몬스터가 플레이어를 때립니다.");

        Debug.Log("공격을 합니다."); //크리티컬발동 활률을 위한 랜덤 
        M_attack = Random.Range(1, 101);
        M_perChek = (0 == M_attack % 2);
        Debug.Log(M_perChek);

        if (M_perChek) 
        { 
            Debug.Log("공격!!!!"); 
            //데미지 랜덤 
            M_damage = Random.Range(5, 20); 
            Debug.Log(M_damage + "데미지가 들어갑니다.");
            Monster_Attack_Player();
        } 

        else 
        { 
            Debug.Log("회피");
            Monster_Attack_Player();
        }

    }
    public void Monster_Attack_Player()
    {

        if(M_perChek)
        {
            playerHP = playerData.GetComponent<PlayerAttackController>().playerHP -= M_damage;
            Debug.Log("Player HP : " + playerHP);

            if (playerHP <= 0) // player 사망
            {
                Destroy(playerData);
                Debug.Log("Player가 죽었습니다.");
                Panel_Attack.panel_out();
                SceneManager.LoadScene(1);
            }

        }
        else
        {
            Debug.Log("현재 HP" + playerHP);
        }
        
    }

}
