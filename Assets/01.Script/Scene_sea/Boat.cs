using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position -= new Vector3(1, 0, 0)* 1.5f * Time.deltaTime;
        }
        if (Input.GetMouseButton(1))
        {
            transform.position += new Vector3(1, 0, 0) * 1.5f * Time.deltaTime;
        }
    }
}
