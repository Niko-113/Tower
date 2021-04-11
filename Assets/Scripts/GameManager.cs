using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager master;
    public HordeManager hordeManager;
    public Text coinText;
    public Text livesText;
    public Button restartButton;
    public int coins = 0;
    public int lives;


    void Start()
    {
        master = this;
        coinText.text = "Coins: " + coins;
        livesText.text = "Lives: " + lives;
        // PauseGame();
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
        if (lives <= 0) GameOver();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneLoader.loader.ReloadScene();
    }

    public void CheckForEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0 && !hordeManager.finished.Contains(false)) GameOver();
    }

    void GameOver()
    {
        PauseGame();
        restartButton.gameObject.SetActive(true);
    }

}
