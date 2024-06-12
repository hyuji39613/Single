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
        int fishNumber = Random.Range(0, fishDataList.Count);
        fishData = fishDataList[0];

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
        if (isFising) return;
        rigid.velocity = transform.right*dir * fishData.speed;
    }

    public void ResetItem()
    {

    }
}
