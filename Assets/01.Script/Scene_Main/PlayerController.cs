using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float v;
    public float h;
    public float speed = 1.5f;

    [SerializeField] private GameObject textpanel;
    [SerializeField] private TextMeshProUGUI talkTxt;
    public Vector2 moveDir { get; private set; }
    private void Start()
    {
        if (ItemView.instance.firstStart)
        {
            StartCoroutine("MoveCoroutine");
        }
    }
    void Update()
    {
        if (!ItemView.instance.firstStart)
        {

            v = Input.GetAxisRaw("Vertical");
            h = Input.GetAxisRaw("Horizontal");

            if (h != 0)
                v = 0;

        }

        moveDir = new Vector2(h, v);
        moveDir = moveDir.normalized * speed;
    }
    private IEnumerator MoveCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        v = -1;
        h = 0;
        yield return new WaitForSeconds(0.96f);
        v = 0;
        h = 0;
        textpanel.SetActive(true);
        StartCoroutine(Typing("¾È³ç! ¹Ý°¡¿ö\n³¬½Ã¸¦ ÇÏ·Á¸é ³¬½Ë´ë°¡ ÇÊ¿äÇÏ°ÚÁö?", 0.1f));
        yield return new WaitForSeconds(5f);
        textpanel.SetActive(false);
        h = 1;
        v = 0;
    }
    public IEnumerator Typing(string text, float rate)
    {
        for (int i = 0; i <= text.Length; i++)
        {
            talkTxt.text = text.Substring(0, i);
            yield return new WaitForSecondsRealtime(rate);
        }
    }
}
