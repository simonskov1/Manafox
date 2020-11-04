using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreSystem : MonoBehaviour
{
    const string privatCode = "HWj2j3uo1kCcJKXuTPJAggL2b01Ybj00SxK5A1RgLMQQ";
    const string publicCode = "5fa17e6eeb371a09c49231e8";
    const string WebUrl = "http://dreamlo.com/lb/";

    public Highscore[] highscoreList;
    static HighscoreSystem instance;
    DisplayHighscores highscoreDisplay;


    static public void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    public void DownloadHighscores()
    {
        StartCoroutine(DownloadHighscoresFromDatabase());
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoreList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoreList[i] = new Highscore(username, score);
        }

    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(WebUrl + privatCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload was succesfull");
            DownloadHighscores();
        }
        else
            Debug.Log("Error uploading: " + www.error);
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(WebUrl + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload was succesfull");
            FormatHighscores(www.text);
            highscoreDisplay.OnHighscoresDownloaded(highscoreList);
        }
        else
            Debug.Log("Error downloading: " + www.error);
    }


    private void Awake()
    {
        instance = this;

        


        
    }



    // Start is called before the first frame update
    void Start()
    {
        highscoreDisplay = GetComponent<DisplayHighscores>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
