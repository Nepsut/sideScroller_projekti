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
    private int score;
    public Button RestartButton;


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
