using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePeixe : MonoBehaviour
{
    private GameObject player;
    private GameMaster gameMaster;
    private Rigidbody2D rigidPeixe;
    private Transform waypoint;
    private float distancia;
    private float distanciaDoPlayer;
    public float distanciaMedo =2;
    public float speed = 5;
    private bool fugindo = false;

    public fuguinha[] fuguinhas;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        rigidPeixe = this.gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (waypoint != null)
        {
            distancia = Vector2.Distance(this.transform.position, waypoint.position);
        }

        distanciaDoPlayer = Vector2.Distance(this.transform.position, player.transform.position);

        if (fugindo)
        {
            Run();
        }
        else
        {
            Idle();
        }
    }

    void Idle()
    {
        if (distanciaDoPlayer < distanciaMedo)
        {
            fugindo = true;
            waypoint = null;
            return;
        }

        if (waypoint == null)
        {
            AcharWaypoint();
        }

        else
        {
            if (distancia < .1f)
            {
                AcharWaypoint();
            }

            else
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, waypoint.transform.position, speed*Time.deltaTime);
            }
        }
    }

    void Run()
    {
        if ( distanciaDoPlayer > 1.5*distanciaMedo)
        {
            fugindo = false;
            return;
        }

        Transform fuguinhaMaisLonge = null;
        float distanciaMaisLonge = 0;

        foreach (fuguinha f in fuguinhas)
        {

            if (f.fugaValida)
            {
                float fd = Vector2.Distance(player.transform.position, f.transform.position);
                if (fd > distanciaMaisLonge)
                {
                    distanciaMaisLonge = fd;
                    fuguinhaMaisLonge = f.transform;
                }
            }
        }

        //this.transform.position = Vector2.MoveTowards(this.transform.position, fuguinhaMaisLonge.position, speed*2*Time.deltaTime);
        Vector2 movimento = new Vector2(this.transform.position.x, fuguinhaMaisLonge.position.y);

        rigidPeixe.AddForce (movimento*speed);
        //Debug.Log(fuguinhaMaisLonge);
    }

    void AcharWaypoint()
    {
        int random = Random.Range(0, gameMaster.waypoints.Length);
        waypoint = gameMaster.waypoints[random];
    }
}
