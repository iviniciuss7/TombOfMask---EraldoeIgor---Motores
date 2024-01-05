using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Mime;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject pauseObj;
    private bool isPaused;
    public GameObject gameoverObj;
    public TextMeshProUGUI scoreText;
    public int score; 
    

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        
        PauseGame();
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
    }
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
            
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    
    public void GameOver()
    {
        gameoverObj.SetActive(true);
        isPaused = true;
    }

    public void ReiniciarMenu()
    {
        SceneManager.LoadScene(1);
    }
    
    public void EncerrarJogo()
    {
        Application.Quit();
    }
    
    
}
