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
        numList.Remove(0);
        slot.gameObject.GetComponent<Image>().sprite = fishData.fishSprite;
        slot.EnumSet(fishData.fishEnum);
        slot.gameObject.SetActive(true);
    }
}
