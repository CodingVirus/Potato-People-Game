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

    //public BoxCollider2D bound;
    //private Vector3 minBound;
    //private Vector3 maxBound;
   // private float halfWidth;
    //private float halfHeight;
    //private Camera theCamera;

    private void Awake() 
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Start()
    {
        //theCamera = GetComponent<Camera>();
        //minBound = bound.bounds.min;
       //maxBound = bound.bounds.max;
        //halfHeight = theCamera.orthographicSize;
        //halfWidth = halfHeight * Screen.width / Screen.height;
    }

    void LateUpdate()
    {
        // camera�� player�� ����
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + height, transform.position.z);

        //float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth,  maxBound.x - halfWidth);//범위 안에 가둠
        //float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight,  maxBound.y - halfHeight);

       // this.transform.position = new Vector3(clampedX, clampedY, this.transform.position.z);
    }

    //public void SetBound(BoxCollider2D newBound)
    //{
        //bound = newBound;
        //minBound = bound.bounds.min;
        //maxBound = bound.bounds.max;
    //}
}
