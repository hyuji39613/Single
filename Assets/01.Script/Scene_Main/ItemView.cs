using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image rodBtnImage;
    private List<ItemSO> rodDataSo = new List<ItemSO>();
    public ItemSO rodData;
    private int index;
    public static ItemView instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void RodBtnClick()
    {
        if (rodDataSo.Count <= 0) return;
        if (index == rodDataSo.Count) index = 0;
        rodData = rodDataSo[index++];
        rodBtnImage.sprite = rodData.rodSprite;
    }
    public void BuyRod(ItemSO item)
    {
        rodDataSo.Add(item);
        rodData = item;
        index = rodDataSo.Count - 1;
        rodBtnImage.sprite = rodData.rodSprite;
        
    }
    private void Update()
    {
        ViewVisible();
    }
    public void ViewVisible()
    {
        if(SceneManager.GetActiveScene().name == "Main")
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }
}
