using System.Collections.Generic;
using UnityEngine;

public class EncyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> encyList;
    public static EncyManager instance;
    public int fishcount = 0;
    public int count;
    private List<int> registList = new List<int>();
    public void EncyEnable(int index)
    {
        if (!registList.Contains(index))
        {
            registList.Add(index);
            count++;
            if (index < 10) fishcount++;
        }
        encyList[index].SetActive(true);
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Awake()
    {
        if (instance == null)
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
