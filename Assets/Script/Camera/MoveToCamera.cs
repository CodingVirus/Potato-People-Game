using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCamera : MonoBehaviour
{
    public GameObject target;
    public GameObject ply;

    Vector3 vel = Vector3.zero;

    Vector3 test1;

    // Update is called once per frame
    public void MoveCamera()
    {
        test1 = this.transform.position;

        this.GetComponent<CameraFollow>().enabled = false;
        this.GetComponent<MoveToCamera>().enabled = true;
        //transform.position = Vector3.SmoothDamp(gameObject.transform.position, target.transform.position, ref vel, 1f);
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, target.transform.position, ref vel, 1f);
        Invoke("MoveToPly", 3f);
    }

    void MoveToPly()
    {
        transform.position = Vector3.SmoothDamp(gameObject.transform.position, test1, ref vel, 1f);
        //this.GetComponent<CameraFollow>().enabled = true;
    }
}
