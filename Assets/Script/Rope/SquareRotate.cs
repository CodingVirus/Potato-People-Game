
    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareRotate : MonoBehaviour
{
    
    float rotSpeed = 50f;
    void Start()
    {

    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime));
    }
}
