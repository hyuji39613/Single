using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainUi : MonoSingleTon<MainUi>
{
    [SerializeField] private List<Sprite> basket;
    
    public Image inventoryBasket;

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
}
