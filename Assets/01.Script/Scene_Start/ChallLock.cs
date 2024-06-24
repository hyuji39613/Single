using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallLock : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(ItemView.instance.firstStart);
    }

}
