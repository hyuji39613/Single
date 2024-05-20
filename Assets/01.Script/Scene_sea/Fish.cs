using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Fish : ScriptableObject
{
    [SerializeField]
    private float speed = 1.5f;

    void Update()
    {
      //transform.position += transform.right * speed * Time.deltaTime;
    }
}
