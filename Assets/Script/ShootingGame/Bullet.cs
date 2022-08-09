using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5;
    void Start()
    {
        
    }

   
    void Update()
    {
        Vector3 dir = Vector3.up;
        transform.position += dir * bulletSpeed * Time.deltaTime;
    }
}
