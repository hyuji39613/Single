using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisingrod : MonoBehaviour

{
    private float desiredAngle;
    private ItemSO rodData;

    private void Awake()
    {
        rodData = ItemView.instance.rodData;
    }
    void Update()
    {
        if (!ScenreManage.Stoping)
        {
            Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 aimDir = (Vector3)point - transform.position;
            desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
            desiredAngle = Mathf.Clamp(desiredAngle, rodData.rodMinAngle, rodData.rodMaxAngle);
            transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);
        }
    }
}
