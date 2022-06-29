using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class PlayerAttackController : MonoBehaviour
{
    public GameObject monsterData;
    private int monHP;

    //public static Action P_HP, hit20, hit50, hit80;
    //public string monNam;   
    public int playerHP = 100;
    int attack = 0; //공격
    int damage = 0; //추가 데미지 1~20% 
    bool perChek; //확률 체크 (참,거짓)

    public void Hit_20()
    {

        Debug.Log("플레이어가 몬스터를 사냥합니다.");

        Debug.Log("공격을 합니다."); //크리티컬발동 활률을 위한 랜덤 
        attack = Random.Range(1, 101);
        perChek = (0 == attack % 5);
        Debug.Log(perChek);
        Panel_Attack.panel_out();

        if (perChek)
        {
            Debug.Log("공격!!!!");
            //데미지 랜덤 
            damage = Random.Range(31, 41);
            Debug.Log(damage + "데미지가 들어갑니다.");
            Monster_HpChek();
        }

        else
        {
            Debug.Log("회피");
            Monster_HpChek();

        }

    }

    public void Hit_50()
    {

        Debug.Log("플레이어가 몬스터를 사냥합니다.");

        Debug.Log("공격을 합니다."); //크리티컬발동 활률을 위한 랜덤 
        attack = Random.Range(1, 101);
        perChek = (0 == attack % 2);
        Debug.Log(perChek);
        Panel_Attack.panel_out();

        if (perChek)
        {
            Debug.Log("공격!!!!");
            //데미지 랜덤 
            damage = Random.Range(16, 21);
            Debug.Log(damage + "데미지가 들어갑니다.");
            Monster_HpChek();
        }

        else
        {
            Debug.Log("회피");
            Monster_HpChek();
        }

    }

    public void Hit_80()
    {

        Debug.Log("플레이어가 몬스터를 사냥합니다.");

        Debug.Log("공격을 합니다."); //크리티컬발동 활률을 위한 랜덤 
        attack = Random.Range(1, 101);
        perChek = (0 == attack % 1.25);
        Debug.Log(perChek);
        Panel_Attack.panel_out();

        if (perChek)
        {
            Debug.Log("공격!!!!");
            //데미지 랜덤 
            damage = Random.Range(1, 11);
            Debug.Log(damage + "데미지가 들어갑니다.");
            Monster_HpChek();

        }

        else
        {
            Debug.Log("회피");
            Monster_HpChek();

        }

    }

    public void Monster_HpChek()
    {
        if (perChek)
        {
            monHP = monsterData.GetComponent<Monster_Attack>().monHP -= damage;
            Debug.Log("Monster HP : " + monHP);

            if (monHP <= 0) // 적 사망
            {
                Destroy(monsterData);
                Debug.Log("몬스터가 죽었습니다.");
                Panel_Attack.panel_out();
            }
        }
        else
        {
            Debug.Log("현재 HP" + monHP);
        }
    }

 }


