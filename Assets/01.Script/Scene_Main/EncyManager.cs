using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EncyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> encyList;
    public static EncyManager instance;

    public void EncyEnable(int index)
    {
        encyList[index].SetActive(true);
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
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
    }  
    public void ExitBtn()
    {
        gameObject.SetActive(false);
    }
}
