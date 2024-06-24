using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutoManager : MonoBehaviour
{
    [SerializeField] private List<Button> tutoBtnList;
    public static TutoManager instance;
    [SerializeField] private TextMeshProUGUI talkTxt;
    [SerializeField] private List<string> talkList;
    [SerializeField] private GameObject textObj, panel;
    private int index = 0;
    private bool endText;
    private void Start()
    {
        if (ItemView.instance != null)
        {
            if (!ItemView.instance.firstStart)
            {
                Destroy(gameObject);
                return;
            }
        }
        if (!SellManager.instance.isFirst)
        {
            Destroy(gameObject);
            return;
        }
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            SceneManager.sceneLoaded += HandleEventChange;
        }
        else
        {
            Destroy(gameObject);
        }
        TalkSys();
        tutoBtnList[1].onClick.AddListener(BtnManager.Instance.CommonRodBtn);
        tutoBtnList[2].onClick.AddListener(BtnManager.Instance.ExitBuyPanel);
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= HandleEventChange;
    }
    private void HandleEventChange(Scene arg0, LoadSceneMode arg1)
    {
        if ((arg0.name == "Sea"))
        {
            Time.timeScale = 0;
            TalkSys();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !endText)
        {
            endText = true;
        }
    }

    public void NextBtn()
    {
        if (!endText) return;

        switch (index)
        {
            case 2:
                SettingBtn();
                break;
            case 3:
                SettingBtn();
                break;
            case 4:
                SettingBtn();
                break;
            case 5:
                SettingBtn();
                ItemView.instance.firstStart = false;
                break;
            case 6:
                TutoOff();
                break;
            case 7:
                TutoOff();
                break;
            case 14:
                Time.timeScale = 1;
                ItemView.instance.firstStart = false;
                SellManager.instance.isFirst = false;
                Destroy(gameObject);
                break;
            default:
                TalkSys();
                break;
        }
    }

    private void TutoOff()
    {
        panel.SetActive(false);
        textObj.SetActive(false);
    }

    private void SettingBtn()
    {
        textObj.SetActive(false);
        tutoBtnList[index - 2].gameObject.SetActive(true);
    }
    public void Exitbtn()
    {
        SceneManager.LoadScene("Main");
    }
    public void BuyBtnON()
    {
        BtnManager.Instance.BuyPanel.SetActive(true);
    }
    public void TextObjOn()
    {
        textObj.SetActive(true);
    }
    public void BuyBtnOff()
    {
        GameObject button = EventSystem.current.currentSelectedGameObject;
        button.SetActive(false);
        TalkSys();
    }

    public void TalkSys()
    {
        if (index >= talkList.Count) return;
        panel.SetActive(true);
        textObj.SetActive(true);
        StartCoroutine(Typing(talkList[index], 0.1f));
    }
    public IEnumerator Typing(string text, float rate)
    {
        endText = false;
        for (int i = 0; i <= text.Length; i++)
        {
            talkTxt.text = text.Substring(0, i);
            if (endText) break;
            yield return new WaitForSecondsRealtime(rate);
        }
        talkTxt.text = text;
        endText = true;
        index++;
    }
}
