using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slots : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int slotNum;
    public FishDataSo fishData;
    private Image image;
    public UnityEngine.Color color;
    public UnityEngine.Color myColor;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SlotBtn);
        image = GetComponent<Image>();
        myColor = image.color;
        color = new UnityEngine.Color(255, 0, 0, 255);
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
            image.color = myColor; 
        }
        if(SellManager.instance.isSell) 
        {
            SellManager.instance.SellItemSelect(slotNum,fishData);
            GameObject button = EventSystem.current.currentSelectedGameObject;
            button.transform.parent.GetComponent<Image>().color = UnityEngine.Color.green;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (DestoryItem.isDel)
        {
            image.color = color;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (DestoryItem.isDel)
        {
            image.color = myColor;
        }
    }
}
