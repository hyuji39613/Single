using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoCollider : MonoBehaviour
{
    private void Start()
    {
        if (!ItemView.instance.firstStart&&!SellManager.instance.isFirst)
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TutoManager.instance.TalkSys();
        }
    }
}
