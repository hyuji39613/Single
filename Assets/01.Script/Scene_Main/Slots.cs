using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            InventoryManager.instance.EmptyFillStart(slotNum,fishData);
            DestoryItem.isDel = false;
        }
    }
}
