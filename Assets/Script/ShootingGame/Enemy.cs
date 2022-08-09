using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    Vector3 dir;
    int playTime = 0;
    
   
    private void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
        if(other.gameObject.name == "Player")
        {
            Time.timeScale = 0;
            playTime++;
            SceneManager.LoadScene("BuwonScene");
        }
       
    }

    void Start()
    {
        
        int randValue = UnityEngine.Random.Range(0, 5);
        if(randValue < 3)
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += dir * speed * Time.deltaTime;
       
        
    }
}
