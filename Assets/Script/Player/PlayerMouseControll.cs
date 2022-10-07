using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMouseControll : MonoBehaviour
{

    public float walkspeed = 5f;
    //public float runspeed = 10f;
    public bool playerWalk;
    //public bool playerRun;
    public bool playerFilp = true;
    //public float speed = 5f;
    public Vector3 target;
    private Vector3 transPos;
    private Vector3 mousePos;
    public Vector3 dir;

    Animator anim;
    bool facingRight = true;
    public bool playerMove = true;

    public static PlayerMouseControll instance;

    private void Awake() 
    {
        instance = this;
        //Application.targetFrameRate = 120;
    }
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Debug.Log(this.GetComponent<PlayerTeleport>().transferStart);
        target.y = transform.position.y;
        if(Input.GetMouseButton(0))
        {
            //this.GetComponent<PlayerTeleport>().transferStart = false;
            
            playerWalk = true;
            playerMove = true;
            if(playerMove == true)
            {
                mousePos = Input.mousePosition;
                transPos = Camera.main.ScreenToWorldPoint(mousePos);
                target = new Vector3(transPos.x, target.y, 0);
                anim.SetBool("isWalking", true);
                dir = target - transform.position;
                if(playerFilp == true)
                {
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
        }
        if(playerWalk == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Time.smoothDeltaTime * walkspeed);
        }

        /*if(Input.GetMouseButton(1))
        {
            // playerRun = true;
            playerMove = true;
            if(playerMove == true)
            {
                mousePos = Input.mousePosition;
                transPos = Camera.main.ScreenToWorldPoint(mousePos);
                target = new Vector3(transPos.x, target.y, 0);
                anim.SetBool("isWalking", true);
                if(playerFilp == true)
                {
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
        }*/
        //if(playerRun == true)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, target, Time.smoothDeltaTime * runspeed);
        //}

        if (target.x == transform.position.x)
        {
            playerMove = false;
            playerWalk = false;
            //playerRun = false;
            anim.SetBool("isWalking", false);
        }
        if(playerMove == false)
        {
            anim.SetBool("isWalking", false);
        }
        if(walkspeed == 0.0f) //|| runspeed == 0.0f)
        {
            anim.SetBool("isWalking", false);
        }
    }

    public void StopMove()
    {
        walkspeed = 0.0f;
        //runspeed = 0.0f;
        playerFilp = false;
        anim.SetBool("isWalking", false);
    }

    public void DialogueStartMove()
    {
        MaintainPosition();
        Invoke("StartMove", 0.5f);
    }

    public void StartMove()
    {
        walkspeed = 5.0f;
        //runspeed = 10.0f;
        playerFilp = true;
        anim.SetBool("isWalking", false);
    }

    //public void DiealogueMove()
    //{
    //    walkspeed = 5.0f;
    //    //runspeed = 10.0f;
    //    playerFilp = true;
    //    anim.SetBool("isWalking", false);
    //}

    public void MaintainPosition()
    {
        target = this.transform.position;
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
