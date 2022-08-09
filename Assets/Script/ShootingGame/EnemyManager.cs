using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float minTime = 1;
    float maxTime = 5;
    float currentTime;
    public float creatTime = 1;
    public GameObject enemyFactory;
    void Start()
    {
        creatTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > creatTime)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;
            currentTime = 0;
            creatTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
