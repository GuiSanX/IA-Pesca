using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rede : MonoBehaviour
{
    public Scoreboard scoreboard;
    public int pontos;
    public float tempoExtra;
    public float tempoQueDiminui;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Truta"))
        {
            scoreboard.UpdateScore(pontos, tempoExtra);
            Destroy(other.gameObject);
            ReduzTempoBonus();
        }
    }

    void ReduzTempoBonus()
    {
        //instancia peixe no cu
        tempoExtra -= tempoQueDiminui;
    }
}
