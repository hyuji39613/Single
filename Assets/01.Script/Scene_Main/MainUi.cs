using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainUi : MonoBehaviour
{
    public void EncyBtn()
    {
        EncyManager.instance.gameObject.SetActive(true);
    }
    
    public void InvenBtn()
    {
        InventoryManager.instance.gameObject.SetActive(true);
    }
}
