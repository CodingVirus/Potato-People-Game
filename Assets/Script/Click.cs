using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{
    public void OnClickNewGame()
    {
        SceneManager.LoadScene(0);
    }
}
