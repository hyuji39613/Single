using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnManager : MonoBehaviour
{
    public void CommonRodBtn()
    {
        if(CoinManager.instance.UseCoin(CoinEnum.SilverCoin, 50))
        {

        }
    }
}
