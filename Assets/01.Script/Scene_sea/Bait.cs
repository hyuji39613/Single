using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bait : MonoBehaviour
{

    [SerializeField]
    private Transform line;
    [SerializeField]
    private Transform rod;
    private bool trigger = false;
    private GameObject fish;



    private void Update()
    {
        float a = rod.localScale.x * 0.5f;
        transform.position = line.position + line.right * a;

        if (Input.GetKeyDown(KeyCode.Space) && trigger)
        {
            int b = (int)(fish.GetComponent<Fish>().fishData.fishEnum);
            Destroy(fish);

            EncyManager.instance.EncyEnable(b);
            InventoryManager.instance.FishingItem(fish.GetComponent<Fish>().fishData);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            trigger = true;        
            fish = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger = false;
    }


}
