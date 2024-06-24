using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public float speed = 2.7f;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))    
        {
            transform.position += -transform.up* speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-21.7f,0),transform.position.z);
    }
}
