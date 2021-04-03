using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Purse : MonoBehaviour
{
    public static Purse coinPurse;
    public Text coinText;
    public int coins = 0;

    void Start(){
        coinPurse = this;
        coinText.text = "Coins: " + coins;
    }

    public void addCoins(int num){
        coins += num;
        coinText.text = "Coins: " + coins;
    }
}
