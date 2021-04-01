using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoreSystem : MonoBehaviour
{
    const string privatCodePerm = "tM_Qlw5cdkCM2k-S7b4i_wRF1cy-wP-UeyZSJoeJMKgQ";
    const string publicCodePerm = "601adecc8f40bb2a7051a3e7";
    const string privatCodeDaily = "HWj2j3uo1kCcJKXuTPJAggL2b01Ybj00SxK5A1RgLMQQ";
    const string publicCodeDaily = "5fa17e6eeb371a09c49231e8";
    const string WebUrl = "http://dreamlo.com/lb/";

    public Highscore[] highscoreList;
    static HighscoreSystem instance;
    [SerializeField]
    DisplayHighscores highscoreDisplayPerm;
    [SerializeField]
    DisplayHighscores highscoreDisplayDaily;



    static public void AddNewHighscore(string username, int score)
    {
        
        instance.StartCoroutine(instance.UploadNewHighscore(username, score, privatCodeDaily));
    }

    public void DownloadHighscores()
    {
        StartCoroutine(DownloadHighscoresFromDatabase(publicCodeDaily));
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

    IEnumerator UploadNewHighscore(string username, int score, string privatCode)
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

        if(privatCode == privatCodeDaily)
        {
            yield return new WaitForSecondsRealtime(1.1f);
            instance.StartCoroutine(instance.UploadNewHighscore(username, score, privatCodePerm));
        }
    }

    IEnumerator DownloadHighscoresFromDatabase(string publicCode)
    {
        WWW www = new WWW(WebUrl + publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Download was succesfull: " + publicCode);
            FormatHighscores(www.text);

            if (publicCode == publicCodeDaily)
            {
                Highscore[] highscores = highscoreList;
                highscoreDisplayDaily.OnHighscoresDownloaded(highscores);
            }
            else
            {
                Highscore[] highscores = highscoreList;
                highscoreDisplayPerm.OnHighscoresDownloaded(highscores);
            }
        }
        else
            Debug.Log("Error downloading: " + www.error);

        if(publicCode == publicCodeDaily)
        {
            yield return new WaitForSecondsRealtime(1.1f);
            StartCoroutine(DownloadHighscoresFromDatabase(publicCodePerm));
        }
        
    }

    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            DownloadHighscores();
            yield return new WaitForSecondsRealtime(30);
        }
    }

    public void Start()
    {
        StartCoroutine(RefreshHighscores());
    }


    private void Awake()
    {
        instance = this;

        


        
    }



    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
