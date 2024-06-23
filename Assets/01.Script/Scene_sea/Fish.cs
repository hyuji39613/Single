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
    Sunfish,
    garBag,
    plCup,
    pot,
    glassCup
}
public class Fish : MonoBehaviour, Ipoolable
{
    [SerializeField] private string poolName;
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
        float posY = Random.Range(fishData.minY, fishData.maxY);
        int ranX = Random.Range(0, 2);
        float posX = posXList[ranX];

        transform.position = new Vector3(posX, posY, 0);
        spriteRen.flipX = ranX == 1;
        dir = spriteRen.flipX ? -1 : 1;
    }
    private void FixedUpdate()
    {
        if(Mathf.Abs(transform.position.x)>= 11.1f)
        {
            PoolManager.Instance.Push(this);
        }
        if (isFising) return;
        rigid.velocity = transform.right * dir * fishData.speed;
    }
    public void ResetItem()
    {
        isFising = false;
    }
}
