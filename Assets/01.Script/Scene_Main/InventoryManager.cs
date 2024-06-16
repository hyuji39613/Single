using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject sellBtn, sellCheck;
    public Color slotColor;
    private List<Slots> invenList = new List<Slots>();//인벤 슬롯들 담아두는 리스트
    public static InventoryManager instance; //싱글턴
    private int invenNum; // 시작할때 슬롯들 번호 매겨주는 용도
    public List<int> emptySlotNums = new List<int>(); // 빈 슬롯 번호 목록

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
              DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        foreach (Slots slot in transform.GetComponentsInChildren<Slots>())
        {
            slot.gameObject.SetActive(false);
            slot.slotNum = invenNum;
            emptySlotNums.Add(invenNum);
            invenList.Add(slot);
            invenNum++;
        }
    }
    private void Start()
    {
        ExitBtn();
    }
    public void SellBtnOnOff(bool value)
    {
        sellBtn.SetActive(value);
    }
    public void SellectBtn()
    {
        sellCheck.SetActive(true);
        SellManager.instance.isSell = false;
    }
    public void SellectOk()
    {
        SellManager.instance.sellSlotList.Sort();
        for (int i = SellManager.instance.sellSlotList.Count - 1; i >= 0; i--)
        {
            EmptyFill(SellManager.instance.sellSlotList[i]);
            invenList[SellManager.instance.sellSlotList[i]].gameObject.transform.parent.GetComponent<Image>().color = slotColor;
        }
        SellManager.instance.SellCheckOk();
        ExitBtn();
        sellCheck.SetActive(false);
        SellManager.instance.ReSetAll();
    }
    public void SellectNo()
    {
        sellCheck.SetActive(false);
        SellManager.instance.isSell = true;
        for (int i = SellManager.instance.sellSlotList.Count-1; i >= 0; i--)
            invenList[SellManager.instance.sellSlotList[i]].gameObject.transform.parent.GetComponent<Image>().color = slotColor;
        SellManager.instance.ReSetAll();

    }
    public void ExitBtn(bool value = false)
    {
        transform.Find("Canvas").gameObject.SetActive(value);
    }
    public void FishingItem(FishDataSo fishData)
    {
        if (emptySlotNums.Count <= 0) return;
        emptySlotNums.Sort();
        int index = emptySlotNums[0];
        Slots slot = invenList[index];
        emptySlotNums.RemoveAt(0);
        slot.EnumSet(fishData);
        slot.gameObject.SetActive(true);

    }
    public void EmptyFillStart(int slotNum)
    {
        StartCoroutine(EmptyFillCoru(slotNum));
    }
    private IEnumerator EmptyFillCoru(int slotNum)
    {
        int n = slotNum;
        yield return new WaitForSeconds(0.7f);
        if (!(emptySlotNums[0] - 1 == n))
        {
            do
            {
                invenList[n].gameObject.SetActive(true);
                invenList[n].EnumSet(invenList[++n].fishData);
                invenList[n].gameObject.SetActive(false);
            } while (n < emptySlotNums[0] - 1);
        }
        emptySlotNums.Add(n);
        invenList[n].gameObject.SetActive(false);
        emptySlotNums.Sort();
        MainUi.Instance.FishingBasket();
    }
    private void EmptyFill(int slotNum)
    {
        int n = slotNum;
        if (!(emptySlotNums[0] - 1 == n))
        {
            do
            {
                invenList[n].gameObject.SetActive(true);
                invenList[n].EnumSet(invenList[++n].fishData);
                invenList[n].gameObject.SetActive(false);
            } while (n < emptySlotNums[0] - 1);
        }
        emptySlotNums.Add(n);
        invenList[n].gameObject.SetActive(false);
        emptySlotNums.Sort();
    }
}
