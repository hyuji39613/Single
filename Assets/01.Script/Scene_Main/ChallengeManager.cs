using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChallengeManager : MonoBehaviour
{
    public static ChallengeManager instance;
    [SerializeField] private RectTransform encyChallenge;
    [SerializeField] private RectTransform encyChallengeAll;
    [SerializeField] private RectTransform trashChallenge;
    [SerializeField] private GameObject ChallengPanel;
    [SerializeField] private GameObject challenge1, challenge2, challenge3;
    private bool encyChallengeClear = false;
    private bool encyChallengeAllClear = false;
    private bool trashCatchChallenge = false;
    public int trashCount;
     
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += HandleSceneChange;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void HandleSceneChange(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "Start")
        {
            GameObject.Find("Cllange").GetComponent<Button>().onClick.AddListener(PanelOn);
        }
    }
    private void PanelOn()
    {
        ChallengPanel.SetActive(true);
    }
    public void PanelOff()
    {
        ChallengPanel.SetActive(false);
    }
    private void Update()
    {
        EncyChClear();
        EncyChAllClear();
        TrashCatchCha();
    }
    private void EncyChClear()
    {
        if (!encyChallengeClear && EncyManager.instance.fishcount >= 10)
        {
            encyChallengeClear = true;
            Sequence seq = DOTween.Sequence();
            seq.Append(encyChallenge.DOAnchorPosY(255, 1f));
            seq.AppendInterval(2f);
            seq.Append(encyChallenge.DOAnchorPosY(-0, 1f));
            challenge1.SetActive(true);
        }
    }
    private void EncyChAllClear()
    {
        if (!encyChallengeAllClear && EncyManager.instance.count >= 15)
        {
            encyChallengeAllClear = true;
            Sequence seq = DOTween.Sequence();
            seq.Append(encyChallengeAll.DOAnchorPosY(255, 1f));
            seq.AppendInterval(2f);
            seq.Append(encyChallengeAll.DOAnchorPosY(-0, 1f));
            challenge2.SetActive(true);
        }
    }
    private void TrashCatchCha()
    {
        if (!trashCatchChallenge && trashCount >= 50)
        {
            trashCatchChallenge = true;
            Sequence seq = DOTween.Sequence();
            seq.Append(trashChallenge.DOAnchorPosY(255, 1f));
            seq.AppendInterval(2f);
            seq.Append(trashChallenge.DOAnchorPosY(-0, 1f));
            challenge3.SetActive(true);
        }
    }
}
