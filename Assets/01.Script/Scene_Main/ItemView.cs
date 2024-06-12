using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private List<ItemSO> rodDataSo;
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
        if (index == rodDataSo.Count) index = 0;
        rodData = rodDataSo[index++];

        rodBtnImage.sprite = rodData.rodSprite;

    }
}
