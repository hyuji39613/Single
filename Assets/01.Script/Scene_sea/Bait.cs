using DG.Tweening;
using UnityEngine;

public class Bait : MonoSingleton<Bait>
{
    [SerializeField]
    private Transform line;
    [SerializeField]
    private Transform rod;
    public bool trigger = false;
    public GameObject fish;
    public bool pulling;
    private void Update()
    {
        float a = rod.localScale.x * 0.5f;
        transform.position = line.position + line.right * a;
        if (Input.GetKey(KeyCode.Space))
        {
            pulling = true;
            if (trigger)
            {
                Debug.Log(trigger);
                Fish fishCompo = fish.GetComponent<Fish>();
                fish.transform.position = transform.position;
                fishCompo.isFising = true;
                if (rod.localScale == new Vector3(1, 1, 1) && fishCompo.isFising)
                {
                    Camera.main.transform.DOMoveY(0, 0.3f).SetEase(Ease.InOutQuad);
                    Destroy(fish);
                    EncyManager.instance.EncyEnable((int)(fishCompo.fishData.fishEnum));
                    trigger = false;
                    if (fishCompo.fishData.fishEnum == FishEnum.pot)
                        ItemView.instance.PotBtnOn();

                    else if (fishCompo.fishData.fishEnum == FishEnum.glassCup)
                        ItemView.instance.GlassBtnOn();
                    else
                        InventoryManager.instance.FishingItem(fishCompo.fishData);
                }
            }
        }
        else
        {
            pulling = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            fish = collision.gameObject;
            trigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
            trigger = false;
    }
}
