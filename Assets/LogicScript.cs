using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public AudioSource scoreSFX, gameOverSFX;
    public GameObject gameOverScreen;
    public bool gameOverSFX_play = true;

    public void AddScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        scoreSFX.Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverSFX_play=true;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        if (gameOverSFX_play)
        {
            gameOverSFX.Play();
            gameOverSFX_play=false;
        }
        
    }
}
