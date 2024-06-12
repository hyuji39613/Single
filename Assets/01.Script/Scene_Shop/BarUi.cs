using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BarUi : MonoBehaviour
{
    public GameObject buyShop;
    public GameObject sellShop;

    private void Start()
    {
        buyShop.SetActive(false);
        sellShop.SetActive(false);

    }
    public void Exitbtn()
    {
        SceneManager.LoadScene("Main");
    }
    public void BuyBtn()
    {
        buyShop.SetActive(true);
    }
    public void BuyCancel()
    {
        buyShop.SetActive(false);
    }
    public void SellBtn()
    {
        sellShop.SetActive(true);     
    }
    public void SellCancel()
    {
        sellShop.SetActive(false);
    }
    public void InvenBtn()
    {
        InventoryManager.instance.gameObject.SetActive(true);
    }

}
