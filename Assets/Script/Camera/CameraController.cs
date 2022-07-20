using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    public float playerheight = 4.5f;

    [SerializeField]
    Vector3 cameraPosition;

    [SerializeField]
    Vector2 center;
    [SerializeField]
    public Vector2 mapSize;

    [SerializeField]
    float cameraMoveSpeed;
    float height;
    float width;

    //public BoxCollider2D bound;
    public Vector3 minBound;
    public Vector3 maxBound;
    private float halfWidth;
    private float halfHeight;
    private Camera theCamera;

    //private void Awake() 
    //{
    //    playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    //}

    void Start()
    {
        theCamera = GetComponent<Camera>();
        //minBound = bound.bounds.min;
        //maxBound = bound.bounds.max;
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height;
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        height = Camera.main.orthographicSize;
        width = height * Screen.width / Screen.height;
    }

    private void LateUpdate() 
    {
        LimitCameraArea();
    }

    void LimitCameraArea()
    {
        cameraPosition.y = 4f;
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + cameraPosition, Time.deltaTime * cameraMoveSpeed);

        float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth,  maxBound.x - halfWidth);//범위 안에 가둠
        float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight,  maxBound.y - halfHeight);

        this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);

        //transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + playerheight, transform.position.z);

        //float lx = mapSize.x - width;
        //float clampX = Mathf.Clamp(transform.position.x, -lx + center.x, lx + center.x);

        //float ly = mapSize.y - height;
        //float clampY = Mathf.Clamp(transform.position.y, -ly + center.y, ly + center.y);

        //transform.position = new Vector3(clampX, clampY, -10f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, mapSize * 2);
    }

    //void LateUpdate()
    //{
        // camera�� player�� ����
        //transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + height, transform.position.z);

        //float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth,  maxBound.x - halfWidth);//범위 안에 가둠
        //float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight,  maxBound.y - halfHeight);

        //this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
    //}

    //public void SetBound(BoxCollider2D newBound)
    //{
    //    bound = newBound;
    //    minBound = bound.bounds.min;
    //    maxBound = bound.bounds.max;
    //}
}
