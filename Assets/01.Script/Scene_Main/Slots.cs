using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slots : MonoBehaviour
{
    private FishEnum slotInfo;
    public int slotNum;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SlotBtn);
    }
    public void EnumSet(FishEnum fishenum)
    {
        slotInfo = fishenum;
    }

    private void SlotBtn()
    {
        if (DestoryItem.isDel)
        {
            gameObject.SetActive(false);
            slotInfo = 0;
            InventoryManager.instance.numList.Add(slotNum);
            DestoryItem.isDel = false;
        }
    }
}
