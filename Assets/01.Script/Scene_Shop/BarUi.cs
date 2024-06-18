using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BarUi : MonoSingleTon<BarUi>
{
    public GameObject buyShop;
    public GameObject sellShop;

    
    private void Start()
    {
        buyShop.SetActive(false);
        sellShop.SetActive(false);

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
         BtnManager.Instance.BuyPanel.SetActive(false);
        }
    }
    public void Exitbtn()
    {
        SceneManager.LoadScene("Main");
    }
    public void BuyBtn()
    {
        BtnManager.Instance.BuyPanel.SetActive(true);
    }
    public void SellBtn()
    {
        sellShop.SetActive(true);
        InventoryManager.instance.SellBtnOnOff(true);
        InventoryManager.instance.DelBtn(false);
    }
    public void SellCancel()
    {
        sellShop.SetActive(false);
        InventoryManager.instance.SellBtnOnOff(false);
        InventoryManager.instance.DelBtn();
    }
    public void InvenBtn()
    {
        InventoryManager.instance.ExitBtn(true);
        SellManager.instance.isSell = true;
    }

}
