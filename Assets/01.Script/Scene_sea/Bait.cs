using DG.Tweening;
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

        if (Input.GetKey(KeyCode.Space) && trigger)
        {
            Fish fishCompo = fish.GetComponent<Fish>();
            fish.transform.position = transform.position;   
            fishCompo.isFising = true;
            if (rod.localScale == new Vector3(1, 1, 1) && fishCompo.isFising)
            {
                Camera.main.transform.DOMoveY(0, 0.3f).SetEase(Ease.InOutQuad);
                Destroy(fish);
                EncyManager.instance.EncyEnable((int)(fishCompo.fishData.fishEnum));
                InventoryManager.instance.FishingItem(fishCompo.fishData);

            }
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
