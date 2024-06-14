using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum CoinEnum
{
    GoldCoin,
    SilverCoin
}
public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;
    [SerializeField] Text goldCoinTxt, silverCoinTxt;

    private int goldCoin = 0, silverCoin = 250;


    public void GetCoin(CoinEnum coinEnum,int value)
    {
        if(coinEnum == CoinEnum.GoldCoin) goldCoin += value;
        if(coinEnum == CoinEnum.SilverCoin) silverCoin += value;
    }
    public bool UseCoin(CoinEnum coinEnum, int value)
    {
        if(coinEnum == CoinEnum.GoldCoin)
        {
            if(goldCoin - value >= 0)
            {
                goldCoin = goldCoin - value;
                return true;
            }
            else if(goldCoin - value < 0) 
            { 
                return false;
            }
        }
        else if(coinEnum == CoinEnum.SilverCoin)
        {
            if (silverCoin - value >= 0)
            {
                silverCoin = silverCoin - value;
                return true;
            }
            else if (silverCoin - value < 0)
            {
                return false;
            }
        }
        return false;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        goldCoinTxt.text = goldCoin.ToString();
        silverCoinTxt.text = silverCoin.ToString();
    }
}
