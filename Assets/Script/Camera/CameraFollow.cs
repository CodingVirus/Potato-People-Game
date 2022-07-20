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

    // Start is called before the first frame update
    void Start()
    {
        cameraTarget = GameObject.Find("Player").GetComponent<Transform>();
        cameraHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        cameraHalfHeight = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //cameraPosition.y = 4f;
        transform.position = Vector3.Lerp(transform.position, cameraTarget.position, Time.deltaTime * cameraMoveSpeed);

        float clampX = Mathf.Clamp(cameraTarget.position.x + offset.x, limitMinX + cameraHalfWidth, limitMaxX - cameraHalfWidth);
        float clampY = Mathf.Clamp(cameraTarget.position.y + offset.y, limitMinY + cameraHalfHeight, limitMaxY - cameraHalfHeight);
        transform.position = new Vector3(clampX, clampY, -10);
    }
}
