using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
   public float Coin_Score;
    public Text CoinTXT;

    // Update is called once per frame
    void Update()
    {
        Coin_Score = MosqCoin.MosqCoins;
        CoinTXT.text = "현재 획득 코인" + Mathf.Round(Coin_Score) + "X 개";
    }
}
