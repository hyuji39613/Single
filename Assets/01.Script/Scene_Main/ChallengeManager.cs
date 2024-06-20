using DG.Tweening;
using UnityEngine;

public class ChallengeManager : MonoBehaviour
{
    [SerializeField] private RectTransform encyChallenge;
    [SerializeField] private RectTransform encyChallengeAll;
    private bool encyChallengeClear = false;

    private void Update()
    {
        if (!encyChallengeClear && EncyManager.instance.count == 16)
        {
            encyChallengeClear = true;
            Sequence seq = DOTween.Sequence();
            seq.Append(encyChallenge.DOAnchorPosY(255, 1f));
            seq.AppendInterval(2f);
            seq.Append(encyChallenge.DOAnchorPosY(-0, 1f));

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            encyChallengeClear = true;
            Sequence seq = DOTween.Sequence();
            seq.Append(encyChallenge.DOAnchorPosY(255, 1f));
            seq.AppendInterval(2f);
            seq.Append(encyChallenge.DOAnchorPosY(0, 1f));
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            encyChallengeClear = true;
            Sequence seq = DOTween.Sequence();
            seq.Append(encyChallengeAll.DOAnchorPosY(255, 1f));
            seq.AppendInterval(2f);
            seq.Append(encyChallengeAll.DOAnchorPosY(0, 1f));
        }
    }

}
