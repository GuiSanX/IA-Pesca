using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfGame : MonoBehaviour
{
    public GameObject newHS, notHS, ui;
    public Text yourScore, highScore01, highScore02;
    [HideInInspector] public int newScore_int, highScore_Int;

    private void Start()
    {
        newHS.SetActive(false);
        notHS.SetActive(false);
        ui.SetActive(false);
        int i = PlayerPrefs.GetInt("HighScore");
        highScore_Int = i;
    }

    public void OpenEndGameUi(int newScore)
    {
        ui.SetActive(true);
        newScore_int = newScore;
        if (newScore_int > highScore_Int)
        {
            NewHighScore();
        }
        else
        {
            NotHighScore();
        }
    }

    private void NewHighScore()
    {
        newHS.SetActive(true);
        highScore02.text = newScore_int.ToString();
        PlayerPrefs.SetInt("HighScore", newScore_int);
    }

    private void NotHighScore()
    {
        notHS.SetActive(true);
        highScore01.text = highScore_Int.ToString();
        yourScore.text = newScore_int.ToString();
    }

    public void QuitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }

}
