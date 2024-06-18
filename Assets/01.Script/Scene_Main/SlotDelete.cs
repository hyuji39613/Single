using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotDelete : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    private Image spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<Image>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
