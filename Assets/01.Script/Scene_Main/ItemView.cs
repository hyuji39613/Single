using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private Image rodBtnImage;
    private List<ItemSO> rodDataSo = new List<ItemSO>();
    public ItemSO rodData;
    private int index;
    public static ItemView instance;
    [SerializeField] private GameObject potBtn,glassBtn;
    [SerializeField]
    private RectTransform itemViewUi;
    [SerializeField]
    private Image arrow;
    private float tweenTime = 1f;
    public bool firstStart = true;
    public bool isPot, isGlass;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Color color = arrow.color;
        color.a = 1;
        arrow.color = color;
    }
    public void RodBtnClick()
    {
        if (rodDataSo.Count <= 0) return;
        if (index == rodDataSo.Count) index = 0;
        rodData = rodDataSo[index++];
        rodBtnImage.sprite = rodData.rodSprite;

        if (SceneManager.GetActiveScene().name == "Sea")
        {

        }       
    }
    public void BuyRod(ItemSO item)
    {
        rodDataSo.Add(item);
        rodData = item;
        index = rodDataSo.Count;
        rodBtnImage.sprite = rodData.rodSprite;
    }
    private void Update()
    {
        ViewVisible();
    }
    public void ViewVisible()
    {
        if(SceneManager.GetActiveScene().name == "Main")
        {
            transform.localScale = Vector3.one;
        }
        else
        {
            transform.localScale = Vector3.zero;
        }
    }
    
    public void PotBtnOn()
    {
        potBtn.SetActive(true);
        isPot = true;
    }
    public void PotBtn()
    {
        //냄비 착용 비착용 코드 작성
    }
    public void GlassBtnOn()
    {
        glassBtn.SetActive(true);
        isGlass = true;
    }
    public void GlassBtn()
    {
        //유리병 관련 코드
    }

    public void LeftMove()
    {
        itemViewUi.DOAnchorPosX(-340, 0.3f).SetEase(Ease.OutExpo);
        Color color = arrow.color;
        color.a = 0;
        arrow.color = color;
    }
    public void RightMove()
    {
        itemViewUi.DOAnchorPosX(154, 0.3f).SetEase(Ease.InExpo);
        Color color = arrow.color;
        color.a = 1;
        arrow.color = color;
    }
}
