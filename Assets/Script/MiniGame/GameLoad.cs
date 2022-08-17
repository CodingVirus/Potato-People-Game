using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoad : MonoBehaviour
{
    public void BlockGame()
    {
        SceneManager.LoadScene("game");
    }

    public void ShootingGame()
    {
        SceneManager.LoadScene("ShootingGame");
    }
}
