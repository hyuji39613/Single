using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
     private List<ItemSO> rodDataSo = new List<ItemSO>();
    [SerializeField] private Image rodBtnImage;
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
}
