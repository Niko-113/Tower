using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager master;
    public Text coinText;
    public Text livesText;
    public int coins = 0;
    public int lives;


    void Start()
    {
        master = this;
        coinText.text = "Coins: " + coins;
        livesText.text = "Lives: " + lives;
        PauseGame();
    }

    public void addCoins(int num)
    {
        coins += num;
        coinText.text = "Coins: " + coins;
    }

    public void goalHit()
    {
        lives--;
        livesText.text = "Lives: " + lives;
        if (lives <= 0) Debug.Log("placeholder"); // scenemanager go!
    }

    void PauseGame(){
        Time.timeScale = 0;
    }

    public void UnpauseGame(){
        Time.timeScale = 1;
    }
}
