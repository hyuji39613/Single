using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    private Transform rod;

    private void Update()
    {
        float a = rod.localScale.x * 0.5f;
        transform.position = rod.position + rod.right * a;
    }
}
