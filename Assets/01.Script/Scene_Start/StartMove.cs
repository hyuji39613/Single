using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    public RectTransform boat;
    public Transform bluetang;
    public Transform white;

    private void Start()
    {
        bluetang.DOMoveX(-11,20f).SetLoops(-1,LoopType.Restart);
        bluetang.DOMoveY(-1,0.7f).SetLoops(-1,LoopType.Yoyo);
        white.DOMoveX(10,15f).SetLoops(-1,LoopType.Restart);
        white.DOMoveY(-4.5f,0.7f).SetLoops(-1,LoopType.Yoyo);
        boat.DOAnchorPosX(-2700, 30f);
    }
}
