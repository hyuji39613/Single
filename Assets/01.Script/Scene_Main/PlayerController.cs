using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float v;
    public float h;
    public float speed = 1.5f;
    public Vector2 moveDir {  get; private set; }


    void Update()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");

        if (h != 0)      
            v = 0;
        moveDir = new Vector2(h, v);
        moveDir = moveDir.normalized * speed;
    }

}
