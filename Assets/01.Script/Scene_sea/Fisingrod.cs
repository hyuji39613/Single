using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisingrod : MonoBehaviour

{
    private float desiredAngle;

   
    void Update()
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 aimDir = (Vector3)point - transform.position; //z값 0으로 자동변환됨
        desiredAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        //rotation = 쿼터니언
        transform.rotation = Quaternion.AngleAxis(desiredAngle, Vector3.forward);

        
      
    }
}
