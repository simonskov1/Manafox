using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject highscoreMenu;

    float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > cooldown && Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
            highscoreMenu.SetActive(true);
        }
            

        if (Input.GetKeyDown(KeyCode.U))
            ResumeGame();

    }

    public void DoGameOver()
    {
        PauseGame();
        highscoreMenu.SetActive(true);
    }

    void PauseGame()
    {
        AudioListener.pause = true;
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Mads_Test", LoadSceneMode.Single);
    }
}
