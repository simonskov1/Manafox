using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalScoreSystem : MonoBehaviour
{
    bool hasBeenUploaded = false;
    [SerializeField]
    private int score = 0;
    [SerializeField]
    private TextMeshProUGUI nameTextForUpload;

    public int Score
    {
        get { return score; }
        private set { score = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPointsToScore(int points)
    {
        Score += points;
    }

    public void UploadScore()
    {
        if(!hasBeenUploaded)
        {
            if (!string.IsNullOrEmpty(nameTextForUpload.text))
                HighscoreSystem.AddNewHighscore(nameTextForUpload.text, score);
            else
                HighscoreSystem.AddNewHighscore("unknown", score);

            hasBeenUploaded = true;
        }
    }

    
}
