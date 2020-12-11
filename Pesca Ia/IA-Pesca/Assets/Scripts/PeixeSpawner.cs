using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeixeSpawner : MonoBehaviour
{
    private Scoreboard scoreboard_ref;
    private GameMaster game_ref;
    public GameObject peixePrefab;

    private void Awake()
    {
        scoreboard_ref = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Scoreboard>();
        game_ref = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        scoreboard_ref.peixeSpawner_ref = this;
    }

    public Transform RandomSpawnPoint()
    {
        Transform t;

        int i = Random.Range(0, game_ref.waypoints.Length);
        t = game_ref.waypoints[i];
        return t;
    }

    public void SpawnPeixe()
    {
        Transform t = RandomSpawnPoint();
        Instantiate(peixePrefab, t.position, Quaternion.identity);
    }
}
