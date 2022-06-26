using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    Vector3 cameraPosition;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        // camera�� player�� ����
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 2.5f, transform.position.z);
    }
}
