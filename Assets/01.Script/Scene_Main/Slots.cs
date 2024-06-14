using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    public int slotNum;
    public FishDataSo fishData;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SlotBtn);
    }
    public void EnumSet(FishDataSo fishData)
    {
        gameObject.GetComponent<Image>().sprite = fishData.fishSprite;  
        this.fishData = fishData;
    }
    private void SlotBtn()
    {
        if (DestoryItem.isDel)
        {
            gameObject.SetActive(false);
            InventoryManager.instance.EmptyFillStart(slotNum);
            DestoryItem.isDel = false;
        }
        if(SellManager.instance.isSell) 
        {
            SellManager.instance.SellItemSelect(slotNum,fishData);
            GameObject button = EventSystem.current.currentSelectedGameObject;
            button.transform.parent.GetComponent<Image>().color = Color.green;
        }
    }
}
