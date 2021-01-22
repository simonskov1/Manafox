﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGayme : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            int score = Random.Range(0,2000);
            string username = "";
            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            for (int i = 0; i < Random.Range(3,7); i++)
            {
                username += alphabet[Random.Range(0, alphabet.Length)];
            }
            HighscoreSystem.AddNewHighscore(username, score);
        }
    }
}
