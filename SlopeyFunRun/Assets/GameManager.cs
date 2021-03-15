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

        if (Input.GetKeyDown(KeyCode.B))
        {
            Time.timeScale = 0.05f;
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
        Time.timeScale = 0;
        AudioSource[] PlayerSounds = FindObjectOfType<Controller>().GetComponents<AudioSource>();
        foreach (AudioSource sound in PlayerSounds)
        {
            sound.Stop();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void Restart()
    {
        ResumeGame();
        SceneManager.LoadScene("Mads_Test", LoadSceneMode.Single);
    }
}
