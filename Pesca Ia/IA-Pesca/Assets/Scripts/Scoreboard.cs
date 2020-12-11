using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    public Text scoreText, timerText;
    private int pontosCurrent;
    [HideInInspector] public PeixeSpawner peixeSpawner_ref;
    public float timerMax;
    private float timeCurrent;
    private bool gameEnded = false;
    private EndOfGame endGame_ref;

    private void Awake()
    {
        endGame_ref = GameObject.FindGameObjectWithTag("Canvas").GetComponent<EndOfGame>();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameEnded = false;
        timeCurrent = timerMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded)
        {
            return;
        }
        if (timeCurrent <= 0)
        {
            gameEnded = true;
            endGame_ref.OpenEndGameUi(pontosCurrent);
        }
        timeCurrent -= Time.deltaTime;
        int i = (int)timeCurrent;
        timerText.text = i.ToString();
    }

    public void UpdateScore(int pontos, float tempo)
    {
        pontosCurrent += pontos;
        scoreText.text = pontosCurrent.ToString();
        timeCurrent += tempo;
        peixeSpawner_ref.SpawnPeixe();
    }

}
