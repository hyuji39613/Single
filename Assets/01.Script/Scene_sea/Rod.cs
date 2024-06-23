using DG.Tweening;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Rod : MonoBehaviour
{
    private ItemSO rodData;
    public SpriteRenderer bait;

    private void Awake()
    {
        rodData = ItemView.instance.rodData;      
        bait.sprite = rodData.rodSprite;
    }
    void Update()
    {
        if (ScenreManage.Stoping) return;     
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.DOScaleX(1, 0.3f).SetEase(Ease.InOutQuad);
        }
        Vector2 wheelInput = Input.mouseScrollDelta;
        if (wheelInput.y > 0)
        {
            transform.localScale += new Vector3(rodData.rodSpeed, 0, 0);
        }
        else if (wheelInput.y < 0)
        {
            transform.localScale -= new Vector3(rodData.rodSpeed, 0, 0);
        }
        transform.localScale = new Vector3(Mathf.Clamp(transform.localScale.x, 1, rodData.rodMax), transform.localScale.y, transform.localScale.z);
    }
}
