using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    public float height = 4.5f;
    [SerializeField]
    Vector3 cameraPosition;

    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        // camera�� player�� ����
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + height, transform.position.z);
    }
}
