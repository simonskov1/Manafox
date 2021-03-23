using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highscore
{
    public string username;
    public int score;

    public Highscore(string username, int score)
    {
        this.username = username;
        this.score = score;
    }
}
