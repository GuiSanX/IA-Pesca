using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuguinha : MonoBehaviour
{
    public bool fugaValida = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Parede") || other.gameObject.CompareTag("Player"))
        {
            fugaValida = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Parede") || other.gameObject.CompareTag("Player"))
        {
            fugaValida = true;
        }
    }
}
