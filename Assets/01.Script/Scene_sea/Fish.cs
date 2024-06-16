using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public enum FishEnum
{
    Anchovy,
    Mackerel,
    StarFish,
    BlueFish,
    StoneFish,
    PufferFish,
    WhiteDongari,
    Bluetang,
    Sharks,
    Sunfish
}
public class Fish : MonoBehaviour, Ipoolable
{
    [SerializeField] private string poolName;
    [SerializeField] private List<FishDataSo> fishDataList;
    [SerializeField] private List<float> posXList;
    [SerializeField] private LayerMask layerMask;
    public string PoolName => poolName;
    public FishDataSo fishData;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRen;
    private float dir;
    public GameObject ObjectPrefab => gameObject;
    public bool isFising = false;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        int fishNumber = Random.Range(0, 2);
        fishData = fishDataList[fishNumber];

        spriteRen.sprite = fishData.fishSprite;

        float posY = Random.Range(fishData.minY, fishData.maxY);
        int ranX = Random.Range(0, 2);
        float posX = posXList[ranX];

        transform.position = new Vector3(posX, posY, 0);
        spriteRen.flipX = ranX == 1;
        dir = spriteRen.flipX ? -1 : 1;
    }
    private void FixedUpdate()
    {
        TriggerBool();
        if (isFising) return;
        rigid.velocity = transform.right * dir * fishData.speed;
    }
    public void ResetItem()
    {

    }

    public void TriggerBool()
    {
        Collider2D collider = Physics2D.OverlapBox(transform.position, fishData.boxSize, layerMask);
        if(collider && !Bait.Instance.trigger &&!Bait.Instance.pulling)
        {
            Bait.Instance.trigger = collider;
            Bait.Instance.fish = gameObject;    
        }
        else if(isFising&&!collider)
        {
            Bait.Instance.trigger = false;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position,fishData.boxSize);
        Gizmos.color = Color.white;

        
    }
#endif

}
