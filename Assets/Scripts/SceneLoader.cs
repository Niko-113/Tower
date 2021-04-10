using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    Button startButton;
    bool isStart = true;
    public static SceneLoader loader = null;

    void Awake()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded;
        if (loader == null)
        {
            DontDestroyOnLoad(this.gameObject);
            loader = this;
        } 
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void ReloadScene()
    {
        isStart = false;
        SceneManager.LoadScene("TowerDefense");    
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (this != loader) return;

        if (!isStart)
        {
            if (this == null) return;
            startButton = GameObject.Find("Start").GetComponent<Button>();
            startButton.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else {Time.timeScale = 0;}
    }

}
