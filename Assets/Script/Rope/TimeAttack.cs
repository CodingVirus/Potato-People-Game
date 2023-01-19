using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class TimeAttack : MonoBehaviour
{

    [SerializeField] float setTime = 10.0f;
    [SerializeField] TextMeshProUGUI countdownText;
     void Start()
    {
        countdownText.text = setTime.ToString();
    }
    void Update()
    {
        if(setTime > 0)
        {
            setTime -= Time.deltaTime;
        }
        else if(setTime <= 0)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene("GameOver");

        }
            countdownText.text = Mathf.Round(setTime).ToString();
    }
}
