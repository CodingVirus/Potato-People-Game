using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBGameManger : MonoBehaviour
{
    public static MBGameManger instance = null;

    [SerializeField] private GameObject player;
    private bool blackOut = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // player 관련 함수들
    public GameObject GetPlayerObj()
    {
        return player;
    }
    public float GetPlayerSpeed()
    {
        return player.GetComponent<MobilePlayerMovement>().moveSpeed;
    }
    // 게임 상태 관련 함수들
    public bool BlackOut { get { return blackOut; } }
}
