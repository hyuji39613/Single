using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUi : MonoSingleTon<MainUi>
{
    [SerializeField] private List<Sprite> basket;
    public Image inventoryBasket;
    public GameObject stopUi;
    public GameObject SettingUi;

    private void Start()
    {
        FishingBasket();
    }
    public void EncyBtn()
    {
        EncyManager.instance.gameObject.SetActive(true);
    } 
    public void InvenBtn()
    {
        InventoryManager.instance.ExitBtn(true);       
    }
    public void FishingBasket()
    {
        if (InventoryManager.instance.emptySlotNums[0] == 0)
           inventoryBasket.sprite = basket[0];
        else
            inventoryBasket.sprite = basket[1];
    }
    public void StopBtn()
    {
        stopUi.SetActive(true);
    }
    public void ContinueBtn()
    {
        stopUi.SetActive(false);
    }
    public void QuitBtn()
    {
        SceneManager.LoadScene("Start");
    }
    public void SettingBtn()
    {
        SettingUi.SetActive(true);
    }
    public void SettingOkBtn()
    {
        SettingUi.SetActive(false);
        stopUi.SetActive(false);
    }
}
