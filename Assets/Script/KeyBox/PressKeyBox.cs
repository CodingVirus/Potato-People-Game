using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressKeyBox : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Sokoban");
    }
}
