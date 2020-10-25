using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Restart : MonoBehaviour
{
    float cooldown;
    private void Awake()
    {
        cooldown = Time.time + 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > cooldown && Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }

    private void Reset()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
