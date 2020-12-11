using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text highscore_Text;

    public void Start()
    {
        int i =PlayerPrefs.GetInt("HighScore");
        highscore_Text.text = "High Score: " + i.ToString();

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void  PlayButton()
    {
        SceneManager.LoadScene(1);
    }


}
