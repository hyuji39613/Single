using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private List<Slots> invenList = new List<Slots>();
    public static InventoryManager instance;
    private int invenNum;
    public List<int> numList = new List<int>();
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        foreach (Slots slot in transform.GetComponentsInChildren<Slots>())
        {
            slot.gameObject.SetActive(false);
            slot.slotNum = invenNum;
            numList.Add(invenNum);
            invenList.Add(slot);
            invenNum++;
        }
    }

    public void ExitBtn()
    {
        gameObject.SetActive(false);
    }
    public void FishingItem(FishDataSo fishData)
    {
        if (numList.Count <= 0) return;
        numList.Sort();
        Slots slot = invenList[numList[0]];
        numList.Remove(numList[0]);
        slot.EnumSet(fishData);
        slot.gameObject.SetActive(true);
    }


    public void EmptyFill(int slotNum,FishDataSo fishData)
    {
        numList.Add(slotNum);
        numList.Sort();
        int n = numList[0];
        int index = 0;
        while (n < numList[1]-1)
        {
            invenList[numList[index]].gameObject.SetActive(true);
            invenList[numList[index]].EnumSet(invenList[++numList[index]].fishData);
            n++;
            index++;
        }
    }
}
