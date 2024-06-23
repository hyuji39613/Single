using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PcPosition : MonoBehaviour
{
    public bool inShop, inSea;
    public Transform shopPos, seaPos;
    public static PcPosition instance;

    private void Awake()
    {     
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(this.gameObject);

        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

    }

    private void StartScene()
    {
        Transform playerTrm = GameObject.Find("Player").transform;

        if (inShop)
        {
            inShop = false;
            playerTrm.localPosition = shopPos.position;

        }
        else if (inSea)
        {
            inSea = false;
            playerTrm.localPosition = seaPos.position;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    { 
        if(scene.name == "Main")
        {
            StartScene();
        }
    }

 }
