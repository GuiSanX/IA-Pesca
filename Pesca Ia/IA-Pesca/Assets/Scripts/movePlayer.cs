using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private Transform t;

    void Start()
    {
        t = this.transform;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            t.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector3 (t.position.x, t.position.y, 0);
        }   
    }
}
