using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnManager : MonoBehaviour
{
    [SerializeField] private List<ItemSO> rodDataSo;
    public static BtnManager Instance;
    public GameObject BuyPanel;
    public GameObject commonLodSlot;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void CommonRodBtn()
    {
        if (CoinManager.instance.UseCoin(CoinEnum.SilverCoin, 20))
        {
            ItemView.instance.BuyRod(rodDataSo[0]);
            commonLodSlot.SetActive(false);
        }
    }
    public void RareRodBtn()
    {
        if (CoinManager.instance.UseCoin(CoinEnum.SilverCoin, 100))
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

    public void ExitBuyPanel()
    {
        BuyPanel.SetActive(false);
    }
}
