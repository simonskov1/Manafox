using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowLocalScore : MonoBehaviour
{
    private TextMeshProUGUI textElement;
    LocalScoreSystem localScore;
    private void Awake()
    {
        textElement = GetComponent<TextMeshProUGUI>();
        localScore = FindObjectOfType<LocalScoreSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
        textElement.text = localScore.Score.ToString();
    }
}
