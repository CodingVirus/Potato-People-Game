using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCameraFollow : MonoBehaviour
{
    private Transform cameraTarget;
    public Vector2 center;
    public Vector2 size;
    private void Awake()
    {
        cameraTarget = GameObject.Find("Player").GetComponent<Transform>();
    }
    void Update()
    {
        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y + 4.39f, -5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
    }
}
