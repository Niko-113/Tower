using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives;

    public static GameManager master;
    // Start is called before the first frame update
    void Start()
    {
        master = this;
    }

    public void GoalHit(){
        lives--;
        if (lives <= 0) GameOver();
    }

    void GameOver()
    {
        // Tell scenemanager to do its thing
    }

    
}
