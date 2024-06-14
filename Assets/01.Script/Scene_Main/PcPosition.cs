using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PcPosition : MonoBehaviour
{
    private Transform playerTrm;
    private Vector2 playerPosition = new Vector2(0,0);
    public static PcPosition instance;

    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        if (SceneManager.GetActiveScene().name == "Main")
        { 
            playerTrm = GameObject.Find("Player").GetComponent<Transform>();
            MainChange();
        }
    }
    public void SceneChange()
    {
        playerPosition = playerTrm.position;
    }
    public void MainChange()
    {
        playerTrm.position = playerPosition;
    }
}
