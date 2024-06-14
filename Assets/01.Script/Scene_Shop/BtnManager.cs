using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnManager : MonoBehaviour
{
    [SerializeField] private List<ItemSO> rodDataSo;

    public void CommonRodBtn()
    {
        if(CoinManager.instance.UseCoin(CoinEnum.SilverCoin, 50))
        {
            ItemView.instance.BuyRod(rodDataSo[0]);
            DestoryShopItem();
        }
    }
    public void RareRodBtn()
    {
        if (CoinManager.instance.UseCoin(CoinEnum.SilverCoin, 200))
        {
            ItemView.instance.BuyRod(rodDataSo[1]);
            DestoryShopItem();
        }
    }
    public void EpicRodBtn()
    {
        if (CoinManager.instance.UseCoin(CoinEnum.GoldCoin, 100))
        {
            ItemView.instance.BuyRod(rodDataSo[2]);
            DestoryShopItem();
        }
    }
    private static void DestoryShopItem()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        button.transform.parent.gameObject.SetActive(false);
    }
}
