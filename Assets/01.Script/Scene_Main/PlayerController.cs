using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float v;
    private float h;
    public float speed = 1.5f;

    void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(h, v, 0).normalized* speed * Time.deltaTime;

    }

}
