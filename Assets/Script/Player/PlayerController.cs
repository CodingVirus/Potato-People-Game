using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public GameObject drugCombiner;
    public float speed = 6.0f;
    Rigidbody2D rb;
    bool facingRight = true;

    // �ڷ���Ʈ �ϴ� ���� ������ ���߱� ���� bool ����.
    public bool playerMove = true;

    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerMove == true)
        {
            float input = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(input * speed, rb.velocity.y);

            // ĳ���� �¿� �̵��� �ٶ󺸴� ���� ��ȯ
            if (input > 0 && facingRight == false)
            {
                Flip();
            }
            else if (input < 0 && facingRight == true)
            {
                Flip();
            }

            if (input != 0)
            {
                anim.SetBool("isWalking", true);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            if (speed == 0)
            {
                anim.SetBool("isWalking", false);
            }
        }
    }

    void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        facingRight = !facingRight;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("DrugCombiner"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                collision.transform.GetChild(0).gameObject.SetActive(true);
                //drugCombiner.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                collision.transform.GetChild(0).gameObject.SetActive(false);
                //drugCombiner.SetActive(false);
            }
        }

    }
}
