using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItenViewDo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        ItemView.instance.LeftMove();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ItemView.instance.RightMove();

    }
}

