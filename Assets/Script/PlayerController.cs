using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 8.0f;
    Rigidbody2D rb;
    bool facingRight = true;

    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        // 캐릭터 좌우 이동시 바라보는 방향 전환
        if (input > 0 && facingRight == false)
        {
            Flip();
        } else if (input < 0 && facingRight == true)
        {
            Flip();
        }

        if (input != 0)
        {
            anim.SetBool("isWalking", true);
        } else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }
}
