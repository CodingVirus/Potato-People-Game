using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    // SerializeField 기능을 사용하여 private 변수를 인스펙터에서 접근 가능하게 만든다.
    // 목적지 위치를 저장하는 변수
    [SerializeField] private Transform destination;

    public Transform GetDestination()
    {
        return destination;
    }
}
