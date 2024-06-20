using System.Collections;
using TMPro;
using UnityEngine;

public class TalkSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;
    private bool pushEsc;
    private void Start()
    {
        StartCoroutine(Typing(txt, "¾È³ç11dasd", 0.1f));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            pushEsc = true;
        }
    }
    public IEnumerator Typing(TextMeshProUGUI txtObj, string text, float rate)
    {
        for (int i = 0; i <= text.Length; i++)
        {
            if (pushEsc)
            {
                txtObj.text = text;
                pushEsc = false;
                break;
            }
            txtObj.text = text.Substring(0, i);
            yield return new WaitForSecondsRealtime(rate);
        }
    }
}
