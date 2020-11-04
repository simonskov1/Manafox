using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHighscores : MonoBehaviour
{
    public TextMeshProUGUI [] highscoreText;
    HighscoreSystem highscoreSystem;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = (i + 1) + ". Fetching...";
        }

        highscoreSystem = GetComponent<HighscoreSystem>();

        StartCoroutine(RefreshHighscores());
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = (i + 1) + ". ";
            if(highscoreList.Length > i)
            {
                highscoreText[i].text += highscoreList[i].username + " - " + highscoreList[i].score;
            }
        }
    }

    IEnumerator RefreshHighscores()
    {
        while(true)
        {
            highscoreSystem.DownloadHighscores();
            yield return new WaitForSeconds(30);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
