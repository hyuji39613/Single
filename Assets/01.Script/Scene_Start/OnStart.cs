using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnStart : MonoBehaviour
{
    public void StartCLickBtn()
    {
        SceneManager.LoadScene("Main");
    }
    public void QuitLickBtn()
    {
        Application.Quit();
    }
}
