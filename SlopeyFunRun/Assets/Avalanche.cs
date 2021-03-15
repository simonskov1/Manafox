using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avalanche : MonoBehaviour
{
    Transform player;

    private void Awake()
    {
        player = FindObjectOfType<Controller>().transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position, player.position) > 350)
        {
            transform.position += new Vector3(0, -0.3f, 1.25f) * 0.5f;
        }
        else
        transform.position += new Vector3(0, -0.15f, 0.625f) * 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Controller controller;
        other.gameObject.TryGetComponent<Controller>(out controller);
        if(controller != null)
        {
            endgame();
        }
    }

    private void endgame()
    {
        FindObjectOfType<GameManager>().DoGameOver();
    }
}
