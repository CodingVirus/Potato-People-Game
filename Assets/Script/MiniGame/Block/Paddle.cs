using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paddle : MonoBehaviour
{
    [Multiline(12)]
    public string[] StageStr;
    public Sprite[] B;
    //public GameObject P_Item;
    //public SpriteRenderer P_ItemSr;
    public Text StageText;
    public Text ScoreText;
    public GameObject Life0;
    public GameObject Life1;
    public GameObject WinPanel;
    public GameObject GameOverPanel;
    //public GameObject PausePanel;
    //public AudioSource S_Break;
    //public AudioSource S_Eat;
    //public AudioSource S_Fail;
    //public AudioSource S_Gun;
    //public AudioSource S_HardBreak;
    //public AudioSource S_paddle;
    //public AudioSource S_Victory;
    //public Transform[] ItemsTr;
    public Transform BlocksTr;
    public BoxCollider2D[] BlockCol;
    public GameObject[] Ball;
    public Animator[] BallAni;
    public Transform[] BallTr;
    public SpriteRenderer[] BallSr;
    public Rigidbody2D[] BallRg;
    //public GameObject[] Bullet;
    public SpriteRenderer PaddleSr;
    public BoxCollider2D PaddleCol;
    //public GameObject Magnet;
    //public GameObject Gun;

    bool isStart;
    public float paddleX;
    public float ballSpeed;
    float oldBallSpeed = 250;
    float paddleBorder = 4.74f;
    //float paddleSize = 1.58f;
    int combo;
    int score;
    int stage;

    public void AllReset(int _stage)
    {
        if(_stage == 0) stage++;
        else if(_stage != -1) stage = _stage;
        if(stage >= StageStr.Length) return;
        
        //Clear();
        BlockGenerator();
        StartCoroutine("BallReset");

        //점수 초기화
        score = 0;
        ScoreText.text = "0";
        PaddleSr.enabled = true;
        Life0.SetActive(true);
        Life1.SetActive(true);
        WinPanel.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    void BlockGenerator()
    {
        string currentStr = StageStr[stage].Replace("\n", "");
        currentStr = currentStr.Replace(" ", "");

        for (int i = 0; i < currentStr.Length; i++)
        {
            BlockCol[i].gameObject.SetActive(false);
            char A = currentStr[i]; 
            string currentName = "Block"; 
            int currentB = 0;

            if(A == '*') continue;
            //else if(A == '8'){currentB = 8; currentName = "HardBlock0";}
            //else if(A == '9'){currentB = Random.Range(0, 8);}
            else currentB = int.Parse(A.ToString());

            BlockCol[i].gameObject.name = currentName;
            BlockCol[i].gameObject.GetComponent<SpriteRenderer>().sprite = B[currentB];
            BlockCol[i].gameObject.SetActive(true);
        }
    }

    IEnumerator InfinityLoop()
    {
        while(true)
        {
            if(Input.GetMouseButton(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved))
            {
                paddleX = Mathf.Clamp(Camera.main.ScreenToWorldPoint(Input.GetMouseButton(0) ? Input.mousePosition : (Vector3)Input.GetTouch(0).position).x, -paddleBorder, paddleBorder);
                transform.position = new Vector2(paddleX, transform.position.y);
                if(!isStart) BallTr[0].position = new Vector2(paddleX, BallTr[0].position.y);
            }

            if(!isStart && (Input.GetMouseButtonUp(0) || (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)))
            {
                isStart = true;
                ballSpeed = oldBallSpeed;
                BallRg[0].AddForce(new Vector2(0.1f, 0.9f).normalized * ballSpeed);
            }
            yield return new WaitForSeconds(0.01f);
        }
        
    }
    
    public IEnumerator BallCollisionEnter2D(Transform ThisBallTr, Rigidbody2D ThisBallRg, Ball ThisBallCs, GameObject Col, Transform ColTr, SpriteRenderer ColSr, Animator ColAni)
    {
        if(!isStart) yield break;

        switch (Col.name)
        {
            case "Paddle" :

                ThisBallRg.velocity = Vector2.zero;
                ThisBallRg.AddForce((ThisBallTr.position - transform.position).normalized * ballSpeed);
                combo = 0;
                break;

            case "DeathZone" :
                ThisBallTr.gameObject.SetActive(false);
                BallCheck();
                break;

            //case "HardBlock0" : 
            //    Col.name = "HardBlock1";
            //    ColSr.sprite = B[9];
            //    break;

            //case "HardBlock1" : 
            //    Col.name = "HardBlock1";
            //    ColSr.sprite = B[9];
            //    break;

            //case "HardBlock2" : 
            //    break;

            case "Block" :
                BlockBreak(Col, ColTr, ColAni);
                break;

        }
    }
    
    public void BlockBreak(GameObject Col, Transform ColTr, Animator ColAni)
    {
        //스코어 증가
        score += (++combo > 3) ? 3 : combo;
        ScoreText.text = score.ToString();

        //벽돌 부서지는 애니메이션
        ColAni.SetTrigger("Break");
        StartCoroutine(ActiveFalse(Col));

        //블럭 체크
        StopCoroutine("BlockCheck");
        StartCoroutine("BlockCheck");
    }

    IEnumerator ActiveFalse(GameObject Col)
    {
        yield return new WaitForSeconds(0.2f);
        Col.SetActive(false);
    }

    GameObject BallCheck()
    {
        int ballCount = 0;
        GameObject ReturnBall = null;
        foreach (GameObject OneBall in GameObject.FindGameObjectsWithTag("Ball"))
        {
            ballCount ++;
            ReturnBall = OneBall;
        }

        if(ballCount == 0)
        {
            if(Life1.activeSelf)
            {
                Life1.SetActive(false);
                StartCoroutine("BallReset");
            }
            else if(Life0.activeSelf)
            {
                Life0.SetActive(false);
                StartCoroutine("BallReset");
            }
            else
            {
                GameOverPanel.SetActive(true);
                Clear();
            }
        }

        return ReturnBall;

    }

    IEnumerator BlockCheck()
    {
        yield return new WaitForSeconds(0.5f);
        int blockCount = 0;
        for(int i = 0; i < BlocksTr.childCount; i++)
        {
            if(BlocksTr.GetChild(i).gameObject.activeSelf) blockCount++;
        }
        if(blockCount == 0)
        {
            WinPanel.SetActive(true);
            Clear();
        }
    }

    void Clear()
    {
        for(int i = 0; i < 3; i ++)
        {
            Ball[i].SetActive(false);
        }

        PaddleSr.enabled = false;
    }

    IEnumerator BallReset()
    {
        isStart = false;
        combo = 0;
        Ball[0].SetActive(true);
        BallAni[0].SetTrigger("Blink");
        BallTr[0].position = new Vector2(paddleX, -3.486f);
        
        StopCoroutine("InfinityLoop");
        yield return new WaitForSeconds(0.7f);
        StartCoroutine("InfinityLoop");
    }

    public void BallAddForce(Rigidbody2D ThisBallRg)
    {
        Vector2 dir = ThisBallRg.velocity.normalized;
        ThisBallRg.velocity = Vector2.zero;
        ThisBallRg.AddForce(dir * ballSpeed);
    }

}
