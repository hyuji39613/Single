using System.Collections;
using TMPro;
using UnityEngine;

public class TalkSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;
    AudioSource a;
    private bool pushEsc;
    private void Start()
    {
        StartCoroutine(Typing(txt, "¾È³ç11dasd", 0.2f, a));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pushEsc = true;
        }
    }
    public IEnumerator Typing(TextMeshProUGUI txtObj, string text, float rate, AudioSource audio)
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
            //if (txtObj.text.Length > 0 && txtObj.text[txtObj.text.Length - 1] != ' ') audio.Play();
            yield return new WaitForSecondsRealtime(rate);
        }
    }
}
