using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private List<Slots> invenList = new List<Slots>();//인벤 슬롯들 담아두는 리스트
    public static InventoryManager instance; //싱글턴
    private int invenNum; // 시작할때 슬롯들 번호 매겨주는 용도
    public List<int> emptySlotNums = new List<int>(); // 빈 슬롯 번호 목록
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
            emptySlotNums.Add(invenNum);
            invenList.Add(slot);
            invenNum++;
        }
    }
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ExitBtn()
    {
        gameObject.SetActive(false);
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

    public void EmptyFillStart(int slotNum, FishDataSo fishData)
    {
        StartCoroutine(EmptyFill(slotNum, fishData));
    }

    private IEnumerator EmptyFill(int slotNum, FishDataSo fishData)
    {
        int n = slotNum;
        yield return new WaitForSeconds(0.7f);
        do
        {
            //맨뒤 삭제시 문제
            invenList[n].gameObject.SetActive(true);
            invenList[n].EnumSet(invenList[++n].fishData);
            invenList[n].gameObject.SetActive(false);
        } while (n < emptySlotNums[0]-1);
        emptySlotNums.Add(n);
        invenList[n].gameObject.SetActive(false);
    }
}
