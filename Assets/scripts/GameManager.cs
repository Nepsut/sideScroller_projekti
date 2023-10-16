using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//THIS SCRIPT IS FOR UI

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    public TextMeshProUGUI MainMenuText;
    private int score;
    public Button RestartButton;
    public Button PlayButton; //adds
    public Button QuitButton; //adds


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int ScoreToAdd)
    {
        score += ScoreToAdd;
        ScoreText.text = "Score: " + score;

    }


    public void OnPlayButton() //adds
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnQuitButton() //adds
    {
        Application.Quit(); 
    }

    public void GameOver()
    {
        RestartButton.gameObject.SetActive(true);
        GameOverText.gameObject.SetActive(true);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
