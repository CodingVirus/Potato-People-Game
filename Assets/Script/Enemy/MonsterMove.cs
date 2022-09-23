using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterMove : MonoBehaviour
{
    Rigidbody2D rigid;
    public Transform montarget;

    public int nextMove;
    public float thinkTime;
    public float monSpeed = 2f;
    public float traceSpeed = 3.5f;

    private bool facingRight;
    private Vector3 dir;
    private float dis;
    //public bool monteleport = false;
    public bool traceState = false;

    private void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine("Think");
    }

    private void FixedUpdate() 
    {
        if(montarget.GetComponent<PlayerTeleport>().transferState == false)
        {
            dis = Vector3.Distance(transform.position, montarget.position);

            if(dis > 10 || traceState == false)
            {
                Move();
                traceState = false;
                //monteleport = false;
            }

            //낭떠러지 감지
            Sensor();

            //추적
            if(dis <= 10)
            {
                Trace();
                traceState = true;
                StopCoroutine("Think");
                if(montarget.GetComponent<PlayerHide>().hideStart == true)
                {
                    traceState = false;
                    StartCoroutine("Think");
                }
            }
            
        }
    }
    
    private void Move()
    {
        rigid.velocity = new Vector2(nextMove * monSpeed,rigid.velocity.y);
        Flip();
    }

    IEnumerator Think()
    {
        while (true)
        {
            yield return new WaitForSeconds(thinkTime);
            MonMove();
            //nextMove = Random.Range(-1, 2);
            //thinkTime = Random.Range(1, 10);
            //yield return new WaitForSeconds(thinkTime);
        }
    }

    public void MonMove()
    {
        nextMove = Random.Range(-1, 2);
        thinkTime = Random.Range(1, 10);
        Debug.Log(nextMove);
        Debug.Log(thinkTime);
    }

    private void Trace()
    {
        transform.position = Vector2.MoveTowards(transform.position, montarget.position, Time.smoothDeltaTime * traceSpeed);
        dir = montarget.position - transform.position;
        //if(dir > 10)
        //{
        //    StartCoroutine("Think");
        //}
        Flip();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(traceState == true)
            {
                Debug.Log("gameover");
                SceneManager.LoadScene(1);
                //PlayerMouseControll.instance.StopMove();
                //traceSpeed = 0f;
            }
        }
    }

    void Sensor()
    {
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D raycast = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("platform"));
        if(raycast.collider == null)
        {
            //Debug.Log("낭떠러지");
            nextMove = nextMove * (-1);
            //if(dis > 10)
            //{
            //    CancelInvoke();
            //    Invoke("Think", 5);
            //}
            //if(dis <= 10)
            //{
            //   CancelInvoke();
            //}
        }
    }

    void Flip()
    {
        if ((nextMove > 0 && facingRight == false && traceState == false) || (dir.x > 0 && facingRight == false && traceState == true))
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            facingRight = !facingRight;
        }
        if ((nextMove < 0 && facingRight == true && traceState == false) || (dir.x < 0 && facingRight == true && traceState == false))
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;

            facingRight = !facingRight;
        }
    }
}
