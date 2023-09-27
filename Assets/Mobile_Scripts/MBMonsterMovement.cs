using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBMonsterMovement : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float moveSpeed = 5.0f;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            player.transform.position, Time.deltaTime * moveSpeed);
    }
}
