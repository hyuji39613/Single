using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItenViewDo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOLocalMoveX(640, 0.3f);    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOLocalMoveX(1200, 0.3f);

    }
}

