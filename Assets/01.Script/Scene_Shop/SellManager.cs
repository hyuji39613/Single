using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellManager : MonoBehaviour
{
    public List<int> sellSlotList = new List<int>();
    private List<FishDataSo> sellDataList = new List<FishDataSo>();
    public GameObject SellCheck;
    public static SellManager instance;
    public bool isSell = false;
    private int silverPriceSum, goldPriceSum;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReSetAll()
    {
        sellSlotList.Clear();
        sellDataList.Clear();
        goldPriceSum = 0;
        silverPriceSum = 0;
    }
    public void SellItemSelect(int slotNum, FishDataSo fishData)
    {
        sellSlotList.Add(slotNum);
        sellDataList.Add(fishData);
        if(CoinEnum.SilverCoin ==  fishData.coinEnum) 
        {
            silverPriceSum += fishData.price;
        }
        else if (CoinEnum.GoldCoin == fishData.coinEnum)
        {
            goldPriceSum += fishData.price;
        }
    }

    public void SellCheckOk()
    {
        CoinManager.instance.GetCoin(CoinEnum.SilverCoin, silverPriceSum);
        CoinManager.instance.GetCoin(CoinEnum.GoldCoin, goldPriceSum);
        isSell = false;
    }
}