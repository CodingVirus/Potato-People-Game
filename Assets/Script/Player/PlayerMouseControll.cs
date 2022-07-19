using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouseControll : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 target;
    private Vector3 transPos;
    private Vector3 mousePos;
    private Vector3 dir;

    Animator anim;
    bool facingRight = true;
    public bool playerMove = true;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        target.y = transform.position.y;
        if(Input.GetMouseButtonDown(0))
        {
            playerMove = true;
            if(playerMove == true)
            {
                mousePos = Input.mousePosition;
                transPos = Camera.main.ScreenToWorldPoint(mousePos);
                target = new Vector3(transPos.x, 0, 0);
                anim.SetBool("isWalking", true);
                dir = target - transform.position;
                if (dir.x > 0 && facingRight == false)
                {
                    Flip();
                }
                if (dir.x < 0 && facingRight == true)
                {
                     Flip();
                }
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);
        if(target == transform.position)
        {
            StopMove();
        }
        if(playerMove == false)
        {
            StopMove();
        }
    }

    void StopMove()
    {
        playerMove = false;
        anim.SetBool("isWalking", false);
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
    
}
