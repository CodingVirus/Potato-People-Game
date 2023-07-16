using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTarget;

    [SerializeField]
    Vector3 cameraPosition;

    public float cameraMoveSpeed;
    public Vector2 offset;
    public float limitMinX, limitMaxX, limitMinY, limitMaxY;
    float cameraHalfWidth, cameraHalfHeight;

    void Start()
    {
        cameraTarget = GameObject.Find("Player").GetComponent<Transform>();
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        cameraHalfHeight = Camera.main.orthographicSize;
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position + cameraPosition, Time.smoothDeltaTime * cameraMoveSpeed);

        float clampX = Mathf.Clamp(cameraTarget.position.x + offset.x, limitMinX + cameraHalfWidth, limitMaxX - cameraHalfWidth);
        float clampY = Mathf.Clamp(cameraTarget.position.y + offset.y, limitMinY + cameraHalfHeight, limitMaxY - cameraHalfHeight);
        transform.position = new Vector3(clampX, clampY, -10);
    }
}
