using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IteemInfoManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject itemInfo;

    public void OnPointerEnter(PointerEventData eventData)
    {
        itemInfo.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        itemInfo.SetActive(false);
    }
}
