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

    // player ���� �Լ���
    public GameObject GetPlayerObj()
    {
        return player;
    }
    public float GetPlayerSpeed()
    {
        return player.GetComponent<MobilePlayerMovement>().moveSpeed;
    }
    // ���� ���� ���� �Լ���
    public bool BlackOut { get { return blackOut; } }
}
