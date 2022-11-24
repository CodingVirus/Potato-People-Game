using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCamera : MonoBehaviour
{
    public GameObject target;
    public GameObject ply;

    public bool moveToTarget = false;
    public bool moveToPlayer = false;

    Vector3 vel = Vector3.zero;

    Vector3 test1;
    Vector3 test2;

    // Update is called once per frame
    public void MoveCamera()
    {
        test1 = this.transform.position;
        test2 = target.transform.position;

        test2.z = test1.z;
        test2.y = test1.y;

        this.GetComponent<CameraFollow>().enabled = false;
        this.GetComponent<MoveToCamera>().enabled = true;

        moveToTarget = true;
        //transform.position = Vector3.SmoothDamp(gameObject.transform.position, target.transform.position, ref vel, 1f);
    }

    void Update()
    {
        if (moveToTarget == true)
        {
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, test2, ref vel, 1f);
            //Invoke("MoveToPly", 3f);
        }
        else if (moveToPlayer == true)
        {
            MoveToPly();
        }
    }

    public void MoveToPly()
    {
        //transform.position = Vector3.SmoothDamp(gameObject.transform.position, test1, ref vel, 0.5f);
        //Invoke("ActiveCameraFollow", 3f);
        //Debug.Log("hihi");
        ActiveCameraFollow();
    }

    public void SetTrue()
    {
        moveToTarget = false;
        moveToPlayer = true;
    }

    public void ActiveCameraFollow()
    {
        this.GetComponent<CameraFollow>().enabled = true;
        this.GetComponent<MoveToCamera>().enabled = false;
    }
}
