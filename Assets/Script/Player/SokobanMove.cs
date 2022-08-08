using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SokobanMove : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float moveSpeed;
    Vector3 inputPos;
    Vector2 dir;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        //this.transform.position = new Vector2(8.41f, -0.62f);
    }
    private void Update()
    {
        //float inputX = Input.GetAxisRaw("Horizontal");
        //float inputY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButton(0))
            inputPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = inputPos - transform.position;

        rigidbody2D.MovePosition(Vector2.MoveTowards(transform.position, inputPos, Time.deltaTime * moveSpeed));
        //transform.Translate(new Vector2(inputX, inputY) * Time.deltaTime * moveSpeed);
    }
}
