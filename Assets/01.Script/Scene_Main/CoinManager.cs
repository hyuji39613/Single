using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum CoinEnum
{
    GoldCoin,
    SilverCoin
}
public class CoinManager : MonoBehaviour
{
    [SerializeField] Text goldCoinTxt, silverCoinTxt;
    [SerializeField] Transform currencyCoin;
    public static CoinManager instance;
    private int goldCoin = 0, silverCoin = 20;


    public void GetCoin(CoinEnum coinEnum, int value)
    {
        if (coinEnum == CoinEnum.GoldCoin) goldCoin += value;
        if (coinEnum == CoinEnum.SilverCoin) silverCoin += value;
    }
    public bool UseCoin(CoinEnum coinEnum, int value)
    {
        if (coinEnum == CoinEnum.GoldCoin)
        {
            if (goldCoin - value >= 0)
            {
                goldCoin = goldCoin - value;
                return true;
            }
            else if (goldCoin - value < 0)
            {
                return false;
            }
        }
        else if (coinEnum == CoinEnum.SilverCoin)
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
        if (SceneManager.GetActiveScene().name == "Shop")
        {
            currencyCoin.position = new Vector3(260, currencyCoin.position.y, currencyCoin.position.z);
        }
        else if (SceneManager.GetActiveScene().name == "Sea")
        {
            currencyCoin.gameObject.SetActive(false);
        }
        else
        {
            currencyCoin.gameObject.SetActive(true);
            currencyCoin.position = new Vector3(392, currencyCoin.position.y, currencyCoin.position.z);
        }

    }

}
